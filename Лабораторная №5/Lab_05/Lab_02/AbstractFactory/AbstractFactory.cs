using Lab_02.InfoBuildings;
using System;
using System.Collections.Generic;

namespace Lab_02.AbstractFactory
{
    /* порождающий паттерн проектирования, 
     * который позволяет создавать семейства связанных объектов, 
     * не привязываясь к конкретным классам создаваемых объектов */

    public interface IAbstractFactory
    {
        House CreateHouse();             
    }

    public class NativeBuildingFileFactory : IAbstractFactory
    {
        private readonly DateTime _date_Buildings;
        private readonly string _material;
        private int _floor;
        private decimal _rooms;
        private int _meter;
        private AddressInfo _address;
        private int _price;


        public NativeBuildingFileFactory(Form1 currentForm)
        {
        }

        public NativeBuildingFileFactory(DateTime dateTime,
            string material, int floor, decimal rooms, int meter, AddressInfo address, int price)
        {
            _date_Buildings= dateTime;
            _material = material;   
            _floor = floor; 
            _rooms = rooms;
            _meter = meter; 
            _address = address; 
            _price = price;
        }

        public House CreateHouse()
        {
            return new House(_date_Buildings, _material, _floor, _rooms, _meter, _address, _price);
        }
    }
}
