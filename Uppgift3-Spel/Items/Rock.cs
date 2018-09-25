using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift3_Spel.Rooms;

namespace Uppgift3_Spel.Items
{
    class Rock : Item
    {
        public Rock(string name, string description, int id, string examine, bool takeAble) 
            : base(name, description, id, examine, takeAble)
        {
        }


        public override void Use(Player player, Room room)
        {
            var findItem = room.RoomInventory.FirstOrDefault(i => i.Name == "Pile of Rocks");
            if (findItem == null) return;
            room.RoomInventory.Add(new Item("Lighter",
                "A red Bic-lighter.",
                6,
                "It still works!"));

            room.Examine =
                "There is a path leading to the left, it looks dark. There's also a path leading to the right.\n" +
                "I can see a lighter where the rock pile were.";

            Console.WriteLine($"{player.Name} moves the rocks with great ease!");
        }

    }
}
