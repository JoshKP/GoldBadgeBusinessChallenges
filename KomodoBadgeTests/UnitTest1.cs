using System;
using System.Collections;
using System.Collections.Generic;
using KomodoBadge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoBadgeTests
{
    [TestClass]
    public class UnitTest1
    {
        private BadgeRepo _repo = new BadgeRepo();
        private IDictionary<int, List<string>> _dictionary = new Dictionary<int, List<string>>();


        public void Arrange()
        {
            _dictionary = _repo.ReturnDictionary();
            int ID = 111;
            string roomAccess = "A111, B111, C111";
            _repo.AddBadgeToDictionary(ID, roomAccess);
        }

        [TestMethod]
        public void AddBadgeToDictionaryTest()
        {
            Arrange();

            Assert.AreEqual(1, _dictionary.Count);
        }

        [TestMethod]
        public void AddBadgeAccessTest()
        {
            Arrange();

            string roomToAdd = "D111";
            _repo.AddBadgeAccess(_dictionary[111], roomToAdd);

            Assert.AreEqual(4, _dictionary[111].Count);
        }

        [TestMethod]
        public void RemoveBadgeAccessTest()
        {
            Arrange();

            _repo.RemoveBadgeAccess(111, "A111");

            Assert.AreEqual(2, _dictionary[111].Count);
        }

        [TestMethod]
        public void RemoveAllRoomsFromBadgeTest()
        {
            Arrange();

            _repo.RemoveAllRoomsFromBadge(111);

            Assert.AreEqual(0, _dictionary[111].Count);
        }

        [TestMethod]
        public void RemoveBadgeFromDictionaryTest()
        {
            Arrange();

            _repo.RemoveBadgeFromDictionary(111);
            bool badgeExists = _dictionary.ContainsKey(111);

            Assert.IsFalse(badgeExists);
        }
    }
}
