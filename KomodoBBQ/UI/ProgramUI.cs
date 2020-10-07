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

        }

        void ListParties()
        {

        }
        void PartyStats()
        {

        }
        void SeedParties()
        {

        }
    }
}

