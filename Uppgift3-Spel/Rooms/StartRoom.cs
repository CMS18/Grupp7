using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift3_Spel.Items;

namespace Uppgift3_Spel.Rooms
{
    class StartRoom : Room
    {
        public StartRoom(string title, string description, string examine) : base(title, description, examine)
        {
        }

        public override void ShowRoomDescription()
        { 
                if (RoomInventory.Any())
                {

                }
                //"I'm inside a small room with bad lighting, I can see a door, maybe I can open it?",
                //"There's a key and a note on the ground!"
            
        }
    }
}
