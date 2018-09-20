namespace Uppgift3_Spel
{
    public class Exit
    {
        public string LeadsTo { get; private set; }

        public Exit(string leadsto)
        {
            LeadsTo = leadsto;
        }
    }
}