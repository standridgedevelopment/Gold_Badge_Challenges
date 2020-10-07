using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreenPlan
{
    public class HybridCar : Car
    {
        public int MPG;
        public int DistancePerCharge;
        public override void PrintProps()
        {
            Console.WriteLine($"1. Make: {Make}");
            Console.WriteLine($"2. Model: {Model}");
            Console.WriteLine($"3. Year: {Year}");
            Console.WriteLine($"4. CostToDrive: ${CostToDrivePerYear}");
            Console.WriteLine($"5. MPG: {MPG}");
            Console.WriteLine($"6. DistancePerCharge: {DistancePerCharge}");
        }
        public HybridCar() { }
        public HybridCar(string make, string model, string year, int costToDrive, int mpg, int distance)
            :base(make, model, year, costToDrive)
        {
            MPG = mpg;
            DistancePerCharge = distance;
        }
    }
}
