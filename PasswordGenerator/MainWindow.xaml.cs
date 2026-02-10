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

namespace PasswordGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppData.PasswordGenerator _passwordGenerator;
        public MainWindow()
        {
            InitializeComponent();

            _passwordGenerator = new AppData.PasswordGenerator(true, true, true, true);
        }

        private void ShowPasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ShowPasswordBtn.IsChecked == true)
            {
                PasswordTb.Text = PasswordPb.Password;
                PasswordPb.Visibility = Visibility.Collapsed;
                PasswordTb.Visibility = Visibility.Visible;
                ShowPasswordBtn.Content = "🔒";
            }
            else
            {
                PasswordPb.Password= PasswordTb.Text;
                PasswordPb.Visibility = Visibility.Visible;
                PasswordTb.Visibility = Visibility.Collapsed;
                ShowPasswordBtn.Content = "🔓";
            }
                

        }
        

        private void GeneratePasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            PasswordTb.Text = PasswordTb.Text = _passwordGenerator.Start();
        }
    }
}