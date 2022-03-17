using System.Windows;

namespace ExamScoresReport
{
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
