using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CarGame
{
    internal class VM : INotifyPropertyChanged
    {
        public Car playerOneCar = new Car(2020, "Ferrari");
        public Car playerTwoCar = new Car(2018, "Buggati");

        private bool playerOneSelected = false;

        private bool playerTwoSelected = false;

        private Car selectedCar = null;

        public Car SelectedCar
        {
            get { return selectedCar; }
            set { selectedCar = value; NotifyPropertyChanged(); }
        }

        public bool PlayerOneSelected
        {
            get { return playerOneSelected; }
            set
            {
                playerOneSelected = value;
                if (playerOneSelected)
                {
                    SelectedCar = playerOneCar;
                }
                NotifyPropertyChanged();
            }
        }

        public bool PlayerTwoSelected
        {
            get { return playerTwoSelected; }
            set
            {
                playerTwoSelected = value;
                if (playerTwoSelected)
                {
                    SelectedCar = playerTwoCar;
                }
                NotifyPropertyChanged();
            }
        }

        #region Property Changed
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
