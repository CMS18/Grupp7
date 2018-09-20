using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3_Spel
{
    class Item
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public virtual void Use()
        {

        }

        public void InspectItem()
        {
            
        }
    }
}
