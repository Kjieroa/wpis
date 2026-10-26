
# Ankieta – aplikacja WPF C#

## Opis projektu

Projekt przedstawia prostą aplikację desktopową stworzoną w języku C# z wykorzystaniem technologii WPF (Windows Presentation Foundation).

Aplikacja umożliwia wypełnianie ankiet, zapisywanie ich do pliku tekstowego oraz wyświetlanie statystyk na podstawie zapisanych danych.

## Funkcjonalności

- Wybór płci: Mężczyzna lub Kobieta.
- Wprowadzanie wieku.
- Wybór koloru z listy.
- Zaznaczenie zgody.
- Zapisywanie ankiet do pliku `ankiety.txt`.
- Odczytywanie zapisanych ankiet po uruchomieniu programu.
- Wyświetlanie liczby wszystkich ankiet.
- Zliczanie ankiet według płci.
- Zliczanie osób, które wyraziły zgodę.
- Wyświetlanie najczęściej wybieranego koloru.
- Walidacja wprowadzanych danych.

## Technologie

- C#
- WPF (Windows Presentation Foundation)
- XAML
- .NET
- Plik tekstowy do przechowywania danych

## Wygląd aplikacji

Aplikacja składa się z dwóch głównych części:

- **Panel ankiety** – wybór płci, wpisanie wieku, wybór koloru i zaznaczenie zgody.
- **Panel wyników** – wyświetlanie statystyk na podstawie zapisanych ankiet.

## Zapis danych

Dane ankiet są zapisywane w pliku `ankiety.txt`.

Każda ankieta zajmuje osobny wiersz. Poszczególne wartości są oddzielone znakiem `|`.

Przykładowa zawartość pliku:

```text
M|25|Niebieski|1
K|31|Czerwony|0
M|19|Zielony|1
```

Kolejność danych:

1. Płeć (`M` – mężczyzna, `K` – kobieta).
2. Wiek.
3. Wybrany kolor.
4. Zgoda (`1` – zaznaczona, `0` – niezaznaczona).

Po ponownym uruchomieniu aplikacja odczytuje dane z pliku i ponownie oblicza statystyki.

## Uruchomienie projektu

1. Sklonuj repozytorium na komputer:

   ```bash
   git clone ADRES_REPOZYTORIUM
   ```

2. Otwórz projekt w Visual Studio.
3. Uruchom plik rozwiązania `.sln`.
4. Poczekaj na przywrócenie wymaganych zależności.
5. Uruchom aplikację przyciskiem **Start** lub klawiszem `F5`.
6. Wypełnij formularz i kliknij **Zapisz**.

## Wymagania

- System Windows.
- Visual Studio z obsługą programowania w C# i WPF.
- Zainstalowany odpowiedni pakiet .NET wymagany przez projekt.

## Struktura projektu

```text
Ankieta/
├── MainWindow.xaml
├── MainWindow.xaml.cs
├── App.xaml
├── App.xaml.cs
├── ankiety.txt
└── README.md
```

Plik `ankiety.txt` jest tworzony automatycznie, gdy zostanie zapisana pierwsza ankieta. Jego dokładna lokalizacja zależy od katalogu uruchomieniowego aplikacji.

## Cel projektu

Celem projektu jest praktyczne wykorzystanie języka C#, tworzenie interfejsu graficznego w WPF, obsługa plików tekstowych oraz przetwarzanie i analizowanie zapisanych danych.

## Autor

Wpisz tutaj swoje imię lub nazwę użytkownika GitHub.
