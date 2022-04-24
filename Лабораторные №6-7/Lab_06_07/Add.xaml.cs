using Microsoft.Win32;
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
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : UserControl
    {
        public Flowers flower = new Flowers();
        public string Imagelink;
        Collection<Flowers> flowers = new Collection<Flowers>();
        Command.ManagerOperation manager = Command.ManagerOperation.Instance;
        private bool isClose;

        public Add()
        {
            InitializeComponent();
            TypeSelected.Items.Add(TypeFlowers.Gypsophiles);
            TypeSelected.Items.Add(TypeFlowers.Peonies);
            TypeSelected.Items.Add(TypeFlowers.Roses);
            TypeSelected.Items.Add(TypeFlowers.Tulips);
            TypeSelected.Items.Add(TypeFlowers.Lilies);

            Name.Text = flower.Name;
            TypeSelected.SelectedItem = flower.Type;
            Price.Text = flower.Price.ToString();
            Description.Text = flower.Description;
            Imagelink = flower.Link;
            Color.Text = flower.Color;
            flowers = FlowersCollection.Deserialize("Flowers.xml");
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            manager.AddOperation(new Command.AddName(flower, Name.Text));
            manager.AddOperation(new Command.AddType(flower, (TypeFlowers)TypeSelected.SelectedItem));
            manager.AddOperation(new Command.AddPrice(flower, int.Parse(Price.Text)));
            manager.AddOperation(new Command.AddDescription(flower, Description.Text));
            manager.AddOperation(new Command.AddLink(flower, Imagelink));
            manager.AddOperation(new Command.AddColor(flower, Color.Text));
            manager.AddOperation(new Command.AddCollection(flower, flowers));
            manager.AddOperation(new Command.Serialize(flowers, "CollectionFlowers.xml"));
            manager.ProcessOperation();
            Name.Clear();
            TypeSelected.SelectedIndex = -1;
            Price.Clear();
            Description.Clear();
            Imagelink = "";
            //StatusLink.Text = "";
            flower = new Flowers();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            isClose = true;
        }

        private void ImgLink_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image file (*.png;*jpg)|*png;*.jpg";
            if (openFile.ShowDialog() == true)
            {
                string selFileName = openFile.FileName;
                Imagelink = selFileName;
            }
        }
    }
}
