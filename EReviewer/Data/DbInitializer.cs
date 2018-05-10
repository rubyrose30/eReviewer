using EReviewer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EReviewer.Data
{
    /// <summary>
    /// This class will create a database when needed and loads test data into the new database.
    /// </summary>
    public static class DbInitializer
    {
        public static void Initialize(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<int>> roleManager, ApplicationDbContext context)
        {
            //TODO: Add initial or default values here

            SeedRoles(roleManager);
            SeedUsers(userManager);
            SeedDefaultValues(context);
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

            if (admin == null)
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

                    foreach (var claim in ClaimData.UserClaims)
                    {
                        userManager.AddClaimAsync(user, new Claim(claim, claim)).Wait();
                    }

                }
            }
        }

        public static void SeedDefaultValues(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Subject.
            if (context.Subjects.Any())
            {
                return;   // DB has been seeded
            }

            var subjects = new Subject[]
            {
                new Subject{ Code = "", Name = "Algebra",  Description = "Study of mathematical symbols and the rules for manipulating these symbols; it is a unifying thread of almost all of mathematics."},
                new Subject{ Code = "", Name = "Trigonometry",  Description = "Study of relationships involving lengths and angles of triangles."},
                new Subject{ Code = "", Name = "Analytic Geometry",  Description = "Study of geometry using a coordinate system."},
                new Subject{ Code = "", Name = "Differential Calculus",  Description = "Subfield of calculus concerned with the study of the rates at which quantities change."},
                new Subject{ Code = "", Name = "Integral Calculus",  Description = "Subfield of calculus concerned with the study of the notion of an integral, its properties and methods of calculation."},
            };

            // Add values to Subjects
            context.Subjects.AddRange(subjects);

            // Save all changes in the database
            context.SaveChanges();

            // Look for any Exam Type.
            if (context.ExamTypes.Any())
            {
                return;   // DB has been seeded
            }

            var examTypes = new ExamType[]
            {
                new ExamType{ Name = "Identification"},
                new ExamType{ Name = "Multiple Choice"}
            };

            // Add values to ExamTypes
            context.ExamTypes.AddRange(examTypes);

            // Save all changes in the database
            context.SaveChanges();
        }
    }
}
