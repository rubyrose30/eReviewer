using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EReviewer.ViewModels.QuestionViewModels
{
    public class QuestionViewVM
    {
        public int Id { get; set; }

        public string Subject { get; set; }

        public string ExamType { get; set; }

        public string Question { get; set; }

        public int Points { get; set; }

        public string Answer { get; set; }

        public List<QuestionOptionViewVM> Options { get; set; }
    }
}
