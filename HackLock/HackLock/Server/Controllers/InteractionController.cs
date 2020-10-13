using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using HackLock.Server.Data.Models;
using HackLock.Server.hardware;
using HackLock.Server.Services;
using HackLock.Shared.CommunicationModels.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HackLock.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InteractionController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IDoorManipulator _doorManipulator;
        private readonly ILoggingService _loggingService;
        private readonly IUserService _userService;

        public InteractionController(IAuthenticationService authenticationService, 
            ILoggingService loggingService,
            IDoorManipulator doorManipulator,
            IUserService userService)
        {
            _authenticationService = authenticationService;
            _loggingService = loggingService;
            _doorManipulator = doorManipulator;
            _userService = userService;
        }

        [HttpGet]
        [Route("unlock")]
        public async Task<IActionResult> UnlockDoor([FromBody] AuthenticationRequest request)
        {
            var authResult =
                await _authenticationService.AuthenticateUser(request.UserName, request.Password);
            if (!authResult)
                return BadRequest("invalid user");

            var user = _userService.GetUser(request.UserName);

            _loggingService.LogItem(new EntryLogItem
            {
                Action = "unlocked door",
                Class = user.Class,
                Email = user.Email,
                Id = Guid.NewGuid().ToString(),
                Name = user.Name,
                Timestamp = DateTime.Now.ToString(CultureInfo.InvariantCulture)
            });

            _doorManipulator.Cycle();
            return Ok();
        }
    }
}
