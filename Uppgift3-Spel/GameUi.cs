using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
            var statement = inputArray[0];

            switch(statement.ToLower())
            {
                case "open":
                    Open(inputArray);
                    break;
                case "use":
                    Use(inputArray);
                    break;
                case "show": case "inventory":
                    Show(inputArray);
                    break;
                case "take":
                    Take(inputArray);
                    break;
                case "go":
                    Go((inputArray));
                    break;
                case "drop":
                    Drop((inputArray));
                    break;
                default:
                    Console.WriteLine();
                    break;
            }
        }

        public void Show(string[] value)
        {
            foreach (var str in value)
            {
                if (str.ToLower() == "inventory")
                {
                    _player.ShowInventory();
                }
            }
        }

        public void Use(string[] value)
        {
            // ordet value
            // kolla om spelaren har det i sitt inventory
            // kolla om det kan användas på det andra föremålet
            // kolla om det kan användas på exit
        }

        public void Open(string[] value)
        {

        }

        public void Take(string[] value)
        {
  
        }
        
        public void Go(string[] value)
        {

        }

        public void Drop(string[] value)
        {

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
