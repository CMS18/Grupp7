using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Uppgift3_Spel
{
    internal class GameUi
    {
        private Player _player;
        private Room _currentRoom;
        private List<Room> _rooms;

        public void PlayerInput(Player player, Room room, List<Room> rooms)
        {
            _rooms = rooms;
            _currentRoom = room;
            _player = player;
            PlayersTurn();
        }

        // Method to handle user input
        public void PlayersTurn()
        {
            Console.Write("> ");
            var input = Console.ReadLine();
            // om input är tom, gå tillbaks hit.
            
            var inputArray = input.Split(' ');

            switch(inputArray[0].ToLower())
            {
                case "open":
                    break;
                case "use":
                    break;
                case "show":
                    Show(inputArray[1]);
                    break;
                case "take":
                    break;
                case "go":
                    break;
                case "drop":
                    break;
            }
            
        }

        public void Show(string value)
        {
            if (value.ToLower() == "inventory")
            {
                _player.ShowInventory();
            }
        }

        public void Use(string value)
        {
            if (value.ToLower() == "use")
            {

            }
        }

        public void Open(string value)
        {
            if (value.ToLower() == "open")
            {

            }
        }

        public void Take(string value)
        {
            if (value.ToLower() == "take" || value.ToLower() == "pick up")
            {

            }
        }
        
        public void Go(string value)
        {
            if (value.ToLower() == "go")
            {

            }
        }

        public void Drop(string value)
        {
            if(value.ToUpper() == "drop")
            {

            }
        }

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
