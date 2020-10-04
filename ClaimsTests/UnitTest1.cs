using System;
using KomodoClaimsDepartment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KomodoClaimsDepartment.UI;

namespace ClaimsTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            private readonly ClaimsRepository _claims = new ClaimsRepository();
            Claims claim1 = new Claims("5", ClaimType.Car, "Car Crash", 500, new DateTime(2020, 9, 15), new DateTime(02020, 09, 25));
            Claims claim2 = new Claims("7", ClaimType.Home, "Someone Broke in and stole TV and killed my dog", 5000, new DateTime(2020, 02, 15), new DateTime(2020, 09, 25));
            Claims claim3 = new Claims("9", ClaimType.Theft, "Mugged", 20, new DateTime(2020, 3, 15), new DateTime(2020, 04, 15));
            Claims claim4 = new Claims("3", ClaimType.Car, "Fender Bender", 1000, new DateTime(2020, 8, 15), new DateTime(2020, 09, 25));
            _claims.AddClaimToQueue(claim1);
            _claims.AddClaimToQueue(claim2);
            _claims.AddClaimToQueue(claim3);
            _claims.AddClaimToQueue(claim4);
        }
    }
}
