using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

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
            Console.Write("> ");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) return;
            var playerAction = input.ToPlayerAction();

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
                    Go((input));
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

        // TODO loop to check if currentroom is room, own method? Mycket copy pasta just nu...LARM!
        // TODO Calla och ändra description för nuvarande room? DropItem bör finnas på marken i nya rummet.
        // TODO Kolla player inventory för item i player istället för här? Samma med Rum och Exit i respektive klasser?

        private void Examine(string value)
        {
            var item = _player.GetItemByName(value);
            if (PlayerParse.CheckValue(value, item.Name))
            {
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
