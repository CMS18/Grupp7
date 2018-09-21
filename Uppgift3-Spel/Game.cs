namespace Uppgift3_Spel
{
    internal class Game
    {
        private Player _player;
        private Room _room;

        public void PlayerInput(Player player, Room room)
        {
            _room = room;
            _player = player;        
            //Console.WriteLine ("> input");
        }

        // Method to handle user input

        public void PlayerParse()
        {
            // Check user input, split string to array
            // Check if first word matches one of the method, switch?
            // Go to that method
        }

        // Method "Go", "Use", "Open", "Examine/Inspect" "Look"
        // Return true, false?
    }
}
