using Lab_02.InfoBuildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02
{
    public class MainDecorator
    {
        public static void DecoratorMain()
        {
            // получение случайного элемента из списка построек билдера
            var sizeOfList = Director.listOfHousesBuilder.Count;
            Random random = new Random();
            int value = random.Next(0, sizeOfList);


            // рандом для выбора случайной декорации
            Random random1 = new Random();
            int randDecor = random1.Next(0, 2);


            // выбор декорации (Присутствие гаража, отсутствие гаража)
            switch (randDecor)
            {
                case 0:
                    Building buildingWithGarage = Director.listOfHousesBuilder[value];
                    buildingWithGarage = new Garage_HaveDecorate(buildingWithGarage).buildingDecorate;
                    Director.listOfHousesBuilder[value] = buildingWithGarage;
                    break;
                case 1:
                    Building buildingWithoutGarage = Director.listOfHousesBuilder[value];
                    buildingWithoutGarage = new Garage_NotHaveDecorate(buildingWithoutGarage).buildingDecorate;
                    Director.listOfHousesBuilder[value] = buildingWithoutGarage;
                    break;
            }
        }
    }

    // Абстрактный класс декоратора.
    // Сюда передаем готовую постройку как поле класса
    abstract class BuildingDecorator : Building
    {
        public Building buildingDecorate;
        public BuildingDecorator(Building building) => buildingDecorate = building;
    }



    // присутствие гаража:
    class Garage_HaveDecorate : BuildingDecorator
    {
        public Garage_HaveDecorate(Building building) : base(building)
        { 
            buildingDecorate.Garage = "HAVE!";
        }
    }


    // присутствие гаража:
    class Garage_NotHaveDecorate : BuildingDecorator
    {
        public Garage_NotHaveDecorate(Building building) : base(building)
        {
            buildingDecorate.Garage = "NOT HAVE :(";
        }
    }
}
