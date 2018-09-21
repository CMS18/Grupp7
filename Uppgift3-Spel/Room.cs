using System;
using System.Collections.Generic;

namespace Uppgift3_Spel
{
    public class Room
    {
        public string Title { get; }
        public string Description { get; } 
        public List<Exit> Exit { get; }
        public List<Item> RoomInventory { get; }

        public Room(string title, string description, Exit exit, Item item)
        {
            Console.Title = title;
            Title = title;
            Description = description;
            Exit = new List<Exit> {exit};
            RoomInventory = new List<Item> { item };
        }

        public Room(string title, string description)
        {
            Title = title;
            Description = description;
            Exit = new List<Exit>();
            RoomInventory = new List<Item>();
        }


        public void ShowRoomDescription()
        {
            Console.Title = Title;
            Console.WriteLine(Title);
            Console.WriteLine(Description);

            // If item is gone, show other description?
        }

        public void RemoveItem(Item item)
        {
            RoomInventory.Remove(item);
            // Change description?
        }

    }
}
