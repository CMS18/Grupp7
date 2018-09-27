using System;

namespace Uppgift3_Spel.Exits
{
    internal class FinalDoor : Exit
    {
        public FinalDoor(int exitId, bool locked, bool endPoint, string name, string openExit, string lockedString, string examine) : base(exitId, locked, endPoint, name, openExit, lockedString, examine)
        { }

        public override void Unlock(Player player, string value)
        {
            Console.WriteLine();
            Console.Write("The combination is four numbers: ");
            value = Console.ReadLine();
            if (value == "1483")
            {
                Console.Beep(440, 200);
                Console.Beep(500, 200);
                Console.Beep(700, 200);
                Console.Beep(600, 200);
                Locked = false;
                EndPoint = true;
                Console.WriteLine(OpenExit);
                Examine = "The door is unlocked, let's get out of here!";
                return;
            }
            Console.Beep(440, 200);
            Console.Beep(600, 200);
            Console.Beep(300, 200);
            Console.Beep(500, 200);
            Console.WriteLine("Incorrect combination.");
        }

        public override void LockedDescription() => Console.WriteLine(LockedString);
    }
}
