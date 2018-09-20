using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3_Spel
{
    public class Room
    {

        public string Title { get; private set; }
        public string Description { get; private set; } 
        public List<Exit> Exit { get; private set; }


        public List<Item> RoomInventory { get; private set; }

        public Room(string title, string description, Exit exit, Item item)
        {
            Console.Title = title;
            Title = title;
            Description = description;
            Exit = new List<Exit>();
            Exit.Add(exit);
            RoomInventory = new List<Item> { item };
        }


        public void ShowRoomDescription()
        {
            Console.WriteLine(Title);
            Console.WriteLine(Description);

            // If item is gone, show other description
        }

        public void RemoveItem()
        {
            // Remove item
            // Change description
        }
    }
}
