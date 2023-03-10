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
            LoadParentOptions();
            this.Owner = App.Current.MainWindow;
        }

        private string ParentOptionGuid { get; set; }

        private void LoadParentOptions()
        {
            KeyValuePair<string, Guid> stringArray = new KeyValuePair<string, Guid>();

            TaskManagementFactory taskManagementFactory = (TaskManagementFactory)Activator.GetObject(typeof(TaskManagementFactory),
               "tcp://localhost:8085/TaskManagementFactory");

            List<OptionEntityViewModel> options = taskManagementFactory.ListOptions();

            foreach(OptionEntityViewModel option in options)
            {
                this.ComboBox_ParentOption.Items.Add(new KeyValuePair<string, Guid>(option.Label, option.EntityGuid));
            }
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            TaskManagementFactory taskManagementFactory = (TaskManagementFactory)Activator.GetObject(typeof(TaskManagementFactory),
               "tcp://localhost:8085/TaskManagementFactory");

            Console.WriteLine(string.IsNullOrEmpty(this.ParentOptionGuid));

            List<OptionEntityViewModel> options = taskManagementFactory.AddOption(new OptionEntityViewModel
            {
                Label = this.TextBox_OptionLabel.Text,
                ParentEntityGuid = string.IsNullOrEmpty(this.ParentOptionGuid) ? Guid.Empty : Guid.Parse(this.ParentOptionGuid),
            });

            this.Close();
        }

        private void ParentOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.ParentOptionGuid = this.ComboBox_ParentOption.SelectedValue.ToString();
        }
    }
}
