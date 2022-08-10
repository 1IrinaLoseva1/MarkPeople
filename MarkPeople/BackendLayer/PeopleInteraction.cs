//using MarkPeople.DBLayer;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace MarkPeople.BackendLayer
//{
//    public class PeopleInteraction
//    {
//        public List<People> GetPeoples()
//        {
//            using(ApplicationContext ac = new ApplicationContext())
//            {
//                return ac.Peoples.ToList();
//            }
//        }
        
//        public People GetPeople(int id)
//        {
//            using (ApplicationContext ac = new ApplicationContext())
//            {
//                return ac.Peoples.FirstOrDefault(i => i.PeopleId == id);
//            }
//        }

//        public bool DeletePeople(int id)
//        {
//            using (ApplicationContext ac = new ApplicationContext())
//            {
//                var people = ac.Peoples.FirstOrDefault(i => i.PeopleId == id);
//                if (people != null)
//                {
//                    ac.Peoples.Remove(people);
//                    ac.SaveChanges();
//                    return true;
//                }
//                else
//                {
//                    return false;
//                }
//            }
//        }
//        public bool CreatePeople(string name, string surname, int age, double weight, DateTime bday, int countryId)
//        {
//            using (ApplicationContext ac = new ApplicationContext())
//            {
//                if (string.IsNullOrEmpty(name) 
//                    || string.IsNullOrEmpty(surname)
//                    || age <= 0
//                    || weight <= 0
//                    || CalcAge(bday) != age)
//                {
//                    return false;
//                }

//                var country = ac.Countries.FirstOrDefault(i => i.CountryId == countryId);
//                if (country == null)
//                {
//                    return false;
//                }

//                ac.Peoples.Add(new People() 
//                {
//                   PeopleName = name,
//                   PeopleSurname = surname,
//                   PeopleAge = age,
//                   PeopleWeight = weight,
//                   PeopleBDay = bday,
//                   CountryId = countryId
//                });
//                ac.SaveChanges();
//                return true;
//            }
//        }

//        public bool UpdatePeople(int id, string name, string surname, int age, double weight, DateTime bday, int countryId)
//        {
//            using (ApplicationContext ac = new ApplicationContext())
//            {
//                if (string.IsNullOrEmpty(name)
//                    || string.IsNullOrEmpty(surname)
//                    || age <= 0
//                    || weight <= 0
//                    || CalcAge(bday) != age)
//                {
//                    return false;
//                }

//                var country = ac.Countries.FirstOrDefault(i => i.CountryId == countryId);
//                if (country == null)
//                {
//                    return false;
//                }

//                var people = ac.Peoples.FirstOrDefault(i => i.PeopleId == id);
//                if (people == null)
//                {
//                    return false;
//                }

//                people.PeopleName = name;
//                people.PeopleSurname = surname;
//                people.PeopleWeight = weight;
//                people.PeopleBDay = bday;
//                people.PeopleAge = age;
//                people.CountryId = countryId;

//                ac.Peoples.Update(people);
//                ac.SaveChanges();
//                return true;
//            }
//        }

//        private int CalcAge(DateTime bday)
//        {
//            var today = DateTime.Today; //Получаем текущую дату

//            var age = today.Year - bday.Year; //получаем разницу в годах

//            if (bday.Date > today.AddYears(-age)) age--;

//            return age;
//        }
//    }
//}
