using System;
using System.Collections.Generic;
using System.Text;

namespace Automated_Warehouse
{
    class Shelf
    {
        public string Name { get; set; }
        public Package[,] Containers = new Package[0, 0];
    }
}
