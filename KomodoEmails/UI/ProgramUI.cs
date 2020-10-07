using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KomodoEmails.UI
{
    class ProgramUI
    {
        private readonly EmailMethodRepository _customers = new EmailMethodRepository();
        public void Run()
        {
            SeedCustomers();
            MainMenu();
        }

        private void MainMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Komodo Email System:\n" +
                            "1. Add New Customer \n" +
                            "2. Display All Customers\n" +
                            "3. Update Customer Information \n" +
                            "4. Delete Customer\n" +
                            "5. Exit");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        NewCustomer();
                        break;
                    case "2":
                        ListAllCustomers();
                        break;
                    case "3":
                        UpdateCustomer();
                        break;
                    case "4":
                        DeleteCustomer();
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
        void NewCustomer()
        {
            Console.Clear();
            bool addCustomer = false;
            bool chooseFirstName = false;
            bool chooseLastName = false;
            bool chooseType = false;
            bool chooseChanges = false;
            bool makeChanges = false;
            var newCustomer = new Customer();
            while (addCustomer == false)
            {
                chooseChanges = false;
                while (chooseFirstName == false)
                {
                    chooseFirstName = true;
                    Console.WriteLine("What is the customer's first name?");
                    newCustomer.FirstName = Console.ReadLine();
                    Console.Clear();
                }
                while (chooseLastName == false)
                {
                    chooseLastName = true;
                    Console.WriteLine("What is the customer's last name?");
                    newCustomer.LastName = Console.ReadLine();
                    Console.Clear();
                }
                while (chooseType == false)
                {
                    chooseType = true;
                    Console.WriteLine("What is the status of the customer?\n" +
                   "1. Current\n" +
                   "2. Past\n" +
                   "3. Potential");

                    string customerType = Console.ReadLine();
                    switch (customerType)
                    {
                        case "1":
                            newCustomer.CustomerStatus = CustomerStatus.Current;
                            break;
                        case "2":
                            newCustomer.CustomerStatus = CustomerStatus.Past;
                            break;
                        case "3":
                            newCustomer.CustomerStatus = CustomerStatus.Potential;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Please enter a valid number.\n" +
                                 "Press any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            chooseType = false;
                            break;
                    }
                    Console.Clear();
                }
                while (chooseChanges == false)
                {
                    chooseChanges = true;

                    Console.WriteLine("Please review the information for the new customer\n");
                    Console.WriteLine($"1. First Name: {newCustomer.FirstName}");
                    Console.WriteLine($"2. Last Name: {newCustomer.LastName}");
                    Console.WriteLine($"3. Status: {newCustomer.CustomerStatus}");
                    Console.WriteLine("\nDo you want to make any changes to this customer?(y/n)");
                    string changesAnswer = Console.ReadLine().ToLower();

                    switch (changesAnswer)
                    {
                        case "y":
                            makeChanges = true;
                            break;
                        case "n":
                            addCustomer = true;
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
                    Console.WriteLine($"What property would you like to change? Or select 4 to add the new customer.\n");
                    Console.WriteLine($"1. First Name: {newCustomer.FirstName}");
                    Console.WriteLine($"2. Last Name: {newCustomer.LastName}");
                    Console.WriteLine($"3. Status: {newCustomer.CustomerStatus}");
                    Console.WriteLine("4. Continue");
                    string propertyAnswer = Console.ReadLine().ToLower();
                    switch (propertyAnswer)
                    {
                        case "1":
                            chooseFirstName = false;
                            Console.Clear();
                            break;
                        case "2":
                            chooseLastName = false;
                            Console.Clear();
                            break;
                        case "3":
                            chooseType = false;
                            Console.Clear();
                            break;
                        case "4":
                            addCustomer = true;
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
            if (addCustomer == true)
            {
               _customers.AddCustomerToDirectory(newCustomer);
                Console.Clear();
                Console.WriteLine($"You have successfully added the customer.");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        void ListAllCustomers()
        {
            Console.Clear();
            List<Customer> allCustomers = new List<Customer>();
            allCustomers = _customers.GetCustomers();
            allCustomers.Sort((left, right) => string.Compare(left.FirstName, right.FirstName));
            Console.WriteLine("FirstName".PadRight(14)+"LastName".PadRight(14)+"Type".PadRight(12)+"Email\n");
            foreach (var customer in allCustomers)
            {
                string currentEmail = customer.SendEmail();
                Console.WriteLine($"{customer.FirstName}".PadRight(14) + $"{customer.LastName}".PadRight(14) + $"{customer.CustomerStatus}".PadRight(12) + $"{currentEmail}");
            }
            Console.ReadKey();
        }
        void UpdateCustomer()
        {
            Console.Clear();
            Console.WriteLine("Please enter the full name of the customer you would like to update");
            string nameToUpdate = Console.ReadLine();
            var customerToUpdate = new Customer();
            customerToUpdate = _customers.GetCustomerByName(nameToUpdate);
            Console.Clear();
            bool makeChanges = true;
            while (makeChanges == true && customerToUpdate != null)
            {
                makeChanges = false;
                Console.WriteLine($"What property would you like to change? Or select 4 to cancel.\n");
                Console.WriteLine($"1. First Name: {customerToUpdate.FirstName}");
                Console.WriteLine($"2. Last Name: {customerToUpdate.LastName}");
                Console.WriteLine($"3. Status: {customerToUpdate.CustomerStatus}");
                Console.WriteLine("4. Cancel");
                string propertyAnswer = Console.ReadLine().ToLower();
                Console.Clear();
                switch (propertyAnswer)
                {
                    case "1":
                        Console.WriteLine("Enter a new first name");
                        customerToUpdate.FirstName = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine($"Name is now {customerToUpdate.FullName}\n");
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        Console.WriteLine("Enter a new last name");
                        customerToUpdate.LastName = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine($"Name is now {customerToUpdate.FullName}\n");
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        bool chooseType = false;
                        while (chooseType == false)
                        {
                            chooseType = true;
                            Console.WriteLine("What is the status of the customer?\n" +
                           "1. Current\n" +
                           "2. Past\n" +
                           "3. Potential");
                            string customerType = Console.ReadLine();
                            switch (customerType)
                            {
                                case "1":
                                    customerToUpdate.CustomerStatus = CustomerStatus.Current;
                                    break;
                                case "2":
                                    customerToUpdate.CustomerStatus = CustomerStatus.Past;
                                    break;
                                case "3":
                                    customerToUpdate.CustomerStatus = CustomerStatus.Potential;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Please enter a valid number.\n" +
                                         "Press any key to continue...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    chooseType = false;
                                    break;
                            }
                            Console.Clear();
                            Console.WriteLine($"{customerToUpdate.FullName}'s status updated to {customerToUpdate.CustomerStatus} \n");
                            Console.WriteLine("Press any key to return to menu...");
                            Console.ReadKey();
                            Console.Clear();
                            Console.Clear();
                        }
                        break;
                    case "4":
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
            if (customerToUpdate == null)
            {
                Console.WriteLine("Could not find that customer");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        void DeleteCustomer()
        {
            Console.Clear();
            Console.WriteLine("Enter the full name of the customer to delete.");
            string nameToDelete = Console.ReadLine();
            Customer deleteThis = _customers.GetCustomerByName(nameToDelete);
            if (deleteThis != null)
            {
                _customers.DeleteExistingCustomer(deleteThis);
                Console.Clear();
                Console.WriteLine($"Success! {nameToDelete} has been deleted.\n");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                Console.Clear();
                Console.Clear(); ;
            }
            else
            {
                Console.WriteLine("Could not find that customer");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                Console.Clear();
            }
           
        }

        void SeedCustomers()
        {
            var cust1 = new Customer("Isaiah", "Standridge", CustomerStatus.Current);
            var cust2 = new Customer("Seline", "Bolton", CustomerStatus.Past);
            var cust3 = new Customer("Adam", "Standridge", CustomerStatus.Potential);
            _customers.AddCustomerToDirectory(cust1);
            _customers.AddCustomerToDirectory(cust2);
            _customers.AddCustomerToDirectory(cust3);
        }
    }
}
