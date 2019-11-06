using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.API.Models;
using Authentication.API.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controllers
{
    [Route("api/v1/[Controller]")]
    [Authorize]
    public class AuthController : Controller
    {
        private readonly IAuthService service;
        private readonly ITokenGenerator tokenGenerator;

        public AuthController(IAuthService _service)
        {
            this.service = _service;
            this.tokenGenerator = new TokenGenerator();
        }
        public AuthController(IAuthService _service, ITokenGenerator _tokenGenerator)
        {
            this.service = _service;
            this.tokenGenerator = _tokenGenerator;
        }
        // POST api/<controller>
        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody]User user)
        {
            var result = service.RegisterUser(user);
            return Created("auth/register", true);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody]User user)
        {
            var loginUser = service.LoginUser(user.UserName, user.Password);
            if (loginUser != null)
            {
                if (tokenGenerator != null)
                {
                    string token = tokenGenerator.GetJWTToken(user.UserName);
                    return Ok(token);
                }
                else
                {
                    return Ok(loginUser);
                }
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        [Route("isAuthenticated")]
        public IActionResult isAuthenticated()
        {
            return Ok(true);
        }

    }
}