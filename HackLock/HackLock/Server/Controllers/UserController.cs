using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using HackLock.Server.Data.Models;
using HackLock.Server.Services;
using HackLock.Shared.CommunicationModels.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HackLock.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser([FromBody]RegisterUserRequest registerUserRequest)
        {
            var newUser = new ApplicationIdentityUser
            {
                Class = registerUserRequest.Class,
                Name = registerUserRequest.Name,
                CreatedAt = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                Email = registerUserRequest.Email,
                UserName = registerUserRequest.UserName
            };

            var result = await _userService.RegisterUser(newUser, registerUserRequest.Password);

            if (result)
                return Ok();

            return BadRequest("request invalid");
        }
    }
}
