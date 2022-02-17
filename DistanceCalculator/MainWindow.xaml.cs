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
            bool unit = false;

            if(KM.IsChecked != null)
            {
                unit = (bool)KM.IsChecked;
            }

            if (unit == true)
            {
                distanceLogicManager.CalcDistance(true);
            }
            else
            {
                distanceLogicManager.CalcDistance(false);
            }
        }
    }
}
