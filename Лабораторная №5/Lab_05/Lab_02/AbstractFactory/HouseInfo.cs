using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_02.AbstractFactory;
using Lab_02.InfoBuildings;

namespace Lab_02.AbstractFactory
{
    public class HouseInfo
    {
        public HouseInfo(DateTime date_Buildings, string material, int floor, decimal rooms, int meter, AddressInfo address, int price)
        {
            Date_Buildings = date_Buildings;
            Material = material;
            Floor = floor;
            Rooms = rooms;
            Meter = meter;
            Address = address;
            Price = price;
        }

        public DateTime Date_Buildings { get; private set; }
        public string Material { get; private set; }
        public int Floor { get; private set; }
        public decimal Rooms { get; private set; }
        public int Meter { get; private set; }
        public AddressInfo Address { get; private set; }
        public int Price { get; private set; }
    }
}
