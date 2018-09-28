using System;
using System.Linq;
using Uppgift3_Spel.Rooms;

namespace Uppgift3_Spel.Items
{
    class Note : Item
    {
        public Note(string name, string description, int id, string examine) : base(name, description, id, examine)
        {
        }


        public override void ShowItemDescription()
        {
            Console.WriteLine("Welcome to my game, I hope I didn't drug you too heavily..." +
                              " I left a key for you to leave this room.\n" +
                              "However if you want to escape, you have to solve the upcoming puzzles as well." +
                              " Muhahahaha....haha! /Mr X.");
        }

        public override void Use(Player player, Room room, Item item)
        {
            var findItem = room.RoomInventory.FirstOrDefault(i => i.Name == "Painting");
            if (findItem == null) return;
            player.PlayerInventory.Remove(item);
            room.RoomInventory.Remove(findItem);
            room.RoomInventory.Add(new Item(
                "Completed Painting",
                "It's a complete painting of Mr.X... I think?",
                5,
                "There is a number written here! 1, 4, 8, 3. I wonder what that's for?",
                false));

            Console.WriteLine($"{player.Name} placed the note on the painting, it fits perfectly.");
        }
    }
}
