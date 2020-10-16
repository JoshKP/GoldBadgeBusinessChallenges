using GoldBadgeAgain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoMenuUI
{
    class ProgramUI
    {
        private bool _isRunning = true;

        private readonly MenuRepo _menuRepo = new MenuRepo();

        public void Start()
        {
            SeedData();
            RunMenu();
        }

        private void RunMenu()
        {
            while (_isRunning)
            {
                string userInput = GetMenuSelection();
                OpenMenuItem(userInput);
            }
        }

        private void SeedData()
        {
            MenuItem firstItem = new MenuItem(1, "Rigatoni Funghi Salsiccia", "Homemade Rigatoni, spicy italian sausage and mushrooms tossed in a rich white cream sauce. It's our best seller.", "Rigatoni, Sausage, Mushrooms, Heavy Cream, Onions, Butter, Pancetta.", 18.95);
            MenuItem secondItem = new MenuItem(2, "Barbatelle", "Beet infused tagliatelle, tossed in a light red wine sauce, figs, prosciutto, carmelized onions and some goat cheese. An amazing vegeterian dish.", "Tagliatelle, beets, figs, prosciutto, goat cheese, onions, butter, red wine.", 17.95);
            MenuItem thirdItem = new MenuItem(3, "Bolognese", "Tagliatelle pasta tossed in a classic Italian bolognese that we simmer for 5 hours giving it amazing flavors.", "Tagliatelle, tomato, marinara, beef, pork, pancetta, butter, onion.", 17.95);

            _menuRepo.AddItemToMenu(firstItem);
            _menuRepo.AddItemToMenu(secondItem);
            _menuRepo.AddItemToMenu(thirdItem);
        }

        private string GetMenuSelection()
        {
            Console.Clear();
            Console.WriteLine(
                "1  Show all menu items\n" +
                "2  Find menu item by name\n" +
                "3  Add new menu item\n" +
                "4  Update menu item\n" +
                "5  Remove menu item\n" +
                "6  Exit");

            string userInput = Console.ReadLine();
            return userInput;
        }

        private void OpenMenuItem(string userInput)
        {
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    // Show all
                    DisplayAllMenuItems();
                    Console.WriteLine("Press a key to return to menu");
                    Console.ReadKey();
                    break;
                case "2":
                    // Find by name
                    DisplayMenuItemByName();
                    break;
                case "3":
                    // Add new item
                    CreateNewMenuItem();
                    break;
                case "4":
                    // Update item
                    UpdateExistingMenuItem();
                    break;
                case "5":
                    // Remove item
                    DeleteExistingMenuItem();
                    break;
                case "6":
                    // Exit
                    _isRunning = false;
                    return;
                default:
                    // Invalid selection
                    return;

            }
        }

        private void DisplayAllMenuItems()
        {
            List<MenuItem> menuList = _menuRepo.GetMenuDirectory();

            foreach (MenuItem item in menuList)
            {
                DisplayMenuItem(item);
            }
        }

        private void DisplayMenuItem(MenuItem item)
        {
            Console.WriteLine($"Meal Number: {item.Number}  |  Name: {item.Name}  |  Price: {item.Price}\n\n" +
                $"Description: {item.Description}\n" +
                $"Ingredients: {item.Ingredients}\n\n");
        }

        private void DisplayMenuItemByName()
        {
            Console.WriteLine("Enter meal name:  ");
            string name = Console.ReadLine();
            MenuItem item = _menuRepo.GetMenuItemByName(name);

            if (item != null)
            {
                DisplayMenuItem(item);
            }
            else
            {
                Console.WriteLine("Meal not found");
            }
            Console.WriteLine("Press key to continue");
            Console.ReadKey();
        }

        private void CreateNewMenuItem()
        {
            Console.WriteLine("Enter a number for the meal:  ");
            var input = Console.ReadLine();

            int newNumber;
            while(!int.TryParse(input, out newNumber))
            {
                Console.WriteLine("Invalid number try again");
                input = Console.ReadLine();
            }
            int number = newNumber;
                       
            Console.WriteLine("Enter meal name:  ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter meal description:  ");
            string description = Console.ReadLine();

            Console.WriteLine("Enter meal ingredients:  ");
            string ingredients = Console.ReadLine();

            Console.WriteLine("Enter a price for the meal:  $");
            var priceInput = Console.ReadLine();

            double priceNumber;
            while (!double.TryParse(priceInput, out priceNumber))
            {
                Console.WriteLine("Invalid number try again");
                priceInput = Console.ReadLine();
            }
            double price = priceNumber;

            MenuItem newItem = new MenuItem(number, name, description, ingredients, price);

            _menuRepo.AddItemToMenu(newItem);
        }

        private bool UpdateExistingMenuItem()
        {
            DisplayAllMenuItems();

            Console.WriteLine("Enter name of item you are updating");
            string oldName = Console.ReadLine();

            MenuItem item = _menuRepo.GetMenuItemByName(oldName);

            if (oldName != null)
            {
                DisplayMenuItem(item);
            }
            else
            {
                Console.WriteLine("Menu item not found");
            }

            Console.WriteLine("Enter a number for the meal:  ");
            var input = Console.ReadLine();

            int newNumber;
            while (!int.TryParse(input, out newNumber))
            {
                Console.WriteLine("Invalid number try again");
                input = Console.ReadLine();
            }
            int number = newNumber;

            Console.WriteLine("Enter meal name:  ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter meal description:  ");
            string description = Console.ReadLine();

            Console.WriteLine("Enter meal ingredients:  ");
            string ingredients = Console.ReadLine();

            Console.WriteLine("Enter a price for the meal:  $");
            var priceInput = Console.ReadLine();

            double priceNumber;
            while (!double.TryParse(priceInput, out priceNumber))
            {
                Console.WriteLine("Invalid number try again");
                priceInput = Console.ReadLine();
            }
            double price = priceNumber;

            MenuItem newItem = new MenuItem(number, name, description, ingredients, price);

            bool wasUpdated = _menuRepo.UpdateMenuItem(newItem, oldName);
            if (wasUpdated)
            {
                Console.WriteLine("Meal updated");
            }
            else
            {
                Console.WriteLine("Unable to update meal");
            }
            return false;

        }

        private void DeleteExistingMenuItem()
        {
            Console.Clear();
            DisplayAllMenuItems();

            Console.WriteLine("Enter name of meal to be removed");
            string name = Console.ReadLine();

            bool wasDeleted = _menuRepo.DeleteMenuItemByName(name);
            if (wasDeleted)
            {
                Console.WriteLine($"\n{name} was deleted");
            }
            else
            {
                Console.WriteLine("Meal could not be deleted");
            }
            Console.WriteLine("Press key to continue");
            Console.ReadKey();
        }

    }
}
