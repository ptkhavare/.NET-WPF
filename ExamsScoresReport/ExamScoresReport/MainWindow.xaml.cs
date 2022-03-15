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

namespace ExamScoresReport
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly ExamVM examVM = new();

        public MainWindow()
        {
            DataContext = examVM;
            InitializeComponent();
            
        }

        public void GenerateReport(object sender, RoutedEventArgs e)
        {
            examVM.GenerateReport();
        }

    }


}
