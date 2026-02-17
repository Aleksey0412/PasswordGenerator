using System;
using System.Windows;
using System.Windows.Controls;

namespace PasswordGenerator
{
    public partial class MainWindow : Window
    {
        AppData.PasswordGenerator _passwordGenerator;

        public MainWindow()
        {
            InitializeComponent();
            _passwordGenerator = new AppData.PasswordGenerator();

            // Генерируем начальный пароль при запуске
            GeneratePasswordPreview();
        }

        private void ShowPasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ShowPasswordBtn.IsChecked == true)
            {
                PasswordTb.Text = PasswordPb.Password;
                PasswordTb.Visibility = Visibility.Visible;
                PasswordPb.Visibility = Visibility.Collapsed;
                ShowPasswordBtn.Content = "🔓"; // Открытый замок при показе
            }
            else
            {
                PasswordPb.Password = PasswordTb.Text;
                PasswordPb.Visibility = Visibility.Visible;
                PasswordTb.Visibility = Visibility.Collapsed;
                ShowPasswordBtn.Content = "🔒"; // Закрытый замок при скрытии
            }
        }

        private void GeneratePasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            GeneratePasswordPreview();
        }

        private void PasswordType_Checked(object sender, RoutedEventArgs e)
        {
            // Генерируем новый пароль при изменении чекбоксов
            GeneratePasswordPreview();
        }

        private void PasswordLengthSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            AppData.PasswordGenerator.PASSWORD_LENGTH = (int)((Slider)sender).Value;
            GeneratePasswordPreview();
        }

        private void PasswordLengthTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(PasswordLengthTb.Text, out int length))
            {
                length = Math.Max(4, Math.Min(16, length));
                PasswordLengthSlider.Value = length;
                AppData.PasswordGenerator.PASSWORD_LENGTH = length;
                GeneratePasswordPreview();
            }
        }

        private void GeneratePasswordPreview()
        {
            // Проверяем, что все элементы инициализированы
            if (LowerCaseCb == null || UpperCaseCb == null || NumberCb == null || SymbolsCb == null)
                return;

            PasswordPb.Password = PasswordTb.Text = AppData.PasswordGenerator.Start(
                LowerCaseCb.IsChecked ?? false,
                UpperCaseCb.IsChecked ?? false,
                NumberCb.IsChecked ?? false,
                SymbolsCb.IsChecked ?? false);
        }

    }
}
