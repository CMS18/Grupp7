using System;

namespace Uppgift3_Spel.Items
{
    public class Item
    {
        public string Name { get; }
        public string Description { get; }
        public string Examine { get; }
        public int ItemId { get; }
        public bool TakeAble { get; }

        public Item(string name, string description, int id, string examine)
        {
            Name = name;
            Description = description;
            ItemId = id;
            Examine = examine;
            TakeAble = true;
        }

        public Item(string name, string description, int id, string examine, bool takeAble)
        {
            Name = name;
            Description = description;
            ItemId = id;
            Examine = examine;
            TakeAble = takeAble;
        }

        public void ShowItemDescription()
        {
            Console.WriteLine(Description);
        }

        public virtual Item Use(Player player, Item item)
        {
            return null;
        }

        public virtual void Use(Player player, Room room, Item item)
        {
            //
        }

        public virtual void Use(Player player, Room room) { }

        public void ExamineItem()
        {
            Console.WriteLine(Examine);
        }
    }
}
