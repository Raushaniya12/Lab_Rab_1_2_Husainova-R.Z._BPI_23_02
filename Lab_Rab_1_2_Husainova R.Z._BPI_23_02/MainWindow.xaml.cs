using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lab_Rab_1_2_Husainova_R.Z._BPI_23_02
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WriteX_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0) && e.Text != "." && e.Text != "," && e.Text != "-")
                e.Handled = true;
        }

        private void WriteX_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (!TryGetFunctionAndX(out Function func, out double x))
                return;

            try
            {
                double result = func.Calculate(x);
                TxtResult.Text = $"f(x) = {func.Name}({x})\nРезультат: {result:F6}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                WriteX.SelectAll();
                WriteX.Focus();
            }
        }

        private void BtnDerivative_Click(object sender, RoutedEventArgs e)
        {
            if (!TryGetFunctionAndX(out Function func, out double x))
                return;

            try
            {
                double result = Derivative.Calculate(func, x);
                TxtResult.Text = $"f'(x) = производная {func.Name}({x})\nРезультат: {result:F6}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                WriteX.SelectAll();
                WriteX.Focus();
            }
        }

        private bool TryGetFunctionAndX(out Function func, out double x)
        {
            func = null;
            x = 0;

            string input = WriteX.Text?.Trim();
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Введите значение x!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                WriteX.Focus();
                return false;
            }

            string cleaned = input.Replace(',', '.');
            if (!double.TryParse(cleaned, NumberStyles.Float, CultureInfo.InvariantCulture, out x))
            {
                MessageBox.Show("Некорректное число! Используйте формат 0.5 или 0,5", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                WriteX.SelectAll();
                WriteX.Focus();
                return false;
            }

            switch (ComboFunction.SelectedIndex)
            {
                case 0:
                    func = new Arcsin();
                    return true;
                case 1:
                    func = new Arccos();
                    return true;
                default:
                    MessageBox.Show("Выберите функцию из списка!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
            }
        }
        }
    }
