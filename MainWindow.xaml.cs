
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private class Ankieta
        {
            public int Wiek { get; set; }
            public string Kolor { get; set; } = "";
            public string Plec { get; set; } = "";
            public bool Zgoda { get; set; }
        }

        private readonly List<Ankieta> ankiety =
            new List<Ankieta>();

        private readonly string sciezkaPliku =
            Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "ankiety.txt"
            );

        public MainWindow()
        {
            InitializeComponent();

            WczytajAnkiety();
            AktualizujStatystyki();
        }

        private void Zapisz_Click(
            object sender,
            RoutedEventArgs e)
        {
            // Sprawdzenie wieku
            if (!int.TryParse(WiekTextBox.Text, out int wiek)
                || wiek < 0)
            {
                MessageBox.Show(
                    "Podaj prawidłowy wiek."
                );
                return;
            }

            // Sprawdzenie płci
            if (MezczyznaRadio.IsChecked != true &&
                KobietaRadio.IsChecked != true)
            {
                MessageBox.Show(
                    "Wybierz płeć."
                );
                return;
            }

            // Sprawdzenie koloru
            if (KolorComboBox.SelectedItem
                is not ComboBoxItem wybranyKolor)
            {
                MessageBox.Show(
                    "Wybierz kolor."
                );
                return;
            }

            string plec =
                MezczyznaRadio.IsChecked == true
                ? "M"
                : "K";

            string kolor =
                wybranyKolor.Content.ToString() ?? "";

            bool zgoda =
                ZgodaCheckBox.IsChecked == true;

            // Utworzenie ankiety
            Ankieta nowaAnkieta = new Ankieta
            {
                Wiek = wiek,
                Kolor = kolor,
                Plec = plec,
                Zgoda = zgoda
            };

            // Przygotowanie wiersza do pliku
            string linia = string.Join(
                "|",
                nowaAnkieta.Plec,
                nowaAnkieta.Wiek,
                nowaAnkieta.Kolor,
                nowaAnkieta.Zgoda ? "1" : "0"
            );

            try
            {
                // Zapis do pliku
                File.AppendAllText(
                    sciezkaPliku,
                    linia + Environment.NewLine,
                    Encoding.UTF8
                );

                // Odczyt danych z pliku
                WczytajAnkiety();

                // Aktualizacja statystyk
                AktualizujStatystyki();

                // Wyczyszczenie formularza
                WiekTextBox.Clear();
                ZgodaCheckBox.IsChecked = false;

                MezczyznaRadio.IsChecked = false;
                KobietaRadio.IsChecked = false;

                MessageBox.Show(
                    "Ankieta została zapisana."
                );
            }
            catch (IOException)
            {
                MessageBox.Show(
                    "Nie udało się zapisać lub odczytać pliku."
                );
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show(
                    "Brak uprawnień do pliku."
                );
            }
        }

        private void WczytajAnkiety()
        {
            ankiety.Clear();

            // Jeśli plik nie istnieje, lista pozostaje pusta
            if (!File.Exists(sciezkaPliku))
            {
                return;
            }

            string[] linie = File.ReadAllLines(
                sciezkaPliku,
                Encoding.UTF8
            );

            foreach (string linia in linie)
            {
                string[] dane = linia.Split('|');

                // Każda ankieta musi mieć 4 pola
                if (dane.Length != 4)
                {
                    continue;
                }

                if (!int.TryParse(dane[1], out int wiek)
                    || wiek < 0)
                {
                    continue;
                }

                if (dane[0] != "M" && dane[0] != "K")
                {
                    continue;
                }

                if (dane[3] != "0" && dane[3] != "1")
                {
                    continue;
                }

                Ankieta ankieta = new Ankieta
                {
                    Plec = dane[0],
                    Wiek = wiek,
                    Kolor = dane[2],
                    Zgoda = dane[3] == "1"
                };

                ankiety.Add(ankieta);
            }
        }

        private void AktualizujStatystyki()
        {
            // Liczba wszystkich ankiet
            IloscWpisowTextBox.Text =
                ankiety.Count.ToString();

            // Liczba mężczyzn
            IloscMTextBlock.Text =
                ankiety.Count(a => a.Plec == "M")
                .ToString();

            // Liczba kobiet
            IloscKTextBlock.Text =
                ankiety.Count(a => a.Plec == "K")
                .ToString();

            // Liczba zaznaczonych zgód
            IloscZgodTextBlock.Text =
                ankiety.Count(a => a.Zgoda)
                .ToString();

            // Najczęściej wybierany kolor
            var najczestszyKolor = ankiety
                .GroupBy(a => a.Kolor)
                .OrderByDescending(grupa => grupa.Count())
                .ThenBy(grupa => grupa.Key)
                .FirstOrDefault();

            if (najczestszyKolor == null)
            {
                NajczestszyKolorTextBlock.Text =
                    "Brak danych";
            }
            else
            {
                NajczestszyKolorTextBlock.Text =
                    najczestszyKolor.Key;
            }
        }
    }
}
