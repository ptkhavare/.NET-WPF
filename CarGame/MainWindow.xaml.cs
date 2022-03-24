using System;
using System.Windows;
using System.Windows.Threading;

namespace CarGame
{
    public partial class MainWindow : Window
    {
        readonly VM vm = new();
        private const int maxTimerSeconds = 15;
        int count = 0;
        int count2 = 0;
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer timer2 = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void Accelarate_Click(object sender, RoutedEventArgs e)
        {
            if (vm.SelectedCar != null)
            {

                vm.SelectedCar.Accelarate();
            }
        }

        private void Start_Timer1(object sender, RoutedEventArgs e)
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        private void timer_Tick(object? sender, EventArgs e)
        {
            count++;
            playerOneTimer.Content = count;
            if (count >= maxTimerSeconds)
            {
                timer.Stop();
                playerOne.IsEnabled = false;
                playerTwo.IsEnabled = true;
                accelarateBtn.IsEnabled = false;
                brakeBtn.IsEnabled = false;
            }
        }

        private void Start_Timer2(object sender, RoutedEventArgs e)
        {
            accelarateBtn.IsEnabled = true;
            brakeBtn.IsEnabled = true;
            timer2.Interval = TimeSpan.FromSeconds(1);
            timer2.Tick += timer_Tick2;
            timer2.Start();
        }

        private void timer_Tick2(object? sender, EventArgs e)
        {
            count2++;
            playerTwoTimer.Content = count2;

            if (count2 >= maxTimerSeconds)
            {
                timer2.Stop();
                accelarateBtn.IsEnabled = false;
                brakeBtn.IsEnabled = false;
                playerOne.IsEnabled = true;

                if (vm.playerOneCar.Speed == vm.playerTwoCar.Speed)
                {
                    result.Content = "The race was a draw";
                }

                else if (vm.playerOneCar.Speed > vm.playerTwoCar.Speed)
                {
                    result.Content = "Player One won the race with a top speed of " + vm.playerOneCar.Speed;
                }
                else
                {
                    result.Content = "Player Two won the race with a top speed of " + vm.playerTwoCar.Speed;
                }
            }
        }

        private void Brake_Click(object sender, RoutedEventArgs e)
        {
            if (vm.SelectedCar != null)
            {
                vm.SelectedCar.Brake();
            }
        }

        private void GearUP_Click(object sender, RoutedEventArgs e)
        {
            if (vm.SelectedCar != null)
            {
                vm.SelectedCar.gearUp();
            }
        }

        private void GearDOWN_Click(object sender, RoutedEventArgs e)
        {
            if (vm.SelectedCar != null)
            {
                vm.SelectedCar.gearDown();
            }
        }
    }
}
