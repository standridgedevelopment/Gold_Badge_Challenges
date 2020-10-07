using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreenPlan
{
    public class ElectricCar : Car
    {
        public int DistancePerCharge;
        public override void PrintProps()
        {
            Console.WriteLine($"1. Make: {Make}");
            Console.WriteLine($"2. Model: {Model}");
            Console.WriteLine($"3. Year: {Year}");
            Console.WriteLine($"4. CostToDrive: ${CostToDrivePerYear}");
            Console.WriteLine($"5. DistancePerCharge: {DistancePerCharge}");

        }
        public ElectricCar(string make, string model, string year, int costToDrive, int distance)
            : base(make, model, year, costToDrive)
        {
            DistancePerCharge = distance;
        }
        public ElectricCar() { }
    }
    
}
