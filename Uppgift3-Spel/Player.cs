using System.Collections.Generic;

namespace Uppgift3_Spel
{
    internal class Player
    {
        public List<string> PlayerInventory { get; }
        public string Name { get; }
        private readonly bool _alive;
        
        public Player(string name)
        {
            Name = name;
            PlayerInventory = new List<string>();
            _alive = true;
        }

        public void Move()
        {

        }

        public bool IsDead() => _alive == false;

        public void Look() //Room
        {

        }

        public void PickUpItem()
        {

        }

        public void ShowInventory()
        {

        }

        public void UseItem()
        {

        }
    }
}
