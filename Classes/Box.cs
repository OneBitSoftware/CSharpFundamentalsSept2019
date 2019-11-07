using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    class Box
    {
        public Box()
        {
            //Item = new Item();
        }

        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal PriceInBox { get; set; }
    }
}
