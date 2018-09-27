using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using Uppgift3_Spel.Exits;
using Uppgift3_Spel.Items;

namespace Uppgift3_Spel.Rooms
{
    public class Room
    {
        public string Title { get; }
        public string Description { get; set; }
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
            Console.WriteLine(Title);
            Console.WriteLine(Description);
        }

        public virtual void ExamineRoom()
        {
            var sb = new StringBuilder("I can see the following items:");

            foreach (var item in RoomInventory)
            {
                sb.Append(Environment.NewLine + item.Name);
            }

            if (sb.Length == 30)
            {
                Console.WriteLine("There's nothing here...");
                return;
            }
            Examine = sb.ToString();
            Console.WriteLine(Examine);
        }

        public void AddRoomItem(Item item)
        {
            RoomInventory.Add(item);
        }

        public void RemoveRoomItem(Item item)
        {
            if(item != null)
            RoomInventory.Remove(item);
        }

        // Kanske inte behövs
        protected bool ItemExist(string value)
        {
            return RoomInventory.Any(i => string.Equals(i.Name, value, StringComparison.CurrentCultureIgnoreCase));
        }



    }
}
