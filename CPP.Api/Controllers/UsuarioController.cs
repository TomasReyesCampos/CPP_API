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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepostory _repository;
        private readonly IBaseRepository _baseRepository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _generator;

        public UsuarioController(
                   IUsuarioRepostory repository,
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
        public async Task<ActionResult<UsuarioDto[]>> GetAsync()
        {
            try
            {
                var results = await _repository.GetUsuarios();
                return Ok(results);
            }
            catch (Exception err)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "DataBase Failure " + err.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("ObtenerUsuarioPorId")]
        public async Task<ActionResult<Usuario>> GetByIdAsync([FromQuery]int id)
        {
            try
            {
                var result = await _repository.GetUsuarioById(id);

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
        public async Task<ActionResult<UsuarioDto>> Post([FromBody]UsuarioDto tipoDto)
        {
            try
            {
                var erroDto = new UsuarioDto();
                var tipoOld = await _repository.GetUsuarioByName(tipoDto.user);

                if (tipoOld != null)
                {
                    erroDto.error = $"Ya existe un usario con el user nombre de : {tipoDto.user}, en la base de datos.";
                    return BadRequest(erroDto);
                }

                if (tipoOld == null)
                {
                    var itemEntity = _mapper.Map<Sucursal>(tipoDto);
                    _baseRepository.Add(itemEntity);
                    if (await _baseRepository.SaveChangesAsync())
                    {
                        return Ok(_mapper.Map<UsuarioDto>(itemEntity));
                    }
                }
                else
                {
                    if (await _baseRepository.SaveChangesAsync())
                    {
                        return Ok(_mapper.Map<UsuarioDto>(tipoDto));
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
        [Route("ActualizarUsuario")]
        public async Task<ActionResult<UsuarioDto>> UpdateUsuario([FromBody]UsuarioDto itemDto)
        {
            try
            {
                var erroDto = new UsuarioDto();
                var itemOld = await _repository.GetUsuarioById(itemDto.Id);

                if (itemOld == null)
                {
                    erroDto.error = $"El usuario {itemDto.nombre}, no existe en la base de datos.";
                    return BadRequest(erroDto);
                }

                var userName = await _repository.GetUsuarioByName(itemDto.user);

                if (userName != null)
                {
                    erroDto.error = $"Ya existe un usuario con el user de {itemDto.user}, en la base de datos.";
                    if (userName.Id != itemDto.Id) return BadRequest(erroDto);
                }

                _mapper.Map(itemDto, itemOld);

                var updated = await _baseRepository.SaveChangesAsync();
                return Ok(_mapper.Map<UsuarioDto>(itemOld));
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioDto>> Delete(int id)
        {
            try
            {
                var erroDto = new UsuarioDto();
                var itemOld = await _repository.GetUsuarioById(id);

                if (itemOld == null)
                {
                    erroDto.error = $"El usuario {itemOld.user}, no existe en la base de datos.";
                    return BadRequest(erroDto);
                }

                //var remisiones = await _repository.GetOrdenesPorSucursal(id);
                //if (remisiones.Any())
                //{

                //    dto.error = $"No se puede eliminar la sucursal porque tiene {remisiones.Count()} remisiones relacionadas.";
                //    return BadRequest(dto);
                //}

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