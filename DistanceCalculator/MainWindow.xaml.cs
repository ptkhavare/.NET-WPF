﻿using System.Windows;

namespace DistanceCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DistanceLogicManager distanceLogicManager;

        enum DistancUnit
        {
           KMH,
           MS,
           MILESH
        }

        public MainWindow()
        {
            InitializeComponent();
            distanceLogicManager = new DistanceLogicManager();
            DataContext = distanceLogicManager;
        }

        public void CalculateDistance(object sender, RoutedEventArgs e)
        {

            int unitSelected = -1;
            if (KMRd.IsChecked == true)
            {
                unitSelected = (int)DistancUnit.KMH;
            }
            else if(MetersRd.IsChecked == true)
            {
                unitSelected = (int)DistancUnit.MS;
            }
            else if (MilesRd.IsChecked == true) {
                unitSelected = (int)DistancUnit.MILESH;
            }
            distanceLogicManager.CalcDistance(unitSelected);

        }
    }
}
