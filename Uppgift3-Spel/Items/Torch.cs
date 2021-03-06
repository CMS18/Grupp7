﻿using System;
using System.Linq;

namespace Uppgift3_Spel.Items
{
    class Torch : Item
    {
        public Torch(string name, string description, int id, string examine) : base(name, description, id, examine)
        {
        }

        public override Item Use(Player player, Item item, string value)
        {
            if (!InputParse.CompareStrings(value, "lighter")) return null;
            var findItem = player.PlayerInventory.FirstOrDefault(x => x.ItemId == 6);

            if (findItem == null) return null;
            player.PlayerInventory.Remove(findItem);
            player.PlayerInventory.Remove(item);
            Console.WriteLine($"{player.Name} got a Lighted Torch.");
            return new Item(
                "Lighted Torch",
                "It's a torch that is burning bright.",
                10,
                "Woah! Keep it away from my face!");
        }
    }
}
