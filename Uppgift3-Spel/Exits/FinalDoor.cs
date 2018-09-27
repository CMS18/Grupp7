using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift3_Spel.Rooms;

namespace Uppgift3_Spel.Exits
{
    class FinalDoor : Exit
    {
        public FinalDoor(int exitId, bool locked, bool endPoint, string name, string openExit, string lockedString, string examine) : base(exitId, locked, endPoint, name, openExit, lockedString, examine)
        {
        }

        public override void Unlock(Player player, string value)
        {
            Console.WriteLine();
            Console.Write("The combination is four numbers: ");
            value = Console.ReadLine();
            if (value == "1483")
            {
                Locked = false;
                EndPoint = true;
                Console.WriteLine(OpenExit);
                Examine = "The door is unlocked, let's get out of here!";
                return;
            }
            Console.WriteLine("Incorrect combination.");
        }

        public override void LockedDescription() => Console.WriteLine(LockedString);
    }
}
