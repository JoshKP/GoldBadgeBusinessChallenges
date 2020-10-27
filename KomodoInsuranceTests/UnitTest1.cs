using System;
using System.Collections;
using System.Collections.Generic;
using KomodoInsurance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static KomodoInsurance.Claim;

namespace KomodoInsuranceTests
{
    [TestClass]
    public class UnitTest1
    {
        private ClaimsRepo _repo = new ClaimsRepo();
        public Queue<Claim> _claimQueue = new Queue<Claim>();
        private Claim _claim = new Claim();
        private Claim _claimTwo = new Claim();

        public void Arrange()
        {
            _claimQueue = _repo.GetDirectory();
            _claim = new Claim("01", ClaimType.Car, "Casey was texting while driving", 5500, "2020/08/01", "2020/08/02");
            _repo.AddClaim(_claim);
        }

        [TestMethod]
        public void ClaimInitializationTest()
        {
            _claim = new Claim("01", ClaimType.Home, "Flood damage", 10200, "2020/09/01", "2020/09/05");

            Assert.IsTrue(_claim.IsValid);
            Assert.AreEqual(10200, _claim.Amount);
        }

        [TestMethod]
        public void AddClaimToDirectoryTest()
        {
            _claimQueue = _repo.GetDirectory();
            _claimTwo = new Claim("02", ClaimType.Theft, "Car was stolen", 35000, "2020/06/01", "2020/09/05");
            _repo.AddClaim(_claimTwo);

            Assert.AreEqual(1, _claimQueue.Count);
            Assert.IsTrue(_claimQueue.Contains(_claimTwo));
        }

        [TestMethod]
        public void GetDirectoryTest()
        {
            Arrange();

            Assert.AreEqual(1, _claimQueue.Count);
        }

        [TestMethod]
        public void GetClaimByIDTest()
        {
            Arrange();
            
            _repo.GetClaimByID("01");

            Assert.IsTrue(5500 == _claim.Amount);
        }

        [TestMethod]
        public void UpdateExistingClaimTest()
        {
            Arrange();
            _claimTwo = new Claim("02", ClaimType.Car, "Josh crashed his car", 475, "2019/01/01", "2019/01/28");
            _repo.UpdateClaim(_claimTwo, "01");

            Assert.IsTrue(_claim.Amount == 475);
        }
     

        
    }
}
