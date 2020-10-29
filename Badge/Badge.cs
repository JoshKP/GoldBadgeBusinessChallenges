using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadge
{
    public class Badge
    {
        public Badge() { }

        public Badge(int id, List<string> roomAccess)
        {
            BadgeID = id;
            RoomAccess = roomAccess;
        }
        public int BadgeID { get; set;}

        public List<string> RoomAccess { get; set;}
    }
}
