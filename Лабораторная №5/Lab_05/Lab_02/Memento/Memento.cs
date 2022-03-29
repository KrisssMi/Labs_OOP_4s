using Lab_02.InfoBuildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.Memento
{
    public class Memento
    {
        public Memento(string text)
        {
            Text = text;
        }
        public string Text { get; private set; }
    }
}
