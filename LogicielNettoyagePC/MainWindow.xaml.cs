using System.Diagnostics;
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

namespace LogicielNettoyagePC
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

        private void analyse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void clean_Click(object sender, RoutedEventArgs e)
        {

        }

        private void history_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("TODO: Create history page", "History", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void udpate_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You are running the latest version", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void website_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo("https://github.com/Raul-Toache")
                {
                    UseShellExecute = true
                });
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Error: ", ex.Message);
            }
        }
    }
}