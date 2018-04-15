using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EReviewer.Models
{
    public class TestQuestion
    {
        public int Id { get; set; }
        public SubjectQuestion SubjectQuestionId { get; set; }

    }
}
