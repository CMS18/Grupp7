using System;
using System.Collections.Generic;
using Uppgift3_Spel.Exits;
using Uppgift3_Spel.Items;
using Uppgift3_Spel.Rooms;

namespace Uppgift3_Spel
{
    internal class WorldBuilder
    {
        private List<Room> Rooms { get; }

        public List<Room> GetWorldRooms()
        {
            return Rooms;
        }

        public WorldBuilder()
        {
            var result = new List<Room>();

            // Create Rooms
            var room1 = new StartRoom(
                "The Room",
                "\nI'm inside a small room with bad lighting, I can see a door, maybe I can open it?",
                "There's a key and a note on the ground!");

            var room2 = new Hallway(
                "Hallway",
                "A small hallway with cement covered walls, the air is damp. I think I'm in a cellar?\n" +
                "There is a path leading to the left, it looks dark. There's also a path leading to the right.\nThere's a pile of rocks " +
                "lying on the ground.",
                "");

            var room3Right = new JanitorsRoom(
                "Janitor's Room",
                "It's a small room, quite messy, it smells like gasoline. I see a painting of an old man with a handle bar mustasch.\n" +
                "I can't see any exits here besides the way I came from.",
                "There's a table with a bottle. I also see a cleaning cart with some rags and a broom");

            var room4Left = new FinalRoom(
                "Final Room",
                "An empty room with a door.",
                "There's nothing here except the door...");

            // Create Items
            var roomKey = new Key(
                "Room Key",
                "It looks like it could fit to this door.",
                1,
                "The key is old and rusty, it looks fragile.");

            var note = new Note(
                "Note",
                "Welcome to my game, I hope I didn't drug you too heavily... I left a key for you to leave this room.\n" +
                "However if you want to escape you have to solve the upcoming puzzles as well. Enjoy! /Mr X.",
                0,
                "A piece of paper with something written on it.");
            
            var bottle = new Bottle(
                "Bottle of Kerosene",
                "It's commonly used to power jet engines.",
                2,
                "A bottle of kerosene, it's very flammable.");
            var rags = new Rags(
                "Rags",
                "Some old clothes ripped apart.",
                2,
                "I think this used to be a shirt...");
            var broom = new Broom(
                "Broom",
                "A regular broom used to cleaning.",
                5, "It's a broom, what more do you need to know?");

            var painting = new Painting("Painting",
                "A painting of Mr.X?",
                0,
                "The painting is signed by Mr X." +
                " there seems to be missing a piece of the painting.",
                false);

            var rocks = new Rock("Pile of Rocks",
                "It's a pile of rocks.",
                7,
                "A large pile of small rocks, almost as someone placed them there?",
                false);

            // TODO
            // Lägg till pile of rocks för rum 2, gör den non takeable,
            // Lägg till move i InputParse const
            // Lägg till metod Move i World.PlayersTurn
            // Gör subklass Lighter : Item, överrida Use att kunna tända eld på facklan.
            // Gör Room2ExitLeft, locked = true tills att användaren har facklan i inventoryt.
            // Lägg till ett till rum med en låst dörr, dörren är också endpoint och har ett kombinationslås
            // Skapa någon metod för vad som visas då man klarat ut spelet!




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

            var room2RightExit = new RightOfHallway(
                room3Right,
                2,
                false,
                false,
                "Right",
                "",
                "",
                ""
                );

            var room2LeftExit = new LeftOfHallway(
                room4Left,
                10,
                true,
                false,
                "Left",
                "Finally some light! I can now see where I'm going.",
                "I can't go that way, it's too dark. I need some light...",
                "It's just a dark passage..."
                );

            var finalRoomExit = new FinalDoor(
                11,
                true,
                false,
                "Final door",
                "YAAAY",
                "The door is locked. There's a codelock to it. I need to find that code!",
                "A big iron door with codelock next to it."
                );

            // Add Exits to Lists
            room1.Exit.Add((roomExit));

            room2.Exit.Add(new Door(room1, 1, false, false, "Rooms Door", "", "", "That's the door I came from. The key is still stuck inside the lock, whoops!"));
            room2.Exit.Add(room2RightExit);
            room2.Exit.Add(room2LeftExit);
            room3Right.Exit.Add(new Exit(room2, 2, false, false, "Left", "", "", ""));
            room4Left.Exit.Add(new Exit(room2, 2, false, false, "Right", "", "", ""));
            room4Left.Exit.Add(finalRoomExit);
                                                                                        
            // Add Items to RoomList
            room1.RoomInventory.Add(roomKey);
            room1.RoomInventory.Add(note);

            room2.RoomInventory.Add(rocks);

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
            Console.WriteLine("Hello!?...Where am I ? !...Ugh...I don't feel too well.");
            return new Player(name);
        }

        

    }
}
