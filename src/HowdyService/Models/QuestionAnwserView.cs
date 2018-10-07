using HowdyService.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HowdyService.Models
{
    public class QuestionAnwserView
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public ICollection<Anwser> Anwsers { get; set; }
    }
}
