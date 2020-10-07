using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreenPlan
{
    public class CarMethodRepository
    {
        protected readonly List<Car> _carDirectory = new List<Car>();

        //Create
        public bool AddCarToDirectory(Car car)
        {
            int _startingCount = _carDirectory.Count;
            _carDirectory.Add(car);
            bool wasAdded = (_carDirectory.Count > _startingCount) ? true : false;
            return wasAdded;
        }
        //GetAlls
        public List<GasCar> GetAllGasCars()
        {
            List<GasCar> allGasCars = new List<GasCar>();
            foreach (Car gasCar in _carDirectory)
            {
                if (gasCar is GasCar)
                {
                    allGasCars.Add((GasCar)gasCar);
                }
            }
            return allGasCars;
        }
        public List<HybridCar> GetAllHybridCars()
        {
            List<HybridCar> allHybridCars = new List<HybridCar>();
            foreach (Car hybridCar in _carDirectory)
            {
                if (hybridCar is HybridCar)
                {
                    allHybridCars.Add((HybridCar)hybridCar);
                }
            }
            return allHybridCars;
        }
        public List<ElectricCar> GetAllElectricCars()
        {
            List<ElectricCar> allElectricCars = new List<ElectricCar>();
            foreach (Car electricCar in _carDirectory)
            {
                if (electricCar is ElectricCar)
                {
                    allElectricCars.Add((ElectricCar)electricCar);
                }
            }
            return allElectricCars;
        }
        //Get By Year Make Model
        public GasCar GetGasCarByTitle(string YearMakeModel)
        {
            foreach (Car gasCar in _carDirectory)
            {
                if (gasCar.YearMakeModel.ToLower() == YearMakeModel.ToLower() && gasCar.GetType() == typeof(GasCar))
                {
                    return (GasCar)gasCar;
                }
            }
            return null;
        }
        public HybridCar GetHybridCarByTitle(string YearMakeModel)
        {
            foreach (Car hybridCar in _carDirectory)
            {
                if (hybridCar.YearMakeModel.ToLower() == YearMakeModel.ToLower() && hybridCar.GetType() == typeof(HybridCar))
                {
                    return (HybridCar)hybridCar;
                }
            }
            return null;
        }
        public ElectricCar GetElectricCarByTitle(string YearMakeModel)
        {
            foreach (Car electricCar in _carDirectory)
            {
                if (electricCar.YearMakeModel.ToLower() == YearMakeModel.ToLower() && electricCar.GetType() == typeof(ElectricCar))
                {
                    return (ElectricCar)electricCar;
                }
            }
            return null;
        }
        //Delete
        public bool DeleteCar(Car existingCar)
        {
            bool deleteResult = _carDirectory.Remove(existingCar);
            return deleteResult;
        }
    }
}
