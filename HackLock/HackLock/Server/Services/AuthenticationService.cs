using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackLock.Server.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace HackLock.Server.Services
{
    public interface IAuthenticationService
    {
        public Task<bool> AuthenticateUser(string userName, string password);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationIdentityUser> _userManager;

        public AuthenticationService(UserManager<ApplicationIdentityUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<bool> AuthenticateUser(string userName, string password)
        {
            var user = 
                _userManager.Users
                    .FirstOrDefault(u => u.UserName == userName);
            if (user == null)
                return false;

            var result = await _userManager.CheckPasswordAsync(user, password);
            return result;
        }
    }
}
