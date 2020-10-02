using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges.UI
{
    public class ProgramUI
    {
        public void Run()
        {
            SeedBadges();
            MainMenu();
        }

        private void MainMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Komodo Insurance Door Program. Please select a menu item:\n" +
                            "1) Create a badge  \n" +
                            "2) Edit a badge\n" +
                            "3) List all badges \n" +
                            "4) Exit)");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //Create Badge
                        CreateBadge();
                        break;
                    case "2":
                        //Edit Badge
                        UpdateBadge();
                        ; break;
                    case "3":
                        //List all Badges
                        //ListAllBadges();
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
                        break;
                }
            }
        }
        private void CreateBadge()
        {
            bool createNewBadge = false;
            bool chooseBadgeID = false;
            bool chooseDoors = false;
            bool chooseMoreDoors = false;
            int badgeID = 0;
            List<string> doorAccess = new List<string>();
            while (createNewBadge == false)
            {
                bool chooseChanges = false;
                Console.Clear();
                while (chooseBadgeID == false)
                {
                    //Badge ID
                    chooseBadgeID = true;
                    Console.WriteLine("What is the number on the badge?");

                    try
                    {
                        badgeID = int.Parse(Console.ReadLine());
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nPlease enter a valid number.\n" +
                                    "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        chooseBadgeID = false;
                    }
                    Console.Clear();
                }
                while (chooseDoors == false)
                {
                    doorAccess.Clear();
                    chooseDoors = true;
                    chooseMoreDoors = false;
                    while (chooseMoreDoors == false)
                    {
                        chooseMoreDoors = true;
                        Console.WriteLine("List a door that it needs access to");
                        string door = Console.ReadLine();
                        doorAccess.Add(door);
                        Console.WriteLine("\nAny other doors?(y/n)");
                        string response = Console.ReadLine();

                        switch (response)
                        {
                            case "y":
                                chooseMoreDoors = false;
                                break;
                            case "n":
                                break;
                            default:
                                Console.WriteLine("\nInvalid selection. \nPress any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                chooseMoreDoors = false;
                                break;
                        }
                        Console.WriteLine();
                    }
                   

                    
                    Console.Clear();
                }
                while (chooseChanges == false)
                {
                    chooseChanges = true;
                    bool makeChanges = false;
                    Console.WriteLine($"Please review the information for badge {badgeID}\n");
                    Console.WriteLine($"1) BadgeID : {badgeID}");
                    Console.WriteLine($"2) Door Access:");
                    foreach (var item in doorAccess)
                    {
                        int count = 1;
                        Console.WriteLine($"   {item}");
                        count++;
                    }
                    Console.WriteLine($"\nDo you want to make any changes before adding badge {badgeID} to the system?\n(y/n)");
                    string changesAnswer = Console.ReadLine().ToLower();
                    switch (changesAnswer)
                    {
  
                        case "y":
                            makeChanges = true;
                            break;
                        case "n":
                            createNewBadge = true;
                            break;
                        default:
                            Console.WriteLine("\nInvalid selection. \nPress any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            chooseChanges = false;
                            break;

                    }
                    Console.Clear();
                    while (makeChanges == true)
                    {
                        makeChanges = false;
                        Console.WriteLine($"What property would you like to change? Or select 3 to add badge {badgeID} to the system.\n");
                        Console.WriteLine($"1) BadgeID : {badgeID}");
                        Console.WriteLine($"2) Door Access:");
                        foreach (var item in doorAccess)
                        {
                            int count = 1;
                            Console.WriteLine($"   {item}");
                            count++;
                        }
                        Console.WriteLine("3. Continue");
                        string propertyAnswer = Console.ReadLine().ToLower();
                        switch (propertyAnswer)
                        {
                            case "1":
                                chooseBadgeID = false;
                                Console.Clear();
                                break;
                            case "badgeid":
                                chooseBadgeID = false;
                                Console.Clear();
                                break;
                            case "2":
                                chooseDoors = false;
                                Console.Clear();
                                break;
                            case "door access":
                                chooseDoors = false;
                                Console.Clear();
                                break;
                            case "3":
                                createNewBadge = true;
                                Console.Clear();
                                break;
                            case "continue":
                                createNewBadge = true;
                                Console.Clear();
                                break;
                            default:
                                Console.WriteLine("\nInvalid selection. \nPress any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                makeChanges = true;
                                break;
                        }
                    }
                }
                if (createNewBadge == true)
                {
                    var badge = new Badge(badgeID, doorAccess);
                    Console.Clear();
                    Console.WriteLine($"You have successfully added badge {badge.BadgeID} to the system.");
                    Console.WriteLine("Press any key to return to menu...");
                    Console.ReadKey();
                }
            }
        }
        private void UpdateBadge()
        {
            Console.Clear();
            int badgeUpdate = 0;
            bool inputBadge = false;
            bool updateBadge = false;
            bool searchForBadge = false;
            bool removeDoors = false;
            bool makeChanges = false;
            while (updateBadge == false)
            {
                while (inputBadge == false)
                {
                    searchForBadge = false;
                    inputBadge = true;
                    Console.WriteLine("What is the badge number to update?");
                    try
                    {
                        badgeUpdate = int.Parse(Console.ReadLine());
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a valid number.\n" +
                                    "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        inputBadge = false;
                    }
                    Console.Clear();
                }
                while (searchForBadge == false)
                {
                    searchForBadge = true;
                    int doesBadgeExist = BadgeRepository.GetBadgeByNumber(badgeUpdate);
                    if (doesBadgeExist == 0)
                    {
                        Console.WriteLine("Cannot find that badge.\n" +
                                   "Would you like to search for another badge?(y/n)");
                        string response = Console.ReadLine();
                        switch (response)
                        {
                            case "y":
                                inputBadge = false;
                                break;
                                case "n":
                                updateBadge = true;
                                break;
                            default:
                                Console.WriteLine("Please enter a valid number.\n" +
                                    "Press any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                inputBadge = false;
                                break;
                        }
                        Console.Clear();
                        
                    }
                    else
                    {
                        while (makeChanges == false)
                        {
                            searchForBadge = true;
                            Console.WriteLine($"Badge {badgeUpdate} has access to doors:");
                            foreach (var doors in BadgeRepository.BadgeCollection[badgeUpdate])
                            {
                                int count = 1;
                                Console.WriteLine($"   {doors}");
                                count++;
                            }
                            Console.WriteLine("\nWhat would you like to do?\n" +
                                "\n1. Remove a door\n" +
                                "2. Add a door\n" +
                                "3. Return to main menu");
                            string response = Console.ReadLine();
                            switch (response)
                            {
                                case "1":
                                    while (removeDoors == false)
                                    {
                                        removeDoors = true;
                                        int originalCount = BadgeRepository.BadgeCollection[badgeUpdate].Count();
                                        Console.Clear();
                                        foreach (var doors in BadgeRepository.BadgeCollection[badgeUpdate])
                                        {
                                            int count = 1;
                                            Console.WriteLine($"{doors}");
                                            count++;
                                        }
                                        Console.WriteLine("Which door would you like to remove?");
                                        string doorRemove = Console.ReadLine();
                                        try
                                        {
                                                BadgeRepository.BadgeCollection[badgeUpdate].Remove(doorRemove);
                                                Console.Clear();
                                           
                                        }
                                        catch { }
                                        if (BadgeRepository.BadgeCollection[badgeUpdate].Count() < originalCount)
                                        {
                                            Console.WriteLine($"Door {doorRemove} removed.");
                                            Console.WriteLine("Press any key to continue...");
                                            Console.ReadKey();
                                            Console.Clear();
                                        }
                                        if (BadgeRepository.BadgeCollection[badgeUpdate].Count() == originalCount)
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"Sorry, {badgeUpdate} does not have access to that door." +
                                            $"\nPress any key to continue...");
                                            Console.ReadKey();
                                            Console.Clear();
                                            removeDoors = false;
                                            break;
                                        }
                                    }
                                    break;
                                case "2":
                                    Console.Clear();
                                    foreach (var doors in BadgeRepository.BadgeCollection[badgeUpdate])
                                    {
                                        int count = 1;
                                        Console.WriteLine($"{doors}");
                                        count++;
                                    }
                                    Console.WriteLine("What door would you like to add?");
                                    string doorAdd = Console.ReadLine();
                                    BadgeRepository.BadgeCollection[badgeUpdate].Add(doorAdd);
                                    Console.Clear();
                                    Console.WriteLine($"Door {doorAdd} successfully added");
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case "3":
                                    makeChanges = true;
                                    updateBadge = true;
                                    Console.Clear();
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                default:
                                    Console.WriteLine("\nInvalid selection. \nPress any key to continue...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                            }
                        }
                        
                    }

                }
            }
        }
        void SeedBadges()
        {
            var newBadge = new Badge(25, new List<string>());
        }
    }
}
