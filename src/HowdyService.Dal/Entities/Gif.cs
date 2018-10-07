using System;
using System.Collections.Generic;
using System.Text;

namespace HowdyService.Dal.Entities
{
    public class Gif : BaseEntity
    {
        public string Name { get; set; }
        public string GiphyId { get; set; }
    }
}
