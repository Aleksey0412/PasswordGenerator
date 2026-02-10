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

            _passwordGenerator = new AppData.PasswordGenerator(true, false, true, true);
        }

        private void ShowPasswordBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GeneratePasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginTb.Text = _passwordGenerator.Start();
        }
    }
}