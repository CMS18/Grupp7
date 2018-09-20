﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3_Spel
{
    public class Item
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int ItemId { get; private set; }

        public Item(string name, string description, int id)
        {
            Name = name;
            Description = description;
            ItemId = id;
        }

        public virtual void Use()
        {

        }

        public void InspectItem()
        {
            
        }
    }
}
