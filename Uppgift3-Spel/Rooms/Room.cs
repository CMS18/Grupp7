using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uppgift3_Spel.Exits;
using Uppgift3_Spel.Items;

namespace Uppgift3_Spel.Rooms
{
    public class Room
    {
        public string Title { get; }
        public string Description { get; protected set; }
        public string Examine { get; protected set; }
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

        public virtual void ShowRoomDescription()
        {
            Console.WriteLine(Title);
            Console.WriteLine(Description);
            ExamineRoom();
        }

        public Exit GetExitFromRoom(string value)
        {
            var compareArray = value.Split(' ').ToArray();
            foreach (var exit in Exit)
            {
                if (compareArray.Any(str => exit.ExitName.ToLower().Contains(str.ToLower())))
                {
                    return exit;
                }
            }
            return null;
        }


        public virtual void ExamineRoom()
        {
            var sb = new StringBuilder("There's following items in here:  ");

            foreach (var item in RoomInventory)
            {
                if (RoomInventory.Count == 1)
                {
                    sb.Clear();
                    sb.Append($"There's a {item.Name} here.");
                    break;
                }
                sb.Append(Environment.NewLine + item.Name);
            }
            if (sb.Length == 34)
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



    }
}
