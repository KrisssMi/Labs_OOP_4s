using Lab_02.AbstractFactory;
using Lab_02.Prototype;
using Lab_02.InfoBuildings;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Collections.Generic;
using Lab_02.Properties;

namespace Lab_02
{
    public partial class Form1 : Form
    {
        public Building building;
        private IAbstractFactory _HouseFileFactory;
        public string prototype = "";   // сюда запишем объект, который мы клонировали в Prototype

        public Form1()
        {
            InitializeComponent();
            building = new Building();
        }


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label14.Text = string.Format($"Текущее значение: {trackBar1.Value}");
        }

        private void button1_Click(object sender, EventArgs e)      // Добавление
        {
        var dateTime = dateTimePicker1.Value;
        var material= comboBox1.Text;
        var floor= trackBar1.Value;
        var rooms= numericUpDown1.Value;
        int meter= Int32.Parse(textBox6.Text);

            try
            {
                if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("")
                    || textBox4.Text.Equals("") || textBox5.Text.Equals(""))
                {
                    MessageBox.Show("Все поля адреса квартиры должны быть заполнены!");
                    return;
                }

                if (textBox6.Text.Equals(""))
                {
                    MessageBox.Show("Введите площадь квартиры!");
                    return;
                }

                if (!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked && !checkBox4.Checked
                    && !checkBox5.Checked && !checkBox6.Checked)
                {
                    MessageBox.Show("Не выбраны пристуствующие комнаты");
                    return;
                }

                if (comboBox1.Text.Equals(""))
                {
                    MessageBox.Show("Выберите тип материала дома");
                    return;
                }


                var address = new AddressInfo
                {
                    Country = textBox1.Text,
                    City = textBox2.Text,
                    Street = textBox3.Text,
                    Home = Int32.Parse(textBox4.Text),
                    Apartment = Int32.Parse(textBox5.Text)
                };


                /*  House currentHouse = new House(dateTimePicker1.Value,comboBox1.Text,trackBar1.Value,numericUpDown1.Value, Int32.Parse(textBox6.Text),address, Decimal.ToInt32(numericUpDown1.Value) * 5000 - trackBar1.Value * 50);*/


                // Abstract Factory:
                _HouseFileFactory = new NativeBuildingFileFactory(dateTimePicker1.Value, comboBox1.Text, trackBar1.Value, numericUpDown1.Value, Int32.Parse(textBox6.Text), address, Decimal.ToInt32(numericUpDown1.Value) * 5000 - trackBar1.Value * 50);
                House currentHouse = _HouseFileFactory.CreateHouse();

                var price = currentHouse.Price;
                building.Houses.Add(currentHouse);
                

                currentHouse.Result = "Город: " + currentHouse.Address.City + ", улица: " + currentHouse.Address.Street + ",\n" + currentHouse.Rooms + "-комн., " +
                    currentHouse.Floor + " этаж, " + currentHouse.Meter + " кв.м";

                if (checkBox1.Checked) currentHouse.Result += " + Кухня";
                if (checkBox2.Checked) currentHouse.Result += " + Туалет";
                if (checkBox3.Checked) currentHouse.Result += " + Ванная";
                if (checkBox4.Checked) currentHouse.Result += " + Гостевая комната";
                if (checkBox5.Checked) currentHouse.Result += " + Спальня";
                if (checkBox6.Checked) currentHouse.Result += " + Балкон";
                listBox1.Items.Add(currentHouse.Result);
                listBox1.Items.Add("\r\nСтоимость: " + currentHouse.Price + " $");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)      // Сохранение
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Building));
            using (FileStream stream = new FileStream("Building.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(stream, building);
            }
        }

        private void button3_Click(object sender, EventArgs e)      // Открытие
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Building));
            using (FileStream stream = new FileStream("Building.xml", FileMode.Open))
            {
                building = serializer.Deserialize(stream) as Building;
            }
            foreach (House house in building.Houses)
                listBox1.Items.Add(house.Result);
        }

        private void button4_Click(object sender, EventArgs e)      // Очистка  
        {
           Controls.Clear();
        }






        // -------------- ЛАБОРАТОРНАЯ РАБОТА #4: -------------- 

        // Builders:
        private void button5_Click(object sender, EventArgs e)
        {
            // статический метод который вызывает своеобразный мейн, создает один
            // рандомный объект и сразу выводит его на экран
            Director.BuilderMain();

            // проходимся по list из director, где хранятся все
            // созданные объекты, и выводим в MessageBox
            string result = "______________________________________\n\n";
            foreach (Building dist in Director.listOfHousesBuilder)
                result += dist.ToString();

            MessageBox.Show(result);
        }



        // Prototype: cклонировать случайный объект
        private void button6_Click(object sender, EventArgs e)
        {
            var prot = new PrototypeBuilder();  // из билдера
            var prot1 = prot.Clone();
            string res = prot1.ToString();      // записываем этот объект в поле класса, чтобы добавить в общий вывод на экран
            MessageBox.Show("______________________________________\n\n" + res);
        }



        // Singleton:
        private void button7_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();

            if (settings != null)
            {
                Text = "HousesRedact";
                StartPosition = FormStartPosition.CenterScreen;
                Width = 850;
                Height = 580;
                this.BackColor = Singleton.Instance.Color;
                this.Font = Singleton.Instance.Font;
            }
        }
    }
}
