using EReviewer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EReviewer.Data
{
    public static class DbInitializer
    {
        public static void Initialize(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //TODO: Add initial or default values here

            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            //Add Admin User Roles
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Administrator"
                };

                var roleResult = roleManager.CreateAsync(role).Result;
            }
        }

        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            //Add Admin User
            if (userManager.FindByNameAsync("Administator").Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "Administator",
                    Email = "admin@mail.com",
                    FirstName = "Administrator",
                    LastName = "Administrator"
                };

                var userResult = userManager.CreateAsync(user, "P@ssw0rd").Result;

                if (userResult.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }
    }
}
