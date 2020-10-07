using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBBQ
{
    public interface Party { }
    public class Booths : Party
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

        public double VeggieburgerCost
        {
            get
            {
                return HowManyVeggieburgers * 4;
            }
        }
        public double HamburgerCost
        {
            get
            {
                return HowManyHamburgers * 3;
            }
        }
        public double HotDogCost
        {
            get
            {
                return HowManyHotDogs*2;
            }
        }
        public double MiscBurgerCost
        {
            get
            {
                return (HowManyHamburgers + HowmanyHotDogs + HowManyVeggieburgers) * 0.5d;
            }
        }

        public int HowManyPopcorns;
        public int HowManyIcecream;

        public double PopCornCost
        {
            get
            {
                return HowManyPopcorns * .50d;
            }
        }
        public double IceCreamCost
        {
            get
            {
                return HowManyIcecream * 0.75d;
            }
        }
        public double MiscTreatCost
        {
            get
            {
                return (HowManyIcecream + HowManyPopcorns) * 0.50d;
            }
        }
    }
}
