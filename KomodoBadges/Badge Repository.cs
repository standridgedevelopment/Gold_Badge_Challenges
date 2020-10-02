using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges
{
    public static class BadgeRepository
    {
        public static Dictionary<int, List<string>> BadgeCollection = new Dictionary<int, List<string>>();
        public static int GetBadgeByNumber(int badgeNumber)
        {
            foreach (KeyValuePair<int, List<string>> badge in BadgeCollection)
            {
                if (badge.Key == badgeNumber)
                {
                    return badge.Key;
                }
            }
            return 0;
        }
    }
}
