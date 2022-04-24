using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {

        Collection<Flowers> flowers = new Collection<Flowers>();

        Command.ManagerOperation manager = Command.ManagerOperation.Instance;
        public Home()
        {
            InitializeComponent();
            flowers = FlowersCollection.Deserialize("CollectionFlowers.xml");
            ListFlowers.ItemsSource = flowers;
        }

        private void ToolsListEdit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ToolsListEdit.SelectedIndex;
            ToolsListEdit.SelectedItem = null;
            switch (index)
            {
                case 0:         //Edit
                    {
                        Flowers flowers_del = (Flowers)ListFlowers.SelectedItem;
                        if (flowers_del == null) break;
                        manager.AddOperation(new Command.DeleteItems(flowers, flowers_del));
                        manager.ProcessOperation();
                        manager.AddOperation(new Command.Serialize(flowers, "CollectionFlowers.xml"));
                        manager.ProcessOperation();
                        Edit editFlowers = new Edit(flowers_del);
                        editFlowers.ShowDialog();
                        if (editFlowers.isClose == true)
                        {
                            flowers = FlowersCollection.Deserialize("CollectionFlowers.xml");
                            ListFlowers.ItemsSource = flowers;
                        }
                        break;
                    }
                    break;

                case 1:       // Delete
                        if (ListFlowers.SelectedItem != null)
                        {
                            Flowers flowers_del = (Flowers)ListFlowers.SelectedItem;
                            manager.AddOperation(new Command.DeleteItems(flowers, flowers_del));
                            manager.ProcessOperation();
                            manager.AddOperation(new Command.Serialize(flowers, "CollectionFlowers.xml"));
                            manager.ProcessOperation();
                            ListFlowers.ItemsSource = null;
                            ListFlowers.ItemsSource = flowers;
                        }
                    break;


                case 2:
                    break;
                case 3:
                    {
                        Search_Enter();
                        break;
                    }
                case 4:
                    {

                        break;
                    }
                default: break;
            }
        }


        private void Search_Enter()
        {
            String search = Search.Text;
            Collection<Flowers> search_flowers = new Collection<Flowers>();
            if (Regex.IsMatch(search, @"\w*"))
            {
                int i = 0;
                foreach (Flowers flower in flowers)
                {
                    if (flower.Name.Contains(search))
                    {
                        search_flowers.Add(flower);
                    }
                }
                ListFlowers.ItemsSource = search_flowers;
            }
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = PriceDipBox.Text;
            Collection<Flowers> search_flowers = new Collection<Flowers>();
            int a = 0;
            int b = 0;
            if (Regex.IsMatch(str, @"[0-9]*-[0-9]*"))
            {
                int i = 0;
                Regex r = new Regex(@"-");
                String[] s = r.Split(str);

                a = int.Parse(s[0]);
                b = int.Parse(s[1]);
            }

            List<TypeFlowers> typeFlowers = new List<TypeFlowers>();
            if (CheckGypsophiles.IsChecked==true)
            {
                typeFlowers.Add(TypeFlowers.Gypsophiles);
            }
            if (CheckRoses.IsChecked == true)
            {
                typeFlowers.Add(TypeFlowers.Roses);
            }
            if (CheckTulips.IsChecked == true)
            {
                typeFlowers.Add(TypeFlowers.Tulips);
            }
            if (CheckPeonies.IsChecked == true)
            {
                typeFlowers.Add(TypeFlowers.Peonies);
            }
            if (CheckLilies.IsChecked == true)
            {
                typeFlowers.Add(TypeFlowers.Lilies);
            }
            if (typeFlowers.Count == 0)
            {
                search_flowers = flowers;
            }
            else
            {
                Collection<Flowers> search_Flowers = new Collection<Flowers>();
                foreach (Flowers flower in flowers)
                {
                    if (typeFlowers.Contains(flower.Type))
                    {
                        search_Flowers.Add(flower);
                    }
                }
                search_flowers = search_Flowers;
            }
            
            if (str != null)
            {
                Collection<Flowers> search_Flowers = new Collection<Flowers>();
                if (search_flowers.Count == 0)
                    search_flowers = flowers;
                foreach (Flowers f in search_flowers)
                {
                    if (((a<=f.Price && b>=f.Price)))
                    {
                        search_Flowers.Add(f);
                    }
                }

                if (search_Flowers.Count != 0)
                    search_flowers = search_Flowers;
            }
            if (search_flowers.Count==0)
            {
                search_flowers = flowers; 
            }
            ListFlowers.ItemsSource = search_flowers;
        }
    }
}
