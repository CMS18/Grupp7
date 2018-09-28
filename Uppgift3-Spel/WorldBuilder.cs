using System;
using System.Collections.Generic;
using Uppgift3_Spel.Exits;
using Uppgift3_Spel.Items;
using Uppgift3_Spel.Rooms;

namespace Uppgift3_Spel
{
    internal class WorldBuilder
    {
        private List<Room> Rooms { get; } = new List<Room>();

        public List<Room> GetWorldRooms()
        {
            return Rooms;
        }

        public WorldBuilder()
        {

            // Create Rooms
            var room1 = new StartRoom(
                "The Room",
                "I'm inside a small room with bad lighting, I can see a door, maybe I can open it?",
                "There's a key and a note on the ground!");

            var room2 = new Hallway(
                "Hallway",
                "A small hallway with cement covered walls, the air is damp. I think I'm in a cellar?\n" +
                "There is a path leading to the left, it looks dark. There's also a path leading to the right.",
                "");

            var room3Right = new JanitorsRoom(
                "Janitor's Room",
                "It's a small room, quite messy, it smells like gasoline. I see a painting of an old man with a handle bar mustasch.\n" +
                "I can't see any exits here besides the way I came from.",
                "There's a table with a bottle. I also see a cleaning cart with some rags and a broom");

            var room4Left = new FinalRoom(
                "Final Room",
                "It's a small room with walls covered in moist, I can see a door with a codelock next to it.",
                "There's nothing here except the door...");

            // Create Items
            var roomKey = new Item(
                "Room Key",
                "It looks like it could fit to this door.",
                1,
                "The key is old and rusty, it looks fragile.");

            var note = new Note(
                "Note",
                "A piece of paper with something written on it.",
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

            var painting = new Painting(
                "Painting",
                "A painting of Mr.X?",
                0,
                "The painting is signed by Mr X." +
                " There seems to be missing a piece of the painting.",
                false);

            var rocks = new Rock(
                "Pile of Rocks",
                "It's a pile of rocks.",
                7,
                "A large pile of small rocks, almost as someone placed them there? Maybe I can move them.",
                false);


            // Create Exit Points
            var roomExit = new Door(
                room2,
                1,
                true,
                false,
                "Rooms Door",
                "You hear a crack... the door is unlocked! Oh... the key broke in half.",
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
                "Codelock Door",
                "Success! The door is unlocked, let's get out of here!",
                "The door is locked. There's a codelock to it. I need to find that code!",
                "A big iron door with a codelock next to it."
                );

            // Add exits to room sists
            room1.Exit.Add(roomExit);
            room2.Exit.Add(new Door(
                room1,
                1,
                false,
                false,
                "Rooms Door",
                "",
                "",
                "That's the door I came from. The key is still stuck inside the lock, whoops!"));
            room2.Exit.Add(room2RightExit);
            room2.Exit.Add(room2LeftExit);

            room3Right.Exit.Add(new Exit(
                room2,
                2,
                false,
                false,
                "Left",
                "",
                "",
                ""));

            room4Left.Exit.Add(new Exit
                (room2,
                2,
                false,
                false,
                "Right",
                "",
                "",
                ""));
            room4Left.Exit.Add(finalRoomExit);
                                                                                        
            // Add items to room inventory
            room1.RoomInventory.Add(roomKey);
            room1.RoomInventory.Add(note);

            room2.RoomInventory.Add(rocks);

            room3Right.RoomInventory.Add(bottle);
            room3Right.RoomInventory.Add(rags);
            room3Right.RoomInventory.Add(broom);
            room3Right.RoomInventory.Add(painting);

            // Add all instances of rooms to property Rooms
            Rooms.Add(room1);
            Rooms.Add(room2);
            Rooms.Add(room3Right);
        }

        public Player CreateNewPlayer()
        {
            Console.Title = "New Game";
            string name;
            var creatingPlayer = true;
            MainScreen();
            do
            {
                Console.Write("> What's your name? ");
                name = Console.ReadLine();
                if(string.IsNullOrEmpty(name))continue;
                creatingPlayer = false;
            } while (creatingPlayer);

            Console.Clear();
            Console.WriteLine("Hello!?...Where am I?!...Ugh...I don't feel too well.\n");
            return new Player(name);
        }

        public void MainScreen()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("+----------------------------------------+");
            Console.WriteLine("+         MR.X DUNGEON GAME v1.0         +");
            Console.WriteLine("+----------------------------------------+");
            Console.WriteLine("+ Type help for commands during the game +");
            Console.WriteLine("+----------------------------------------+");
            Console.ResetColor();
        }

        

    }
}
