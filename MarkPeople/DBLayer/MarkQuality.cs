using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkPeople.DBLayer
{
    public class MarkQuality
    {
        public int MarkQualityId { get; set; }
        public int PeopleId { get; set; }
        public People People { get; set; }
        public int Beauty { get; set; }
        public int Power { get; set; }
        public int Mind { get; set; }
        public bool IsLikePizzaPineApple { get; set; }
    }
}
