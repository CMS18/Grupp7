﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3_Spel.Rooms
{
    class Hallway : Room
    {
        public Hallway(string title, string description, string examine) : base(title, description, examine)
        {
        }

        public override void ShowRoomDescription()
        {
            foreach (var exit in Exit)
            {
                if (!exit.Locked && exit.ExitId == 10)
                {
                    Description = "A small hallway with cement covered walls, the air is damp. I think I'm in a cellar.\n" +
                                  "There's a path leading to the left, my torch should be able to light up the path for me to follow.\n" +
                                  "There's also a path leading to the right and a door.";
                    Console.WriteLine(Description);
                    return;
                }

            }

            base.ShowRoomDescription();


        }

    }
}
