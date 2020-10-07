using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SmartInsurance
{
    class Program
    {
        static void Main(string[] args)
        {
            
            bool doQuote = false;
            var driver = new Driver();
            while (doQuote == false)
            {
                driver.Score = 0;
                doQuote = true;
                decimal starterPremium = 0;
                decimal finalPremium = 0;
                bool chooseSpeeding = false;
                bool chooseSwerving = false;
                bool chooseRollingStop = false;
                bool chooseFollowClosey = false;
                while (chooseSpeeding == false)
                {
                    chooseSpeeding = true;
                    Console.WriteLine("How many times a week do you speed?");
                    try
                    {
                        driver.HowOftenSpeedLimit = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a valid number.\n" +
                                    "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        chooseSpeeding = false;
                    }
                    Console.Clear();
                    if (driver.HowOftenSpeedLimit <= 0) driver.Score += 10;
                    else if (driver.HowOftenSpeedLimit <= 2) driver.Score += 8;
                    else if (driver.HowOftenSpeedLimit <= 4) driver.Score += 6;
                    else if (driver.HowOftenSpeedLimit <= 6) driver.Score += 4;
                    else if (driver.HowOftenSpeedLimit <= 8) driver.Score += 2;
                    Console.Clear();
                }
                while (chooseSwerving == false)
                {
                    chooseSwerving = true;
                    Console.WriteLine("How many times a week do you swerve out of your lane?");
                    try
                    {
                        driver.HowOftenSwerve = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a valid number.\n" +
                                    "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        chooseSwerving = false;
                    }
                    Console.Clear();
                    if (driver.HowOftenSwerve <= 0) driver.Score += 10;
                    else if (driver.HowOftenSwerve == 1) driver.Score += 8;
                    else if (driver.HowOftenSwerve == 2) driver.Score += 6;
                    else if (driver.HowOftenSwerve == 3) driver.Score += 4;
                    else if (driver.HowOftenSwerve == 4) driver.Score += 2;
                    Console.Clear();
                }
                while (chooseRollingStop == false)
                {
                    chooseRollingStop = true;
                    Console.WriteLine("How many times a week do you have a rolling stop?");
                    try
                    {
                        driver.HowOftenRollingStop = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a valid number.\n" +
                                    "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        chooseRollingStop = false;
                    }
                    Console.Clear();
                    if (driver.HowOftenRollingStop <= 0) driver.Score += 10;
                    else if (driver.HowOftenRollingStop == 1) driver.Score += 8;
                    else if (driver.HowOftenRollingStop == 2) driver.Score += 6;
                    else if (driver.HowOftenRollingStop == 3) driver.Score += 4;
                    else if (driver.HowOftenRollingStop == 4) driver.Score += 2;
                    Console.Clear();
                }
                while (chooseFollowClosey == false)
                {
                    chooseFollowClosey = true;
                    Console.WriteLine("How many times a week do you follow too closely?");
                    try
                    {
                        driver.HowOftenFollowClosely = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a valid number.\n" +
                                    "Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        chooseFollowClosey = false;
                    }
                    Console.Clear();
                    if (driver.HowOftenFollowClosely <= 0) driver.Score += 10;
                    else if (driver.HowOftenFollowClosely == 1) driver.Score += 8;
                    else if (driver.HowOftenFollowClosely == 2) driver.Score += 6;
                    else if (driver.HowOftenFollowClosely == 3) driver.Score += 4;
                    else if (driver.HowOftenFollowClosely == 4) driver.Score += 2;
                    Console.Clear();
                }
                starterPremium = 450;
                finalPremium = starterPremium / driver.ScoreAsPercentage;
                Console.WriteLine($"You qualify for a 6 month premium of ${Math.Round(finalPremium)}");
                Console.WriteLine();
                Console.WriteLine("Would you like another quote?(y/n)");
                string anotherQuote = Console.ReadLine();
                switch (anotherQuote)
                {
                    case "y":
                        Console.Clear();
                        doQuote = false;
                        break;
                    default:
                        doQuote = true;
                        break;
                }

            }

        }
    }
}
