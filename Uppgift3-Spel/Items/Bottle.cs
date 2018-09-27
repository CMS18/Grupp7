using System;
using System.Linq;

namespace Uppgift3_Spel.Items
{
    internal class Bottle : Item
    {
        public Bottle(string name, string description, int id, string examine) : base(name, description, id, examine)
        {
        }

        public override Item Use(Player player, Item item)
        {
            var findItem = player.PlayerInventory.FirstOrDefault(i => i.Name == "Rags");
            if (findItem == null) return null;
            player.PlayerInventory.Remove(findItem);
            player.PlayerInventory.Remove(item);

            Console.WriteLine($"{player.Name} got Soaked Rags.");

            return new SoakedRags("Soaked Rags",
                "Rags drained with Kerosene",
                5,
                "Rags drained with Kerosene, this can burn very well!");
        }
    }
}
