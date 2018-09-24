using System;
using System.Collections.Generic;

namespace Uppgift3_Spel
{
    internal class World
    {
        private readonly GameUi _game = new GameUi();
        private readonly Player _player;
        private readonly List<Room> _rooms;
        private Room _currentLocation;

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
            _currentLocation = _rooms[0]; // Sätter startposition till första index i listan av rum.
            _currentLocation.ShowRoomDescription();
            _game.LoadGameUi(_player, _currentLocation);
            while (!_player.IsDead())
            {
                _game.PlayersTurn();
            }
        }


    }
}
