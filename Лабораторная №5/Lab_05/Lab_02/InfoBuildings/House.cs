using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.InfoBuildings
{
    [Serializable]
    public class House
    {
        public House(DateTime date_Buildings, int floor, decimal rooms, int meter, int price)
        {
            Date_Buildings = date_Buildings;
            Floor = floor;
            Rooms = rooms;
            Meter = meter;
            Price = price;
        }

        public House(DateTime date_Buildings, string material, int floor, decimal rooms, int meter, AddressInfo address, int price)
        {
            Date_Buildings = date_Buildings;
            Material = material;
            Floor = floor;
            Rooms = rooms;
            Meter = meter;
            Address = address;
            Price = price;
        }

        public DateTime Date_Buildings { get; set; }
        public string Material { get; set; }
        public int Floor { get; set; }
        public decimal Rooms { get; set; }
        public int Meter { get; set; }
        public string Result { get; set; }
        public AddressInfo Address { get; set; }
        public int Price { get; set; }
    }
}
