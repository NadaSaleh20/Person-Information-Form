using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonInformation.Data
{
    public class Dbcontext :IdentityDbContext<IdentityUser>
    {
        public Dbcontext(DbContextOptions<Dbcontext> options) : base(options)
        {

        }

        public DbSet<Info> Info { get; set; }

        public DbSet<Country> Country { get; set; }

        public DbSet<City> City { get; set; }
       
    }
}
