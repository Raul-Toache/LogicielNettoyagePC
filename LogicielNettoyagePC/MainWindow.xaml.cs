using System.Diagnostics;
using System.IO;
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
        public DirectoryInfo winTemp;
        public DirectoryInfo appTemp;

        public MainWindow()
        {
            InitializeComponent();
            winTemp = new DirectoryInfo(@"C:\Windows\Temp");
            appTemp = new DirectoryInfo(System.IO.Path.GetTempPath());
        }

        // Calculates a folder's size
        public long DirSize(DirectoryInfo dir)
        {
            return dir.GetFiles().Sum(fi => fi.Length) + dir.GetDirectories().Sum(di => DirSize(di));
        }

        // Clear a folder
        public void ClearTempData(DirectoryInfo di)
        {
            foreach (FileInfo file in di.GetFiles())
            {
                try
                {
                    file.Delete();
                    Console.WriteLine(file.FullName);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                try
                {
                    dir.Delete(true);
                    Console.WriteLine(dir.FullName);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
        }

        private void scan_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Starting analysis...");
            long totalSize = 0;

            try
            {
                totalSize += DirSize(winTemp) / 1_000_000;
                totalSize += DirSize(appTemp) / 1_000_000;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible to analyze these folders: " + ex.Message);
            }

            space.Content = totalSize + " MB";
            title.Content = "Analyze done!";
            date.Content = DateTime.Today;
        }

        private void clean_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            TextBlock textBlock = (TextBlock)((StackPanel)button.Content).Children[1];

            Console.WriteLine("Cleaning...");
            textBlock.Text = "CLEANING";

            Clipboard.Clear();

            try
            {
                ClearTempData(winTemp);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            try
            {
                ClearTempData(appTemp);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            textBlock.Text = "FINISHED CLEANING";
            title.Content = "Finished cleaning";
            space.Content = "0 MB";
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