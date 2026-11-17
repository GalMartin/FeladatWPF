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
using System.Collections.ObjectModel;
using System.Windows;

namespace FeladatWPF
{
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<Dolgozat> dolgozatok =
            new ObservableCollection<Dolgozat>();

        public MainWindow()
        {
            InitializeComponent();

            dolgozatok.Add(new Dolgozat("Kiss Péter", 16, 87));
            dolgozatok.Add(new Dolgozat("Nagy Anna", 17, 92));
            dolgozatok.Add(new Dolgozat("Szabó Tamás", 16, 78));
            dolgozatok.Add(new Dolgozat("Tóth Éva", 18, 95));
            dolgozatok.Add(new Dolgozat("Varga Bence", 17, 81));
            dolgozatok.Add(new Dolgozat("Horváth Zsolt", 16, 65));
            dolgozatok.Add(new Dolgozat("Molnár Réka", 18, 89));
            dolgozatok.Add(new Dolgozat("Lakatos Dániel", 17, 72));

            DolgozatTabla.ItemsSource = dolgozatok;
        }
    }
}