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
    public class RemisionController : ControllerBase
    {
        private readonly IRemisionesRepository _repository;
        private readonly IProveedorRepository _proveedorRepository;
        private readonly IBaseRepository _baseRepository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _generator;

        public RemisionController(
                      IRemisionesRepository repository,
                      IMapper mapper,
                      IBaseRepository baseRepository,
                      IProveedorRepository proveedorRepository,
                      LinkGenerator generator)
        {
            _repository = repository;
            _mapper = mapper;
            _generator = generator;
            _baseRepository = baseRepository;
            _proveedorRepository = proveedorRepository;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<RemisionDto[]>> GetAsync()
        {
            try
            {
                var results = await _repository.GetRemisiones();
                return Ok(results);
            }
            catch (Exception err)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "DataBase Failure " + err.Message);
            }
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("ObtenerRemisionPorId")]
        public async Task<ActionResult<RemisionDto>> GetByIdAsync([FromQuery]int id)
        {
            try
            {
                var result = await _repository.GetRemisionPorId(id);

                if (result == null)
                {
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
        public async Task<ActionResult<RemisionDto>> Post([FromBody]RemisionAltaDto itemDto)
        {
            try
            {
                if (itemDto.fecha_remision > DateTime.Now)
                {
                    var dto = new RemisionDto();
                    dto.error = $"La fecha de remisión no puede ser mayor a la fecha actual";
                    return BadRequest(dto);
                }

                var itemEntity = _mapper.Map<Remision>(itemDto);                
                var proveedor = await _proveedorRepository.GetProveedorPorId(itemDto.proveedor_id);
                itemEntity.estado_remision_id = 1;
                itemEntity.fecha_pago = itemDto.fecha_remision.AddDays(proveedor.dias_credito);
                itemEntity.comentarios = itemDto.comentarios == null ? "" : itemDto.comentarios;
                _baseRepository.Add(itemEntity);

                if (await _baseRepository.SaveChangesAsync())
                {
                    return Ok(_mapper.Map<RemisionDto>(itemEntity));
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return BadRequest();
        }

        [HttpPost()]
        [Route("ActualizarRemision")]
        public async Task<ActionResult<Remision>> UpdateRemision([FromBody]RemisionAltaDto itemDto)
        {
            try
            {
                var itemOld = await _repository.GetRemisionNoDtoPorId(itemDto.Id);
                if (itemOld == null)
                {
                    itemOld = new Remision();
                    itemOld.error = $"La remision {itemDto.Id}, no existe en la base de datos.";
                    return BadRequest(itemOld);
                }

                if (itemDto.fecha_remision > DateTime.Now) {
                    itemOld.error = $"La fecha de remisión no puede ser mayor a la fecha actual";
                    return BadRequest(itemOld);
                } 

                var proveedor = await _proveedorRepository.GetProveedorPorId(itemDto.proveedor_id);
                itemOld.fecha_pago = itemDto.fecha_remision.AddDays(proveedor.dias_credito);
                _mapper.Map(itemDto, itemOld);

                var updated = await _baseRepository.SaveChangesAsync();
                return Ok(_mapper.Map<RemisionDto>(itemOld));
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
                var itemOld = await _repository.GetRemisionNoDtoPorId(id);
                
                if (itemOld == null)
                {
                    return NotFound($"No existe la remisión en la base de datos.");
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