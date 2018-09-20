using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3_Spel
{
    class WorldBuilder
    {
        public List<Room> _rooms { get; private set; }

        public WorldBuilder()
        {
            var exit1 = new Exit("Room 2");
            var item1 = new Item("Item1", "This is item1");

            // Generate Rooms, add inventorys, add exits
            var room1 = new Room("Outside Mansion", "We are outside the mansion", exit1, item1);

            _rooms.Add(room1);
            // Add to List
            
        }

        public Player CreateNewPlayer()
        {
            string name = Console.ReadLine();
            Player player = new Player(name);
            return player;
        }

    }
}
