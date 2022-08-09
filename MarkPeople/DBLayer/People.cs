using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkPeople.DBLayer
{
    public class People
    {
        public int PeopleId { get; set; }
        public string PeopleName { get; set; }
        public string PeopleSurname { get; set; }
        public int PeopleAge { get; set; }
        public double PeopleWeight { get; set; }
        public DateTime PeopleBDay { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
