# Cat Years Calculator

Lekka aplikacja WPF konwertująca wiek kota na przybliżony wiek ludzki.

## Przegląd
`CatYears` to aplikacja desktopowa napisana w C# (.NET 10 / WPF). Umożliwia wprowadzenie wieku kota (liczba całkowita lub zmiennoprzecinkowa) i obliczenie równowartości w latach ludzkich według prostego modelu (pierwszy rok bardzo szybki, drugi rok — mniejszy wzrost, kolejne lata — stabilny przyrost).

## Wymagania
- .NET 10 SDK
- Visual Studio 2026 z obsługą WPF
- System Windows obsługujący WPF

## Budowanie i uruchamianie

W Visual Studio 2026:
- Otwórz rozwiązanie `CatYears`.
- Przywróć pakiety NuGet (jeśli są wymagane).
- Zbuduj projekt: użyj __Build > Build Solution__.
- Uruchom aplikację: użyj __Debug > Start Debugging__ (F5) lub __Debug > Start Without Debugging__ (Ctrl+F5).

Lub z linii poleceń:

```
dotnet build dotnet run --project ./CatYears
```

## Użycie
- Wprowadź wiek kota w polu tekstowym (np. `3` lub `2.5`).
- Naciśnij Enter lub kliknij przycisk `Oblicz`.
- Wynik pojawi się w kontrolce `ResultTextBlock`.
- Kliknij `Wyczyść`, aby zresetować pole wejściowe i wynik.

## Walidacja wejścia i ograniczenia
- Akceptowane formaty: liczby całkowite i zmiennoprzecinkowe.
- Parsowanie odbywa się najpierw z użyciem `CultureInfo.InvariantCulture`, potem `CultureInfo.CurrentCulture` (obsługa zarówno separatora kropki, jak i separatora przecinka).
- Dopuszczalne wartości: > 0. Aplikacja zgłasza błąd, jeśli wartość jest pusta, niepoprawna lub mniejsza/równa 0.
- Dodatkowe powiadomienie: jeśli wartość przekracza 25 lat, aplikacja pokazuje informację sugerującą, że kot jest wyjątkowo stary.

## Zasady obliczania
Przybliżenie wykonywane jest według następującego algorytmu (opis zgodny z implementacją w `MainWindow.xaml.cs`):
- Dla `catYears <= 1.0`: `humanYears = 15.0 * catYears`
- Dla `1.0 < catYears <= 2.0`: `humanYears = 15.0 + 9.0 * (catYears - 1.0)`
- Dla `catYears > 2.0`: `humanYears = 24.0 + 4.0 * (catYears - 2.0)`
Wynik jest zaokrąglany do jednego miejsca po przecinku.

## Struktura projektu (ważniejsze pliki)
- `MainWindow.xaml` — definicja UI
- `MainWindow.xaml.cs` — logika obsługi zdarzeń i kalkulacji
- `App.xaml` / `App.xaml.cs` — konfiguracja aplikacji
- `AssemblyInfo.cs` — ustawienia motywu zasobów

## Lokalizacja
Interfejs użytkownika jest w języku polskim. Parsowanie liczb wspiera zarówno format invariant (kropka) jak i ustawienia lokalne (np. przecinek).

## Wkład (Contributing)
Repozytorium zdalne: https://github.com/Michiczi/CatYearsCalculator
