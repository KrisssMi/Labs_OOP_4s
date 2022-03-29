﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.InfoBuildings
{
    [Serializable]
    public class Building
    {
        public List<House> Houses { get; set; }
        public AddressInfo Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Home { get; set; }
        public int Apartment { get; set; }
        public DateTime Date_Buildings { get;  set; }
        public string Material { get; set; }
        public int Floor { get; set; }
        public decimal Rooms { get; set; }
        public int Meter { get; set; }
        public int Price { get; set; }
        public string Type { get;  set; }
        public string Garage { get;  set; }

        public Building()
        {
            Houses = new List<House>();
            Address = new AddressInfo();
        }


        public Building(string country, string city, string street, int home, int apartment, string garage, string type)
        {;
            Country = country;
            City = city;    
            Street = street;    
            Home = home;    
            Apartment = apartment; 
            Garage = garage;
            Type = type;
        }

        public Building(string city, string street, int home, int apartment, string garage, string type)
        {
            City = city;
            Street = street;
            Home = home;
            Apartment = apartment;
            Garage = garage;
            Type = type;
        }

        public override string ToString()   /// вывод инфы об объекте
        {

            string res = $"\t\t BUILDER: \nСтрана: {Country}\nГород: {City}\nУлица: {Street}\n" +
                $"Дом: {Home}\nКвартира: {Apartment}" +
                $"\nГараж: {Garage}\nТип: {Type}"
            +"\n____________________________________\n\n";
            return res;
        }
    }
}
