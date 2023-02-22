using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TaskManagement.Desktop.Domain.ViewModel;
using TaskManagement.Domain.Factories;
using TaskManagement.Domain.ViewModels.Options;

namespace TaskManagement.Desktop.Domain.Windows
{
    /// <summary>
    /// Interaction logic for OptionsFormView.xaml
    /// </summary>
    public partial class OptionsFormView : Window
    {
        public OptionsFormView()
        {
            InitializeComponent();
            this.Owner = App.Current.MainWindow;
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(this.OptionLabel.Text);
            TaskManagementFactory taskManagementFactory = (TaskManagementFactory)Activator.GetObject(typeof(TaskManagementFactory),
               "tcp://localhost:8085/TaskManagementFactory");

            

            List<OptionEntityViewModel> options = taskManagementFactory.AddOption(new OptionEntityViewModel
            {
                Label = this.OptionLabel.Text
            });

            foreach (OptionEntityViewModel option in options)
            {
                Console.WriteLine($"{option.Label}");
            }

            this.Close();
        }
    }
}
