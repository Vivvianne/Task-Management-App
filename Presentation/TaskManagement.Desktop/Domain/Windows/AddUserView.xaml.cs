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
using TaskManagement.Domain.Factories;
using TaskManagement.Domain.ViewModels.Options;
using TaskManagement.Domain.ViewModels.Users;

namespace TaskManagement.Desktop.Domain.Windows
{
    /// <summary>
    /// Interaction logic for AddUserView.xaml
    /// </summary>
    public partial class AddUserView : Window
    {
        public AddUserView()
        {
            InitializeComponent();
            this.Owner = App.Current.MainWindow;
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            TaskManagementFactory taskManagementFactory = (TaskManagementFactory)Activator.GetObject(typeof(TaskManagementFactory),
               "tcp://localhost:8085/TaskManagementFactory");

            List<UserEntityViewModel> users = taskManagementFactory.AddUser(new UserEntityViewModel
            {
                
                Name = this.TextBox_UserName.Text,
            });

            this.Close();
        }
    }
}
