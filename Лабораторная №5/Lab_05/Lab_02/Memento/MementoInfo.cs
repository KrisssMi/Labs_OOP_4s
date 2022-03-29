using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.Memento
{
    public class MementoInfo
    {
        private int _index;
        private readonly List<Memento> _mementoes;      // лист состояний

        public MementoInfo(string text)                 // конструктор одного состояния
        {
            _index = 0;
            Text = text;
            _mementoes = new List<Memento>() { 
                new Memento(Text) 
            };
        }

        public void Change(string text)         // добавление состояния
        {
            Text = text;
            _mementoes.Add(new Memento(Text));
            _index++;
        }

        public Memento Undo()                    // отмена состояния
        {
            if (_index <= 0) return null;
            var state = _mementoes[--_index];
            Text = state.Text;
            return state;
        }

        public Memento Refund()                    // возврат предыдущего состояния
        {
            if (_index + 1 >= _mementoes.Count) 
                return null;
            var state = _mementoes[++_index];
            Text = state.Text;
            return state;
        }

        public string Text { get; private set; } // записываемый текст в TextBox
    }
}
