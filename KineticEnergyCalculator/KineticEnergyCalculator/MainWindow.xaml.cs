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

namespace KineticEnergyCalculator
{
    public partial class MainWindow : Window
    {
        KinecticEnergyManager kinecticEnergyManager = new KinecticEnergyManager();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = kinecticEnergyManager;
        }

        public void CalculateKineticEnergy(object sender, RoutedEventArgs e)
        {
            cbUnits.SelectedValue = 0 ;
            kinecticEnergyManager.calcKE();
        }

    }
}
