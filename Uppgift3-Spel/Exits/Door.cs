using System;
using Uppgift3_Spel.Rooms;

namespace Uppgift3_Spel.Exits
{
    internal class Door : Exit
    {
        public Door(Room leadsto, int exitId, bool locked, bool endPoint, string name, string openExit, string lockedString, string examine) 
            : base(leadsto, exitId, locked, endPoint, name, openExit, lockedString, examine)
        { }

        public override void Unlock()
        {
            Locked = false;
            Console.WriteLine(OpenExit);
            Examine = "A brown wooden door, the lock is broken and the key is stuck inside.";
        }
    }
}
