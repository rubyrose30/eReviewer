using EReviewer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EReviewer.Data
{
    public static class DbInitializer
    {
        public static void Initialize(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            //TODO: Add initial or default values here

            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedRoles(RoleManager<IdentityRole<int>> roleManager)
        {
            //Add Admin User Roles
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var role = new IdentityRole<int>
                {
                    Name = "Administrator"
                };

                var roleResult = roleManager.CreateAsync(role).Result;
            }
        }

        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            var admin = userManager.Users.FirstOrDefault(u => u.UserName.Equals("admin", StringComparison.OrdinalIgnoreCase));

            if (admin ==  null)
            {
                var user = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@mail.com",
                    FirstName = "Administrator",
                    LastName = "Administrator"
                };

                var userResult = userManager.CreateAsync(user, "P@ssw0rd").Result;

                if (userResult.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();

                    // Add User Claims for full name. You can check for the success of addition 
                    userManager.AddClaimAsync(user, new Claim("FirstName", user.FirstName)).Wait();
                    userManager.AddClaimAsync(user, new Claim("LastName", user.LastName)).Wait();
                }
            }
        }
    }
}
