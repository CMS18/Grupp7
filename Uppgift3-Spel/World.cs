using System;
using System.Collections.Generic;
using Uppgift3_Spel.Rooms;

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
            _rooms = world.GetWorldRooms();
            // Ask player for Name, create Player.
            _player = world.CreateNewPlayer();
            PlayGame();
        }

        public void PlayGame()
        {
            _currentRoom = _rooms[0];
            _currentRoom.ShowRoomDescription();

            while (!_player.Won) // TODO fixa bool för endpoint
            {
               PlayersTurn();
            }
            Victory();
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
                case "move":
                    Move(input);
                    break;
                default:
                    Console.WriteLine("Do what now?");
                    break;
            }
        }

        private void Move(string value)
        {
            foreach (var item in _currentRoom.RoomInventory)
            {
                if (!InputParse.CompareStrings(value, item.Name)) continue;
                item.Use(_player, _currentRoom);
                _currentRoom.RemoveRoomItem(item);
                return;
            }

            Console.WriteLine("I can't do that.");
           
        }

        private void Read(string value)
        {
            foreach (var item in _player.PlayerInventory)
            {
                if (!InputParse.CompareStrings(value, item.Name)) continue;
                item.ShowItemDescription();
                return;
            }
            Console.WriteLine("I can't do that.");
        }

        private void Examine(string value)
        {
            // Examine Room
            if (InputParse.CompareStrings(value, _currentRoom.Title))
            {
                _currentRoom.ExamineRoom();
                return;
            }

            // Examine Item in Room
            foreach (var item in _currentRoom.RoomInventory)
            {
                if (InputParse.CompareStrings(value, item.Name))
                {
                    Console.WriteLine(item.Examine);
                }
            }

            // Examine Item in PlayerInventory
            foreach (var item in _player.PlayerInventory)
            {
                if (!InputParse.CompareStrings(value, item.Name)) continue;
                item.ExamineItem();
                return;
            }

            // Examine Room Exits
            foreach (var exit in _currentRoom.Exit)
            {
                if (!InputParse.CompareStrings(value, exit.ExitName)) continue;
                exit.ExamineExit();
            }
        }

        public void Use(string value)
        {

            // Kolla om användaren tar use på ett exit
            foreach (var item in _player.PlayerInventory)
            {
                if (!InputParse.CompareStrings(value, item.Name)) continue;
                foreach (var exit in _currentRoom.Exit)
                {
                    if (exit.ExitId != item.ItemId || !InputParse.CompareStrings(value, exit.ExitName)) continue;
                    _player.PlayerInventory.Remove(item);
                    exit.Unlock();
                    return;
                }
            }

            // Kolla om final door.
            foreach (var exit in _currentRoom.Exit)
            {
                if (!InputParse.CompareStrings(value, exit.ExitName)) continue;
                exit.Unlock(_player, value);
                return;
            }

            // Kolla om användaren tar use på ett item i rummet
            var playerItem = _player.GetItemFromInventory(value);
            if (playerItem == null) return;
            foreach (var item in _currentRoom.RoomInventory)
            {
                if (!InputParse.CompareStrings(value, item.Name)) continue;
                playerItem.Use(_player, _currentRoom, playerItem);
                return;
            }


            // Kolla om användaren  tar use på ett item i sitt inventory
            var playerFirstItem = _player.GetItemFromInventory(value);
            if (playerFirstItem == null) return;
            playerFirstItem = playerFirstItem.Use(_player, playerFirstItem, value);
            if (playerFirstItem == null) return;
            _player.PlayerInventory.Add(playerFirstItem);

        }

        public void Open(string value)
        {
            foreach (var exit in _currentRoom.Exit)
            {
                if (!InputParse.CompareStrings(value, exit.ExitName)) return;
                if (!exit.Locked && exit.EndPoint)
                {
                    _player.HasWon();

                }
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
                if (!InputParse.CompareStrings(value, item.Name)) continue;
                if (item.TakeAble)
                {
                    _player.PickUpItem(item);
                    _currentRoom.RemoveRoomItem(item);
                    return;
                }
            }
            Console.WriteLine("I can't take that.");
        }

        public void Go(string value)
        {
            foreach (var exit in _currentRoom.Exit)
            {
                if (!InputParse.CompareStrings(value, exit.ExitName)) continue;
                if (exit.Unlock(_player))
                {
                    _currentRoom = exit.LeadsTo;
                    _currentRoom.ShowRoomDescription();
                    break;
                }
            }
        }

        public void Drop(string value)
        {
            foreach (var item in _player.PlayerInventory)
            {
                if (!InputParse.CompareStrings(value, item.Name)) continue;
                _currentRoom.AddRoomItem(item);
                _player.DropItem(item);
                return;
            }
        }

        public void Victory()
        {
            Console.WriteLine($"---------------YOU ARE THE BEST---------------");
            Console.WriteLine($"{_player.Name} escape the dungeon! Total moves: {_moves}, great job!");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}