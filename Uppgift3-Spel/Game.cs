using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3_Spel
{
    class Game
    {
        private Player _player;
        private List<Room> _rooms = new List<Room>();
        private Room _currentLocation;

        public Game()
        {
            NewGame();
        }

        public void NewGame()
        {
            // Load WorldBuilder
            WorldBuilder world = new WorldBuilder();

            // Set worldbuilder room list to _rooms
            _rooms = world._room;

            // Ask player for Name, create Player.
            _player = world.CreateNewPlayer();

            // Go to PlayingGame
            PlayingGame();
        }

        public void PlayingGame()
        {
            _currentLocation = _rooms[0]; // Sätter startposition till första index i listan av rum.

            while(!_player.isDead()) // or _rooms endpoint !true
            {
                Console.WriteLine("Hello " + _player.Name);
                Console.WriteLine(_currentLocation.Title);
                Console.WriteLine(_currentLocation.Description);
                Console.ReadKey();
            }
        }
    }
}
