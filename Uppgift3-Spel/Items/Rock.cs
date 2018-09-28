using System;
using System.Linq;
using Uppgift3_Spel.Rooms;

namespace Uppgift3_Spel.Items
{
    class Rock : Item
    {
        public Rock(string name, string description, int id, string examine, bool takeAble) 
            : base(name, description, id, examine, takeAble)
        { }

        public override void Use(Player player, Room room)
        {
            var findItem = room.RoomInventory.FirstOrDefault(i => i.Name == "Pile of Rocks");
            if (findItem == null) return;
            room.RoomInventory.Add(new Lighter(
                "Lighter",
                "A red BIC lighter.",
                6,
                "It still works!"));

            Console.WriteLine($"{player.Name} moves the rocks with great ease!");
            Console.WriteLine("A lighter!");
        }

    }
}
