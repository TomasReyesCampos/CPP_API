using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CPP.Entities.Data;
using CPP.Entities.Dtos;
using CPP.Repository.Interfaces;
using CPP.Repository.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace CPP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalController : ControllerBase
    {
        private readonly ISucursalRepository _repository;
        private readonly IBaseRepository _baseRepository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _generator;

        public SucursalController(
                      ISucursalRepository repository,
                      IMapper mapper,
                      IBaseRepository baseRepository,
                      LinkGenerator generator)
        {
            _repository = repository;
            _mapper = mapper;
            _generator = generator;
            _baseRepository = baseRepository;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<Sucursal[]>> GetAsync()
        {
            try
            {
                var results = await _repository.GetSucursal();                
                return Ok(results);
            }
            catch (Exception err)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "DataBase Failure " + err.Message);
            }
        }
        
        [HttpGet]
        [AllowAnonymous]
        [Route("ObtenerSucursalPorId")]
        public async Task<ActionResult<Sucursal>> GetByIdAsync([FromQuery]int id)
        {
            try
            {
                var result = await _repository.GetSucursalPorId(id);

                if (result == null)                {
                    
                    return NotFound();
                }
 
                return Ok(result);
            }
            catch (Exception err)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "DataBase Failure " + err.Message);
            }
        }
        
        [HttpGet]
        [AllowAnonymous]
        [Route("SucursalPorNombre")]
        public async Task<ActionResult<Sucursal>> GetByNameAsync([FromQuery] string nombre)
        {
            try
            {
                var result = await _repository.GetSucursalNombre(nombre);

                if (result == null) {
                     
                    return NotFound();
                }
                 
                return Ok(result);
            }
            catch (Exception err)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "DataBase Failure " + err.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<SucursalDto>> Post([FromBody]SucursalDto tipoDto)
        {
            try
            {
                var erroDto = new SucursalDto();
                var tipoOld = await _repository.GetSucursalNombre(tipoDto.nombre);

                if (tipoOld != null)
                {
                    erroDto.error = $"Ya existe una sucursal con el nombre de : {tipoDto.nombre}, en la base de datos.";
                    return BadRequest(erroDto);
                }

                if (tipoOld == null)
                {
                    var itemEntity = _mapper.Map<Sucursal>(tipoDto);
                    _baseRepository.Add(itemEntity);
                    if (await _baseRepository.SaveChangesAsync())
                    {
                        return Ok(_mapper.Map<SucursalDto>(itemEntity));
                    }
                }
                else
                {
                    if (await _baseRepository.SaveChangesAsync())
                    {
                        return Ok(_mapper.Map<SucursalDto>(tipoDto));
                    }
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return BadRequest();
        }

        [HttpPost()]
        [Route("ActualizarSucursal")]
        public async Task<ActionResult<SucursalDto>> UpdateSucursal([FromBody]SucursalDto itemDto)
        {
            try
            {
                var itemOld = await _repository.GetSucursalPorId(itemDto.Id);

                if (itemOld == null)
                {
                    return NotFound($"La sucursal {itemDto.nombre}, no existe en la base de datos.");
                }

                var itemName = await _repository.GetSucursalNombre(itemDto.nombre);

                if (itemName != null)
                {
                    itemDto.error = $"Ya existe una sucursal con el nombre de {itemDto.nombre}, en la base de datos.";
                    if (itemName.Id != itemDto.Id) return BadRequest(itemDto);
                }

                _mapper.Map(itemDto, itemOld);

                var updated = await _baseRepository.SaveChangesAsync();
                return Ok(_mapper.Map<SucursalDto>(itemOld));
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var itemOld = await _repository.GetSucursalPorId(id);

                if (itemOld == null)
                {
                    return NotFound($"No existe la sucursal en la base de datos.");
                }

                _baseRepository.Delete(itemOld);

                if (await _baseRepository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return BadRequest("An error ocurrs trying to delete a size");
        }
    }
}