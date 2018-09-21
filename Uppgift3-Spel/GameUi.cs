using System;
using System.Collections.Generic;

namespace Uppgift3_Spel
{
    internal class GameUi
    {
        private Player _player;
        private Room _currentRoom;
        private List<Room> _rooms;

        public void LoadGameUi(Player player, List<Room> rooms, Room room)
        {
            _currentRoom = room;
            _rooms = rooms;
            _player = player;
        }

        // Method to handle user input
        public void PlayersTurn()
        {      
                Console.Clear();
                _currentRoom.ShowRoomDescription();
                Console.Write("> ");
                var input = Console.ReadLine();
                if (input == null) return;

                var inputArray = input.Split(' ');
                var statement = inputArray[0];

                switch (statement.ToLower())
                {
                    case "open":
                        Open(inputArray);
                        break;
                    case "use":
                        Use(inputArray);
                        break;
                    case "look":
                        _currentRoom.ShowRoomDescription();
                        break;
                    case "show":
                    case "inventory":
                        Show(inputArray);
                        break;
                    case "take":
                    case "pickup":
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
            foreach (var str in value)
            {
                foreach(var item in _player.PlayerInventory)
                {
                    if (!item.Name.ToLower().Contains(str)) continue;
                    foreach (var room in _rooms)
                    {
                        if (room != _currentRoom) continue;
                        foreach (var exit in room.Exit)
                        {
                            if (exit.ExitId == item.ItemId)
                            {
                                exit.Locked = false;
                            }
                        }
                    }
                }
            }

        }

        public void Open(string[] value)
        {
            foreach (var str in value)
            {
                foreach (var room in _rooms)
                {
                    if (room == _currentRoom)
                    {
                        foreach (var exit in room.Exit)
                        {
                            if (!exit.Locked)
                            {
                                _currentRoom = exit.LeadsTo;
                            }
                        }
                    }
                }
            }
        }

        public void Take(string[] value)
        {
            foreach (var str in value)
            {
                foreach (var room in _rooms)
                {
                    if (room == _currentRoom)
                    {
                        foreach (var item in room.RoomInventory)
                        {
                            if (item.Name.ToLower().Contains(str))
                            {
                                _player.PlayerInventory.Add(item);
                                room.RoomInventory.Remove(item);
                                Console.WriteLine("Taken.");
                                return;
                            }
                        }
                    }
                }
            }
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
