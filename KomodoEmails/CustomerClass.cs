using System;
using System.Collections.Generic;
using System.Text;

namespace KomodoEmails
{
    public enum CustomerStatus { Potential, Current, Past }
    public class Customer
    {
        public string FirstName;
        public string LastName;
        public string FullName
        {
            get
            {
                string fullName = $"{FirstName} {LastName}";
                return fullName;
            }
        }
        public CustomerStatus CustomerStatus;
        public virtual string SendEmail()
        {
            switch (CustomerStatus)
            {
                case CustomerStatus.Potential:
                    return "We currently have the lowest rates on Helicopter Insurance!";
                case CustomerStatus.Current:
                    return "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                case CustomerStatus.Past:
                    return "It's been a long time since we've heard from you, we want you back.";
                default:
                    return "Not sure what customer this is";
            }
        }
        public Customer(string firstName, string lastName, CustomerStatus customerStatus)
        {
            FirstName = firstName;
            LastName = lastName;
            CustomerStatus = customerStatus;
        }
        public Customer() { }
    }
}
