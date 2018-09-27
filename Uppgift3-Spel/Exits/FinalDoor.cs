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
        public FinalDoor(Room leadsto, int exitId, bool locked, bool endPoint, string name, string openExit, string lockedString, string examine) : base(leadsto, exitId, locked, endPoint, name, openExit, lockedString, examine)
        {
        }

        public FinalDoor(int exitId, bool locked, bool endPoint, string name, string openExit, string lockedString, string examine) : base(exitId, locked, endPoint, name, openExit, lockedString, examine)
        {
        }
    }
}
