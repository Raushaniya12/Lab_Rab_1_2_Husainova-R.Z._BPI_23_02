using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            try
            {
                string input = WriteX.Text?.Trim();
                if (string.IsNullOrEmpty(input))
                {
                    MessageBox.Show("Введите значение x!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    WriteX.Focus();
                    return;
                }

                string cleaned = input.Replace(',', '.');

                if (!double.TryParse(cleaned, NumberStyles.Float, CultureInfo.InvariantCulture, out double x))
                {
                    MessageBox.Show("Некорректное число! Используйте формат 0.5 или 0,5", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    WriteX.SelectAll();
                    WriteX.Focus();
                    return;
                }

                int selectedIndex = ComboFunction.SelectedIndex;

                double result = 0;
                string funcName = "";

                switch (selectedIndex)
                {
                    case 0:
                        if (x < -1 || x > 1)
                            throw new ArgumentOutOfRangeException(nameof(x), "Для arcsin(x): x должен быть в диапазоне [-1; 1]");
                        var arcsinFunc = new Arcsin();
                        result = arcsinFunc.Calculate(x);
                        funcName = arcsinFunc.GetName();
                        break;


                    case 1:
                        if (x < -1 || x > 1)
                            throw new ArgumentOutOfRangeException(nameof(x), "Для arccos(x): x должен быть в диапазоне [-1; 1]");
                        var arccosFunc = new Arccos();
                        result = arccosFunc.Calculate(x);
                        funcName = arccosFunc.GetName();
                        break;


                    default:
                        MessageBox.Show("Выберите функцию из списка!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                }


                TxtResult.Text = $"f(x) = {funcName}({x})\nРезультат: {result:F6}";
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                WriteX.SelectAll();
                WriteX.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизвестная ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnDerivative_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = WriteX.Text?.Trim();
                if (string.IsNullOrEmpty(input))
                {
                    MessageBox.Show("Введите значение x!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    WriteX.Focus();
                    return;
                }
                string cleaned = input.Replace(',', '.');
                if (!double.TryParse(cleaned, NumberStyles.Float, CultureInfo.InvariantCulture, out double x))
                {
                    MessageBox.Show("Некорректное число", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    WriteX.SelectAll();
                    WriteX.Focus();
                    return;
                }

                int selectedIndex = ComboFunction.SelectedIndex;


                if (selectedIndex < 0)
                {
                    MessageBox.Show("Выберите функцию из списка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                double result = 0;
                string funcName = "";

                switch (selectedIndex)
                {
                    case 0:
                        if (Math.Abs(x) >= 1)
                            throw new ArgumentOutOfRangeException(nameof(x), "Для производной arcsin(x): |x| должен быть < 1");
                        var arcsinFunc = new Arcsin();
                        result = arcsinFunc.CalculateDerivative(x);
                        funcName = "производная arcsin";
                        break;


                    case 1:
                        if (Math.Abs(x) >= 1)
                            throw new ArgumentOutOfRangeException(nameof(x), "Для производной arccos(x): |x| должен быть < 1");
                        var arccosFunc = new Arccos();
                        result = arccosFunc.CalculateDerivative(x);
                        funcName = "производная arccos";
                        break;
                    default:
                        MessageBox.Show("Неизвестная функция!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;

                }

                TxtResult.Text = $"f'(x) = {funcName}({x})\nРезультат: {result:F6}";
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                WriteX.SelectAll();
                WriteX.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизвестная ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}