namespace Uppgift3_Spel
{
    public class Exit
    {
        public string LeadsTo { get; }
        public int ExitId { get; }
        public bool EndPoint { get; }
        public string ExitName { get; }


        public Exit(string leadsto, int id, string name)
        {
            LeadsTo = leadsto;
            ExitId = id;
            ExitName = name;
            EndPoint = false;
        }

        public Exit(string leadsto, int id, bool endpoint)
        {

        }
    }
}
// Make subclass window, door, ladder?