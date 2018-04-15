using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EReviewer.Models
{
    public class QuestionOption
    {
        public int Id { get; set; }
        public SubjectQuestion SubjectQuestionId { get; set; }
        public int OptionNo { get; set; }
        public string IsAnswer { get; set; }
    }
}
