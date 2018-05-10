using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EReviewer.ViewModels.QuestionViewModels
{
    public class QuestionAddVM
    {
        [Required]
        public int SubjectId { get; set; }

        [Display(Name = "Subject")]
        public SelectList Subjects { get; set; }

        [Required]
        public int ExamTypeId { get; set; }

        [Display(Name = "ExamTypes")]
        public SelectList ExamTypes { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Question")]
        public string Question { get; set; }

        [Required]
        [Display(Name = "Points")]
        public int Points { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
        [Display(Name = "Answer")]
        public string Answer { get; set; }

        [Required]
        public int AnswerId { get; set; }

        [Display(Name = "Options")]
        public List<QuestionOptionAddVM> Options { get; set; }
    }
}
