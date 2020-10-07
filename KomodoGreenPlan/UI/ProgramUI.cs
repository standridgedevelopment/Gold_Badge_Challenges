using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreenPlan.UI
{
    class ProgramUI
    {
        private readonly CarMethodRepository _cars = new CarMethodRepository();
        public void Run()
        {
            SeedCars();
            MainMenu();
        }

        private void MainMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Welcome Komodo Green Plan!");
                Console.WriteLine("What type of car do you want to work with?");
                Console.WriteLine("Enter the number of the option you'd like to select:\n" +
                                  "1) Gas \n" +
                                  "3) Hybrid \n" +
                                  "3) Electric\n" +
                                  "4) Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        GasMenu();
                        break;
                    case "2":
                        HybridMenu();
                        break;
                    case "3":
                        ElectricMenu();
                        break;
                    case "4":
                        //Exit
                        continueToRun = false;
                        break;

                    default:
                        //default
                        Console.Clear();
                        Console.WriteLine("Please enter a valid number between 1 and 4.\n" +
                            "Press any key to continue");
                        Console.ReadKey();
                        break;
                }
            }
        }
        //Gas Cars
        private void GasMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Gas Car System:\n" +
                            "1. Add Car \n" +
                            "2. Display All Cars\n" +
                            "3. Update Car Information \n" +
                            "4. Delete Car\n" +
                            "5. Return To Main Menu");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        NewGasCar();
                        break;
                    case "2":
                        ListAllGasCars();
                        break;
                    case "3":
                        UpdateGasCar();
                        break;
                    case "4":
                        DeleteGasCar();
                        break;
                    case "5":
                        continueToRun = false;
                        break;
                    default:
                        //default
                        Console.Clear();
                        Console.WriteLine("Please enter a valid number between 1 and 5.\n" +
                            "Press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
        public void NewGasCar()
        {
            bool addNewCar = false;
            bool chooseMake = false;
            bool chooseModel = false;
            bool chooseYear = false;
            bool chooseCTD = false;
            bool chooseMPG = false;
            bool chooseChanges = false;
            bool makeChanges = false;
            var newCar = new GasCar();
            while (addNewCar == false)
            {
                Console.Clear();
                chooseChanges = false;
                while (chooseMake == false)
                {
                    chooseMake = true;
                    Console.WriteLine("What is the make of this car?");
                    newCar.Make = Console.ReadLine();
                    Console.Clear();
                }
                while (chooseModel == false)
                {
                    chooseModel = true;
                    Console.WriteLine("What is the model of this car?");
                    newCar.Model = Console.ReadLine();
                    Console.Clear();
                }
                while (chooseYear == false)
                {
                    chooseYear = true;
                    Console.WriteLine("What is the year of this car? (yyyy)");
                    newCar.Year = Console.ReadLine();
                    Console.Clear();
                }
                while (chooseCTD == false)
                {
                    chooseCTD = true;
                    Console.WriteLine("How much does this car cost per year to drive?");
                    try
                    {
                        newCar.CostToDrivePerYear = int.Parse(Console.ReadLine());
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid selection. \nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        chooseCTD = false;

                    }
                }
                while (chooseMPG == false)
                {
                    chooseMPG = true;
                    Console.WriteLine("What is this car's MPG?");
                    try
                    {
                        newCar.MPG = int.Parse(Console.ReadLine());
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid selection. \nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        chooseMPG = false;
                    }
                }
                while (chooseChanges == false)
                {
                    chooseChanges = true;

                    Console.WriteLine("Please review the information for the new car\n");
                    newCar.PrintProps();
                    Console.WriteLine("\nDo you want to make any changes to this car?(y/n)");
                    string changesAnswer = Console.ReadLine().ToLower();

                    switch (changesAnswer)
                    {
                        case "y":
                            makeChanges = true;
                            break;
                        case "n":
                            addNewCar = true;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid selection. \nPress any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            chooseChanges = false;
                            break;
                    }
                }
                Console.Clear();
                while (makeChanges == true)
                {
                    makeChanges = false;
                    Console.WriteLine($"What property would you like to change? Or select 6 to add the new car.\n");
                    newCar.PrintProps();
                    Console.WriteLine("6. Continue");
                    string propertyAnswer = Console.ReadLine().ToLower();
                    switch (propertyAnswer)
                    {
                        case "1":
                            chooseMake = false;
                            Console.Clear();
                            break;
                        case "2":
                            chooseModel = false;
                            Console.Clear();
                            break;
                        case "3":
                            chooseYear = false;
                            Console.Clear();
                            break;
                        case "4":
                            chooseCTD = false;
                            Console.Clear();
                            break;
                        case "5":
                            chooseMPG = false;
                            Console.Clear();
                            break;
                        case "6":
                            addNewCar = true;
                            Console.Clear();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid selection. \nPress any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            makeChanges = true;
                            break;
                    }
                }
            }
            if (addNewCar == true)
            {
                _cars.AddCarToDirectory(newCar);
                Console.Clear();
                Console.WriteLine($"You have successfully added the {newCar.YearMakeModel}.");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void ListAllGasCars()
        {
            Console.Clear();
            List<GasCar> cars = new List<GasCar>();
            cars = _cars.GetAllGasCars();
            cars.Sort((left, right) => string.Compare(left.Make, right.Make));
            Console.WriteLine("Make".PadRight(12) + "Model".PadRight(12) + "Year".PadRight(11) + "CostToDivePerYear".PadRight(21) + "MPG\n");
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Make}".PadRight(12) + $"{car.Model}".PadRight(12) + $"{car.Year}".PadRight(11) + $"{car.CostToDrivePerYear}".PadRight(21) + $"{car.MPG}");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
            Console.Clear();
        }
        public void UpdateGasCar()
        {
            Console.Clear();
            Console.WriteLine("Please enter the year make and model of the car to update(yyyy make model)");
            string oldcarToUpdate = Console.ReadLine();
            var carToUpdate = new GasCar();
            carToUpdate = _cars.GetGasCarByTitle(oldcarToUpdate);
            Console.Clear();
            bool makeChanges = true;
            while (makeChanges == true && carToUpdate != null)
            {
                makeChanges = false;
                Console.WriteLine($"What property would you like to change? Or select 6 to cancel.\n");
                carToUpdate.PrintProps();
                Console.WriteLine("6. Cancel");
                string propertyAnswer = Console.ReadLine().ToLower();
                Console.Clear();
                switch (propertyAnswer)
                {
                    case "1":
                        Console.WriteLine("Enter a new make");
                        carToUpdate.Make = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine($"Make is now {carToUpdate.Make}\n");
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        Console.WriteLine("Enter a model");
                        carToUpdate.Model = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine($"Model is now {carToUpdate.Model}\n");
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        Console.WriteLine("Enter a year");
                        carToUpdate.Year = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine($"Year is now {carToUpdate.Year}\n");
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        Console.WriteLine("Enter a CostToDrive");
                        try
                        {
                            carToUpdate.CostToDrivePerYear = int.Parse(Console.ReadLine());
                            Console.Clear();
                            Console.WriteLine($"CostToDrive is now {carToUpdate.CostToDrivePerYear}\n");
                            Console.WriteLine("Press any key to return to menu...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        catch (Exception)
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid selection. \nPress any key to continue...");
                            makeChanges = true;
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case "5":
                        Console.WriteLine("Enter a MPG");
                        try
                        {
                            carToUpdate.MPG = int.Parse(Console.ReadLine());
                            Console.Clear();
                            Console.WriteLine($"MPG is now {carToUpdate.MPG}\n");
                            Console.WriteLine("Press any key to return to menu...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        catch (Exception)
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid selection. \nPress any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            makeChanges = true;
                        }
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid selection. \nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        makeChanges = true;
                        break;
                }
            }
            if(carToUpdate == null)
            {
                Console.WriteLine("Could not find that car");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                Console.Clear();
            }

        }
        public void DeleteGasCar()
        {
            Console.Clear();
            ListAllGasCars();
            Console.WriteLine();
            Console.WriteLine("Enter the full year, make, and model of the car to delete.");
            string nameToDelete = Console.ReadLine();
            Car deleteThis = _cars.GetGasCarByTitle(nameToDelete);
            if (deleteThis != null)
            {
                _cars.DeleteCar(deleteThis);
                Console.Clear();
                Console.WriteLine($"Success! {nameToDelete} has been deleted.\n");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                Console.Clear();
                Console.Clear(); ;
            }
            else
            {
                Console.WriteLine("Could not find that car");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                Console.Clear();
            }

        }

        //Electric Cars
        private void ElectricMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Electric Car System:\n" +
                            "1. Add Car \n" +
                            "2. Display All Cars\n" +
                            "3. Update Car Information \n" +
                            "4. Delete Car\n" +
                            "5. Return To Main");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        NewElectricCar();
                        break;
                    case "2":
                        ListAllElectricCars();
                        break;
                    case "3":
                        UpdateElectricCar();
                        break;
                    case "4":
                        DeleteElectricCar();
                        break;
                    case "5":
                        continueToRun = false;
                        break;
                    default:
                        //default
                        Console.Clear();
                        Console.WriteLine("Please enter a valid number between 1 and 5.\n" +
                            "Press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
        public void NewElectricCar()
        {
            bool addNewCar = false;
            bool chooseMake = false;
            bool chooseModel = false;
            bool chooseYear = false;
            bool chooseCTD = false;
            bool chooseDistance = false;
            bool chooseChanges = false;
            bool makeChanges = false;
            var newCar = new ElectricCar();
            while (addNewCar == false)
            {
                Console.Clear();
                chooseChanges = false;
                while (chooseMake == false)
                {
                    chooseMake = true;
                    Console.WriteLine("What is the make of this car?");
                    newCar.Make = Console.ReadLine();
                    Console.Clear();
                }
                while (chooseModel == false)
                {
                    chooseModel = true;
                    Console.WriteLine("What is the model of this car?");
                    newCar.Model = Console.ReadLine();
                    Console.Clear();
                }
                while (chooseYear == false)
                {
                    chooseYear = true;
                    Console.WriteLine("What is the year of this car? (yyyy)");
                    newCar.Year = Console.ReadLine();
                    Console.Clear();
                }
                while (chooseCTD == false)
                {
                    chooseCTD = true;
                    Console.WriteLine("How much does this car cost per year to drive?");
                    try
                    {
                        newCar.CostToDrivePerYear = int.Parse(Console.ReadLine());
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid selection. \nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        chooseCTD = false;

                    }
                }
                while (chooseDistance == false)
                {
                    chooseDistance = true;
                    Console.WriteLine("How far can this car drive on a single charge?");
                    try
                    {
                        newCar.DistancePerCharge = int.Parse(Console.ReadLine());
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid selection. \nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        chooseDistance = false;
                    }
                }
                while (chooseChanges == false)
                {
                    chooseChanges = true;

                    Console.WriteLine("Please review the information for the new car\n");
                    newCar.PrintProps();
                    Console.WriteLine("\nDo you want to make any changes to this car?(y/n)");
                    string changesAnswer = Console.ReadLine().ToLower();

                    switch (changesAnswer)
                    {
                        case "y":
                            makeChanges = true;
                            break;
                        case "n":
                            addNewCar = true;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid selection. \nPress any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            chooseChanges = false;
                            break;
                    }
                }
                Console.Clear();
                while (makeChanges == true)
                {
                    makeChanges = false;
                    Console.WriteLine($"What property would you like to change? Or select 6 to add the new car.\n");
                    newCar.PrintProps();
                    Console.WriteLine("6. Continue");
                    string propertyAnswer = Console.ReadLine().ToLower();
                    switch (propertyAnswer)
                    {
                        case "1":
                            chooseMake = false;
                            Console.Clear();
                            break;
                        case "2":
                            chooseModel = false;
                            Console.Clear();
                            break;
                        case "3":
                            chooseYear = false;
                            Console.Clear();
                            break;
                        case "4":
                            chooseCTD = false;
                            Console.Clear();
                            break;
                        case "5":
                            chooseDistance = false;
                            Console.Clear();
                            break;
                        case "6":
                            addNewCar = true;
                            Console.Clear();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid selection. \nPress any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            makeChanges = true;
                            break;
                    }
                }
            }
            if (addNewCar == true)
            {
                _cars.AddCarToDirectory(newCar);
                Console.Clear();
                Console.WriteLine($"You have successfully added the {newCar.YearMakeModel}.");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void ListAllElectricCars()
        {
            Console.Clear();
            List<ElectricCar> cars = new List<ElectricCar>();
            cars = _cars.GetAllElectricCars();
            cars.Sort((left, right) => string.Compare(left.Make, right.Make));
            Console.WriteLine("Make".PadRight(12) + "Model".PadRight(12) + "Year".PadRight(11) + "CostToDivePerYear".PadRight(21) + "DistancePerCharge\n");
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Make}".PadRight(12) + $"{car.Model}".PadRight(12) + $"{car.Year}".PadRight(11) + $"{car.CostToDrivePerYear}".PadRight(21) + $"{car.DistancePerCharge}");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
            Console.Clear();
        }
        public void UpdateElectricCar()
        {
            Console.Clear();
            Console.WriteLine("Please enter the year make and model of the car to update(yyyy make model)");
            string oldcarToUpdate = Console.ReadLine();
            var carToUpdate = new ElectricCar();
            carToUpdate = _cars.GetElectricCarByTitle(oldcarToUpdate);
            Console.Clear();
            bool makeChanges = true;
            while (makeChanges == true && carToUpdate != null)
            {
                makeChanges = false;
                Console.WriteLine($"What property would you like to change? Or select 6 to cancel.\n");
                carToUpdate.PrintProps();
                Console.WriteLine("6. Cancel");
                string propertyAnswer = Console.ReadLine().ToLower();
                Console.Clear();
                switch (propertyAnswer)
                {
                    case "1":
                        Console.WriteLine("Enter a new make");
                        carToUpdate.Make = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine($"Make is now {carToUpdate.Make}\n");
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        Console.WriteLine("Enter a model");
                        carToUpdate.Model = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine($"Model is now {carToUpdate.Model}\n");
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        Console.WriteLine("Enter a year");
                        carToUpdate.Year = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine($"Year is now {carToUpdate.Year}\n");
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        Console.WriteLine("Enter a CostToDrive");
                        try
                        {
                            carToUpdate.CostToDrivePerYear = int.Parse(Console.ReadLine());
                            Console.Clear();
                            Console.WriteLine($"CostToDrive is now {carToUpdate.CostToDrivePerYear}\n");
                            Console.WriteLine("Press any key to return to menu...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        catch (Exception)
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid selection. \nPress any key to continue...");
                            makeChanges = true;
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case "5":
                        Console.WriteLine("Enter a DistancePerCharge");
                        try
                        {
                            carToUpdate.DistancePerCharge = int.Parse(Console.ReadLine());
                            Console.Clear();
                            Console.WriteLine($"MPG is now {carToUpdate.DistancePerCharge}\n");
                            Console.WriteLine("Press any key to return to menu...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        catch (Exception)
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid selection. \nPress any key to continue...");
                            makeChanges = true;
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid selection. \nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        makeChanges = true;
                        break;
                }
            }
            if (carToUpdate == null)
            {
                Console.WriteLine("Could not find that car");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void DeleteElectricCar()
        {
            Console.Clear();
            ListAllElectricCars();
            Console.WriteLine();
            Console.WriteLine("Enter the full year, make, and model of the car to delete.");
            string nameToDelete = Console.ReadLine();
            Car deleteThis = _cars.GetGasCarByTitle(nameToDelete);
            if (deleteThis != null)
            {
                _cars.DeleteCar(deleteThis);
                Console.Clear();
                Console.WriteLine($"Success! {nameToDelete} has been deleted.\n");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                Console.Clear();
                Console.Clear(); ;
            }
            else
            {
                Console.WriteLine("Could not find that car");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                Console.Clear();
            }

        }
        //Hybrid Cars
        private void HybridMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Hybrid Car System:\n" +
                            "1. Add Car \n" +
                            "2. Display All Cars\n" +
                            "3. Update Car Information \n" +
                            "4. Delete Car\n" +
                            "5. Return To Main");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        NewHybridCar();
                        break;
                    case "2":
                        ListAllHybridCars();
                        break;
                    case "3":
                        UpdateHybridCar();
                        break;
                    case "4":
                        DeleteHybridCar();
                        break;
                    case "5":
                        continueToRun = false;
                        break;
                    default:
                        //default
                        Console.Clear();
                        Console.WriteLine("Please enter a valid number between 1 and 5.\n" +
                            "Press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
        public void NewHybridCar()
        {
            bool addNewCar = false;
            bool chooseMake = false;
            bool chooseModel = false;
            bool chooseYear = false;
            bool chooseCTD = false;
            bool chooseMPG = false;
            bool chooseDistance = false;
            bool chooseChanges = false;
            bool makeChanges = false;
            var newCar = new HybridCar();
            while (addNewCar == false)
            {
                Console.Clear();
                chooseChanges = false;
                while (chooseMake == false)
                {
                    chooseMake = true;
                    Console.WriteLine("What is the make of this car?");
                    newCar.Make = Console.ReadLine();
                    Console.Clear();
                }
                while (chooseModel == false)
                {
                    chooseModel = true;
                    Console.WriteLine("What is the model of this car?");
                    newCar.Model = Console.ReadLine();
                    Console.Clear();
                }
                while (chooseYear == false)
                {
                    chooseYear = true;
                    Console.WriteLine("What is the year of this car? (yyyy)");
                    newCar.Year = Console.ReadLine();
                    Console.Clear();
                }
                while (chooseCTD == false)
                {
                    chooseCTD = true;
                    Console.WriteLine("How much does this car cost per year to drive?");
                    try
                    {
                        newCar.CostToDrivePerYear = int.Parse(Console.ReadLine());
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid selection. \nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        chooseCTD = false;

                    }
                }
                while (chooseMPG == false)
                {
                    chooseMPG = true;
                    Console.WriteLine("What is this car's MPG?");
                    try
                    {
                        newCar.MPG = int.Parse(Console.ReadLine());
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid selection. \nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        chooseDistance = false;
                    }
                }
                while (chooseDistance == false)
                {
                    chooseDistance = true;
                    Console.WriteLine("How far can this car drive on a single charge?");
                    try
                    {
                        newCar.DistancePerCharge = int.Parse(Console.ReadLine());
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid selection. \nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        chooseDistance = false;
                    }
                }
                while (chooseChanges == false)
                {
                    chooseChanges = true;

                    Console.WriteLine("Please review the information for the new car\n");
                    newCar.PrintProps();
                    Console.WriteLine("\nDo you want to make any changes to this car?(y/n)");
                    string changesAnswer = Console.ReadLine().ToLower();

                    switch (changesAnswer)
                    {
                        case "y":
                            makeChanges = true;
                            break;
                        case "n":
                            addNewCar = true;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid selection. \nPress any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            chooseChanges = false;
                            break;
                    }
                }
                Console.Clear();
                while (makeChanges == true)
                {
                    makeChanges = false;
                    Console.WriteLine($"What property would you like to change? Or select 6 to add the new car.\n");
                    newCar.PrintProps();
                    Console.WriteLine("7. Continue");
                    string propertyAnswer = Console.ReadLine().ToLower();
                    switch (propertyAnswer)
                    {
                        case "1":
                            chooseMake = false;
                            Console.Clear();
                            break;
                        case "2":
                            chooseModel = false;
                            Console.Clear();
                            break;
                        case "3":
                            chooseYear = false;
                            Console.Clear();
                            break;
                        case "4":
                            chooseCTD = false;
                            Console.Clear();
                            break;
                        case "5":
                            chooseMPG = false;
                            Console.Clear();
                            break;
                        case "6":
                            chooseDistance = false;
                            Console.Clear();
                            break;
                        case "7":
                            addNewCar = true;
                            Console.Clear();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid selection. \nPress any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            makeChanges = true;
                            break;
                    }
                }
            }
            if (addNewCar == true)
            {
                _cars.AddCarToDirectory(newCar);
                Console.Clear();
                Console.WriteLine($"You have successfully added the {newCar.YearMakeModel}.");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void ListAllHybridCars()
        {
            Console.Clear();
            List<HybridCar> cars = new List<HybridCar>();
            cars = _cars.GetAllHybridCars();
            cars.Sort((left, right) => string.Compare(left.Make, right.Make));
            Console.WriteLine("Make".PadRight(12) + "Model".PadRight(12) + "Year".PadRight(11) + "CostToDivePerYear".PadRight(21) + "MPG".PadRight(12) + "DistancePerCharge\n");
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Make}".PadRight(12) + $"{car.Model}".PadRight(12) + $"{car.Year}".PadRight(11) + $"{car.CostToDrivePerYear}".PadRight(21) + $"{car.MPG}".PadRight(12) + $"{car.DistancePerCharge}");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
            Console.Clear();
        }
        public void UpdateHybridCar()
        {
            Console.Clear();
            Console.WriteLine("Please enter the year make and model of the car to update(yyyy make model)");
            string oldcarToUpdate = Console.ReadLine();
            var carToUpdate = new HybridCar();
            carToUpdate = _cars.GetHybridCarByTitle(oldcarToUpdate);
            Console.Clear();
            bool makeChanges = true;
            while (makeChanges == true && carToUpdate != null)
            {
                makeChanges = false;
                Console.WriteLine($"What property would you like to change? Or select 7 to cancel.\n");
                carToUpdate.PrintProps();
                Console.WriteLine("7. Cancel");
                string propertyAnswer = Console.ReadLine().ToLower();
                Console.Clear();
                switch (propertyAnswer)
                {
                    case "1":
                        Console.WriteLine("Enter a new make");
                        carToUpdate.Make = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine($"Make is now {carToUpdate.Make}\n");
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        Console.WriteLine("Enter a model");
                        carToUpdate.Model = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine($"Model is now {carToUpdate.Model}\n");
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        Console.WriteLine("Enter a year");
                        carToUpdate.Year = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine($"Year is now {carToUpdate.Year}\n");
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        Console.WriteLine("Enter a CostToDrive");
                        try
                        {
                            carToUpdate.CostToDrivePerYear = int.Parse(Console.ReadLine());
                            Console.Clear();
                            Console.WriteLine($"CostToDrive is now {carToUpdate.CostToDrivePerYear}\n");
                            Console.WriteLine("Press any key to return to menu...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        catch (Exception)
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid selection. \nPress any key to continue...");
                            makeChanges = true;
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case "5":
                        Console.WriteLine("Enter a new MPG");
                        try
                        {
                            carToUpdate.DistancePerCharge = int.Parse(Console.ReadLine());
                            Console.Clear();
                            Console.WriteLine($"MPG is now {carToUpdate.MPG}\n");
                            Console.WriteLine("Press any key to return to menu...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        catch (Exception)
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid selection. \nPress any key to continue...");
                            makeChanges = true;
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case "6":
                        Console.WriteLine("Enter a DistancePerCharge");
                        try
                        {
                            carToUpdate.DistancePerCharge = int.Parse(Console.ReadLine());
                            Console.Clear();
                            Console.WriteLine($"MPG is now {carToUpdate.DistancePerCharge}\n");
                            Console.WriteLine("Press any key to return to menu...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        catch (Exception)
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid selection. \nPress any key to continue...");
                            makeChanges = true;
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case "7":
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid selection. \nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        makeChanges = true;
                        break;
                }
            }
            if (carToUpdate == null)
            {
                Console.WriteLine("Could not find that car");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void DeleteHybridCar()
        {
            Console.Clear();
            ListAllHybridCars();
            Console.WriteLine("Enter the full year, make, and model of the car to delete.");
            string nameToDelete = Console.ReadLine();
            Car deleteThis = _cars.GetElectricCarByTitle(nameToDelete);
            if (deleteThis != null)
            {
                _cars.DeleteCar(deleteThis);
                Console.Clear();
                Console.WriteLine($"Success! {nameToDelete} has been deleted.\n");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                Console.Clear();
                Console.Clear(); ;
            }
            else
            {
                Console.WriteLine("Could not find that car");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                Console.Clear();
            }

        }

        public void SeedCars()
        {
            var gasCar1 = new GasCar("Honda", "Civic", "2020", 1000, 25);
            var gasCar2 = new GasCar("Toyota", "Camry", "2020", 800, 30);
            var gasCar3 = new GasCar("Hyundai", "Sonata", "2020", 1200, 28);
            var hybrid1 = new HybridCar("Toyota", "Prius", "2020", 1500, 80, 100);
            var hybrid2 = new HybridCar("Chevy", "Bolt", "2020", 1500, 80, 80);
            var hybrid3 = new HybridCar("Hyundai", "Hybrid", "2020", 2500, 50, 80);
            var ele1 = new ElectricCar("Tesla", "Model S", "2020", 2000, 300);
            var ele2 = new ElectricCar("Tesla", "Model X", "2020", 2300, 300);
            var ele3 = new ElectricCar("Tesla", "Model Y", "2020", 2100, 350);
            _cars.AddCarToDirectory(gasCar1);
            _cars.AddCarToDirectory(gasCar2);
            _cars.AddCarToDirectory(gasCar3);
            _cars.AddCarToDirectory(hybrid1);
            _cars.AddCarToDirectory(hybrid2);
            _cars.AddCarToDirectory(hybrid3);
            _cars.AddCarToDirectory(ele1);
            _cars.AddCarToDirectory(ele2);
            _cars.AddCarToDirectory(ele3);
        }
    }
}
