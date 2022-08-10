using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarkPeople.DBLayer
{
    public class MarkQuality
    {
        public int MarkQualityId { get; set; }
        public int PeopleId { get; set; }
        public People People { get; set; }
       
        [Range(0, 10)]
        public int Beauty { get; set; }

        [Range(0, 10)]
        public int Power { get; set; }

        [Range(0, 10)]
        public int Mind { get; set; }
        public bool IsLikePizzaPineApple { get; set; }
    }
}
