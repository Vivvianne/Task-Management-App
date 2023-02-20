using System.Windows;

namespace TaskManagement.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //RemoteAdd remoteAdd = (RemoteAdd)Activator.GetObject(typeof(RemoteAdd),
            //   "tcp://localhost:8085/RemoteAdd");

            //Console.WriteLine(remoteAdd.Add(1, 2));
        }
    }
}
