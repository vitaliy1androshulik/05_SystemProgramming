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

namespace WPF_ThreadingHomeWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Thread thread;
        private Thread threadMin;
        private Thread threadMax;
        private Thread threadAverage;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(TextBoxStart.Text.Length==0|| TextBoxEnd.Text.Length == 0 || TextBoxCount.Text.Length == 0)
            {
                MessageBox.Show("Enter information!!","Information!",MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                int a = int.Parse(TextBoxStart.Text);
                int b = int.Parse(TextBoxEnd.Text);
                int count = int.Parse(TextBoxCount.Text);
                int s = 0;

                do
                {
                    thread = new Thread(() => Numbers2(a, b));
                    thread.Start();
                    s++;
                } while (s < count);
                threadMin = new Thread(FindMin);
                threadMin.Start();
                threadMax = new Thread(FindMax);
                threadMax.Start();
                threadAverage = new Thread(FindAverage);
                threadAverage.Start();
            }
            
        }
        private void Numbers2(int a, int b)
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                for (int i = a; i <= b; i++)
                {
                    LabelResult.Content += i.ToString() + " ";
                }
                LabelResult.Content += "\n";
            }));    
        }
        private static int[] RandomNumbers()
        {
            int[] a = new int[10000];
            Random rand = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = rand.Next(0, 5000);
            }
            return a;
        }
        private void FindMax()
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                int[] a = RandomNumbers();
                LabelMax.Content = a.Max();
            }));
        }
        private void FindMin()
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                int[] a = RandomNumbers();
                LabelMin.Content = a.Min();
            }));
            
        }
        private void FindAverage()
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                int[] a = RandomNumbers();
                LabelAverage.Content = a.Average();
            }));
        }

        private void BtnSaveToFile_Click(object sender, RoutedEventArgs e)
        {
            string path = @"C:\Users\Vitaliy\Desktop\test\Test.txt";
            

            if (File.Exists(path)) 
            {
                File.Delete(path);
            }
            else
            {
                FileStream fs = File.Create(path);
                fs.Close();
            }
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("Average number : "+LabelAverage.Content.ToString());
                writer.WriteLine("Max. number : " + LabelMax.Content.ToString());
                writer.WriteLine("Min. number : " + LabelMin.Content.ToString());
            }

        }
    }
}