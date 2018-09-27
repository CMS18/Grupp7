using System;
using System.Collections.Generic;
using System.Linq;
using Uppgift3_Spel.Items;

namespace Uppgift3_Spel
{
    public class Player
    {
        public List<Item> PlayerInventory { get; }
        public string Name { get; }
        
        public Player(string name)
        {
            Name = name;
            PlayerInventory = new List<Item>();
        }

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
                    Console.WriteLine($"{item.Name, -10} : {item.Description}");
                }   
            }
        }

        public Item GetItemFromInventory(string value)
        {
            var compareArray = value.Split(' ').ToArray();
            foreach (var item in PlayerInventory)
            {
                foreach (var str in compareArray)
                {
                    if (item.Name.ToLower().Contains(str.ToLower()))
                        return item;
                }
            }

            return null;
        }

    }
}
