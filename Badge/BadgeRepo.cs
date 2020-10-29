using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadge
{
    public class BadgeRepo
    {
        private readonly IDictionary<int, List<string>> _dictionary = new Dictionary<int, List<string>>();

        public void AddBadgeToDictionary(int badgeID, string roomAccess)
        {
            Badge badgeToAdd = new Badge();
            badgeToAdd.BadgeID = badgeID;

            badgeToAdd.RoomAccess = new List<string>();
            string [] roomsToGiveAccess = roomAccess.Split(',');

            foreach (var room in roomsToGiveAccess)
            {
                badgeToAdd.RoomAccess.Add(room);
            }

            _dictionary.Add(badgeID, badgeToAdd.RoomAccess);
        }

        public IDictionary<int, List<string>> ReturnDictionary()
        {
            return _dictionary;
        }

        public List<string> ViewBadgeAccess(int badgeID)
        {
            if (_dictionary.ContainsKey(badgeID))
                return _dictionary[badgeID];
            else return null;
        }

        public void AddBadgeAccess(List<string> badgeDictionary, string roomsToAdd)
        {
            string [] roomsToGiveAccess = roomsToAdd.Split(',');
            
            foreach (var room in roomsToGiveAccess)
            {
                badgeDictionary.Add(room);
            }
        }

        public void RemoveBadgeAccess(int badgeID, string roomsToRemove)
        {
            string [] rooms = roomsToRemove.Split(',');

            foreach (var room in rooms)
            {
                _dictionary[badgeID].Remove(room);
            }
        }

        public void RemoveAllRoomsFromBadge(int badgeID)
        {
            _dictionary[badgeID] = new List<string>();
        }

        public void RemoveBadgeFromDictionary(int badgeID)
        {
            if (_dictionary.ContainsKey(badgeID))
            {
                _dictionary.Remove(badgeID);
            }
        }


    }
}
