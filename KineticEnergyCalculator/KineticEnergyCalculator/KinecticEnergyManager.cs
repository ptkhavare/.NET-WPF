using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KineticEnergyCalculator
{
    internal class KinecticEnergyManager : INotifyPropertyChanged
    {
        private double half = 0.5d;

        private double mass = 0;

        public double Mass
        {
            get { return mass; }
            set { mass = value; NotifyPropertyChanged(); }
        }

        private double velocity = 0;

        public double Velocity
        {
            get { return velocity; }
            set { velocity = value; NotifyPropertyChanged(); }
        }

        private double result = 0;

        public double Result
        {
            get { return result; }
            set { result = value; NotifyPropertyChanged(); }
        }

        public string validation ="";

        public string Validation
        {
                get { return validation; }
                set { validation = value; NotifyPropertyChanged(); }
        }

        public void calcKE()
        {
            (bool isValid, double ke) = CalcKineticEnergy(Mass, Velocity);
            if (isValid)
            {
                Result = ke;
            }
            else
            {
                Validation = "Please Enter correct values:";
            }
        }
        private (bool  , double)  CalcKineticEnergy(double Mass, double Velocity)
        {
            bool isValid = Mass >= 0 && Velocity >= 0;
            double ke = 0;

            if (isValid)
            {
                ke = half * Mass * Math.Pow(Velocity, 2);
            }
            return (isValid, ke);
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
