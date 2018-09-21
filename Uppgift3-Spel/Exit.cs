using System;

namespace Uppgift3_Spel
{
    public class Exit
    {
        public Room LeadsTo { get; private set; }
        public int ExitId { get; }
        public bool Locked { get; set; }
        public bool EndPoint { get; }
        public string ExitName { get; }
        public string OpenExit { get; }
        public string LockedString { get; }


        public Exit(Room leadsto, int exitId, bool locked, bool endPoint, string name, string openExit, string lockedString)
        {
            LeadsTo = leadsto;
            ExitId = exitId;
            Locked = locked;
            EndPoint = endPoint;
            ExitName = name;
            OpenExit = openExit;
            LockedString = lockedString;
        }

        public void Open(Exit exit)
        {
            if (!exit.Locked)
            {
                Console.WriteLine(OpenExit);
            }
        }

        public virtual void Unlock()
        {
            Locked = false;
        }

        public virtual void LockedDescription()
        {
            Console.WriteLine(LockedString);
        }


    }
}