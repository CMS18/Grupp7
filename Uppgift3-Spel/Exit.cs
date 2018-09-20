namespace Uppgift3_Spel
{
    public class Exit
    {
        public string LeadsTo { get; private set; }
        public int ExitId { get; private set; }
        public bool EndPoint { get; private set; }
        public string ExitName { get; private set; }


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