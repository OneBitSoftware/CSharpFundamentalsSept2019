using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    class Catalog
    {
        public Catalog()
        {
            Cars = new List<Car>();
            //Trucks = new List<Truck>();
        }
        public List<Car> Cars { get; }
        public List<Truck> Trucks { get; set; }

    }
}
