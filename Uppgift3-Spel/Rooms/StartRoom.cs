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
            foreach (var exit in Exit)
            {
                if (!exit.Locked)
                {
                    Description = "I'm inside a small room with bad lighting, there's an unlocked door here, the lock is broken.";
                }
               
            }
            Console.WriteLine(Description);
        }

    }
}
