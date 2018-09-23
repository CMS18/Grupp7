using System;
using System.Collections.Generic;

namespace Uppgift3_Spel
{
    internal class Player
    {
        public List<Item> PlayerInventory { get; }
        public string Name { get; }
        private bool Alive { get; }
        
        public Player(string name)
        {
            Name = name;
            PlayerInventory = new List<Item>();
            Alive = true;
        }

        public bool IsDead() => Alive == false;

        public void PickUpItem(Item item)
        {
            if (item != null)
            {
                PlayerInventory.Add(item);
                Console.WriteLine("Taken.");
            }
            else Console.WriteLine("I can't take that...");
        }

        public void DropItem(Item item)
        {
            PlayerInventory.Remove(item);
            Console.WriteLine($"Dropped {item.Name}.");
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

        public Item GetItemByName(string value)
        {
            return value == null ? null : PlayerInventory.Find
                (i => i.Name.ToLower().Contains(value.ToLower()));
        }

        public Room Go(string direction, Room room)
        {
            var exit = room.GetRoomExitByName(direction);
            if (exit != null) return exit.LeadsTo;

            Console.WriteLine("I can't go there.");
            return null;
        }

    }
}
