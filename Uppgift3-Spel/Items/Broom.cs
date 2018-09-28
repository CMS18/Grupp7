using System;
using System.Linq;

namespace Uppgift3_Spel.Items
{
    internal class Broom : Item
    {
        public Broom(string name, string description, int id, string examine) : base(name, description, id, examine)
        {
        }

        public override Item Use(Player player, Item item, string value)
        {
            if (!FindItemFromString(value, "soaked")) return null;

            var findItem = player.PlayerInventory.FirstOrDefault(i => i.Name == "Soaked Rags");
            if (findItem == null) return null;
            player.PlayerInventory.Remove(findItem);
            player.PlayerInventory.Remove(item);

            Console.WriteLine($"{player.Name} got a Torch.");

            return new Torch("Torch",
                "A broom covered in kerosene soaked rags.",
                8,
                "I need something to light this bad boy!");
        }
    }
}
