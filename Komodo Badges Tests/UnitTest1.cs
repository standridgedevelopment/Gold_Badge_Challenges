using System;
using System.Collections.Generic;
using KomodoBadges;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Komodo_Badges_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var newBadge = new Badge(25, new List<string>());
            newBadge.DoorNames.Add("E25");
            int badgeNumber = BadgeRepository.GetBadgeByNumber(25);
            //Should Return 25;
            Console.WriteLine(badgeNumber);
            badgeNumber = BadgeRepository.GetBadgeByNumber(26);
            //Should Return 0;
            Console.WriteLine(badgeNumber);



        }
    }
}
