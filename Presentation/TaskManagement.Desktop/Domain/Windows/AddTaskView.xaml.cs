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
using TaskManagement.Domain.ViewModels.Tasks;
using TaskManagement.Domain.ViewModels.Users;

namespace TaskManagement.Desktop.Domain.Windows
{
    /// <summary>
    /// Interaction logic for AddTaskView.xaml
    /// </summary>
    public partial class AddTaskView : Window
    {
        public AddTaskView()
        {
            InitializeComponent();
            LoadUsers();
            this.Owner = App.Current.MainWindow;
        }

        private void LoadUsers()
        {
            KeyValuePair<string, Guid> stringArray = new KeyValuePair<string, Guid>();

            TaskManagementFactory taskManagementFactory = (TaskManagementFactory)Activator.GetObject(typeof(TaskManagementFactory),
               "tcp://localhost:8085/TaskManagementFactory");

            List<UserEntityViewModel> users = taskManagementFactory.GetUsers();

            foreach (UserEntityViewModel user in users)
            {
                this.ComboBox_Users.Items.Add(new KeyValuePair<string, Guid>(user.Name, user.EntityGuid));
            }
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            TaskManagementFactory taskManagementFactory = (TaskManagementFactory)Activator.GetObject(typeof(TaskManagementFactory),
               "tcp://localhost:8085/TaskManagementFactory");

            List<TaskEntityViewModel> task = taskManagementFactory.AddTask(new TaskEntityViewModel
            {
                Name = this.TextBox_Description.Text,
                UserGuid = this.ComboBox_Users.SelectedValue is null ? Guid.Empty : Guid.Parse(this.ComboBox_Users.SelectedValue.ToString()),
            });

            this.Close();
        }

        private void User_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
