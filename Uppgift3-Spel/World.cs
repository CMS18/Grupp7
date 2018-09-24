using System;
using System.Collections.Generic;

namespace Uppgift3_Spel
{
    internal class World
    {
        private readonly Player _player;
        private readonly List<Room> _rooms;
        private Room _currentRoom;
        private int _moves;

        public World()
        {
            // Instance of worldbuilder
            var world = new WorldBuilder();
            // Set worldbuilder's room list to _rooms
            _rooms = world.Rooms;
            // Ask player for Name, create Player.
            _player = world.CreateNewPlayer();
            PlayGame();
        }

        public void PlayGame()
        {
            _currentRoom = _rooms[0]; // Sätter startposition till första index i listan av rum.
            _currentRoom.ShowRoomDescription();

            while (!_player.IsDead())
            {
               PlayersTurn();
            }
        }

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
                case "show":
                case "inventory":
                    _player.ShowInventory();
                    break;
                case "take":
                case "pickup":
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
                case "help":
                    Help();
                    break;
                default:
                    Console.WriteLine("Do what now?");
                    break;
            }
        }

        private void Help()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Usable commands:\n" +
                              "open, use, look, show, take, go, drop, examine, turn, read, turn");
            Console.ResetColor();
        }

        private void Read(string value)
        {
            foreach (var item in _player.PlayerInventory)
            {
                if (!PlayerParse.CompareStrings(value, item.Name)) continue;
                item.ShowItemDescription();
                break;
            }
        }

        private void Examine(string value)
        {
            if (PlayerParse.CompareStrings(value, _currentRoom.Title))
            {
                _currentRoom.ExamineRoom();
                return;
            }

            foreach (var item in _currentRoom.RoomInventory)
            {
                if (PlayerParse.CompareStrings(value, item.Name))
                {
                    Console.WriteLine(item.Examine);
                }
            }

            foreach (var item in _player.PlayerInventory)
            {
                if (!PlayerParse.CompareStrings(value, item.Name)) continue;
                item.ExamineItem();
                return;
            }
            foreach (var exit in _currentRoom.Exit)
            {
                if (!PlayerParse.CompareStrings(value, exit.ExitName)) continue;
                exit.ExamineExit();
            }
        }

        public void Use(string value)
        {
            // Check Exits
            foreach (var item in _player.PlayerInventory)
            {
                if (!PlayerParse.CompareStrings(value, item.Name)) continue;
                foreach (var exit in _currentRoom.Exit)
                {
                    if (exit.ExitId != item.ItemId || !PlayerParse.CompareStrings(value, exit.ExitName)) continue;
                    _player.PlayerInventory.Remove(item);
                    exit.Unlock();
                    return;
                }
            }

            // Check Room Items
            var playerItem = _player.GetItemFromInventory(value);
            if (playerItem == null) return;
            foreach (var item in _currentRoom.RoomInventory)
            {
                if (!PlayerParse.CompareStrings(value, item.Name)) continue;
                playerItem.Use(_player, _currentRoom, playerItem);
                break;
            }

            // Check Player Items
            var playerFirstItem = _player.GetItemFromInventory(value);
            if (playerFirstItem == null) return;
            playerFirstItem = playerFirstItem.Use(_player, playerFirstItem);
            _player.PlayerInventory.Add(playerFirstItem);

        }

        public void Open(string value)
        {
            foreach (var exit in _currentRoom.Exit)
            {
                if (!PlayerParse.CompareStrings(value, exit.ExitName)) return;
                if (!exit.Locked)
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
                if (!PlayerParse.CompareStrings(value, item.Name)) continue;
                if (item.TakeAble)
                {
                    _player.PickUpItem(item);
                    _currentRoom.RemoveRoomItem(item);
                    return;
                }

            }
        }

        public void Go(string value)
        {
            foreach (var exit in _currentRoom.Exit)
            {
                if (!PlayerParse.CompareStrings(value, exit.ExitName)) continue;
                _currentRoom = exit.LeadsTo;
                _currentRoom.ShowRoomDescription();
                break;
            }
        }

        public void Drop(string value)
        {
            foreach (var item in _player.PlayerInventory)
            {
                if (!PlayerParse.CompareStrings(value, item.Name)) continue;
                _currentRoom.AddRoomItem(item);
                _player.DropItem(item);
                return;
            }
        }






    }
}
