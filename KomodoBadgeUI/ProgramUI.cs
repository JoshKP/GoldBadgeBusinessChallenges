using KomodoBadge;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadgeUI
{
    class ProgramUI
    {
        private bool _isRunning = true;

        private readonly BadgeRepo _badgeRepo = new BadgeRepo();

        public void Run()
        {
            SeedDictionary();
            Menu();
        }

        public void Menu()
        {
            while (_isRunning)
            {
                Console.WriteLine("Select an option:\n" +
                    "1  Create a badge\n" +
                    "2  Edit badge access\n" +
                    "3  View all badges and their access\n" +
                    "4  Exit\n" +
                    "");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        CreateBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ViewAllBadges();
                        break;
                    case "4":
                        _isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("Press a key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreateBadge()
        {
            Console.WriteLine("Enter ID for badge:  ");
            int badgeID = int.Parse(Console.ReadLine());

            Console.WriteLine($"Enter rooms badge {badgeID} will be able to access.  Separate with commas. ");
            string roomAccess = Console.ReadLine();

            _badgeRepo.AddBadgeToDictionary(badgeID, roomAccess);
        }

        private void EditBadge()
        {
            Console.WriteLine("Enter ID of badge to edit:  ");
            int badgeID = int.Parse(Console.ReadLine());

            IDictionary<int, List<string>> badgeDictionary = _badgeRepo.ReturnDictionary();

            DisplaySingleBadgeRoomAccess(badgeID, badgeDictionary[badgeID]);

            Console.WriteLine("Edit this badge? (y/n)");

            string editBadge = Console.ReadLine();
            if (editBadge == "y")
            {
                Console.WriteLine("Would you like to \"add\" or \"remove\" room access?");
                string addOrRemove = Console.ReadLine().ToLower();
                if (addOrRemove == "add")
                {
                    Console.WriteLine("List room(s) to add separated by commas");
                    string roomsToAdd = Console.ReadLine();

                    _badgeRepo.AddBadgeAccess(badgeDictionary[badgeID], roomsToAdd);
                }
                else if (addOrRemove == "remove")
                {
                    Console.WriteLine("List room(s) to remove separated by commas");
                    Console.WriteLine("Enter \"all\" to remove all rooms");
                    string roomsToRemove = Console.ReadLine();
                    if (roomsToRemove == "all")
                    {
                        _badgeRepo.RemoveAllRoomsFromBadge(badgeID);
                        Console.WriteLine("Would you like to remove this badge from Dictionary? (y/n)");
                        string removeBadge = Console.ReadLine();
                        if (removeBadge == "y")
                        {
                            _badgeRepo.RemoveBadgeFromDictionary(badgeID);
                        }
                        else if (removeBadge == "n")
                        {
                            Console.WriteLine("This badge has no room access");
                        }
                        else
                        {
                            Console.WriteLine("Enter \"y\", \"n\" or \"exit\"");
                        }
                    }
                    else _badgeRepo.RemoveBadgeAccess(badgeID, roomsToRemove);
                }
                else if (addOrRemove == "exit")
                { Console.WriteLine("Badge access not changed"); }
                else
                { Console.WriteLine("Please enter a valid response : \"add\" , \"remove\" , or \"exit\""); }
            }
        }

        private void DisplaySingleBadgeRoomAccess(int badgeID, List<string> doorList)
        {
            Console.WriteLine($"Badge {badgeID} has access to rooms: ");
            foreach (var room in doorList)
            {
                Console.WriteLine(room);
            }
            Console.WriteLine();
        }

        private void ViewAllBadges()
        {
            IDictionary<int, List<string>> badgeAccess = _badgeRepo.ReturnDictionary();

            foreach (var badge in badgeAccess)
            {
                Console.WriteLine("Badge ID: " + badge.Key + " has access to rooms:");
                foreach (string room in badge.Value)
                    Console.WriteLine(room);
            }
        }

        private void SeedDictionary()
        {
            _badgeRepo.AddBadgeToDictionary(111, "A1, B1, C1");
            _badgeRepo.AddBadgeToDictionary(222, "A2, B2, C2");
            _badgeRepo.AddBadgeToDictionary(333, "A3, B3, C3");
        }


    }
}
