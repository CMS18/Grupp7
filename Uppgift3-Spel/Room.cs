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

        public Room(string title, string description)
        {
            Title = title;
            Description = description;
            Exit = new List<Exit>();
            RoomInventory = new List<Item>();
        }

        public Item GetRoomItemByName(string value)
        {
            return value == null ? null : RoomInventory.Find
                (i => i.Name.ToLower().Contains(value.ToLower()));
        }

        // TODO overload om flera items finns i inventoryt?
        // TODO method to change room description if item is removed.
        public void ShowRoomDescription()
        {
            Console.Title = Title;
            Console.WriteLine(Title);
            Console.WriteLine(Description);
        }

        public void AddRoomItem(Item item) => RoomInventory.Add(item);

        public void RemoveRoomItem(Item item)
        {
            if(item != null)
            RoomInventory.Remove(item);
        }

        public Exit GetRoomExitByName(string value)
        {
            return value == null ? null : Exit.Find
                (e => e.ExitName.ToLower().Contains(value.ToLower()));
        }

        

    }
}
