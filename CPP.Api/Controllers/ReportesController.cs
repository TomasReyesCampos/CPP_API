using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CPP.Entities.Dtos;
using CPP.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : ControllerBase
    {

        private readonly IReportesRepository _repository;
        private readonly IMapper _mapper;

        public ReportesController(
                      IReportesRepository repository,
                      IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet()]
        [AllowAnonymous]
        [Route("RemisionesVencidas")]
        public async Task<ActionResult<ReporteVencidoDto[]>> GetRemisionesVencidasAsync([FromQuery]int proveedorId, [FromQuery] int sucursalId)
        {
            try
            {
                var results = await _repository.GetRemisionesVencidas(proveedorId, sucursalId);
                return Ok(results);
            }
            catch (Exception err)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "DataBase Failure " + err.Message);
            }
        }


        [HttpGet()]
        [AllowAnonymous]
        [Route("RemisionesPorVencer")]
        public async Task<ActionResult<ReporteVencidoDto[]>> GetRemisionesPorVencerAsync([FromQuery]int proveedorId, [FromQuery] int sucursalId)
        {
            try
            {
                var results = await _repository.GetRemisionesPorVencer(proveedorId, sucursalId);
                results = results.Where(r => r.dias_vencimiento >= -5).ToArray();
                return Ok(results);
            }
            catch (Exception err)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "DataBase Failure " + err.Message);
            }
        }



        [HttpGet()]
        [AllowAnonymous]
        [Route("PagoProveedores")]
        public async Task<ActionResult<PagoProveedoresDto[]>> GetPagoOrdenesProveedores ([FromQuery]int proveedorId)
        {
            try
            {
                var results = await _repository.GetPagoOrdenesPorProveedor(proveedorId);             
                return Ok(results);
            }
            catch (Exception err)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "DataBase Failure " + err.Message);
            }
        }



        [HttpGet()]
        [AllowAnonymous]
        [Route("PagoRemisiones")]
        public async Task<ActionResult<PagoRemisionDto[]>> GetPagoRemisionesAsync([FromQuery]int proveedorId, [FromQuery] int sucursalId)
        {
            try
            {
                var results = await _repository.GetPagoRemisiones(proveedorId, sucursalId);
                return Ok(results);
            }
            catch (Exception err)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "DataBase Failure " + err.Message);
            }
        }
    }
}