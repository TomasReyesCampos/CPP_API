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
    public class TipoProveedorController : ControllerBase
    {
        private readonly ITipoProveedorRepository _repository;
        private readonly IBaseRepository _baseRepository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _generator;

        public TipoProveedorController(
                        ITipoProveedorRepository repository, 
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
        public async Task<ActionResult<TipoProveedorDto[]>> GetAsync()
        {
            try
            {
                var results = await _repository.GetTipoProveedor();
                var items = _mapper.Map<TipoProveedorDto[]>(results);
                return Ok(items);
            }
            catch (Exception err)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "DataBase Failure " + err.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("ObtenerProveedorPorId")]
        public async Task<ActionResult<TipoProveedorDto>> GetByIdAsync([FromQuery]int id)
        {
            try
            {
                var result = await _repository.GetTipoProveedorPorId(id);

                if (result == null)
                {
                    var error = new TipoProveedorDto()
                    {
                        error = "Tipo Proveedor no encontrado"
                    };
                    return NotFound(error);
                }

                var items = _mapper.Map<TipoProveedorDto>(result);
                return Ok(items);
            }
            catch (Exception err)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "DataBase Failure " + err.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("byName")]
        public async Task<ActionResult<TipoProveedorDto>> GetByNameAsync([FromQuery] string nombre)
        {
            try
            {
                var result = await _repository.GetTipoProveedorNombre(nombre);

                if (result == null)
                {
                    var error = new TipoProveedorDto()
                    {
                        error = "Tipo Proveedor no encontrado"
                    };
                    return NotFound(error);
                }

                var items = _mapper.Map<TipoProveedorDto>(result);
                return Ok(items);
            }
            catch (Exception err)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "DataBase Failure " + err.Message);
            }
        }

        [HttpPost]        
        public async Task<ActionResult<TipoProveedorDto>> Post([FromBody]TipoProveedorDto tipoDto)
        {
            try
            {
                var erroDto = new TipoProveedorDto();
                var tipoOld = await _repository.GetTipoProveedorNombre(tipoDto.tipo_proveedor);

                if (tipoOld != null)
                {
                    erroDto.error = $"Ya existe un tipo de proveedor con el nombre de : {tipoDto.tipo_proveedor}, en la base de datos.";
                    return BadRequest(erroDto);
                }   
            

                if (tipoOld == null)
                {
                    var itemEntity = _mapper.Map<TipoProveedor>(tipoDto);
                    _baseRepository.Add(itemEntity);
                    if (await _baseRepository.SaveChangesAsync())
                    {
                        return Ok(_mapper.Map<TipoProveedorDto>(itemEntity));
                    }
                }
                else
                {
                    if (await _baseRepository.SaveChangesAsync())
                    {
                        return Ok(_mapper.Map<TipoProveedorDto>(tipoDto));
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
        [Route("ActualizarTipoProveedor")]
        public async Task<ActionResult<TipoProveedorDto>> UpdateTipoProveedor([FromBody]TipoProveedorDto itemDto)
        {
            try
            {
                var itemOld = await _repository.GetTipoProveedorPorId(itemDto.Id);

                if (itemOld == null)
                {
                    return NotFound($"El tipo de proveedor {itemDto.tipo_proveedor}, no existe en la base de datos.");
                }

                var itemName = await _repository.GetTipoProveedorNombre(itemDto.tipo_proveedor);

                if (itemName != null)
                {
                    itemDto.error = $"Ya existe un tipo de proveedor con el nombre de {itemDto.tipo_proveedor}, en la base de datos.";
                    if (itemName.Id != itemDto.Id) return BadRequest(itemDto);
                }
                           
               _mapper.Map(itemDto, itemOld);

                var updated = await _baseRepository.SaveChangesAsync();
                return Ok(_mapper.Map<TipoProveedorDto>(itemOld));
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
                var itemOld = await _repository.GetTipoProveedorPorId(id);

                if (itemOld == null)
                {
                    return NotFound($"No existe el tipo de proveedor en la base de datos.");
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