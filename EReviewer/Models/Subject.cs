using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// With EF Core, data access is performed using a model. 
/// Models are made up of entity classes and a derived context that represents a session with the database, 
/// allowing you to query and save data. 
/// </summary>
namespace EReviewer.Models
{
    /// <summary>
    /// The Subject Entity corresponds to a Subject table in the database
    /// The Entity Property corresponds to the column in the table
    /// </summary>
    public class Subject
    {
        /// <summary>
        /// This will be the primary key.      
        /// </summary>
        [Key]
        public int Id { get; set; }

        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
