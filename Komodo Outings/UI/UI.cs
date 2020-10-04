using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Outings.UI
{
    public class ProgramUI
    {
        //private readonly ClaimsRepository _claims = new ClaimsRepository();
        public void Run()
        {
            //SeedOutings();
            MainMenu();
        }

        private void MainMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Komodo Outings. Please select a menu item:\n" +
                            "1) See all outings \n" +
                            "2) Add new outing\n" +
                            "3) Calculations \n" +
                            "4) Exit)");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //Display a list of all outings
                        //ListOfOutings();
                        break;
                    case "2":
                        //Add New Outing
                        //AddOuting();
                        break;
                    case "3":
                        //Calculations
                        //Calculations();
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
        void SeedOutings()
        {

        }
    }
}
