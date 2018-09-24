using System;

namespace Uppgift3_Spel
{
    internal class GameUi
    {
        private Player _player;
        private Room _currentRoom;
        private int _moves = 0;

        public void LoadGameUi(Player player, Room room)
        {
            _currentRoom = room;
            _player = player;
        }

        // Method to handle user input
        public void PlayersTurn()
        {
            Console.Title = _currentRoom.Title.PadRight(100) + "Moves: " + _moves;
            Console.Write("> ");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) return;
            var playerAction = input.ToPlayerAction();
            if (playerAction == null) return;
            _moves++;

            switch (playerAction.ToLower())
            {
                case "open":
                    Open(input);
                    break;
                case "use":
                    Use(input);
                    break;
                case "look":
                    _currentRoom.ShowRoomDescription();
                    break;
                case "show": case "inventory":
                    _player.ShowInventory();
                    break;
                case "take": case "pickup":
                    Take(input);
                    break;
                case "go":
                    Go(input);
                    break;
                case "drop":
                    Drop(input);
                    break;
                case "read":
                    Read(input);
                    break;
                case "examine":
                    Examine(input);
                    break;
                case "turn":
                    // TODO turn note to read other side.
                    break;
                default:
                    Console.WriteLine("Do what now?");
                    break;
            }
        }

        private void Read(string value)
        {
            foreach (var item in _player.PlayerInventory)
            {
                if (!PlayerParse.CheckValue(value, item.Name)) continue;
                item.ShowItemDescription();
                break;
            }
        }

        private void Examine(string value)
        {
            if (PlayerParse.CheckValue(value, _currentRoom.Title))
            {
                _currentRoom.ExamineRoom();
                return;
            }
            foreach (var item in _player.PlayerInventory)
            {
                if (!PlayerParse.CheckValue(value, item.Name)) continue;
                item.ExamineItem();
                return;
            }
            foreach (var exit in _currentRoom.Exit)
            {
                if (!PlayerParse.CheckValue(value, exit.ExitName)) continue;
                exit.ExamineExit();
            }
        }

        public void Use(string value)
        {
            foreach (var item in _player.PlayerInventory)
            {
                if (!PlayerParse.CheckValue(value, item.Name)) continue;
                foreach (var exit in _currentRoom.Exit)
                { 
                    if (exit.ExitId != item.ItemId || !PlayerParse.CheckValue(value, exit.ExitName)) continue;
                    _player.DropItem(item); 
                    exit.Unlock();
                    return;
                }
                Console.WriteLine("I can't use that...");
            }
        }

        public void Open(string value)
        {
            foreach (var exit in _currentRoom.Exit)
            {
                if (!PlayerParse.CheckValue(value, exit.ExitName)) return;
                if(!exit.Locked)
                {
                    _currentRoom = exit.LeadsTo;
                    _currentRoom.ShowRoomDescription();
                    return;
                }
                exit.LockedDescription();
                return;
            }
        }

        public void Take(string value)
        {
            foreach (var item in _currentRoom.RoomInventory)
            {
                if (!PlayerParse.CheckValue(value, item.Name)) continue;
                _player.PickUpItem(item);
                _currentRoom.RemoveRoomItem(item);
                return;
            }
        }
        
        public void Go(string value)
        {
            foreach (var exit in _currentRoom.Exit)
            {
                if (!PlayerParse.CheckValue(value, exit.ExitName)) continue;
                _currentRoom = exit.LeadsTo;
                _currentRoom.ShowRoomDescription();
                break;
            }
        }

        public void Drop(string value)
        {
            foreach (var item in _player.PlayerInventory)
            {
                if (!PlayerParse.CheckValue(value, item.Name)) continue;
                _currentRoom.AddRoomItem(item);
                _player.DropItem(item);
                return;
            } 
        }
    }
}
