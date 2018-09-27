using Uppgift3_Spel.Rooms;

namespace Uppgift3_Spel.Exits
{
    class RightOfHallway : Exit
    {
        public RightOfHallway(Room leadsto, int exitId, bool locked, bool endPoint, string name, string openExit, string lockedString, string examine) : base(leadsto, exitId, locked, endPoint, name, openExit, lockedString, examine)
        {
        }

        public override bool Unlock(Player player)
        {
            Locked = false;
            return true;
        }
    }
}
