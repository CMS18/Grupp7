namespace Uppgift3_Spel
{
    public class Exit
    {
        public Room LeadsTo { get; }
        public int ExitId { get; }
        public bool Locked { get; }
        public bool EndPoint { get; }
        public string ExitName { get; }


        public Exit(Room leadsto, int exitId, bool locked, bool endPoint, string name)
        {
            LeadsTo = leadsto;
            ExitId = exitId;
            Locked = locked;
            EndPoint = endPoint;
            ExitName = name;
        }

    }
}