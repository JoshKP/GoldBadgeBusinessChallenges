using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeAgain
{
    public class MenuRepo
    {
        private readonly List<MenuItem> _menuDirectory = new List<MenuItem>();

        // CREATE 
        public void AddItemToMenu(MenuItem item)
        {
            _menuDirectory.Add(item);
        }
       
        // READ
        public List<MenuItem> GetMenuDirectory()
        {
            return _menuDirectory;
        }

        // Get by Name
        public MenuItem GetMenuItemByName(string name)
        {
            foreach (MenuItem item in _menuDirectory)
            {
                if (item.Name.ToLower() == name.ToLower())
                {
                    return item;
                }
            }
            return null;
        }

        // UPDATE
        public bool UpdateMenuItem(MenuItem updatedItem, string originalName)
        {
            MenuItem item = GetMenuItemByName(originalName);
            if (item != null)
            {
                int itemIndex = _menuDirectory.IndexOf(item);
                _menuDirectory[itemIndex] = updatedItem;
                return true;
            }
            return false;
        }

        // DELETE
        public bool DeleteMenuItem(MenuItem item)
        {
            return _menuDirectory.Remove(item);
        }

        public bool DeleteMenuItemByName(string name)
        {
            MenuItem targetItem = GetMenuItemByName(name);
            return DeleteMenuItem(targetItem);
        }
    }
}
