using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EReviewer.Models;
using Microsoft.AspNetCore.Identity;
using EReviewer.ViewModels.AccountViewModels;

namespace EReviewer.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "Users");
                entity.Ignore(c => c.AccessFailedCount);
                entity.Ignore(c => c.EmailConfirmed);
                entity.Ignore(c => c.LockoutEnabled);
                entity.Ignore(c => c.LockoutEnd);
                entity.Ignore(c => c.PhoneNumber);
                entity.Ignore(c => c.PhoneNumberConfirmed);
                entity.Ignore(c => c.TwoFactorEnabled);
            });
        }
    }
}
