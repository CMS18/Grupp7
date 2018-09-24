﻿using System;

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

        public void ShowItemDescription()
        {
            Console.WriteLine(Description);
        }

        public virtual Item Use(Item item)
        {
            return null;
        }

        public void ExamineItem()
        {
            Console.WriteLine(Examine);
        }
    }
}