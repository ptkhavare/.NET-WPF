using System.IO;
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
            string output = "";
            int time = distanceLogicManager.Time;
            int speed = distanceLogicManager.Speed;
            for (int i = 1; i <= time; i++)
            {
                List.Items.Add(speed * i);
            }
            output = "Speed" + speed + "Time ";
            File.AppendAllText("output.txt",output);
        }
    }
}
