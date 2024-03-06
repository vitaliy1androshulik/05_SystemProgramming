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

namespace WPF_TaskAsyncAwait
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random rand = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //int value=GenerateValue();
            //Task<int> task = Task.Run(GenerateValue);

            //ListBoxNumbers.Items.Add(task.Result);
            //task.Wait();//freeze

            //async - allow method tp use await keywords
            //await - wait task without freeze
            //await task;//without freezing 
            //MessageBox.Show("Complete!");
            //int value = task.Result;
            ListBoxNumbers.Items.Add(await GenerateValueAsync());
        }
        int GenerateValue()
        {
            Thread.Sleep(rand.Next(5000));
            //MessageBox.Show("Generated!");
            return rand.Next(0,1000);
        }
        Task<int> GenerateValueAsync()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(rand.Next(1000));
                return rand.Next(0, 1000);
            });
        }
    }

}