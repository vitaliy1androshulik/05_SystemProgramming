using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
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

namespace WPF_AsyncHomeWork
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

        private async void BtnFrom_Click(object sender, RoutedEventArgs e)
        {
            TextBoxFrom.Text = await GetFilePath();
        }
        private async void BtnTo_Click(object sender, RoutedEventArgs e)
        {
            TextBoxTo.Text = await GetFolderPath();
        }
        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            TextBoxFrom.Text = null;
            TextBoxTo.Text = null;
        }

        private async void BtnCopy_ClickAsync(object sender, RoutedEventArgs e)
        {
            string fromPath = TextBoxFrom.Text;
            string toFolderPath = TextBoxTo.Text;
            string finalFilePath = System.IO.Path.Combine(toFolderPath, 
                System.IO.Path.GetFileName(fromPath));
            try
            {
                await CopyFileAsync(fromPath, finalFilePath);
                MessageBox.Show("File copied!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Select files pathes!!{ex.Message}");
            }
        }
        Task<string> GetFolderPath()
        {
            return Task.Run(() =>
            {
                OpenFolderDialog openFolderDialog = new OpenFolderDialog();
                openFolderDialog.ShowDialog();
                return openFolderDialog.FolderName;
            });
        }
        Task<string> GetFilePath()
        {
            return Task.Run(() =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.ShowDialog();
                return openFileDialog.FileName;
            });

        }
        async Task CopyFileAsync(string fromPath, string toPath)
        {
            FileStream fromFile = File.Open(fromPath, FileMode.Open);
            FileStream toFile = File.Create(toPath);
            await fromFile.CopyToAsync(toFile);
        }
    }
}