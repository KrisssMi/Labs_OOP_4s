using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02
{
    [Serializable]
    public class Building
    {
        public List<House> Houses { get; set; }
        public Address Address { get; set; }
        public Building()
        {
            Houses = new List<House>();
            Address = new Address();
        }
    }
}
