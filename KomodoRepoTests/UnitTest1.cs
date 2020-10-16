using System;
using System.Collections.Generic;
using GoldBadgeAgain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoRepoTests
{
    [TestClass]
    public class KomodoMenuRepoTests
    {
        private MenuRepo _repo = new MenuRepo();
        private MenuItem _item;
        private MenuItem _newItem;
        private List<MenuItem> _directory = new List<MenuItem>();

        public void Arrange()
        {
            _directory = _repo.GetMenuDirectory();
            _item = new MenuItem(1, "Rigatoni Funghi Salsiccia", "Rigatoni toseed in a rich white cream sauce with spicy italian sausage and mushrooms.", "Rigatoni, Sausage, Mushrooms, Heavy cream, butter, onions, pancetta.", 18.99);
            _newItem = new MenuItem(3, "Bolognese", "Tagliatelle pasta tossed in a classic Italian bolognese that we simmer for 5 hours giving it amazing flavors.", "Tagliatelle, tomato, marinara, beef, pork, pancetta, butter, onion.", 17.95);
            _repo.AddItemToMenu(_item);
        }

        // Arrange
        // Act
        // Assert
        [TestMethod]
        public void MenuItemInitializationTest() // Instantiating item works
        {
            var food = new MenuItem(1, "Rigatoni Funghi Salsiccia", "Homemade Rigatoni, spicy italian sausage and mushrooms tossed in a rich white cream sauce. It's our best seller.", "Rigatoni, Sausage, Mushrooms, Heavy Cream, Onions, Butter, Pancetta.", 18.95);

            Assert.AreEqual(1, food.Number);
            Assert.AreEqual("Rigatoni Funghi Salsiccia", food.Name);
            Assert.AreEqual(18.95, food.Price);
        }

        [TestMethod]
        public void AddsItemToMenuTest() // Adding instantiated item to menu works
        {
            // Arrange
            Arrange();

            // Act
            _repo.AddItemToMenu(_newItem);

            // Assert
            Assert.AreEqual(2, _directory.Count);
            Assert.AreEqual(17.95, _directory[1].Price);
        }

        [TestMethod]
        public void GetDirectoryTest() // Returning menu works
        {
            // Arrange
            _repo.AddItemToMenu(_newItem);

            // Act
            List<MenuItem> list = _repo.GetMenuDirectory();
            bool listContains = list.Contains(_newItem);

            // Assert
            Assert.IsTrue(listContains);
        }

        [TestMethod]
        public void GetItemByNameTest()
        {
            // Arrange
            Arrange();

            // Act
            _repo.GetMenuItemByName("Rigatoni Funghi Salsiccia");

            // Assert
            Assert.AreEqual(18.99, _item.Price);
        } // Getting item works

        [TestMethod]
        public void UpdateItemTest() // Updating item works
        {
            // Arrange
            Arrange();
            MenuItem _newItemTwo = new MenuItem(2, "Barbatelle", "Beet infused tagliatelle, tossed in a light red wine sauce, figs, prosciutto, carmelized onions and some goat cheese. An amazing vegeterian dish.", "Tagliatelle, beets, figs, prosciutto, goat cheese, onions, butter, red wine.", 17.95);

            // Act
            _repo.UpdateMenuItem(_newItemTwo, "Rigatoni Funghi Salsiccia");

            // Assert
            Assert.AreEqual("Barbatelle", _directory[0].Name);
        }

        [TestMethod]
        public void DeleteMenuItemTest()  // Deleting item via standard method works
        {
            // Arrange
            Arrange();

            // Act
            _repo.DeleteMenuItem(_item);

            // Assert
            Assert.AreEqual(0, _directory.Count);
        }

        [TestMethod]
        public void DeleteMenutItemByName()
        {
            // Arrange
            Arrange();

            // Act
            _repo.DeleteMenuItemByName("Rigatoni Funghi Salsiccia");

            // Assert
            Assert.AreEqual(0, _directory.Count);
        }
    }
}
