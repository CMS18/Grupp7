using System;
using System.Collections.Generic;

namespace Uppgift3_Spel
{
    internal class Player
    {
        public List<Item> PlayerInventory { get; }
        public string Name { get; }
        private readonly bool _alive;
        
        public Player(string name)
        {
            Name = name;
            PlayerInventory = new List<Item>();
            _alive = true;
        }

        public bool IsDead() => _alive == false;

        public void PickUpItem()
        {

        }

        public void ShowInventory()
        {
            if(PlayerInventory.Count == 0) Console.WriteLine("Your inventory is empty.");

            foreach (var item in PlayerInventory)
            {
                if (item != null)
                {
                    Console.WriteLine(item.Name);
                }   
            }
        }
    }
}
