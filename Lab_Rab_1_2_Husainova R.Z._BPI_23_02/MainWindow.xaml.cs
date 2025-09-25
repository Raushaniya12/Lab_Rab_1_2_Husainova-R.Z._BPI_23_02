using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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

            }

            catch { }
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

            }
            catch { }
        }
    }
}
