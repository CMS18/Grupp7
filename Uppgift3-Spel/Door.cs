using System;

namespace Uppgift3_Spel
{
    internal class Door : Exit
    {
        public Door(Room leadsto, int exitId, bool locked, bool endPoint, string name, string openExit, string lockedString, string examine) 
            : base(leadsto, exitId, locked, endPoint, name, openExit, lockedString, examine)
        { }

        public override void Unlock()
        {
            Locked = false;
            if(OpenExit != null)
                Console.WriteLine(OpenExit); // Skriver ut message för openExit om det finns för dörren.
        }
    }
}
