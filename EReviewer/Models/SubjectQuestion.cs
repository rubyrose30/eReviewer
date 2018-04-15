using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EReviewer.Models
{
    public class SubjectQuestion
    {
        public int Id { get; set; }
        public Subject SubjectId { get; set; }
        public string Question { get; set; }
    }
}
