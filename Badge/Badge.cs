using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge
{
    public class Badge
    {
        public Badge() { }

        public Badge(int id, List<string> doors)
        {
            BadgeID = id;
            DoorAccess = doors;
        }
        public int BadgeID { get; set;}

        public List<string> DoorAccess { get; set;}
    }
}
