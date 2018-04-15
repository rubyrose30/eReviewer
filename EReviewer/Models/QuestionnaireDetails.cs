using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EReviewer.Models
{
    public class QuestionnaireDetails
    {
        public int Id { get; set; }
        public Subject SubjectId   { get; set; }
        public int Duration { get; set; }
        public ExamType ExamTypeId { get; set; }
        public int NumberOfItems { get; set; }
    }
}
