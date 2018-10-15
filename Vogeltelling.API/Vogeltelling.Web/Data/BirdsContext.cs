using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vogeltelling.Web.Models;

namespace Vogeltelling.Web.Data
{
    public class BirdsContext : IdentityDbContext<ApplicationUser>
    {
        public BirdsContext(DbContextOptions<BirdsContext> options)
            : base(options)
        {
        }

        public DbSet<Bird> Birds { get; set; }
        public DbSet<Moments> Moments { get; set; }
        public DbSet<Provincie> Region { get; set; }
        public DbSet<User_has_birds> User_has_birds { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
