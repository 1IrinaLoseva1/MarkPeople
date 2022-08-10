using MarkPeople.DBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkPeople.BackendLayer
{
    public class MarkInteraction
    {
        public List<MarkQuality> GetMarks()
        {
            using (ApplicationContext ac = new ApplicationContext())
            {
                return ac.MarkQualities.ToList();
            }
        }

        public MarkQuality GetMark(int id)
        {
            using (ApplicationContext ac = new ApplicationContext())
            {
                return ac.MarkQualities.FirstOrDefault(i => i.MarkQualityId == id);
            }
        }

        public bool DeleteMarkQualities(int id)
        {
            using (ApplicationContext ac = new ApplicationContext())
            {
                var markQuality = ac.MarkQualities.FirstOrDefault(i => i.MarkQualityId == id);
                if (markQuality != null)
                {
                    ac.MarkQualities.Remove(markQuality);
                    ac.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool CreateMarkQualities(int peopleId, int beauty, int power, int mind, bool isLikePizzaPineApple)
        {
            using (ApplicationContext ac = new ApplicationContext())
            {
                if ((beauty < 0 || beauty > 10)
                    || (power < 0 || power > 10)
                    || (mind < 0 || mind > 10))
                {
                    return false;
                }

                var people = ac.Peoples.FirstOrDefault(i => i.PeopleId == peopleId);
                if (people == null)
                {
                    return false;
                }

                ac.MarkQualities.Add(new MarkQuality()
                {
                    PeopleId = peopleId,
                    Beauty = beauty,
                    Power = power,
                    Mind = mind,
                    IsLikePizzaPineApple = isLikePizzaPineApple
                });
                ac.SaveChanges();
                return true;
            }
        }

        public bool UpdateMarkQualities(int markQualityId, int peopleId, int beauty, int power, int mind, bool isLikePizzaPineApple)
        {
            using (ApplicationContext ac = new ApplicationContext())
            {
                if ((beauty < 0 || beauty > 10)
                    || (power < 0 || power > 10)
                    || (mind < 0 || mind > 10))
                {
                    return false;
                }

                var people = ac.Peoples.FirstOrDefault(i => i.PeopleId == peopleId);
                if (people == null)
                {
                    return false;
                }

                var markQuality = ac.MarkQualities.FirstOrDefault(i => i.MarkQualityId == markQualityId);
                if (markQuality == null)
                {
                    return false;
                }

                markQuality.PeopleId = peopleId;
                markQuality.Beauty = beauty;
                markQuality.Power = power;
                markQuality.Mind = mind;
                markQuality.IsLikePizzaPineApple = isLikePizzaPineApple;

                ac.MarkQualities.Update(markQuality);
                ac.SaveChanges();
                return true;
            }
        }

    }
}
