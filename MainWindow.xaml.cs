using System;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace CatYears
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InputCatAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Calculate();
                e.Handled = true;
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            InputCatAge.Text = string.Empty;
            ResultTextBlock.Text = string.Empty;
            InputCatAge.Focus();
        }

        private void Calculate()
        {
            if (string.IsNullOrWhiteSpace(InputCatAge.Text))
            {
                ResultTextBlock.Text = "Wpisz wiek kota.";
                return;
            }

            if (!double.TryParse(InputCatAge.Text.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out double catYears))
            {
                if (!double.TryParse(InputCatAge.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out catYears))
                {
                    ResultTextBlock.Text = "Niepoprawny format. Użyj np. 3 lub 2.5";
                    return;
                }
            }

            if (catYears <= 0)
            {
                ResultTextBlock.Text = "Wiek musi być większy niż 0.";
                return;
            }

            if (catYears > 25)
            {
                ResultTextBlock.Text = "Twój kot musi być naprawdę stary";
                return;
            }

            double humanYears;
            if (catYears <= 1.0)
            {
                humanYears = 15.0 * catYears;
            }
            else if (catYears <= 2.0)
            {
                humanYears = 15.0 + 9.0 * (catYears - 1.0);
            }
            else
            {
                humanYears = 24.0 + 4.0 * (catYears - 2.0);
            }

            humanYears = Math.Round(humanYears, 1);
            ResultTextBlock.Text = $"Twój kot ma równowartość ~ {humanYears} lat ludzkich.";
        }
    }
}