using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HowdyService.Dal.Entities
{
    public class Anwser : BaseEntity
    {
        [Required]
        public string Text { get; set; }
        public int Value { get; set; }

        public virtual Question Question { get; set; }
        public int? QuestionId { get; set; }
    }
}
