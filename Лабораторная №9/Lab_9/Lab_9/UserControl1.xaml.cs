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
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public object Secret
        {
            get { return (object)GetValue(SecretProperty); }
            set { SetValue(SecretProperty, value); }
        } 

        public static readonly DependencyProperty SecretProperty = DependencyProperty.Register("Secret", typeof(object), typeof(UserControl1), new PropertyMetadata("UserControl Visible"));


        private void Spoiler_Click(object sender, RoutedEventArgs e)
        {
            if (spoilerGrid.Visibility == Visibility.Visible)
            {
                contentGrid.Visibility = Visibility.Visible;
                spoilerGrid.Visibility = Visibility.Collapsed;
            }
            else
            {
                contentGrid.Visibility = Visibility.Collapsed;
                spoilerGrid.Visibility = Visibility.Visible;
            }
        }
    }
}
