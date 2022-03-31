using System.Windows;

namespace EmployeeInformation
{
    public partial class MainWindow : Window
    {
        VM vm;

        public MainWindow()
        {
            InitializeComponent();
            vm = VM.Instance;
            DataContext = vm;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            EmployeeEditWindow employeeEditWindow = new EmployeeEditWindow(false) { Owner = this };
            employeeEditWindow.ShowDialog();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (vm.SelectedEmployee != null)
            {
                EmployeeEditWindow employeeEditWindow = new EmployeeEditWindow(true) { Owner = this };
                employeeEditWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an employee to update");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            vm.Delete();
        }
    }
}
