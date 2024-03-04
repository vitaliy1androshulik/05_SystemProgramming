using System.Data;
using System.Runtime.CompilerServices;
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

namespace WPF_TasksHomeWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Task task = new Task(()=>GetCurrentTime(LabelCurrenTime));
            task.Start();
        }
        private void GetCurrentTime(Label name)
        {
            //this.Dispatcher.Invoke(new Action(() =>
            //{
            
            //}));
            
        }
    }
}