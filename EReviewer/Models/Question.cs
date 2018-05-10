using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EReviewer.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Required, ForeignKey("Subject")]
        public int SubjectId { get; set; }

        /// <summary>
        /// Reference to Subject
        /// </summary>
        public Subject Subject { get; set; }

        [Required, ForeignKey("ExamType")]
        public int ExamTypeId { get; set; }

        /// <summary>
        /// Reference to ExamType
        /// </summary>
        public ExamType ExamType { get; set; }

        [Required]
        public string QuestionText { get; set; }

        public int Points { get; set; }

        [ForeignKey("QuestionOption")]
        public int? AnswerId { get; set; }

        public QuestionOption Answer { get; set; }

        public string AnswerText { get; set; }

        public ICollection<QuestionOption> Options { get; set; }
    }
}
