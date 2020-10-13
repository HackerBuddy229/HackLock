using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackLock.Server.Data;
using HackLock.Server.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace HackLock.Server.Services
{
    public interface IUserService
    {
        public Task<bool> RegisterUser(ApplicationIdentityUser user, string password);
        public Task<bool> RemoveUser(ApplicationIdentityUser user);
        public Task<bool> RemoveUser(string id);

        public ApplicationIdentityUser GetUser(string userName);
    }

    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationIdentityUser> _userManager;
        private readonly ApplicationDbContext _dbContext;

        public UserService(UserManager<ApplicationIdentityUser> userManager, 
            ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }


        public async Task<bool> RegisterUser(ApplicationIdentityUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result.Succeeded;
        }

        public async Task<bool> RemoveUser(ApplicationIdentityUser user)
        {
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> RemoveUser(string id)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return false;

            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public ApplicationIdentityUser GetUser(string userName)
        {
            return _userManager.Users.FirstOrDefault(u => u.UserName == userName);
        }
    }
}
