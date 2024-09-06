using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using Microsoft.Win32;

namespace BrickStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<LegoElem> LegoElements = new();
        public MainWindow()
        {
            InitializeComponent();
            dgLegoElements.ItemsSource = LegoElements;
        }

        public void Beolvasas(string fajl)
        {
            if (fajl != null)
            {
                XDocument xaml = XDocument.Load(fajl);
                foreach (XElement element in xaml.Descendants("Item"))
                {
                    string id = element.Element("ItemID").Value;
                    string name = element.Element("ItemName").Value;
                    string colorName = element.Element("ColorName").Value;
                    string categoryName = element.Element("CategoryName").Value;
                    int qty = Convert.ToInt32(element.Element("Qty").Value);
                    LegoElem newLego = new(id, name, colorName, categoryName, qty);
                    LegoElements.Add(newLego);
                    lbCount.Content = $"Count: {LegoElements.Count()}";
                }
            }
            else
            {
                MessageBox.Show($"Nem áll rendelkezésre \"{fajl}\" nevű fájl!");
            }
        }

        private void btnBetoltes_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = ".bsx";
            fileDialog.Filter = "BSX Files (.bsx)|*.bsx";

            fileDialog.ShowDialog();
            Beolvasas(fileDialog.FileName);
        }

        private void tbSzuro_TextChanged(object sender, TextChangedEventArgs e)
        {
            var szurt = LegoElements.Where(x => x.Name.ToLower().StartsWith(tbSzuro.Text.ToLower()) || x.Id.ToLower().StartsWith(tbSzuro.Text.ToLower()));
            dgLegoElements.ItemsSource = szurt;
            lbCount.Content = $"Count: {szurt.Count()}";
        }
    }
}