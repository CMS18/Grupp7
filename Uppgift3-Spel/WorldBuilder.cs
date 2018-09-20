using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3_Spel
{
    class WorldBuilder
    {
        public List<Room> _room { get; private set; }

        public WorldBuilder()
        {
            List<Room> result = new List<Room>();
            var exit1 = new Exit("Room 2", 1);
            var item1 = new Item("Item1", "This is item1", 1);

            // Generate Rooms, add inventorys, add exits
            var room1 = new Room("Outside Mansion", "We are outside the mansion", exit1, item1);


            var exit2 = new Exit("Room 3", 2);
            var item2 = new Item("Item 2", "This is item2", 2);

            var room2 = new Room("Back of the Mansion", "We are still outside the mansion", exit2, item2);

            result.Add(room1);
            result.Add(room2);
            _room = result;
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
