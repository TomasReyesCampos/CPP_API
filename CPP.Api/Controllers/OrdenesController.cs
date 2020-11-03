using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    public class OrdenesController : ControllerBase
    {

        private readonly IOrdenesRepository _repository;
        private readonly IBaseRepository _baseRepository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _generator;

        public OrdenesController(
                        IOrdenesRepository repository,
                        IMapper mapper,
                        IBaseRepository baseRepository,
                        LinkGenerator generator)
        {
            _repository = repository;
            _mapper = mapper;
            _generator = generator;
            _baseRepository = baseRepository;
        }


        [HttpGet("{proveedorId}")]
        [AllowAnonymous]
        public async Task<ActionResult<RemisionesOrdenesDto[]>> GetAsync(int proveedorId)
        {
            try
            {
                var results = await _repository.ObtenerRemisionesOrdenes(proveedorId);
                return Ok(results);
            }
            catch (Exception err)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "DataBase Failure " + err.Message);
            }
        }

        [HttpGet("OrdenesCreadas")]
        [AllowAnonymous]
        public async Task<ActionResult<OrdenesCreadasDto[]>> GetOrdenesCreadas()
        {
            try
            {
                var results = await _repository.ObtenerOrdenesCreadas();
                return Ok(results);
            }
            catch (Exception err)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "DataBase Failure " + err.Message);
            }
        }

        [HttpPost()]
        [AllowAnonymous]
        public async Task<ActionResult<String>> PostOrdenAsync([FromBody] OrdenAltaDto ordenAltaDto)
        {
            try
            {
                var results = await _repository.AltaOrdenes(ordenAltaDto);

                if (results)
                    return Ok();
                else
                    return BadRequest("La orden se no se pudo agregar correctamente");
            }
            catch (Exception err)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "DataBase Failure " + err.Message);
            }
        }

        [HttpPost("ActualizarOrden")]
        [AllowAnonymous]
        public async Task<ActionResult<String>> PostUpdateOrdenAsync([FromBody] OrdenUpdateDto ordenAltaDto)
        {
            try
            {
                var results = await _repository.ObtenerOrdenById(ordenAltaDto.orden_id);

                if (results == null)
                {
                    return NotFound($"No existe la orden en la base de datos.");
                }

                var result = await _repository.ActualizarOrdenes(ordenAltaDto);

                if (result)
                    return Ok("La orden se actualizo correctamente");
                else
                    return BadRequest("La orden se no se pudo agregar correctamente");
            }
            catch (Exception err)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "DataBase Failure " + err.Message);
            }
        }


        [HttpPost("PagarOrden")]
        public async Task<IActionResult> PostPagarOrden(OrdenPagarDto ordenDto)
        {
            try
            {
                var fecha_actual = DateTime.Now;
                var itemOld = await _repository.ObtenerOrdenById(ordenDto.id);

                if (itemOld == null)
                {
                    return NotFound($"No existe la orden en la base de datos.");
                }

                _mapper.Map(ordenDto, itemOld);

                foreach (var remisiones in itemOld.remisiones)
                {
                    remisiones.estado_remision_id = 3;
                    remisiones.fecha_real_pago = fecha_actual;
                }
                itemOld.estado_orden_id = 2;
                itemOld.fecha_pago = fecha_actual;

                if (await _baseRepository.SaveChangesAsync())
                {
                    return Ok();
                }else
                {
                    return BadRequest();
                }
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
                var itemOld = await _repository.ObtenerOrdenById(id);

                if (itemOld == null)
                {
                    return NotFound($"No existe la orden en la base de datos.");
                }

                foreach(var remisiones in itemOld.remisiones)
                {
                    remisiones.estado_remision_id = 1;
                }

                itemOld.remisiones.Clear();

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