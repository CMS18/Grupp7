using System;
using System.Linq;
using Uppgift3_Spel.Rooms;

namespace Uppgift3_Spel.Exits
{
    class LeftOfHallway : Exit
    {
        public LeftOfHallway(Room leadsto, int exitId, bool locked, bool endPoint, string name, string openExit, string lockedString, string examine)
            : base(leadsto, exitId, locked, endPoint, name, openExit, lockedString, examine)
        {
        }

        public override bool Unlock(Player player)
        {
            if (player.PlayerInventory.Any(i => i.Name == "Lighted Torch"))
            {
                Locked = false;
                Console.WriteLine(OpenExit);
                return true;
            }

            Console.Write("It's too dark, ");
            return false;
        }
    }
}
