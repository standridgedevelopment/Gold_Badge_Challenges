using System;
using System.Collections.Generic;
using System.Text;

namespace KomodoEmails
{
    class EmailMethodRepository
    {
        protected readonly List<Customer> _customerDirectory = new List<Customer>();
        //CRUD Create Read Update Delete

        public bool AddCustomerToDirectory(Customer customer)
        {
            int _startingCount = _customerDirectory.Count;
            _customerDirectory.Add(customer);
            bool wasAdded = (_customerDirectory.Count > _startingCount) ? true : false;
            return wasAdded;
        }

        public List<Customer> GetCustomers()
        {
            return _customerDirectory;
        }

        public List<Customer> GetPastCustomers()
        {
            foreach (var customer in _customerDirectory)
            {
                if (customer.CustomerStatus == CustomerStatus.Past)
                {
                    _customerDirectory.Add(customer);
                }
            }
            return _customerDirectory;
        }
        public List<Customer> GetCurrentCustomers()
        {
            foreach (var customer in _customerDirectory)
            {
                if (customer.CustomerStatus == CustomerStatus.Current)
                {
                    _customerDirectory.Add(customer);
                }
            }
            return _customerDirectory;
        }

        public List<Customer> GetPotentialCustomers()
        {
            foreach (var customer in _customerDirectory)
            {
                if (customer.CustomerStatus == CustomerStatus.Potential)
                {
                    _customerDirectory.Add(customer);
                }
            }
            return _customerDirectory;
        }

        public Customer GetCustomerByName(string fullName)
        {
            foreach (Customer customerByName in _customerDirectory)
            {
                if (customerByName.FullName.ToLower() == fullName.ToLower())
                {
                    return customerByName;
                }

            }
            return null;
        }
        public bool UpdateCustomerInformation(string Name, Customer newInfo)
        {
            Customer oldInfo = GetCustomerByName(Name);

            if (Name != null)
            {
                oldInfo.FirstName = newInfo.FirstName;
                oldInfo.LastName = newInfo.LastName;
                oldInfo.CustomerStatus = newInfo.CustomerStatus;

                return true;
            }
            else return false;
        }

        public bool DeleteExistingCustomer(Customer existingCustomer)
        {
            bool deleteResult = _customerDirectory.Remove(existingCustomer);
            return deleteResult;
        }
    }
}
