using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3_Spel.Items
{
    class Broom : Item
    {
        public Broom(string name, string description, int id, string examine) : base(name, description, id, examine)
        {
        }

        public override Item Use(Player player, Item item)
        {
            var findItem = player.PlayerInventory.FirstOrDefault(i => i.Name == "Soaked Rags");
            if (findItem == null) return null;
            player.PlayerInventory.Remove(findItem);
            player.PlayerInventory.Remove(item);

            Console.WriteLine($"{player.Name} got Broom Torch.");

            return new BroomTorch("Broom Torch",
                "A broom covered in kerosene soaked rags.",
                8,
                "I need something to light this bad boy!");
        }
    }
}
