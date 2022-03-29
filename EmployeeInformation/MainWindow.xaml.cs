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

namespace EmployeeInformation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
            if(vm.SelectedEmployee != null)
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
