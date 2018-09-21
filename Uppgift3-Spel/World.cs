using System;
using System.Collections.Generic;

namespace Uppgift3_Spel
{
    internal class World
    {
        private readonly Game _game = new Game();
        private Player _player;
        private List<Room> _rooms = new List<Room>();
        private Room _currentLocation;

        public World()
        {
            NewWorld();
            PlayGame();
        }

        public void NewWorld()
        {
            // Instance of worldbuilder
            WorldBuilder world = new WorldBuilder();
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
                Console.WriteLine("Hello " + _player.Name);
                Console.WriteLine(_currentLocation.Title);
                Console.WriteLine(_currentLocation.Description);
                // Anropa metod för att integrera med spelaren
                _game.PlayerInput(_player, _currentLocation);
                Console.ReadKey();
            }
        }
    }
}
