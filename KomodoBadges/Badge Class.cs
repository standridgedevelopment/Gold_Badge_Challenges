using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges
{
    public class Badge
    {
        public int BadgeID;
        public List<string> DoorNames;
        public Badge()
        {
            new List<string>();
            BadgeRepository.BadgeCollection.Add(BadgeID, DoorNames);
        }
        public Badge(int badgeID, List<string> doorNames)
        {
            BadgeID = badgeID;
            DoorNames = doorNames;
            new List<string>();
            BadgeRepository.BadgeCollection.Add(BadgeID, DoorNames);
        }
    }
    

}
