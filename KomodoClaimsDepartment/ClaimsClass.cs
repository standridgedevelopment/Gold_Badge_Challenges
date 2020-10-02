using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsDepartment
{
    public enum ClaimType
    {
        Car, Home, Theft
    }
    public class Claims
    {
        public string ClaimID;
        public ClaimType Type;
        public string Description;
        public int ClaimAmount;
        public DateTime DateOfIncident;
        public DateTime DateOfClaim;
        public bool IsValid
        {
            get
            {
                TimeSpan timePassed = DateOfClaim - DateOfIncident;

                bool isValid;
                
                {
                    if (timePassed.Days <= 30){return isValid = true;}
                    else{return isValid = false;}
                }
            }
        }
        public void printProps()
        {
            Console.WriteLine($"1. ClaimID: {ClaimID}");
            Console.WriteLine($"2. Claim Type : {Type}");
            Console.WriteLine($"3. Description: {Description}");
            Console.WriteLine($"4. Claim Amount: {ClaimAmount}");
            Console.WriteLine($"5. Date of Incident: {DateOfIncident.ToShortDateString()}");
            Console.WriteLine($"6. Date of Claim: {DateOfClaim.ToShortDateString()}");
            if (IsValid == true)
            {
                Console.WriteLine("This claim is valid");
            }
            else Console.WriteLine("This claim is invalid");

        }
        public Claims() { }
        public Claims(string claimID, ClaimType claimType, string description, int claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            Type = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;

        }
    }
}
