using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3_Spel.Rooms
{
    class FinalRoom : Room
    {
        public FinalRoom(string title, string description, string examine) : base(title, description, examine)
        {

        }

        public override void ShowRoomDescription()
        {
            foreach (var exit in Exit)
            {
                if (!exit.Locked && exit.ExitId == 11)
                {
                    Description = "It's a small room with walls covered in moist, the door is unlocked.\n" +
                                  "I should get out of here while I can!";
                }

            }
            base.ShowRoomDescription();
        }


    }
}
