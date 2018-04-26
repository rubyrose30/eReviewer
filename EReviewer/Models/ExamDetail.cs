using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EReviewer.Models
{
    public class ExamDetail
    {
        [Key]
        public int Id { get; set; }

        [Required, ForeignKey("Exam")]
        public int ExamId { get; set; }

        public Exam Exam { get; set; }

        [Required, ForeignKey("Subject")]
        public int SubjectId { get; set; }

        public Subject Subject { get; set; }

        public int NoOfItems { get; set; }
    }
}
