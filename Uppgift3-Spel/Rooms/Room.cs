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
            var sb = new StringBuilder("I can see following items here: ");
            var count = RoomInventory.Count();
            switch (count)
            {
                case 0:
                    Console.WriteLine("There's no items here...");
                    return;
                case 1:
                    sb.Clear();
                    sb.Append("I can see the following item here: ");
                    break;
            }
            var shouldBeComma = false;
            for (int i = 0; i < count; i++)
            {
                if (shouldBeComma) sb.Append(", ");
                shouldBeComma = true;
                sb.Append($"{RoomInventory[i].Name}");
            }
            sb.Append(".");

            Examine = sb.ToString();
            Console.WriteLine(Examine);
        }

        public void AddRoomItem(Item item) => RoomInventory.Add(item);

        public void RemoveRoomItem(Item item)
        {
            if(item != null)
            RoomInventory.Remove(item);
        }
    }
}
