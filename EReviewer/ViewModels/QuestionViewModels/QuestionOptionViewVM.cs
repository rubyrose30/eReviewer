using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EReviewer.ViewModels.QuestionViewModels
{
    public class QuestionOptionViewVM
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public bool IsAnswer { get; set; }
    }
}
