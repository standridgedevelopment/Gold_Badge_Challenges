using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBBQ
{
    public class Booths
    {
        public int HowManyVeggieburgers;
        public int HowManyHamburgers;
        public int HowManyHotDogs;
        public int HowManyBurgerBoothTickets
        {
            get
            {
                return HowManyVeggieburgers + HowManyHamburgers + HowManyHotDogs;
            }
        }

        public decimal VeggieburgerCost
        {
            get
            {
                return HowManyVeggieburgers * 4.00m;
            }
        }
        public decimal HamburgerCost
        {
            get
            {
                return HowManyHamburgers * 3.00m;
            }
        }
        public decimal HotDogCost
        {
            get
            {
                return HowManyHotDogs*2.00m;
            }
        }
     
        public decimal MiscBurgerCost
        {
            get
            {
                return (HowManyHamburgers + HowManyHotDogs + HowManyVeggieburgers) * 0.50m;
            }
        }
        public decimal BurgerBoothCost
        {
            get
            {
                return HamburgerCost + HotDogCost + VeggieburgerCost + MiscBurgerCost;
            }
        }

        public int HowManyPopcorns;
        public int HowManyIcecream;
        public int HowManyTreatBoothTickets
        {
            get
            {
                return HowManyPopcorns + HowManyIcecream;
            }
        }

        public decimal PopCornCost
        {
            get
            {
                return HowManyPopcorns * .50m;
            }
        }
        public decimal IceCreamCost
        {
            get
            {
                return HowManyIcecream * 0.75m;
            }
        }
        public decimal MiscTreatCost
        {
            get
            {
                return (HowManyIcecream + HowManyPopcorns) * 0.50m;
            }
        }
        public decimal TreatBoothCost
        {
            get
            {
                return PopCornCost + IceCreamCost + MiscTreatCost;
            }
        }

        public int TotalTickets 
        { 
            get
            {
                return HowManyTreatBoothTickets + HowManyBurgerBoothTickets;
            } 
        }
        public decimal TotalCost
        {
            get
            {
                return TreatBoothCost + BurgerBoothCost;
            }
        }
        public DateTime DateOfParty;

        public Booths() { }
        public Booths(int howManyVeg, int howManyHam, int howManyHot, int howManyPopC, int howManyIceC, DateTime date)
        {
            HowManyVeggieburgers = howManyVeg;
            HowManyHamburgers = howManyHam;
            HowManyHotDogs = howManyHot;
            HowManyPopcorns = howManyPopC;
            HowManyIcecream = howManyIceC;
            DateOfParty = date;
        }
        public void PrintProps()
        {
            Console.WriteLine($"1. Date Of Party: {DateOfParty.ToShortDateString()}");
            Console.WriteLine($"2. Hotdog Tickets: {HowManyHotDogs}");
            Console.WriteLine($"3. Hamburger Tickets: {HowManyHamburgers}");
            Console.WriteLine($"4. Veggieburger Tickets: {HowManyVeggieburgers}");
            Console.WriteLine($"5. Popcorn Tickets: {HowManyPopcorns}");
            Console.WriteLine($"6. Icecream Tickets: {HowManyIcecream}");
        }
    }
}
