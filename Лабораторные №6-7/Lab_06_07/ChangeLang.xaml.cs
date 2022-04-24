using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;

namespace Lab_06_07
{
    /// <summary>
    /// Логика взаимодействия для ChangeLang.xaml
    /// </summary>
    public partial class ChangeLang : Window
    {
        public ChangeLang()
        {

            App.LanguageChanged += LanguageChanged;
            InitializeComponent();

            Language.Items.Add(new CultureInfo("en-US"));
            Language.Items.Add(new CultureInfo("ru-RU"));
            
            List<string> styles = new List<string> { "Style-1", "Style-2" };
            Theme.SelectionChanged += SelectTheme;
            Theme.ItemsSource = styles;
        }

        private void LanguageChanged(Object sender, EventArgs e)
        {
            CultureInfo currLang = App.Language;

            //Отмечаем нужный пункт смены языка как выбранный язык
            foreach (CultureInfo i in Language.Items)
            {
                CultureInfo ci = i;
                ci.Equals(currLang);
            }
        }

        private void Language_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CultureInfo lang = Language.SelectedItem as CultureInfo;
            if (lang != null)
            {
                App.Language = lang;
            }
        }

        private void Language_Loaded(object sender, RoutedEventArgs e)
        {
        }


        private void SelectTheme(object sender, SelectionChangedEventArgs e)
        {
            string style = Theme.SelectedItem as string;
            Uri uri = null;
            switch (style)
            {
                case "Style-1":
                    {
                        uri = new Uri("Style.xaml", UriKind.Relative);
                        break;
                    }
                case "Style-2":
                    {
                        uri = new Uri("Style2.xaml", UriKind.Relative);
                        break;
                    }
            }

            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            Theme.SelectedItem = style;
        }
    }
}
