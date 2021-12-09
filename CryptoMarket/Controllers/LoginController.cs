using CryptoMarket.Models;
using CryptoMarket.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMarket.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }


        [HttpPost]
        public IActionResult Login([FromBody]UserLogin user)
        {
            var token = _authenticationService.Authenticate(user);
            if( token != null)
                return Ok(token);
            return NotFound("User not found");
        }
    }
}
