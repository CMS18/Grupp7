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
            var room1 = new Room("House", "It's a house");
            var room2 = new Room("Inside House", "We are inside house");

            

            var exit1 = new Door(room2, 1, false, true, "Maindoor");
            room1.Exit.Add((exit1));
                

           

            result.Add(room1);
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
