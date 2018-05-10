using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EReviewer.Models
{
    public class UserExamQuestion
    {
        [Key]
        public int Id { get; set; }

        [Required, ForeignKey("UserExam")]
        public int UserExamId { get; set; }

        public UserExam UserExam { get; set; }

        [Required, ForeignKey("Question")]
        public int QuestionId { get; set; }

        public Question Question { get; set; }

        [ForeignKey("QuestionOption")]
        public int? QuestionOptionId { get; set; }

        public QuestionOption QuestionOption { get; set; }

        public string AnswerText { get; set; }

        public bool IsCorrect { get; set; }

        public int Points { get; set; }
    }
}
