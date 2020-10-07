using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Outings.UI
{
    public class ProgramUI
    {
        private readonly OutingMethodRepository _outings = new OutingMethodRepository();
        public void Run()
        {
            SeedOutings();
            MainMenu();
        }

        private void MainMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Komodo Outings. Please select a menu item:\n" +
                            "1. See All Outings \n" +
                            "2. Add New Outing\n" +
                            "3. Calculations \n" +
                            "4. Exit");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //Display a list of all outings
                        ListOfOutings();
                        break;
                    case "2":
                        //Add New Outing
                        AddOuting();
                        break;
                    case "3":
                        //Calculations
                        Calculations();
                        break;

                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        //default
                        Console.Clear();
                        Console.WriteLine("Please enter a valid number between 1 and 4.\n" +
                            "Press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
        void ListOfOutings()
        {
            Console.Clear();
            List<Outing> allOutings = new List<Outing>();
            allOutings = _outings.GetOutings();

            Console.WriteLine("Type of Event".PadRight(18) + "Date".PadRight(15) + "Amount of People".PadRight(18) + "Cost Per Person".PadRight(18) + "Total Cost\n");
            foreach (var outing in allOutings)
            {
                Console.WriteLine($"{outing.EventType}".PadRight(18) + $"{outing.Date.ToShortDateString()}".PadRight(15) + $"{outing.Attended}".PadRight(18) + $"{outing.PerPersonCost}".PadRight(18) + $"{outing.TotalCost}");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
            Console.Clear();
        }
        void AddOuting()
        {
            Console.Clear();
            bool enterNewOuting = false;
            bool chooseEventType = false;
            bool choosePeople = false;
            bool chooseDate = false;
            bool chooseCost = false;
            bool chooseChanges = false;
            bool makeChanges = false;
            var newOuting = new Outing();
            while (enterNewOuting == false)
            {
                chooseChanges = false;
                while (chooseEventType == false)
                {
                    //Type of Event
                    chooseEventType = true;
                    Console.WriteLine("What type of event is this?\n" +
                    "1) Golf\n" +
                    "2) Bowling\n" +
                    "3) Amusement Park\n" +
                    "4) Concert");
                    string outingTypeChoice = Console.ReadLine();
                    switch (outingTypeChoice)
                    {
                        case "1":
                            newOuting.EventType = EventType.Golf;
                            break;
                        case "2":
                            newOuting.EventType = EventType.Bowling;
                            break;
                        case "3":
                            newOuting.EventType = EventType.AmusementPark;
                            break;
                        case "4":
                            newOuting.EventType = EventType.Concert;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Please enter a valid number.\n" +
                                 "Press any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            chooseEventType = false;
                            break;
                    }
                    Console.Clear();
                }
                while (choosePeople == false)
                {
                    //Amount of People
                    choosePeople = true;
                    Console.WriteLine("How many people attended this event?");
                    
                    try
                    {
                        newOuting.Attended = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a valid number.\n" +
                                    "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        choosePeople = false;
                    }
                    Console.Clear();
                }
                while (chooseDate == false)
                {
                    //Date of Event
                    chooseDate = true;
                    Console.WriteLine("Please enter the date of the event (mm/dd/yyyy)");
                    try
                    {
                        newOuting.Date = DateTime.Parse(Console.ReadLine());
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a valid date. (mm/dd/yyyy)\n" +
                                    "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        chooseDate = false;
                    }
                }
                while (chooseCost == false)
                {
                    //Per person Cost
                    chooseCost = true;
                    Console.WriteLine("What was the per person cost?");

                    try
                    {
                        newOuting.PerPersonCost = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a valid number.\n" +
                                    "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        choosePeople = false;
                    }
                    Console.Clear();
                }
                while(chooseChanges == false)
                {
                    chooseChanges = true;
                   
                    Console.WriteLine("Please review the information for the new outing\n");
                    newOuting.PrintProps();
                    Console.WriteLine("\nDo you want to make any changes to this outing?(y/n)");
                    string changesAnswer = Console.ReadLine().ToLower();

                    switch (changesAnswer)
                    {
                        case "y":
                            makeChanges = true;
                            break;
                        case "n":
                            enterNewOuting = true;
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
                    Console.WriteLine($"What property would you like to change? Or select 5 to add the new outing.\n");
                    newOuting.PrintProps();
                    Console.WriteLine("5. Continue");
                    string propertyAnswer = Console.ReadLine().ToLower();
                    switch (propertyAnswer)
                    {
                        case "1":
                            chooseEventType = false;
                            Console.Clear();
                            break;
                        case "2":
                            choosePeople = false;
                            Console.Clear();
                            break;
                        case "3":
                            chooseDate = false;
                            Console.Clear();
                            break;
                        case "4":
                            chooseCost = false;
                            Console.Clear();
                            break;
                        case "5":
                            enterNewOuting = true;
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
            if (enterNewOuting == true)
            {
                _outings.AddOuting(newOuting);
                Console.Clear();
                Console.WriteLine($"You have successfully added the outing.");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                Console.Clear();
               
            }
        }
        void Calculations()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("What Type of Calculation woul you like?:\n" +
                            "1) See cost of all outings \n" +
                            "2) See costs of outings by type\n" +
                            "3) Go back to main menu");

                string userInput = Console.ReadLine();
                List<Outing> currentOutings = new List<Outing>();
                currentOutings = _outings.GetOutings();
                switch (userInput)
                {
                    case "1":
                        //Display cost of all outings
                        int totalCost = 0;
                        foreach (var outing in currentOutings)
                        {
                            totalCost += outing.TotalCost;
                        }
                        Console.Clear();
                        Console.WriteLine($"The total cost for all outings is ${totalCost}\n");
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        //Outings by type
                        DisplayOutingsByType();
                        break;
                    case "3":
                        //Main Menu
                        continueToRun = false;
                        break;
                    default:
                        //default
                        Console.Clear();
                        Console.WriteLine("Please enter a valid number between 1 and 4.\n" +
                            "Press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
        void DisplayOutingsByType()
        {
            Console.Clear();
            List<Outing> currentOutings = new List<Outing>();
            currentOutings = _outings.GetOutings();
            Console.WriteLine("What type of event do you want to view?\n" +
                   "1) Golf\n" +
                   "2) Bowling\n" +
                   "3) Amusement Park\n" +
                   "4) Concert");
            string outingTypeChoice = Console.ReadLine();
            switch (outingTypeChoice)
            {
                case "1":
                    int costOfGolfOutings = 0;
                    foreach (var outing in currentOutings)
                    {
                        if (outing.EventType == EventType.Golf)
                        {
                            costOfGolfOutings += outing.TotalCost;
                        }
                    }
                    Console.Clear();
                    Console.WriteLine($"The total cost for golf outings is ${costOfGolfOutings}\n");
                    Console.WriteLine("Press any key to return to menu...");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine();
                    break;
                case "2":
                    int costOfBowling = 0;
                    foreach (var outing in currentOutings)
                    {
                        if (outing.EventType == EventType.Bowling)
                        {
                            costOfBowling += outing.TotalCost;
                        }
                    }
                    Console.Clear();
                    Console.WriteLine($"The total cost for bowling outings is ${costOfBowling}\n");
                    Console.WriteLine("Press any key to return to menu...");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine();
                    break;
                case "3":
                    int costOfAmusementPark = 0;
                    foreach (var outing in currentOutings)
                    {
                        if (outing.EventType == EventType.AmusementPark)
                        {
                            costOfAmusementPark += outing.TotalCost;
                        }
                    }
                    Console.Clear();
                    Console.WriteLine($"The total cost for amusement park outings is ${costOfAmusementPark}\n");
                    Console.WriteLine("Press any key to return to menu...");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine();
                    break;
                case "4":
                    int costOfConcerts = 0;
                    foreach (var outing in currentOutings)
                    {
                        if (outing.EventType == EventType.Concert)
                        {
                            costOfConcerts += outing.TotalCost;
                        }
                    }
                    Console.Clear();
                    Console.WriteLine($"The total cost for concert outings is ${costOfConcerts}\n");
                    Console.WriteLine("Press any key to return to menu...");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine();
                    break;
                default:
                    //default
                    Console.Clear();
                    Console.WriteLine("Please enter a valid number between 1 and 4.\n" +
                        "Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }
        void SeedOutings()
        {
            var outing1 = new Outing(EventType.AmusementPark, 20, new DateTime(2020, 05, 20), 50);
            var outing2 = new Outing(EventType.Concert, 40, new DateTime(2017, 05, 20), 40);
            var outing3 = new Outing(EventType.Golf, 35, new DateTime(2019, 05, 20), 5);
            var outing4 = new Outing(EventType.Bowling, 10, new DateTime(2018, 05, 20), 25);
            _outings.AddOuting(outing1);
            _outings.AddOuting(outing2);
            _outings.AddOuting(outing3);
            _outings.AddOuting(outing4);
        }
    }
}
