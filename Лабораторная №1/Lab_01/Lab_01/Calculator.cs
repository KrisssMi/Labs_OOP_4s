using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_01
{
	public partial class Calculator : Form
	{
		// таблицы соответствия размеров:
		public double[] RuSize = new double[13] { 40, 42, 44, 46, 48, 50, 52, 54, 56, 58, 60, 62, 64 };			// русские размеры
		public double[] EuSize = new double[13] { 34, 36, 38, 40, 42, 44, 46, 48, 50, 52, 54, 56, 58 };			// европейские размеры
		public double[] UkSize = new double[13] { 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32 };			// британские размеры
		public double[] UsSize = new double[13] { 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30 };			// американские размеры
		public int index = 0;

		public Calculator()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			textBox1.Clear();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			textBox2.Clear();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			try
			{
				double size;
				size = Convert.ToDouble(textBox1.Text);		// наш ввод в первое текстовое поле
				if (checkBox1.Checked)
				{
					index = Array.IndexOf(RuSize, size);	// индекс первого вхождения элемента в 1-ый массив
				}
				else if (checkBox2.Checked)
				{
					index = Array.IndexOf(EuSize, size);    // индекс первого вхождения элемента во 2-ой массив
				}
				else if (checkBox3.Checked)
				{
					index = Array.IndexOf(UkSize, size);    // индекс первого вхождения элемента в 3-ий массив
				}
				else if (checkBox4.Checked)
				{
					index = Array.IndexOf(UsSize, size);    // индекс первого вхождения элемента в 4-ый массив
				}
				else if (!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked && !checkBox4.Checked)
				{
					throw new Exception("Не выбрана система измерения первоначальных размеров");
				}

				if (checkBox5.Checked)
				{
					textBox2.Text = RuSize[index].ToString();
				}
				else if (checkBox6.Checked)
				{
					textBox2.Text = EuSize[index].ToString();
				}
				else if (checkBox7.Checked)
				{
					textBox2.Text = UkSize[index].ToString();
				}
				else if (checkBox8.Checked)
				{
					textBox2.Text = UsSize[index].ToString();
				}
				else if (!checkBox5.Checked && !checkBox6.Checked && !checkBox7.Checked && !checkBox8.Checked)
				{
					throw new Exception("Не выбрана конечная система измерения размеров");
				}
			}

			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			textBox1.Text += "1";
		}

		private void button5_Click(object sender, EventArgs e)
		{
			textBox1.Text += "2";
		}

		private void button6_Click(object sender, EventArgs e)
		{
			textBox1.Text += "3";
		}

		private void button7_Click(object sender, EventArgs e)
		{
			textBox1.Text += "4";
		}

		private void button8_Click(object sender, EventArgs e)
		{
			textBox1.Text += "5";
		}

		private void button9_Click(object sender, EventArgs e)
		{
			textBox1.Text += "6";
		}

		private void button10_Click(object sender, EventArgs e)
		{
			textBox1.Text += "7";
		}

		private void button11_Click(object sender, EventArgs e)
		{
			textBox1.Text += "8";
		}

		private void button12_Click(object sender, EventArgs e)
		{
			textBox1.Text += "9";
		}

		private void button13_Click(object sender, EventArgs e)
		{
			textBox1.Text += "0";
		}

		private void button14_Click(object sender, EventArgs e)
		{
			textBox1.Text += ",";
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}
