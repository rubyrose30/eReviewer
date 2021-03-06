﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EReviewer.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser<int>
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public ICollection<UserExam> UserExams { get; set; }
    }
}
