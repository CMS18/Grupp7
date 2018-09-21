using System;
using System.Collections.Generic;
using System.Linq;

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

        private static bool PlayerParse(string[] compare, string compareTo)
        {
            foreach (var str in compare)
            {
                if (compareTo.ToLower().Contains(str))
                    return true;
            }
            return false;
        }


        // Method to handle user input
        public void PlayersTurn()
        {      
            Console.Write("> ");
            var input = Console.ReadLine();
            if (input == null) return;
            var inputArray = input.Split(' ');
            var statement = inputArray[0];
            var inputString = inputArray.Skip(1).ToArray();

                switch (statement.ToLower())
                {
                    case "open":
                        Open(inputString);
                        break;
                    case "use":
                        Use(inputString);
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
                        Take(inputString);
                        break;
                    case "go":
                        Go((inputArray));
                        break;
                    case "drop":
                        Drop((inputArray));
                        break;
                    default:
                        Console.WriteLine("I don't understand what you want?");
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
            foreach (var item in _player.PlayerInventory)
            {
                if (!PlayerParse(value, item.Name)) continue;
                foreach (var room in _rooms)
                {
                    if (room != _currentRoom) continue;
                    foreach (var exit in room.Exit)
                    {
                        if (exit.ExitId == item.ItemId && PlayerParse(value, exit.ExitName))
                        {
                            Console.WriteLine("Its unlocked!");
                            exit.Locked = false;
                        }
                    }
                }
            }
        }

        public void Open(string[] value)
        {
            foreach (var room in _rooms)
            {
                if (room != _currentRoom) continue;
                foreach (var exit in room.Exit)
                {
                    if (exit.Locked)
                    {
                        // Tillfällig
                        Console.WriteLine("The door is locked. There is a keyhole... maybe there's a key?");
                        return;
                    }
                    if(!exit.Locked && PlayerParse(value, exit.ExitName))
                    {
                        _currentRoom = exit.LeadsTo;
                    }
                }
            }
            
        }

        public void Take(string[] value)
        {
            foreach (var room in _rooms)
            {
                if (room != _currentRoom) continue;
                foreach (var item in room.RoomInventory)
                {
                    if (PlayerParse(value, item.Name))
                    {
                        _player.PlayerInventory.Add(item);
                        room.RoomInventory.Remove(item);
                        Console.WriteLine("Taken.");
                        return;
                    }
                }
            } 
        }
        
        public void Go(string[] value)
        {

        }

        public void Drop(string[] value)
        {
            foreach (var str in value)
            {
                foreach (var room in _rooms)
                {
                    if (room == _currentRoom)
                    {
                        foreach (var item in _player.PlayerInventory)
                        {
                            if(item.Name.ToLower().Contains(str))
                            {
                                room.RoomInventory.Add(item);
                                _player.PlayerInventory.Remove(item);
                                Console.WriteLine("Dropped " + item.Name + ".");
                                return;
                            }
                        }
                    }
                }
            }
        }

        // Method for mainscreen

        // Method "Go", "Use", "Open", "Examine/Inspect" "Look"
        // Return true, false?
    }
}
