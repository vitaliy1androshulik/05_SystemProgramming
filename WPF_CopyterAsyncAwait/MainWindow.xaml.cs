using IOExtensions;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using PropertyChanged;
using System.Collections.ObjectModel;
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

namespace WPF_CopyterAsyncAwait
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel model;
        public MainWindow()
        {
            InitializeComponent();
            //SourceTextBox.Text=Source = "C:\\Users\\Vitaliy\\Desktop\\123.zip";
            //
            //Destination = "C:\\Users\\Vitaliy\\Desktop\\s";
            //DestTextBox.Text = Destination;
            //progressbarMy.Value = 0;

            model = new ViewModel()
            {
                Source = "C:\\Users\\Vitaliy\\Downloads\\1GB.bin",
                Destination = "C:\\Users\\Vitaliy\\Desktop\\test",
                Progress = 0
            };
            this.DataContext = model; 
        }

        private async void BtnCopy_Click(object sender, RoutedEventArgs e)
        {
            string fileName = System.IO.Path.GetFileName(model.Source);
            string desFilePath = System.IO.Path.Combine(model.Destination, fileName);

            CopyProcessInfo info = new CopyProcessInfo(fileName);
            model.AddProccess(info);
            await CopyFileAsync(model.Source, desFilePath, info);
            info.Percentage = 100;
            MessageBox.Show("Copied!", "Copy");
        }
        private Task CopyFileAsync(string src, string desc, CopyProcessInfo info)
        {
            //using class FileTransferManager
            return FileTransferManager.CopyWithProgressAsync(src, desc, progress =>
            {
                //model.Progress = progress.Percentage;
                info.Percentage=progress.Percentage;
                info.BytesPerSecond = progress.BytesPerSecond;
            }, false);

            #region
            //copy file from source to destination            
            //File.Copy(Source, desFilePath, true);
            //return Task.Run(() =>
            //{
            //    using (FileStream srcStream = new FileStream(src, FileMode.Open,
            //    FileAccess.Read))
            //    {
            //        using (FileStream decsStream = new FileStream(desc,
            //            FileMode.Create, FileAccess.Write))
            //        {
            //            byte[] buffer = new byte[1024 * 8];//8Kb
            //
            //            do
            //            {
            //                int bytes = srcStream.Read(buffer, 0, buffer.Length);
            //                decsStream.Write(buffer, 0, buffer.Length);
            //                float percentage = decsStream.Length / (srcStream.Length * 100);
            //                model.Progress = percentage;
            //            } while (srcStream.Length > 0);
            //            //srcStream.Close();
            //            //decsStream.Close();
            //        }
            //
            //    }
            //});
            #endregion
        }

        private void BtnSource_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                model.Source = openFileDialog.FileName;
                //SourceTextBox.Text = Source;
            }
        }

        private void BtnDestination_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            //CommonFileDialogResult res =dialog.ShowDialog();
            if(dialog.ShowDialog()==CommonFileDialogResult.Ok)
            {
                model.Destination = dialog.FileName;
               // DestTextBox.Text = Destination;
            }

        }
    }
    [AddINotifyPropertyChangedInterface]
    public class ViewModel
    {
        public ObservableCollection<CopyProcessInfo> processes;
        public string Source { get; set; }
        public string Destination { get; set; }
        public double Progress { get; set; }
        public bool IsWaiting => Progress == 0;
        public ViewModel()
        {
            processes = new ObservableCollection<CopyProcessInfo>();
        }
        public IEnumerable<CopyProcessInfo> Processes => processes;//get
        public void AddProccess(CopyProcessInfo info)
        {
            processes.Add(info);
        }
    }
    [AddINotifyPropertyChangedInterface]
    public class CopyProcessInfo
    {
        public string Name { get; set; }
        public double Percentage { get; set; }
        public int PercentageInt => (int)Percentage;
        public double BytesPerSecond { get; set; }
        public double MegaBytesPerSecond => Math.Round(BytesPerSecond / 1024 / 1024, 1);
        public CopyProcessInfo(string fileName)
        {
            this.Name = fileName;
        }

    }
}