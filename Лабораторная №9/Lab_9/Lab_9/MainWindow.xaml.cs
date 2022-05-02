using System;
using System.Collections.Generic;
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

namespace Lab_9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CommandBinding binding = new CommandBinding(Commands.Visible);
            binding.Executed += CommandBinding_Executed;
            binding.Executed += CommandBinding_Executed2;

            this.CommandBindings.Add(binding);
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (Grid_Col_1.Visibility == Visibility.Collapsed)
                Grid_Col_1.Visibility = Visibility.Visible;
            else
                Grid_Col_1.Visibility = Visibility.Collapsed;
        }

        private void CommandBinding_Executed2(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Command done!");
        }

        private void Control1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            textBlock1.Text += "sender: " + sender.ToString() + "\n";
            textBlock1.Text += "source: " + e.Source.ToString() + "\n";
        }

        private void Control2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            textBlock2.Text += "sender: " + sender.ToString() + "\n";
            textBlock2.Text += "source: " + e.Source.ToString() + "\n";
        }

        private void Control3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            textBlock3.Text += "sender: " + sender.ToString() + "\n";
            textBlock3.Text += "source: " + e.Source.ToString() + "\n";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
