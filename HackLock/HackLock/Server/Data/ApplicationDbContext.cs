using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackLock.Server.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HackLock.Server.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationIdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) 
            : base(dbContextOptions){}

        
        public DbSet<EntryLogItem> EntryLog { get; set; }
    }
}
