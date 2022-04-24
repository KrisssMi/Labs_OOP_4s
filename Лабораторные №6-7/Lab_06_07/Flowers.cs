using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace Lab_06_07
{
    // класс коллекции цветов
    public class FlowersCollection
    {
        public static Collection<Flowers> Deserialize(string path)
        {
            Collection<Flowers> _flowers = new Collection<Flowers>();
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Collection<Flowers>));
                // десериализуем объект
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    Collection<Flowers> products = xmlSerializer.Deserialize(fs) as Collection<Flowers>;
                    _flowers = products;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return _flowers;
        }
    }
    public enum TypeFlowers
    {
        NULL,
        Roses,
        Gypsophiles,
        Peonies,
        Tulips,
        Lilies
    }

    // класс, описывающий объекты коллекции

    public class Flowers
    {
        public string Name { get; set; }
        public int Price { get; set; }
        [RegularExpression(@"#([0-9]|[A-Z]){8}")]
        public string Color { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public TypeFlowers Type { get; set; }

        
        // конструктор по умолчанию с параметрами

        public Flowers(string name, int price, string color, string link, string description, TypeFlowers type)
        {
            Name = name;
            Price = price;
            Color = color;
            Link = link;
            Description = description;
            Type = type;
        }

        // конструктор по умолчанию
        public Flowers()
        {
            Name = "";
            Price = 0;
            Color = "";
            Link = "";
            Description = "";
            Type = TypeFlowers.NULL;
        }

        public override string ToString()
        {
            return $"{Name} {Color}";
        }
    }
}
