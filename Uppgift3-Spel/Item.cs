using System;

namespace Uppgift3_Spel
{
    public class Item
    {
        public string Name { get; }
        public string Description { get; }
        public string Examine { get; }
        public int ItemId { get; }

        public Item(string name, string description, int id, string examine)
        {
            Name = name;
            Description = description;
            ItemId = id;
            Examine = examine;
        }

        public virtual void Use()
        {
            // Do stuff
        }

        public void ExamineItem()
        {
            Console.WriteLine(Examine);
        }
    }
}
