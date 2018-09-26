using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3_Spel.Items
{
    class Lighter : Item
    {
        public Lighter(string name, string description, int id, string examine) : base(name, description, id, examine)
        {
        }

        public override Item Use(Player player, Item item)
        {
            var findItem = player.PlayerInventory.FirstOrDefault(x => x.ItemId == 8);

            if (findItem == null) return null;
            player.PlayerInventory.Remove(findItem);
            player.PlayerInventory.Remove(item);
            Console.WriteLine($"{player.Name} got a Lighted Torch.");
            return new Lighter("Lighted Torch",
                "It's a torch that is burning bright.",
                10,
                "Woah! Keep it away from my face!");
        }
    }
}
