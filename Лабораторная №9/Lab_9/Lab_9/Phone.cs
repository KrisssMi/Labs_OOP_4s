using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab_9
{
    public class Phone : DependencyObject
    {
        public static readonly DependencyProperty TitleProperty;
        public static readonly DependencyProperty PriceProperty;


        static Phone()
        {
            TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(Phone));    // регистрирует свойство зависимостей с указанием имени свойства, типа свойства и типа владельца

            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();
            metadata.CoerceValueCallback = new CoerceValueCallback(CorrectValue);
            PriceProperty = DependencyProperty.Register("Price", typeof(int), typeof(Phone), metadata, new ValidateValueCallback(ValidateValue));       // регистрирует свойство зависимостей с указанием имени свойства, типа свойства и типа владельца

        }

        private static bool ValidateValue(object value)
        {
            int currentValue = (int)value;

            if (currentValue >= 0)
                return true;
            return false;
        }

        private static object CorrectValue(DependencyObject dependencyObject, object value)
        {
            int currentValue = (int)value;

            if (currentValue > 10000)
                return MessageBox.Show("Слишком дорого!");
            else 
                return currentValue;
        }


        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public int Price
        {
            get { return (int)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }
    }
}
