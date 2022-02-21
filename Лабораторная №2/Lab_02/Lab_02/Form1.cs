using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Lab_02
{
    public partial class Form1 : Form
    {
        public Building building;
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

            House currentHouse = new House
            {
                Meter = Int32.Parse(textBox6.Text),
                Material = comboBox1.Text,
                Date_Buildings = dateTimePicker1.Value,
                Floor = trackBar1.Value,
                Rooms = numericUpDown1.Value,
                Address = new Address
                {
                    Country = textBox1.Text,
                    City = textBox2.Text,
                    Street = textBox3.Text,
                    Home = Int32.Parse(textBox4.Text),
                    Apartment = Int32.Parse(textBox5.Text)
                }
            };

            currentHouse.Price = Decimal.ToInt32(currentHouse.Rooms) * 5000 - currentHouse.Floor * 50;
            building.Houses.Add(currentHouse);

            currentHouse.Result = "Город: " + currentHouse.Address.City + ", улица: " + currentHouse.Address.Street +",\n" + currentHouse.Rooms + "-комн., " +
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
    }
}
