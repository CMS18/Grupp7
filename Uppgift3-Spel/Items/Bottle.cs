using System;
using System.Linq;

namespace Uppgift3_Spel.Items
{
    internal class Bottle : Item
    {
        public Bottle(string name, string description, int id, string examine) : base(name, description, id, examine)
        {
        }

        public override Item Use(Player player, Item item, string value)
        {
            if (!CompareValue(player, value)) return null;

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

        protected virtual bool CompareValue(Player player, string value)
        {
            var arrayValue = value.Split(' ').ToArray();
            return arrayValue.Any(str => str.ToLower().Contains("rags"));
        }
    }
}
