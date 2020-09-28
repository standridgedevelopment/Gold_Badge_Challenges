using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Cafe.UI
{
    public class ProgramUI
    {
        private readonly MenuRepository _fullMenu = new MenuRepository();
        public void Run()
        {
            SeedMenu();
            MainMenu();
        }

        private void MainMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Komodo Cafe. Please select a menu item:\n" +
                            "1) Add new menu item \n" +
                            "2) Remove menu item\n" +
                            "3) Show full menu \n" +
                            "4) Exit)");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //Add New Menu Item
                        CreateNewItem();
                        break;
                    case "2":
                        //Remove Menu Item
                        RemoveItemFromList();
                        break;
                    case "3":
                        //Show All Items
                        ShowAllItems();
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
        //CreateNewEntree
        private void CreateNewItem()
        {
            bool createNewItem = false;
            bool chooseItemName = false;
            bool chooseMealNumber = false;
            bool chooseDescription = false;
            bool chooseIngredients = false;
            bool choosePrice = false;
            
            MenuItem item = new MenuItem();
            while (createNewItem == false)
            {
                bool chooseChanges = false;
                //chooseChanges = false;
                while (chooseItemName == false)
                {
                    Console.Clear();
                    //Item Name
                    chooseItemName = true;
                    Console.WriteLine("Please enter the name of the new menu item.");
                    item.ItemName = Console.ReadLine();
                    Console.Clear();
                   
                }
                while (chooseMealNumber == false)
                {
                    chooseMealNumber = true;
                    //Meal Item Number
                    Console.WriteLine($"Please enter the meal number for {item.ItemName}.");
                    try
                    {
                        item.MealNumber = int.Parse(Console.ReadLine());
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a valid number.\n" +
                                    "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        chooseMealNumber = false;
                    }
                }
                while (chooseDescription == false)
                {
                    //Description
                    chooseDescription = true;
                    Console.WriteLine($"Please enter a description for {item.ItemName}.");
                    item.Description = Console.ReadLine();
                    Console.Clear();
                }
                
            //Ingredients
                while (chooseIngredients == false)
                {
                    chooseIngredients = true;
                    Console.WriteLine("How many ingredients are in this item?");
                    int ingredientNumber = 0;
                    try
                    {
                        ingredientNumber = int.Parse(Console.ReadLine());
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please enter a valid number.\n" +
                                    "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        chooseIngredients = false;
                    }
                    for (int i = 0; i < ingredientNumber; i++)
                    {
                        Console.WriteLine($"Please enter ingredient {i + 1}");
                        item.Ingredients.Add(Console.ReadLine());
                        Console.WriteLine();
                    }
                    Console.Clear();
                }
                while (choosePrice == false)
                {
                    //Price
                    choosePrice = true;
                    Console.WriteLine($"Please enter the price for {item.ItemName}.");
                    try
                    {
                        item.Price = int.Parse(Console.ReadLine());
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a valid number.\n" +
                                    "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        choosePrice = false;
                    }
                }
                //Make changes?
                while (chooseChanges == false)
                {
                    chooseChanges = true;
                    //bool chooseYesorNo = false;
                    bool makeChanges = false;
                    Console.WriteLine($"Please review the information for {item.ItemName}\n");
                    item.PrintProperties();
                    Console.WriteLine($"\nDo you want to make any changes before adding {item.ItemName} to the menu?\n1)Yes \n2)No");
                    string changesAnswer = Console.ReadLine().ToLower();
                    
                    
                        switch (changesAnswer)
                        {
                            case "1":
                                
                                makeChanges = true;
                                break;
                            case "yes":
                                
                                makeChanges = true;
                                break;
                            case "y":
                                
                                makeChanges = true;
                                break;
                            case "2":
                                
                                createNewItem = true;
                                break;
                            case "no":
                                
                                createNewItem = true;
                                break;
                            case "n":
                                
                                createNewItem = true;
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("Invalid selection. \nPress any key to continue...");
                                Console.ReadKey();
                               
                                chooseChanges = false;
                                break;
                       
                    }
                    Console.Clear();
                    while (makeChanges == true)
                    {
                        //1. Name
                        //2. Meal Number
                        //3. Description
                        //4. Ingredients
                        //5. Price
                        //6. Continue
                        makeChanges = false;
                        Console.WriteLine($"What property would you like to change? Or select 6 to add {item.ItemName} to the menu.");
                        item.PrintProperties();
                        Console.WriteLine("6. Continue");
                        string propertyAnswer = Console.ReadLine().ToLower();
                        switch (propertyAnswer)
                        {
                            case "1":
                                chooseItemName = false;
                                Console.Clear();
                                break;
                            case "name":
                                chooseItemName = false;
                                Console.Clear();
                                break;
                            case "2":
                                chooseMealNumber = false;
                                Console.Clear();
                                break;
                            case "meal number":
                                chooseMealNumber = false;
                                Console.Clear();
                                break;
                            case "3":
                                chooseDescription = false;
                                Console.Clear();
                                break;
                            case "description":
                                chooseDescription = false;
                                Console.Clear();
                                break;
                            case "4":
                                chooseIngredients = false;
                                Console.Clear();
                                break;
                            case "ingredients":
                                chooseIngredients = false;
                                Console.Clear();
                                break;
                            case "5":
                                choosePrice = false;
                                Console.Clear();
                                break;
                            case "price":
                                choosePrice = false;
                                Console.Clear();
                                break;
                            case "6":
                                createNewItem = true;
                                Console.Clear();
                                break;
                            case "continue":
                                createNewItem = true;
                                Console.Clear();
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("Invalid selection. \nPress any key to continue...");
                                Console.ReadKey();
                                makeChanges = true;
                                break;
                        }
                    }
                }
                if (createNewItem == true)
                {
                    _fullMenu.AddMenuItem(item);
                    Console.Clear();
                    Console.WriteLine($"You have successfully added {item.ItemName} to the menu.");
                    Console.WriteLine("Press any key to return to menu...");
                    Console.ReadKey();
                }
               
            }
           
        }
        //Remove Menu Item
        public void RemoveItemFromList()
        {
        removeItem:
            int targetMenuItem;
            Console.Clear();
            Console.WriteLine("What entree would you like to remove?");
            List<MenuItem> menuList = _fullMenu.GetMenu();
            int count = 0;
            //Display List
            foreach (var item in menuList)
            {
                count++;
                Console.WriteLine($"{count}) {item.ItemName}");
               
            }
            Console.WriteLine($"{count + 1}) Return to main menu.");
            //Get User Input
            try
            {
                targetMenuItem = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Please enter a number.\n" +
                            "Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                goto removeItem;
            }
            int correctIndex = targetMenuItem - 1;
            //Very proud of the way I found to return to menu here.
            if (targetMenuItem == count + 1)
            {
                return;

            }
            else if (correctIndex >= 0 && correctIndex < menuList.Count)
            {
                MenuItem desiredMenuItem = menuList[correctIndex];
                if (_fullMenu.DeleteMenuItem(desiredMenuItem))
                {
                    Console.Clear();
                    Console.WriteLine($"{desiredMenuItem.ItemName} successfully removed!");
                }
                else
                {
                    Console.WriteLine("Something went terribly wrong.");
                }
            }
            
            else
            {
                bool continueToRun = true;
                while (continueToRun)
                {
                    Console.Clear();
                    Console.WriteLine("Please select a valid option. \nDo you want to try another selection?\n1)Yes \n2)No");
                    string tryAgain = Console.ReadLine().ToLower();
                    switch (tryAgain)
                    {
                        case "1":
                            goto removeItem;
                        case "yes":
                            goto removeItem;
                        case "y":
                            goto removeItem;
                        case "2":
                            break;
                        case "no":
                            break;
                        case "n":
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid selection. \nPress any key to continue...");
                            Console.ReadKey();
                            break;
                    }
                }
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                
            }
        }
        //Show Full Menu
        public void ShowAllItems()
        {
            List<MenuItem> menuList = _fullMenu.GetMenu();
            int count = 0;
            foreach (var item in menuList)
            {
                count++;
                Console.WriteLine($"{item.ItemName}");
            }
            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }
            public void SeedMenu()
            {
                MenuItem chickenPlatter = new MenuItem("Chicken Tender Platter", "10 oz of chicken tenders", 16, 1);
                MenuItem sirloin = new MenuItem("Sirloin", "8oz Sirloin", 25, 2);

                _fullMenu.AddMenuItem(chickenPlatter);
                _fullMenu.AddMenuItem(sirloin);
            }
        }

    }
