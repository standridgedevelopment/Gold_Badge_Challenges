using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Builders;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsDepartment.UI
{
    public class ProgramUI
    {
        private readonly ClaimsRepository _claims = new ClaimsRepository();
        public void Run()
        {
            SeedClaims();
            MainMenu();
        }

        private void MainMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Komodo Claims Department. Please select a menu item:\n" +
                            "1. Enter New Claim \n" +
                            "2. Handle Next Claim\n" +
                            "3. Show All Claims \n" +
                            "4. Exit");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //Add New Menu Item
                        EnterNewClaim();
                        break;
                    case "2":
                        //Take care of next claim
                        NextClaim();
;                        break;
                    case "3":
                        //Show All Items
                        ShowAllClaims();
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
        //Enter New Claim
        private void EnterNewClaim()
        {
            Console.Clear();
            bool enterNewClaim = false;
            bool chooseClaimId = false;
            bool chooseTypeOfClaim = false;
            bool chooseDescription = false;
            bool chooseAmount = false;
            bool chooseDateOfAccident = false;
            bool chooseDateOfClaim = false;
            bool chooseChanges = false;
            Claims claim = new Claims();
            while (enterNewClaim == false)
            {
                chooseChanges = false;
                while (chooseClaimId == false)
                {
                    //Claim ID
                    chooseClaimId = true;
                    Console.WriteLine("Please enter a ClaimID for the new claim");
                    claim.ClaimID = Console.ReadLine();
                    try
                    {
                        int.Parse(claim.ClaimID);
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a valid number.\n" +
                                    "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        chooseClaimId = false;
                    }
                }
                while (chooseTypeOfClaim == false)
                {
                    //Claim ID
                    chooseTypeOfClaim = true;
                    Console.WriteLine("What Type of claim is this?\n"+
                        "1) Car\n" +
                        "2) Home\n" +
                        "3) Theft");
                    string claimTypeChoice = Console.ReadLine();
                    switch (claimTypeChoice)
                    {
                        case "1":
                            claim.Type = ClaimType.Car;
                            break;
                        case "2":
                            claim.Type = ClaimType.Home;
                            break;
                        case "3":
                            claim.Type = ClaimType.Theft;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Please enter a valid number.\n" +
                                 "Press any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            chooseTypeOfClaim = false;
                            break;
                    }
                    Console.Clear();
                }
                while (chooseDescription == false)
                {
                    chooseDescription = true;
                    Console.WriteLine("Please enter a description for the claim.");
                    claim.Description = Console.ReadLine();
                    Console.Clear();
                }
                while (chooseAmount == false)
                {
                    chooseAmount = true;
                    Console.WriteLine("How much is the claim?");
                    try
                    {
                        claim.ClaimAmount = int.Parse(Console.ReadLine());
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a valid number.\n" +
                                    "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        chooseAmount = false;
                    }
                }
                while (chooseDateOfAccident == false)
                {
                    chooseDateOfAccident = true;
                    Console.WriteLine("Please enter the date of the incident (mm/dd/yyyy)");
                    try
                    {
                        claim.DateOfIncident = DateTime.Parse(Console.ReadLine());
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a valid date. (mm/dd/yyyy)\n" +
                                    "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        chooseDateOfAccident = false;
                    }
                }
                while (chooseDateOfClaim == false)
                {
                    chooseDateOfClaim = true;
                    Console.WriteLine("Please enter the date of the claim (mm/dd/yyyy)");
                    try
                    {
                        claim.DateOfClaim = DateTime.Parse(Console.ReadLine());
                        Console.Clear();
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a valid date. (mm/dd/yyyy)\n" +
                                    "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        chooseDateOfClaim = false;
                    }
                }
                //Make changes?
                while (chooseChanges == false)
                {
                    chooseChanges = true;
                    //bool chooseYesorNo = false;
                    bool makeChanges = false;
                    Console.WriteLine($"Please review the information for the new claim\n");
                    claim.printProps();
                    Console.WriteLine($"\nDo you want to make any changes before adding the claim to the queue?\n1)Yes \n2)No");
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

                            enterNewClaim = true;
                            break;
                        case "no":

                            enterNewClaim = true;
                            break;
                        case "n":

                            enterNewClaim = true;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid selection. \nPress any key to continue...");
                            Console.Clear();
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
                        Console.WriteLine($"What property would you like to change? Or select 7 to add the claim to the menu.\n");
                        claim.printProps();
                        Console.WriteLine("7. Continue");
                        string propertyAnswer = Console.ReadLine().ToLower();
                        switch (propertyAnswer)
                        {
                            case "1":
                                chooseClaimId = false;
                                Console.Clear();
                                break;
                            case "claimid":
                                chooseClaimId = false;
                                Console.Clear();
                                break;
                            case "2":
                                chooseClaimId = false;
                                Console.Clear();
                                break;
                            case "claimtype":
                                chooseTypeOfClaim = false;
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
                                chooseAmount = false;
                                Console.Clear();
                                break;
                            case "amount":
                                chooseAmount = false;
                                Console.Clear();
                                break;
                            case "5":
                                chooseDateOfAccident = false;
                                Console.Clear();
                                break;
                            case "date of incident":
                                chooseDateOfAccident = false;
                                Console.Clear();
                                break;
                            case "6":
                                chooseDateOfClaim = false;
                                Console.Clear();
                                break;
                            case "date of claim":
                                chooseDateOfClaim = false;
                                Console.Clear();
                                break;
                            case "7":
                                enterNewClaim = true;
                                Console.Clear();
                                break;
                            case "continue":
                                enterNewClaim = true;
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
                if (enterNewClaim == true)
                {
                    _claims.AddClaimToQueue(claim);
                    Console.Clear();
                    Console.WriteLine($"You have successfully added the claim queue.");
                    Console.WriteLine("Press any key to return to menu...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        private void NextClaim()
        {
            Console.Clear();
            Console.WriteLine("This is your next claim\n");
            _claims.PeekClaim();
            Console.WriteLine();
            Console.Write("Do you want to deal with this claim now(y/n)?");
            string dealWithClaim = Console.ReadLine();
            switch (dealWithClaim)
            {
                case "y":
                    Queue<Claims> currentClaims = _claims.GetClaims();
                    Console.WriteLine($"\nClaim # {currentClaims.Peek().ClaimID} has been removed from the queue");
                    _claims.DequeueClaim();
                    Console.WriteLine("Press any key to return to menu...");
                    Console.ReadKey();
                    break;
                default:
                    break;
            }
        }
        private void ShowAllClaims()
        {
            Console.Clear();
            Queue<Claims> allClaims = new Queue<Claims>();
            allClaims = _claims.GetClaims();
            //ClaimID = 4 spaces

            //Find Description Length
            int descriptionLength = 0;
            int finalLength = 0;
            foreach (var claim in allClaims)
            {
                string description = claim.Description;
                descriptionLength = description.Length;
                if (descriptionLength >= finalLength)
                {
                    finalLength = descriptionLength;
                }
            }
            Console.WriteLine("ClaimID".PadRight(9) + "Type".PadRight(9) + "Description".PadRight(finalLength+5) + "Amount".PadRight(10) + "DateOfAccident".PadRight(18) + "DateOfClaim".PadRight(15) + "IsValid");
            //Create Table
            foreach (var claim in allClaims)
            {
                string sType = Convert.ToString(claim.Type);
                string sAmount = Convert.ToString(claim.ClaimAmount);
                string sAccident = claim.DateOfIncident.ToShortDateString();
                string sClaim = claim.DateOfClaim.Date.ToShortDateString();

                Console.WriteLine($"{claim.ClaimID.PadRight(9)}{sType.PadRight(9)}{claim.Description.PadRight(finalLength+5)}{sAmount.PadRight(10)}{sAccident.PadRight(18)}{sClaim.PadRight(15)}{claim.IsValid}");

            }
            Console.WriteLine();
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }
        private void SeedClaims()
        {
            var claim1 = new Claims("5", ClaimType.Car, "Car Crash", 500, new DateTime(2020, 9, 15), new DateTime(02020, 09, 25));
            var claim2 = new Claims("7", ClaimType.Home, "Someone Broke in and stole TV and killed my dog", 5000, new DateTime(2020, 02, 15), new DateTime(2020, 09, 25));
            var claim3 = new Claims("9", ClaimType.Theft, "Mugged", 20, new DateTime(2020, 3, 15), new DateTime(2020, 04, 15));
            var claim4 = new Claims("3", ClaimType.Car, "Fender Bender", 1000, new DateTime(2020, 8, 15), new DateTime(2020, 09, 25));
            _claims.AddClaimToQueue(claim1);
            _claims.AddClaimToQueue(claim2);
            _claims.AddClaimToQueue(claim3);
            _claims.AddClaimToQueue(claim4);
        }

    }
}
