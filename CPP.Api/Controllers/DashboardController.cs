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
    public class DashboardController : ControllerBase
    {

        private readonly IDashboardRepository _repository; 
        private readonly IMapper _mapper; 

        public DashboardController(
                      IDashboardRepository repository,
                      IMapper mapper )
        {
            _repository = repository;
            _mapper = mapper; 
        }
               
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<DashboardDto[]>> GetAsync()
        {
            try
            {
                var results = await _repository.GetDashboardData();
                return Ok(results);
            }
            catch (Exception err)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "DataBase Failure " + err.Message);
            }
        }
    }
}