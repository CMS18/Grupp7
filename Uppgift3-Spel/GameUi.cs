using System.Collections.Generic;

namespace Uppgift3_Spel
{
    internal class GameUi
    {
        private Player _player;
        private Room _room;
        private List<Room> _rooms;

        public void PlayerInput(Player player, Room room, List<Room> rooms)
        {
            _rooms = rooms;
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

        // Method for mainscreen

        // Method "Go", "Use", "Open", "Examine/Inspect" "Look"
        // Return true, false?
    }
}
