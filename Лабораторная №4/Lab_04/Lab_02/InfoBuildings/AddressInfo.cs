using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.InfoBuildings
{
    [Serializable]
    public class AddressInfo
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Home { get; set; }
        public int Apartment { get; set; }


        public AddressInfo(string country, string city, string street, int home, int apartment)
        {
            Country = country;
            City = city;    
            Street = street;    
            Home = home;    
            Apartment = apartment;  
        }

        public AddressInfo()
        {
        }
    }
}
