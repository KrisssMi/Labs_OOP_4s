using Lab_02.Memento;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_02
{
    public partial class MementoForm : Form
    {
        private readonly MementoInfo _mementoTextBox = new MementoInfo(string.Empty);
        public MementoForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string stateText = textBox1.Text;
            _mementoTextBox.Change(stateText);
            CurrentStateTextBox.Text = _mementoTextBox.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_mementoTextBox.Undo() != null)
                CurrentStateTextBox.Text = _mementoTextBox.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_mementoTextBox.Refund() != null)
                CurrentStateTextBox.Text = _mementoTextBox.Text;
        }

        private void MementoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            (sender as MementoForm).Hide();
        }
    }
}
