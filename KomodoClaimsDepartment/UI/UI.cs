using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Builders;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KomodoClaimsDepartment.TableBuilder;

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
                            "1) Enter new claim \n" +
                            "2) Handle next claim\n" +
                            "3) Show all claims \n" +
                            "4) Exit)");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //Add New Menu Item
                        EnterNewClaim();
                        break;
                    case "2":
                        //Remove Menu Item
                        //RemoveItemFromList();
                        break;
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
            bool chooseDescription = false;
            bool chooseAmount = false;
            bool chooseDateOfAccident = false;
            bool chooseDateOfClaim = false;
            bool chooseChanges = false;
            Claims claim = new Claims();
            while (enterNewClaim == false)
            {
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
                while (chooseDescription == false)
                {
                    chooseDescription = true;
                    Console.WriteLine("Please enter a description for the claim.");
                    claim.Description = Console.ReadLine();
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
            Console.ReadLine();
        }
        private void SeedClaims()
        {
            var claim1 = new Claims("5", ClaimType.Car, "Car Crash", 500, new DateTime(2020, 9, 15), new DateTime(02020, 09, 25));
            var claim2 = new Claims("7", ClaimType.Home, "Someone Broke in and stole TV", 5000, new DateTime(2020, 02, 15), new DateTime(2020, 09, 25));
            var claim3 = new Claims("9", ClaimType.Theft, "Mugged", 20, new DateTime(2020, 3, 15), new DateTime(2020, 04, 15));
            var claim4 = new Claims("3", ClaimType.Car, "Fender Bender", 1000, new DateTime(2020, 8, 15), new DateTime(2020, 09, 25));
            _claims.AddClaimToQueue(claim1);
            _claims.AddClaimToQueue(claim2);
            _claims.AddClaimToQueue(claim3);
            _claims.AddClaimToQueue(claim4);
        }

    }
}
