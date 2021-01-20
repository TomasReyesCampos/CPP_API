using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CPP.Api.ViewModels;
using CPP.Entities.Dtos;
using CPP.Repository.Interfaces;
using CPP.Repository.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace CPP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioRepostory _repository;
        private readonly IBaseRepository _baseRepository;
        private readonly LinkGenerator _generator;

        public AuthController(IConfiguration configuration,
            IUsuarioRepostory repository,
                   IBaseRepository baseRepository,
                   LinkGenerator generator)
        {
            _configuration = configuration;
            _repository = repository;
            _generator = generator;
            _baseRepository = baseRepository;
        }

        [HttpPost()]
        [AllowAnonymous]
        [Route("login")]
        public async  Task<ActionResult<AuthUserViewModel>> Login([FromBody] LoginViewModel model)
        {
            var auth = await _repository.AuthenticateUser(model.nombreUsuario, model.password);
            if (auth != null && auth.IsValid)
            {
                var secretKey = _configuration.GetValue<string>("SecretKey");
                var key = Encoding.ASCII.GetBytes(secretKey);

                var claims = new[]
                {
                    new Claim("UserData",JsonConvert.SerializeObject(auth)),
                };

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var createdToken = tokenHandler.CreateToken(tokenDescriptor);
                auth.token = tokenHandler.WriteToken(createdToken);
            }
            else
            {
                BadRequest();
            }
            return Ok(auth);
        }
    }
}
