using System;
using System.Collections.Generic;
using Uppgift3_Spel.Items;

namespace Uppgift3_Spel
{
    public class Room
    {
        public string Title { get; }
        public string Description { get; }
        public string Examine { get; set; }
        public List<Exit> Exit { get; }
        public List<Item> RoomInventory { get; }

        public Room(string title, string description, string examine)
        {
            Title = title;
            Description = description;
            Exit = new List<Exit>();
            RoomInventory = new List<Item>();
            Examine = examine;
        }

        // TODO overload om flera items finns i inventoryt?
        // TODO method to change room description if item is removed.
        public virtual void ShowRoomDescription()
        {
            Console.Title = Title;
            Console.WriteLine(Title);
            Console.WriteLine(Description);
        }

        public void ExamineRoom()
        {
            Console.WriteLine(Examine);
        }

        public void AddRoomItem(Item item)
        {
            RoomInventory.Add(item);
            // TODO update Examine om fler items läggs till, eller tas bort.
        }

        public void RemoveRoomItem(Item item)
        {
            if(item != null)
            RoomInventory.Remove(item);
        }

        

    }
}
