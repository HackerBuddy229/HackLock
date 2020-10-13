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
        public Task<bool> AuthenticateUser(string username, string password);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly SignInManager<ApplicationIdentityUser> _signInManager;

        public AuthenticationService(SignInManager<ApplicationIdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }


        public async Task<bool> AuthenticateUser(string username, string password)
        {
            var user = 
                _signInManager.UserManager.Users
                    .FirstOrDefault(u => u.UserName == username);
            if (user == null)
                return false;

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            return result.Succeeded;
        }
    }
}
