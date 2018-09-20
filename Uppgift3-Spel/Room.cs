using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3_Spel
{
    class Room
    {
        public string Description { get; private set; }
        public int MyProperty { get; set; } // Exit
        public List<string> RoomInventory { get; private set; }

        public void ShowRoomDescription()
        {

        }
    }
}
