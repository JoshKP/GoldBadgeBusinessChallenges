using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeAgain
{
    public class MenuItem
    {
        // Constructors
        public MenuItem() { }
        public MenuItem(int number, string name, string description, string ingredients, double price)
        {
            Number = number;
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }

        public int Number { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Ingredients { get; set; }

        public double Price { get; set; }
    }
}
