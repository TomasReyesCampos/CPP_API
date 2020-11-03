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
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorRepository _repository;
        private readonly IBaseRepository _baseRepository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _generator;

        public ProveedorController(
                        IProveedorRepository repository,
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
        public async Task<ActionResult<Proveedor[]>> GetAsync()
        {
            try
            {
                var results = await _repository.GetProveedor();
                return Ok(results);
            }
            catch (Exception err)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "DataBase Failure " + err.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("ObtenerProveedorPorId")]
        public async Task<ActionResult<Proveedor>> GetByIdAsync([FromQuery]int id)
        {
            try
            {
                var result = await _repository.GetProveedorPorId(id);

                if (result == null)
                {

                    return NotFound("Proveedor no encontrado");
                }

                return Ok(result);
            }
            catch (Exception err)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "DataBase Failure " + err.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProveedorDto>> Post([FromBody]ProveedorDto proveedor)
        {
            try
            {
                var tipoOld = await _repository.GetProveedorNombre(proveedor.nombre);

                if (tipoOld != null)
                {
                    return BadRequest($"Ya existe un tipo de proveedor con el nombre de : {proveedor.nombre}, en la base de datos.");
                }


                if (tipoOld == null)
                {
                    var itemEntity = _mapper.Map<Proveedor>(proveedor);
                    _baseRepository.Add(itemEntity);
                    if (await _baseRepository.SaveChangesAsync())
                    {
                        return Ok(proveedor);
                    }
                }
                else
                {
                    if (await _baseRepository.SaveChangesAsync())
                    {
                        return Ok(proveedor);
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
        [Route("ActualizarProveedor")]
        public async Task<ActionResult<ProveedorDto>> UpdateProveedor([FromBody]ProveedorDto itemDto)
        {
            try
            {
                var itemOld = await _repository.GetProveedorPorId(itemDto.Id);

                if (itemOld == null)
                {
                    return NotFound($"El proveedor {itemDto.nombre}, no existe en la base de datos.");
                }

                var itemName = await _repository.GetProveedorNombre(itemDto.nombre);

                if (itemName != null)
                {
                   
                    if (itemName.Id != itemDto.Id) return BadRequest($"Ya existe un proveedor con el nombre de {itemDto.nombre}, en la base de datos.");
                }

                _mapper.Map(itemDto, itemOld);
                var updated = await _baseRepository.SaveChangesAsync();
                return Ok(_mapper.Map<ProveedorDto>(itemOld));
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
                var itemOld = await _repository.GetProveedorPorId(id);

                if (itemOld == null)
                {
                    return NotFound($"No existe el proveedor en la base de datos.");
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

            return BadRequest("An error ocurrs trying to delete a supplier");
        }

    }
       
    
}