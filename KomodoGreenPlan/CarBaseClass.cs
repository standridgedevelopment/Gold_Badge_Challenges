using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreenPlan
{
    public abstract class Car
    {
        public string Make;
        public string Model;
        public string Year;
        public int CostToDrivePerYear;
        public string YearMakeModel 
        { 
            get
            {
                string yearMakeModel = $"{Year} {Make} {Model}";
                return yearMakeModel;
            } 
        }

        public virtual void PrintProps()
        {

        }
        public Car(string make, string model, string year, int costToDrive)
        {
            Make = make;
            Model = model;
            Year = year;
            CostToDrivePerYear = costToDrive;
        }
        public Car() { }


    }
}
