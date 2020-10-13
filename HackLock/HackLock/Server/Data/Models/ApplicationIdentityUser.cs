using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HackLock.Server.Data.Models
{
    public class ApplicationIdentityUser : IdentityUser
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public string CreatedAt { get; set; }

    }
}
