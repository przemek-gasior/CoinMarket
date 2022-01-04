using CryptoMarket.Models;
using CryptoMarket.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMarket.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class RegisterController : ControllerBase
    {
        private readonly IUserService _userService;

        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserLogin user)
        {
            try
            {
                await _userService.CreateUserAsync(user);
                return Ok("Account Created");
            }
            catch(Exception)
            {
                return StatusCode(422, "User Already Exist");
            }
            
        }
    }
}
