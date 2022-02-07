using System.Windows;
using System.Windows.Media;

namespace SerendipityBooksellersBookClub
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int LEVEL_ONE = 0;
        private const int LEVEL_TWO = 1;
        private const int LEVEL_THREE = 2;
        private const int LEVEL_FOUR = 3;
        private const int LEVEL_FIVE = 4;
        private const int LEVEL_ONE_POINTS = 0;
        private const int LEVEL_TWO_POINTS = 5;
        private const int LEVEL_THREE_POINTS = 15;
        private const int LEVEL_FOUR_POINTS = 30;
        private const int LEVEL_FIVE_POINTS = 60;
        private const string ERROR_MSG_FOR_INVALID = "Please Input a Valid Number";

        public MainWindow()
        {
            InitializeComponent();
            MainGrid.Background = new LinearGradientBrush(Color.FromRgb(34, 111, 84), Color.FromRgb(135, 195, 143), 45);
        }
        private void ClearBtnClick(object sender, RoutedEventArgs e)
        {
            pointsEarnedTBlck.Text = "";
            numberOfBooksTBx.Text = "";
        }
        private void CalcPoints(object sender, RoutedEventArgs e)
        {
            string numOfBooks = numberOfBooksTBx.Text;
            int booksPurchased = -1;
            pointsEarnedTBlck.Text = "";
            if (!string.IsNullOrEmpty(numOfBooks))
            {
                try
                {
                    booksPurchased = int.Parse(numOfBooks);
                }
                catch
                {
                    booksPurchased = -1;
                    pointsEarnedTBlck.Text = ERROR_MSG_FOR_INVALID;
                    pointsEarnedTBlck.Foreground = new SolidColorBrush(Color.FromRgb(218, 44, 56));
                }

                if (booksPurchased >= 0)
                {
                    pointsEarnedTBlck.Foreground = new SolidColorBrush(Colors.Green);

                    if (booksPurchased.Equals(LEVEL_ONE))
                    {
                        pointsEarnedTBlck.Text = "You have earned " + LEVEL_ONE_POINTS + " points.";
                        pointsEarnedTBlck.Foreground = new SolidColorBrush(Colors.Yellow);
                    }
                    else if (booksPurchased.Equals(LEVEL_TWO))
                    {
                        pointsEarnedTBlck.Text = "You have earned " + LEVEL_TWO_POINTS + " points.";

                    }
                    else if (booksPurchased.Equals(LEVEL_THREE))
                    {
                        pointsEarnedTBlck.Text = "You have earned " + LEVEL_THREE_POINTS + " points.";

                    }
                    else if (booksPurchased.Equals(LEVEL_FOUR))
                    {
                        pointsEarnedTBlck.Text = "You have earned " + LEVEL_FOUR_POINTS + " points.";

                    }
                    else if (booksPurchased >= LEVEL_FIVE)
                    {
                        pointsEarnedTBlck.Text = "You have earned " + LEVEL_FIVE_POINTS + " points.";

                    }
                }
                else
                {
                    pointsEarnedTBlck.Text = ERROR_MSG_FOR_INVALID;
                }
            }
           
        }
    }
}



