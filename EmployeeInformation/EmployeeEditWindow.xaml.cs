using System.Windows;

namespace EmployeeInformation
{
    public partial class EmployeeEditWindow : Window
    {
        readonly VM vm;
        readonly Employee employee = new Employee();

        public EmployeeEditWindow(bool isEdit)
        {
            InitializeComponent();
            vm = VM.Instance;

            if (isEdit)
            {
                employee.EmployeeID = vm.SelectedEmployee.EmployeeID;
                employee.Name = vm.SelectedEmployee.Name;
                employee.Position = vm.SelectedEmployee.Position;
                employee.PayPerHour = vm.SelectedEmployee.PayPerHour;

                employee.IsNew = false;
                IDtxt.IsEnabled = false;
            }
            else
            {
                Title = "Add Employee";
                IDtxt.IsEnabled = false;
                IDtxt.Visibility = Visibility.Hidden;
            }
            DataContext = employee;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            vm.Save(employee);
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
