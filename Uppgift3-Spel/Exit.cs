namespace Uppgift3_Spel
{
    public class Exit
    {
        public string LeadsTo { get; private set; }
        public int ExitId { get; private set; }
        public bool EndPoint { get; private set; }


        public Exit(string leadsto, int id)
        {
            LeadsTo = leadsto;
            ExitId = id;
            EndPoint = false;
        }

        public Exit(string leadsto, int id, bool endpoint)
        {

        }
    }
}