using System;
using KomodoClaimsDepartment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KomodoClaimsDepartment.UI;
using System.Collections.Generic;

namespace ClaimsTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddToQueue()
        {
            ClaimsRepository _claims = new ClaimsRepository();
            Claims claim1 = new Claims("5", ClaimType.Car, "Car Crash", 500, new DateTime(2020, 9, 15), new DateTime(02020, 09, 25));
  
            bool testResult = _claims.AddClaimToQueue(claim1);
            //Should return True
            Console.WriteLine(testResult);
        }
        [TestMethod]
        public void TestGetClaims()
        {
            ClaimsRepository _claims = new ClaimsRepository();
            Claims claim1 = new Claims("5", ClaimType.Car, "Car Crash", 500, new DateTime(2020, 9, 15), new DateTime(02020, 09, 25));

            bool testResult = _claims.AddClaimToQueue(claim1);
            var newList = new Queue<Claims>();
            newList = _claims.GetClaims();
            //Should Be 1;
            Console.WriteLine(newList.Count);
        }
        [TestMethod]
        public void TestPeekClaim()
        {
            ClaimsRepository _claims = new ClaimsRepository();
            Claims claim1 = new Claims("5", ClaimType.Car, "Car Crash", 500, new DateTime(2020, 9, 15), new DateTime(02020, 09, 25));

            bool testResult = _claims.AddClaimToQueue(claim1);
            _claims.PeekClaim();
            //should display results
        }
        [TestMethod]
        public void TestDequeue()
        {
            ClaimsRepository _claims = new ClaimsRepository();
            Claims claim1 = new Claims("5", ClaimType.Car, "Car Crash", 500, new DateTime(2020, 9, 15), new DateTime(02020, 09, 25));

            _claims.AddClaimToQueue(claim1);
            bool testRestult =  _claims.DequeueClaim();
            //Should return true
            Console.WriteLine(testRestult);
           
        }
    }
}
