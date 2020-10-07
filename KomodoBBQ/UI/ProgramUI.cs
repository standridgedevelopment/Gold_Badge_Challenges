using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBBQ.UI
{
    class ProgramUI
    {
        private readonly BoothRepository _parties = new BoothRepository();
        public void Run()
        {
            SeedParties();
            MainMenu();
        }

        private void MainMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Komodo Party System:\n" +
                            "1. Add New Party \n" +
                            "2. Display All Parties\n" +
                            "3. Party Statistics \n" +
                            "4. Exit");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        NewParty();
                        break;
                    case "2":
                        ListParties();
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        PartyStats();
                        break;
                    case "4":
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
        void NewParty()
        {
            Console.Clear();
            bool addParty = false;
            bool choosePartyDate = false;
            bool howManyHotDogs = false;
            bool howManyHamburgers = false;
            bool howManyVeggieburgers = false;
            bool howManyPopCorn = false;
            bool howManyIcecream = false;
            bool chooseChanges = false;
            bool makeChanges = false;
            var newParty = new Booths();
            while (addParty == false)
            {
                chooseChanges = false;
                while (choosePartyDate == false)
                {
                    choosePartyDate = true;
                    Console.WriteLine("Please enter the date of the party (mm/dd/yyyy)");
                    try
                    {
                        newParty.DateOfParty = DateTime.Parse(Console.ReadLine());
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a valid date. (mm/dd/yyyy)\n" +
                                    "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        choosePartyDate = false;
                    }
                }
                while (howManyHotDogs == false)
                {
                    howManyHotDogs = true;
                    Console.WriteLine("How many hotdog tickets did you collect?");
                    try
                    {
                        newParty.HowManyHotDogs = int.Parse(Console.ReadLine());
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a valid number.\n" +
                                    "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        howManyHotDogs = false;
                    }
                }
                while (howManyHamburgers == false)
                {
                    howManyHamburgers = true;
                    Console.WriteLine("How many hamburger tickets did you collect?");
                    try
                    {
                        newParty.HowManyHamburgers = int.Parse(Console.ReadLine());
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a valid number.\n" +
                                    "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        howManyVeggieburgers = false;
                    }
                } 
                while (howManyVeggieburgers == false)
                {
                    howManyVeggieburgers = true;
                    Console.WriteLine("How many veggieburger tickets did you collect?");
                    try
                    {
                        newParty.HowManyVeggieburgers = int.Parse(Console.ReadLine());
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a valid number.\n" +
                                    "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        howManyVeggieburgers = false;
                    }
                }
                while (howManyPopCorn == false)
                {
                    howManyPopCorn = true;
                    Console.WriteLine("How many popcorn tickets did you collect?");
                    try
                    {
                        newParty.HowManyPopcorns = int.Parse(Console.ReadLine());
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a valid number.\n" +
                                    "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        howManyPopCorn = false;
                    }
                }
                while (howManyIcecream == false)
                {
                    howManyIcecream = true;
                    Console.WriteLine("How many icecream tickets did you collect?");
                    try
                    {
                        newParty.HowManyIcecream = int.Parse(Console.ReadLine());
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a valid number.\n" +
                                    "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        howManyIcecream = false;
                    }
                }
                while (chooseChanges == false)
                {
                    chooseChanges = true;

                    Console.WriteLine("Please review the information for the new customer\n");
                    newParty.PrintProps();
                    Console.WriteLine();
                    Console.WriteLine("Would you like to make any changes?(y/n)");
                    string changesAnswer = Console.ReadLine().ToLower();
                    switch (changesAnswer)
                    {
                        case "y":
                            makeChanges = true;
                            break;
                        case "n":
                            addParty = true;
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
                    Console.WriteLine($"What property would you like to change? Or select 7 to add the new party.\n");
                    newParty.PrintProps();
                    Console.WriteLine("7. Continue");
                    string propertyAnswer = Console.ReadLine().ToLower();
                    switch (propertyAnswer)
                    {
                        case "1":
                            choosePartyDate = false;
                            Console.Clear();
                            break;
                        case "2":
                            howManyHotDogs = false;
                            Console.Clear();
                            break;
                        case "3":
                            howManyHamburgers = false;
                            Console.Clear();
                            break;
                        case "4":
                            howManyVeggieburgers = false;
                            Console.Clear();
                            break;
                        case "5":
                            howManyPopCorn = false;
                            Console.Clear();
                            break;
                        case "6":
                            howManyIcecream = false;
                            Console.Clear();
                            break;
                        case "7":
                            addParty = true;
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
            if (addParty == true)
            {
                _parties.AddParty(newParty);
                Console.Clear();
                Console.WriteLine($"You have successfully added the party.");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        void ListParties()
        {
            Console.Clear();
            List<Booths> allParties = new List<Booths>();
            allParties = _parties.GetParties();
            allParties.Sort((left, right) => DateTime.Compare(left.DateOfParty, right.DateOfParty));
            Console.WriteLine("DateOfParty".PadRight(14) + "Total Cost".PadRight(14) + "Total Tickets".PadRight(16) + "Hotdogs".PadRight(12) + "Hamburgers".PadRight(14) + "VeggieBurgers".PadRight(16) + "Popcorn".PadRight(12) + "Icecream\n");
            foreach (var party in allParties)
            {
                Console.WriteLine($"{party.DateOfParty.ToShortDateString()}".PadRight(14) + $"${party.TotalCost}".PadRight(14) + $"{party.TotalTickets}".PadRight(16) + $"{party.HowManyHotDogs}".PadRight(12) + $"{party.HowManyHamburgers}".PadRight(14) + $"{party.HowManyVeggieburgers}".PadRight(16) + $"{party.HowManyPopcorns}".PadRight(12) + $"{party.HowManyIcecream}");
            }
            Console.WriteLine();
           
        }
        void PartyStats()
        {
            ListParties();
            Console.WriteLine();
            Console.WriteLine("Type the date of the party you would like to see more stats for (mm/dd/yyyy)");
            DateTime partyDate = new DateTime();
            try
            {
                partyDate = DateTime.Parse(Console.ReadLine());
                Console.Clear();
            }
            catch { }
            var party = new Booths();
            party = _parties.GetPartyByDate(partyDate);
            bool viewCalcs = true;
            while (viewCalcs == true && party != null)
            {
                viewCalcs = false;
                Console.WriteLine("What kind of stat would you like to see?");
                Console.WriteLine("1. Costs");
                Console.WriteLine("2. Tickets");
                Console.WriteLine("3. Main Menu ");
                string calcChoice = Console.ReadLine();
                Console.Clear();
                switch (calcChoice)
                {
                    case "1":
                        Console.WriteLine("Costs:");
                        Console.WriteLine($"Total:             ${party.TotalCost}\n");
                        Console.WriteLine($"Burger Booth:      ${party.BurgerBoothCost}");
                        Console.WriteLine($"Hotdogs:           ${party.HotDogCost}");
                        Console.WriteLine($"Hamburgers:        ${party.HamburgerCost}");
                        Console.WriteLine($"Veggieburger:      ${party.VeggieburgerCost}");
                        Console.WriteLine($"Misc Burger Costs: ${party.MiscBurgerCost}\n");
                        Console.WriteLine($"Treat Booth:       ${party.TreatBoothCost}");
                        Console.WriteLine($"Popcorn:           ${party.PopCornCost}");
                        Console.WriteLine($"Icecream:          ${party.IceCreamCost}");
                        Console.WriteLine($"Misc Treat Costs:  ${party.MiscTreatCost}\n");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        viewCalcs = true;
                        Console.Clear();

                        break;
                    case "2":
                        Console.WriteLine("Tickets:");
                        Console.WriteLine($"Total:        {party.TotalTickets}\n");
                        Console.WriteLine($"Burger Booth: {party.HowManyBurgerBoothTickets}");
                        Console.WriteLine($"Hotdogs:      {party.HowManyHotDogs}");
                        Console.WriteLine($"Hamburgers:   {party.HowManyHamburgers}");
                        Console.WriteLine($"Veggieburger: {party.HowManyVeggieburgers}\n");
                        Console.WriteLine($"Treat Booth:  {party.HowManyTreatBoothTickets}");
                        Console.WriteLine($"Popcorn:      {party.HowManyPopcorns}");
                        Console.WriteLine($"Icecream:     {party.HowManyIcecream}");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        viewCalcs = true;
                        Console.Clear();
                        break;
                    case "3":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid selection. \nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        viewCalcs = true;
                        break;
                }
            }
            if (party == null)
            {
                Console.Clear();
                Console.WriteLine("Cannot find that party");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        void SeedParties()
        {
            var party1 = new Booths(2, 10, 1, 5, 8, new DateTime(2020, 5, 8));
            var party2 = new Booths(9, 2, 3, 2, 4, new DateTime(2018, 10, 8));
            var party3 = new Booths(1, 5, 8, 2, 9, new DateTime(2019, 12, 13));
            var party4 = new Booths(2, 3, 2, 4, 2, new DateTime(2018, 12, 8));
            _parties.AddParty(party1);
            _parties.AddParty(party2);
            _parties.AddParty(party3);
            _parties.AddParty(party4);
        }
    }
}

