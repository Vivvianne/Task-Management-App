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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskManagement.Desktop.Domain.Windows;

namespace TaskManagement.Desktop.Domain.Views
{
    /// <summary>
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class UsersView : UserControl
    {
        public UsersView()
        {
            InitializeComponent();
        }

        private void Add_User_Button_Click(object sender, RoutedEventArgs e)
        {
            AddUserView addUserView = new AddUserView();
            addUserView.ShowDialog();
        }
    }
}
