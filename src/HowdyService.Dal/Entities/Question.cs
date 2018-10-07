using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HowdyService.Dal.Entities
{
    public class Question : BaseEntity
    {
        [Required]
        public string Text { get; set; }

        public virtual ICollection<Anwser> Anwsers { get; set; }
    }
}
