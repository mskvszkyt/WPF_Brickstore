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
        ObservableCollection<LegoElem> legoElements = new();
        public MainWindow()
        {
            InitializeComponent();
            dgLegoElements.ItemsSource = legoElements;
        }

        public void Beolvasas(string fajl)
        {
            if (dgLegoElements.Items.Count != 0)
            {
                legoElements.Clear();
            }
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
                    LegoElem newLego = new(id, name, categoryName, colorName, qty);
                    legoElements.Add(newLego);
                    lbCount.Content = $"Count: {legoElements.Count()}";
                }
                cbKategoriaSzuro.Items.Add("All");
                foreach (var elem in legoElements.Select(x => x.Category).Distinct().Order())
                {
                    cbKategoriaSzuro.Items.Add(elem);
                }
                cbSzinSzuro.Items.Add("All");
                foreach (var elem in legoElements.Select(x => x.Color).Distinct().Order())
                {
                    cbSzinSzuro.Items.Add(elem);
                }
                cbSzinSzuro.SelectedIndex = 0;
                cbKategoriaSzuro.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show($"Nem áll rendelkezésre \"{fajl}\" nevű fájl!");
            }
        }

        private void btnBetoltes_Click(object sender, RoutedEventArgs e)
        {
            OpenFolderDialog folderPicker = new OpenFolderDialog();
            folderPicker.ShowDialog();
            //OpenFileDialog fileDialog = new OpenFileDialog();
            ////fileDialog.DefaultExt = ".bsx";
            ////fileDialog.Filter = "BSX Files (.bsx)|*.bsx";
            //fileDialog.ShowDialog();
            //Beolvasas(fileDialog.FileName);

            foreach (string file in Directory.EnumerateFiles(folderPicker.FolderName, "*.bsx"))
            {

                lbxFileok.Items.Add(file.Split('\\')[file.Split('\\').Count()-1]);
            }
        }

        public void Szures()
        {
            string selectedKategoria = cbKategoriaSzuro.SelectedItem.ToString();
            string selectedSzin = cbSzinSzuro.SelectedItem.ToString();
            var szurt = legoElements.Where(x => (x.Name.ToLower().StartsWith(tbSzuro.Text.ToLower()) || x.Id.ToLower().StartsWith(tbSzuro.Text.ToLower()))
            && x.Category.Contains(selectedKategoria == "All" ? "" : selectedKategoria)
            && x.Color.Contains(selectedSzin == "All" ? "" : selectedSzin));
            dgLegoElements.ItemsSource = szurt;

            cbKategoriaSzuro.Items.Clear();
            cbSzinSzuro.Items.Clear();
            cbKategoriaSzuro.Items.Add("All");
            foreach (var elem in szurt.Select(x => x.Category).Distinct().Order())
            {
                cbKategoriaSzuro.Items.Add(elem);
            }
            cbSzinSzuro.Items.Add("All");
            foreach (var elem in szurt.Select(x => x.Color).Distinct().Order())
            {
                cbSzinSzuro.Items.Add(elem);
            }
            cbSzinSzuro.SelectedItem = selectedSzin;
            cbKategoriaSzuro.SelectedItem = selectedKategoria;
            lbCount.Content = $"Count: {szurt.Count()}";
        }

        private void btnKeres_Click(object sender, RoutedEventArgs e)
        {
            Szures();
        }

        private void btnTorol_Click(object sender, RoutedEventArgs e)
        {
            dgLegoElements.ItemsSource = legoElements;
        }

        private void lbxFileok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgLegoElements.ItemsSource = legoElements;
            Beolvasas(lbxFileok.SelectedItem.ToString());
        }
    }
}