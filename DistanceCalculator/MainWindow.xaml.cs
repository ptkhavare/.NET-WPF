using System.Windows;

namespace DistanceCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DistanceLogicManager distanceLogicManager;

        public MainWindow()
        {
            InitializeComponent();
            distanceLogicManager = new DistanceLogicManager();
            DataContext = distanceLogicManager;
        }

        public void CalculateDistance(object sender, RoutedEventArgs e)
        {
            distanceLogicManager.CalcDistance();
            //todo clear file
            //todo bindinglist
            //todo path.
            //observable
        }
    }
}
