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
        private List<Room> _rooms;
        private bool _alive;
        private bool _victory;
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
            _rooms = world._rooms;

            // Ask player for Name, create Player.
            _player = world.CreateNewPlayer();

        }

        public void PlayingGame()
        {
            while(_alive || !_victory)
            {
                // Playing here

            }
        }

        public void PlayerParse()
        {
            
        }
    }
}
