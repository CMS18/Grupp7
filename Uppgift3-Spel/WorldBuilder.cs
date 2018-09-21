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

            // Create Rooms
            var room1 = new Room("Outside The House", "I'm standing infront of a large house. There's a key on the ground. I also see a door, maybe I can open it?");
            var room2 = new Room("Inside House", "We are inside the house!");
            
            // Create Items
            var item1 = new Key("House Key", "A key to the house", 1, "A rusty key, it looks fragile.");
            
            // Create Exit Points
            var exit1 = new Door(
                room2,  // LeadsTo
                1,      // ExitID
                true,   // Locked
                true,   // EndPoint
                "House Door",
                "You hear a crack... the door is open! Oh... the key broke in half.",
                "The door is locked, maybe there's a key?");





            // Add Exits to Lists
            room1.Exit.Add((exit1));
            room2.Exit.Add(new Door(room1, 1, false, false, "House Door", "", ""));
            room1.RoomInventory.Add(item1);
            
             
            // Add to result and set property Room to result.
            result.Add(room1);
            result.Add(room2);
            Room = result;
        }

        public Player CreateNewPlayer()
        {
            string name;
            bool creatingPlayer = true;
            do
            {
                Console.Clear();
                Console.Write("> What's your name? ");
                name = Console.ReadLine();
                if(string.IsNullOrEmpty(name))continue;
                creatingPlayer = false;
            } while (creatingPlayer);
            return new Player(name);

        }

        

    }
}
