using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarkPeople.DBLayer
{
    public class People
    {
        public int PeopleId { get; set; }

        [StringLength(60, MinimumLength = 3)] //мин. длина - 3, макс. - 60
        [Required] //требуется, должно иметь значение
        public string PeopleName { get; set; }

        [StringLength(60, MinimumLength = 3)] //мин. длина - 3, макс. - 60
        [Required] //требуется, должно иметь значение
        public string PeopleSurname { get; set; }
        
        [Range(1, 120)]
        public int PeopleAge { get; set; }
       
        [Range(1, 200)]
        public int PeopleWeight { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime PeopleBDay { get; set; }
        
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
