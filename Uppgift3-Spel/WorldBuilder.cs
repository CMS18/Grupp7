using System;
using System.Collections.Generic;

namespace Uppgift3_Spel
{
    internal class WorldBuilder
    {
        public List<Room> Room { get; }

        public WorldBuilder()
        {
            var result = new List<Room>();
            var room1 = new Room("House", "It's a house. There's a key on the ground.");
            var room2 = new Room("Inside House", "We are inside house");
            
            var item1 = new Key("House Key", "A key to the house", 1);
            

            var exit1 = new Door(room2, 1, true, true, "Maindoor");
            room1.Exit.Add((exit1));
            room1.RoomInventory.Add(item1);
             

            result.Add(room1);
            result.Add(room2);
            Room = result;
        }

        public Player CreateNewPlayer()
        {
            // Call print first screen
            Console.Write("> What's your name? ");
            var name = Console.ReadLine();
            return new Player(name);
        }

        

    }
}
