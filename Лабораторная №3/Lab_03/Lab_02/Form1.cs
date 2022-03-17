using Lab_02;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Lab_03
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
                if (textBox4.Text.Any(char.IsDigit) && textBox5.Text.Any(char.IsDigit) && textBox6.Text.Any(char.IsDigit))
                {
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


                    currentHouse.Result = "Город: " + currentHouse.Address.City + "., " + currentHouse.Rooms + "-комн., " +
                        currentHouse.Floor + " этаж, " + currentHouse.Meter + " кв.м";

                    //if (checkBox1.Checked) currentHouse.Result += " + Кухня";
                    //if (checkBox2.Checked) currentHouse.Result += " + Туалет";
                    //if (checkBox3.Checked) currentHouse.Result += " + Ванная";
                    //if (checkBox4.Checked) currentHouse.Result += " + Гостевая комната";
                    //if (checkBox5.Checked) currentHouse.Result += " + Спальня";
                    //if (checkBox6.Checked) currentHouse.Result += " + Балкон";
                    currentHouse.Result += "\tСтоимость: " + currentHouse.Price + " $";
                    //listBox1.Items.Add(currentHouse.Result);
                    //building.Houses.Add(currentHouse);

                    var context = new ValidationContext(currentHouse, null, null);
                    IList<ValidationResult> errors = new List<ValidationResult>();
                    IList<ValidationResult> errors2 = new List<ValidationResult>();
                    var context2 = new ValidationContext(currentHouse, null, null);

                    if (!Validator.TryValidateObject(currentHouse, context2, errors2, true) || !Validator.TryValidateObject(currentHouse, context, errors, true))
                    {
                        foreach (var result in errors)
                            MessageBox.Show(result.ErrorMessage);

                        foreach (var result in errors2)
                            MessageBox.Show(result.ErrorMessage);
                    }
                    else
                    {
                        MessageBox.Show("Объект добавлен.");
                        listBox1.Items.Add(currentHouse.Result);
                        building.Houses.Add(currentHouse);
                    }
                }
                else
                {
                    MessageBox.Show("Поля номеров квартиры, дома или площади должны быть цифрами!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
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
            if (building.Houses.Count > 0)
            {
                using (FileStream stream = new FileStream("Building.xml", FileMode.Open))
                {
                    building = serializer.Deserialize(stream) as Building;
                }
                foreach (House house in building.Houses)
                    listBox1.Items.Add("________________________________\n"+house.Result);
            }
        }

        private void button4_Click(object sender, EventArgs e)      // Очистка  
        {
           Controls.Clear();
        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)               // Открытие формы для поиска  
        {
            Search search = new Search();
            search.ShowDialog(this);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)          // Кнопка О программе 
        {
            MessageBox.Show("Лабораторная работа #3. \nРазработчик: Миневич Кристина Викторовна");
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Текущее время - " + DateTime.Now.ToString();
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Текущее количество объектов - " + building.Houses.Count;
        }



        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(textBox1.Text, @"(([А-Я][а-я]+(\s?))+$)|([А-Я][а-я]+(-?)([А-Я]?)([а-я]+)$)"))
            {
                textBox1.Tag = false;
            }
            else { textBox1.Tag = true; }
            Enable();
        }

        private void Enable()
        {
            button1.Enabled = (bool)textBox1.Tag;
        }


        private void площадьToolStripMenuItem_Click(object sender, EventArgs e)               // Сортировка по площади  
        {
            try
            {
                if (building.Houses.Count == 0)
                {
                    throw new Exception("Нет объектов для сортировки");
                }
                listBox1.Items.Clear();
                XmlSerializer ser = new XmlSerializer(typeof(Building));
                using (FileStream stream = new FileStream("Building.xml", FileMode.Open))
                    building = ser.Deserialize(stream) as Building;

                IEnumerable<House> ordered = building.Houses.OrderBy(p => p.Meter);
                foreach (House house in ordered)
                    listBox1.Items.Add(house.Result);
                using (var file = new StreamWriter("file_sort.json", false))
                {
                    file.WriteLine("Сортировка объектов по площади: ");
                    file.Write(JsonConvert.SerializeObject(ordered));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ценаToolStripMenuItem_Click(object sender, EventArgs e)                  // Сортировка по цене
        {
            try
            {
                if (building.Houses.Count == 0)
                {
                    throw new Exception("Нет объектов для сортировки");
                }
                listBox1.Items.Clear();
                XmlSerializer ser = new XmlSerializer(typeof(Building));
                using (FileStream stream = new FileStream("Building.xml", FileMode.Open))
                    building = ser.Deserialize(stream) as Building;

                IEnumerable<House> ordered = building.Houses.OrderBy(p => p.Price);
                foreach (House house in ordered)
                    listBox1.Items.Add(house.Result);
                using (var file = new StreamWriter("file_sort.json", false))
                {
                    file.WriteLine("Сортировка объектов по цене: ");
                    file.Write(JsonConvert.SerializeObject(ordered));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

         private void поКоличествуКомнатToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (building.Houses.Count == 0)
                {
                    throw new Exception("Нет объектов для сортировки");
                }
                listBox1.Items.Clear();
                XmlSerializer ser = new XmlSerializer(typeof(Building));
                using (FileStream stream = new FileStream("Building.xml", FileMode.Open))
                    building = ser.Deserialize(stream) as Building;

                IEnumerable<House> ordered = building.Houses.OrderBy(p => p.Rooms);
                foreach (House house in ordered)
                    listBox1.Items.Add(house.Result);
                using (var file = new StreamWriter("file_sort.json", false))
                {
                    file.WriteLine("Сортировка объектов по количеству комнат: ");
                    file.Write(JsonConvert.SerializeObject(ordered));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void toolStripLabel1_Click(object sender, EventArgs e)      // Открыть (добавить в листбокс) объекты
        {
           button3.Select();
            button3_Click(sender, e);
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)      // Сохранение объектов (добавление в файл xml) 
        {
           button2.Select();
            button2_Click(sender, e);
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)      // Выход
        {
            Application.Exit();
        }

        private void сокрытьПанельИнструментовToolStripMenuItem_Click(object sender, EventArgs e)   // Скрытие панели инструментов (даты и количества объектов)
        {
            statusStrip1.Visible = statusStrip1.Visible == false;
        }
        private void поРайонуToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void сортировкаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
