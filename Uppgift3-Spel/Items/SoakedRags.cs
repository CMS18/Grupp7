using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3_Spel.Items
{
    class SoakedRags : Item
    {
        public SoakedRags(string name, string description, int id, string examine) : base(name, description, id, examine)
        {
        }

        public override Item Use(Player player, Item item, string value)
        {
            if (!FindItemFromString(value, "broom")) return null;

            var findItem = player.PlayerInventory.FirstOrDefault(i => i.Name == "Broom");
            if (findItem == null) return null;
            player.PlayerInventory.Remove(findItem);
            player.PlayerInventory.Remove(item);

            Console.WriteLine($"{player.Name} got Broom Torch.");

            return new Torch("Broom Torch",
                "A broom covered in kerosene soaked rags.",
                8,
                "I need something to light this bad boy!");
        }



    }
}
