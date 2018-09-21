using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3_Spel
{
    internal class Door : Exit
    {
        public Door(Room leadsto, int exitId, bool locked, bool endPoint, string name) 
            : base(leadsto, exitId, locked, endPoint, name)
        {

        }
    }
}
