using System;
using System.Collections.Generic;
using Uppgift3_Spel.Items;

namespace Uppgift3_Spel
{
    internal class WorldBuilder
    {
        public List<Room> Rooms { get; }

        public WorldBuilder()
        {
            var result = new List<Room>();

            // Create Rooms
            var room1 = new Room(
                "The Room",
                "Hello!?...Where am I?!...Ugh... I don't feel too well." +
                "\nI'm inside a small room with bad lighting, I can see a door, maybe I can open it?",
                "There's a key and a note on the ground!");

            var room2 = new Room(
                "Hallway",
                "A small hallway with cement covered walls, the air is damp. I think I'm in a cellar?", 
                "There is a path leading to the left, it looks dark. There's also a path leading to the right.");

            var room3Right = new Room(
                "Janitor's Room",
                "It's a small room, quite messy, it smells like gasoline. I see a painting of an old man with a handle bar mustasch",
                "There's a table with a bottle. I also see a cleaning cart with some rags and a broom");

            // Create Items
            var roomKey = new Key(
                "Room Key",
                "It looks like it can fit to this door.",
                1,
                "The key is old and rusty, it looks fragile.");

            var note = new Item(
                "Note",
                "Welcome to my game, I hope I didn't drug you too heavily... I left a key for you to leave this room.\n" +
                "However if you want to escape you have to solve the upcoming puzzles as well. Enjoy! /Mr X.",
                0,
                "A note from Mr. X, he doesn't sound like a good guy.");
            
            var bottle = new Bottle(
                "Bottle of Kerosene",
                "It's commonly used to power jet engines.",
                2,
                "A bottle of kerosene, it's very flammable.");
            var rags = new Item(
                "Rags",
                "Some old clothes ripped apart.",
                2,
                "I think this used to be a shirt...");
            var broom = new Item(
                "Broom",
                "A regular broom used to cleaning.",
                2, "It's a broom, what more do you need to know?");

            var painting = new Painting("Paining",
                "A painting of Mr.X",
                0,
                "It's a painting of Mr.X," +
                " there seems to be missing a piece of the painting.");

            //var item4 = new Item("Torch", "It's flame burns bright.", 4, "Woah! Keep it away from my face!");
            // Om items används på varandra så skapa Torch


            // Create Exit Points
            var roomExit = new Door(
                room2,  // LeadsTo
                1,      // ExitID
                true,   // Locked
                false,   // EndPoint
                "Rooms Door",
                "You hear a crack... the door is open! Oh... the key broke in half.",
                "The door is locked, maybe there's a key somewhere?",
                "A brown wooden door with a sturdy lock.");

            var room2RightExit = new Exit(
                room3Right,
                2,
                false,
                false,
                "Right",
                "",
                "",
                ""
                );

            // TODO add extit Right for room2

            

            // Add Exits to Lists
            room1.Exit.Add((roomExit));

            room2.Exit.Add(new Door(room1, 1, false, false, "Rooms Door", "", "", "That's the door I came from. The key is still stuck inside the lock, whoops!"));
            room2.Exit.Add(room2RightExit);
            room2.Exit.Add(new Door(room2, 1, false, false, "Left", "", "", ""));

            // Add Items to RoomList
            room1.RoomInventory.Add(roomKey);
            room1.RoomInventory.Add(note);

            room3Right.RoomInventory.Add(bottle);
            room3Right.RoomInventory.Add(rags);
            room3Right.RoomInventory.Add(broom);
            room3Right.RoomInventory.Add(painting);

            // Add to result and set property Rooms to result.
            result.Add(room1);
            result.Add(room2);
            result.Add(room3Right);
            Rooms = result;
        }

        public Player CreateNewPlayer()
        {
            Console.Title = "New Game";
            string name;
            var creatingPlayer = true;
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
