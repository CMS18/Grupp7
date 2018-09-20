using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3_Spel
{
    class Player
    {
        public List<string> Inventory { get; private set; }
        public string Name { get; private set; }
        private bool _alive;
        
        public Player(string name)
        {
            Name = name;
            Inventory = new List<string>();
            _alive = true;
        }

        public void Move()
        {

        }

        public bool isDead() => _alive == false;

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
