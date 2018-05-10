using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EReviewer.Models
{
    public class UserExam
    {
        [Key]
        public int Id { get; set; }

        [Required, ForeignKey("Exam")]
        public int ExamId { get; set; }

        public Exam Exam { get; set; }

        [Required, ForeignKey("ApplicationUser")]
        public int UserId { get; set; }

        public ApplicationUser User { get; set; }

        public DateTime ExamDate { get; set; }

        public string AnswerText { get; set; }

        public int TotalPoints { get; set; }

        public ICollection<UserExamQuestion> UserExamQuestions { get; set; }
    }
}
