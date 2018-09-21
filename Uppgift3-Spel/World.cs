using System;
using System.Collections.Generic;

namespace Uppgift3_Spel
{
    internal class World
    {
        private readonly GameUi _game = new GameUi();
        private Player _player;
        private List<Room> _rooms;
        private Room _currentLocation;

        public World()
        {
            NewWorld();
            PlayGame();
        }

        public void NewWorld()
        {
            // Instance of worldbuilder
            var world = new WorldBuilder();
            // Set worldbuilder's room list to _rooms
            _rooms = world.Room;
            // Ask player for Name, create Player.
            _player = world.CreateNewPlayer();
        }

        public void PlayGame()
        {
            _currentLocation = _rooms[0]; // Sätter startposition till första index i listan av rum.
            while(!_player.IsDead()) // or _rooms endpoint !true
            {
                _currentLocation.ShowRoomDescription();
                _game.PlayerInput(_player, _currentLocation, _rooms);
                Console.ReadKey();
            }
        }
    }
}
