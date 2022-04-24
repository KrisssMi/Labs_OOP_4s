using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_06_07
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Page.Children.Add(new Home());
        }

        private void MenuTools_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = MenuTools.SelectedIndex;
            MenuTools.SelectedItem = null;
            switch (index)
            {
                case 0:     // Home
                    Page.Children.Clear();
                    Page.Children.Add(new Home());
                    break;
                case 1:    // Добавление цветка
                    Page.Children.Clear();
                    Page.Children.Add(new Add());
                    break;
                case 2:    // Изменение языка
                    ChangeLang changeLang = new ChangeLang();
                    changeLang.ShowDialog();
                    break;
                default: break;
            }
        }
    }
}
