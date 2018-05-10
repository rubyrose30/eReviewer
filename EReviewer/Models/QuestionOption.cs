using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EReviewer.Models
{
    public class QuestionOption
    {
        [Key]
        public int Id { get; set; }

        [Required, ForeignKey("Question")]
        public int QuestionId { get; set; }

        public Question Question { get; set; }

        public string Description { get; set; }

        public bool IsAnswer { get; set; }
    }
}
