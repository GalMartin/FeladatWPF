using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
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

        private void Hozzaadas_Click(object kuldo, RoutedEventArgs esemeny)
        {
            string nev = NevMezo.Text.Trim();

            if (nev == "")
            {
                MessageBox.Show("Add meg a tanuló nevét!");
                NevMezo.Focus();
                return;
            }

            if (!int.TryParse(EletkorMezo.Text, out int eletkor) || eletkor <= 0)
            {
                MessageBox.Show("Az életkor pozitív egész szám legyen!");
                EletkorMezo.Focus();
                return;
            }

            if (!int.TryParse(PontszamMezo.Text, out int pontszam) || pontszam < 0)
            {
                MessageBox.Show("A pontszám nulla vagy pozitív egész szám legyen!");
                PontszamMezo.Focus();
                return;
            }

            Dolgozat ujDolgozat = new Dolgozat(nev, eletkor, pontszam);
            dolgozatok.Add(ujDolgozat);
            DolgozatTabla.ScrollIntoView(ujDolgozat);

            NevMezo.Clear();
            EletkorMezo.Clear();
            PontszamMezo.Clear();
            NevMezo.Focus();
        }

        private void Mentes_Click(object kuldo, RoutedEventArgs esemeny)
        {
            SaveFileDialog fajlvalaszto = new SaveFileDialog
            {
                Title = "Dolgozatok mentése",
                FileName = "dolgozatok.csv",
                Filter = "CSV-fájl (*.csv)|*.csv"
            };

            if (fajlvalaszto.ShowDialog(this) != true)
            {
                return;
            }

            try
            {
                using (StreamWriter iro = new StreamWriter(
                    fajlvalaszto.FileName, false, new UTF8Encoding(true)))
                {
                    iro.WriteLine("Név;Életkor;Pontszám");

                    foreach (Dolgozat dolgozat in dolgozatok)
                    {
                        string nev = dolgozat.Nev.Replace("\"", "\"\"");
                        iro.WriteLine($"\"{nev}\";{dolgozat.Eletkor};{dolgozat.Pontszam}");
                    }
                }

                MessageBox.Show("A dolgozatok mentése sikerült.");
            }
            catch (IOException)
            {
                MessageBox.Show("A fájlt nem sikerült menteni. Ha meg van nyitva, zárd be, majd próbáld újra!");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Nincs írási jogosultságod a kiválasztott mappában.");
            }
        }
    }
}