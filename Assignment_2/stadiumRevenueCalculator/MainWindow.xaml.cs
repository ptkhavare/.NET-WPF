using System.Windows;

namespace stadiumRevenueCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /**
     * Authors:
     * Pranav Tanaji Khavare
     * Carlos Marquez
     * Keval Kadia
     * Abinash Rai
     * Jaykumar Gohil
     * Ramandeep Kaur
     * Thais Escridelli da Silveira
     */
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ClearBtnClick(object sender, RoutedEventArgs e)
        {
            ticketSoldForClassA.Text = "";
            ticketSoldForClassB.Text = "";
            ticketSoldForClassC.Text = "";
            Height = 350;
            RevenueReport.Visibility = Visibility.Collapsed;
        }
        private void CalculateRevenue(object sender, RoutedEventArgs e)
        {
            string classAQty = ticketSoldForClassA.Text;
            string classBQty = ticketSoldForClassB.Text;
            string classCQty = ticketSoldForClassC.Text;

            if (classAQty != "" || classBQty != "" || classCQty != "")
            {
                decimal classATotal = 0;
                decimal classBTotal = 0;
                decimal classCTotal = 0;
                decimal classARate = 15;
                decimal classBRate = 12;
                decimal classCRate = 9;
                rateA.Content = classARate.ToString("c");
                rateB.Content = classBRate.ToString("c");
                rateC.Content = classCRate.ToString("c");

                if (classAQty != "")
                {
                    try
                    {
                        classATotal = int.Parse(classAQty) * classARate;
                    }
                    catch
                    {
                        classAQty = "Invalid";
                        MessageBox.Show("Invalid Input Detected For Class A Tickets");
                    }
                }
                else
                {
                    classAQty = "0";
                }

                if (classBQty != "")
                {
                    try
                    {
                        classBTotal = int.Parse(classBQty) * classBRate;
                    }
                    catch
                    {
                        classBQty = "Invalid";
                        MessageBox.Show("Invalid Input Detected For Class B Tickets");
                    }
                }
                else
                {
                    classBQty = "0";
                }

                if (classCQty != "")
                {
                    try
                    {

                        classCTotal = int.Parse(classCQty) * classCRate;
                    }
                    catch
                    {
                        classCQty = "Invalid";
                        MessageBox.Show("Invalid Input Detected For Class C Tickets");
                    }
                }
                else
                {
                    classCQty = "0";
                }

                decimal revenueTotal = classATotal + classBTotal + classCTotal;

                ClassAQty.Content = classAQty;
                ClassBQty.Content = classBQty;
                ClassCQty.Content = classCQty;

                ClassATotal.Text = classATotal.ToString("c");
                ClassBTotal.Text = classBTotal.ToString("c");
                ClassCTotal.Text = classCTotal.ToString("c");

                TotalRevenue.Text = revenueTotal.ToString("c");

                Height = 800;
                RevenueReport.Visibility = Visibility.Visible;

            }
            else
            {
                MessageBox.Show("Please enter atleast one quantity to calculate revenue!");
            }
        }
    }
}
