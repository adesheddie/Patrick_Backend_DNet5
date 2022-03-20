using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rpg_project.Dtos.AddUserDto;
using Rpg_project.Dtos.UserLogin;
using Rpg_project.Models;
using Rpg_project.Services.AuthService;

namespace Rpg_project.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(AddUserDto user)
        {

            var result = await _authService.Register(user.Email, user.Password);


            if (result.Success == false)
                return BadRequest("Invalid Body");
            else
                return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<bool>>> Login(UserLogin user)
        {

            var result = await _authService.Login(user.Email, user.Password);

            if (result.Success == false)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }
    }
}