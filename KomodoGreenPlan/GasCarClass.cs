using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreenPlan
{
    public class GasCar : Car
    {
        public int MPG;
        public override void PrintProps()
        {
            Console.WriteLine($"1. Make: {Make}");
            Console.WriteLine($"2. Model: {Model}");
            Console.WriteLine($"3. Year: {Year}");
            Console.WriteLine($"4. CostToDrive: ${CostToDrivePerYear}");
            Console.WriteLine($"5. MPG: {MPG}");
        }
        public GasCar(string make, string model, string year, int costToDrive, int mpg)
            : base(make, model, year, costToDrive)
        {
            MPG = mpg;
        }
        public GasCar() { }
    }
}
