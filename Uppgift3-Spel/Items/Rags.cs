using System;
using System.Linq;

namespace Uppgift3_Spel.Items
{
    class Rags : Item
    {
        public Rags(string name, string description, int id, string examine) : base(name, description, id, examine)
        { }

        public override Item Use(Player player, Item item, string value)
        {
            if (!FindItemFromString(value, "bottle")) base.Use(player, item, value);

            var findItem = player.PlayerInventory.FirstOrDefault(i => i.Name == "Bottle of Kerosene");
            if (findItem == null) base.Use(player, item, value);
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
