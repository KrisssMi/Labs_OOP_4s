using Lab_02.InfoBuildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02
{
    // абстрактный класс билдера
    abstract class Builders
    {
        public Building Building { get; private set; }                      // в этот обьект будем создавать адрес с помощью конкретных билдеров по шагам:

        // эти методы будем переопределять в каждом конкретном билдере
        public void CreateBuilding() => Building = new Building();          // 0. создать пустой объект
        public abstract void BuildHouse();                                  // 1. создать дом
        public abstract void BuildAddress();                                // 2. создать весь адрес
    }


    // класс директора, который делегирует билдеру создание постройки
    class Director
    {
        // в этот список запишем пару построек и выведем их в MessageBox
        public static List<Building> listOfHousesBuilder = new List<Building>();

        // метод директора, который приказывает билдеру пошагово создать постройку и вернуть ее
        public Building ConstuctAll(Builders builder)
        {
            builder.CreateBuilding();
            builder.BuildHouse();
            builder.BuildAddress();
            return builder.Building;
        }


        // что-то вроде мейна, здесь каждый раз при нажатии баттона будет добавляться в список один рандомный адрес
        public static void BuilderMain()
        {
            Director director = new Director();         // экземпляр директора

            Random random = new Random();               // рандом число от 1 до 4 (т.к. кейсов всего 4)
            int value = random.Next(1, 5);

            switch (value) 
            {
                case 1:
                    Builders builderHouse_1 = new builderHouse_1();             // постройка типа builderHouse_1
                    Building house_1 = director.ConstuctAll(builderHouse_1);    // создаем первый дом с помощью первой постройки
                    listOfHousesBuilder.Add(house_1);                           // добавляем в список, который потом выведем на экран
                    break;
                case 2:
                    Builders builderHouse_2 = new builderHouse_2();             // постройка типа builderHouse_2
                    Building house_2 = director.ConstuctAll(builderHouse_2);    // создаем второй дом с помощью второй постройки
                    listOfHousesBuilder.Add(house_2);                           // добавляем в список который, потом выведем на экран
                    break;
                case 3:
                    Builders builderHouse_3 = new builderHouse_3();             // постройка типа builderHouse_3
                    Building house_3 = director.ConstuctAll(builderHouse_3);    // создаем третий дом с помощью третьей постройки
                    listOfHousesBuilder.Add(house_3);                           // добавляем в список, который потом выведем на экран
                    break;
                case 4:
                    Builders builderHouse_4 = new builderHouse_4();             // постройка типа builderHouse_4
                    Building house_4 = director.ConstuctAll(builderHouse_4);    // создаем четвёртый дом с помощью четвёртой постройки
                    listOfHousesBuilder.Add(house_4);                           // добавляем в список, который потом выведем на экран
                    break;
            }
        }
    }


    class builderHouse_1 : Builders             // первый конкретный билдер: создать постройку по house_1
    {
        public override void BuildHouse()       // переопределяем: дом
        {
            House house= new House(new DateTime(2015, 7, 20),4,3,20, 1500);
        }

        public override void BuildAddress()     // переопределяем всю инфу о постройке
        {
            Building.Country = "Belarus";
            Building.City = "Minsk";
            Building.Street = "Sverdlova";
            Building.Home = 13;
            Building.Apartment = 1;
        }
    }


    class builderHouse_2 : Builders         
    {
        public override void BuildHouse()  
        {
            House house = new House(new DateTime(2010, 10, 23), 2, 1, 15, 1570);
        }

        public override void BuildAddress()  
        {
            Building.Country = "Belarus";
            Building.City = "Brest";
            Building.Street = "Lenina";
            Building.Home = 128;
            Building.Apartment = 98;
        }
    }

    class builderHouse_3 : Builders            
    {
        public override void BuildHouse()       
        {
            House house = new House(new DateTime(2003, 01, 29), 10, 2, 67, 2000);
        }

        public override void BuildAddress()     
        {
            Building.Country = "Russia";
            Building.City = "SP";
            Building.Street = "Mironova";
            Building.Home = 12;
            Building.Apartment = 12;
        }
    }

    class builderHouse_4 : Builders             
    {
        public override void BuildHouse()
        { 
            House house = new House(new DateTime(2005, 03, 10), 12, 4, 60, 2050);
        }

        public override void BuildAddress()    
        {
            Building.Country = "China";
            Building.City = "Shanhai";
            Building.Street = "Lui";
            Building.Home = 101;
            Building.Apartment = 10;
        }
    }
}
