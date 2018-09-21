using System;
using System.Collections.Generic;

namespace Uppgift3_Spel
{
    internal class WorldBuilder
    {
        public List<Room> Room { get; }

        public WorldBuilder()
        {
            List<Room> result = new List<Room>();
            var exit1 = new Exit("Room 2", 1, "West");
            var item1 = new Item("Item1", "This is item1", 1);
            var room1 = new Room("Outside Mansion", "We are outside the mansion", exit1, item1);
            
            var exit2 = new Exit("Room 3", 2, "Door");
            var item2 = new Item("Item 2", "This is item2", 2);
            var room2 = new Room("Back of the Mansion", "We are still outside the mansion", exit2, item2);

            result.Add(room1);
            result.Add(room2);
            Room = result;
        }

        public Player CreateNewPlayer()
        {
            // Call print first screen
            Console.Write("> What's your name? ");
            string name = Console.ReadLine();
            return new Player(name);
        }

        

    }
}
