using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace KineticEnergyCalculator
{
    internal class KinecticEnergyManager : INotifyPropertyChanged
    {
       

        private const double half = 0.5d;
        private const double julesToCalories = 0.239006;

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

        private string validation = "";

        public string Validation
        {
            get { return validation; }
            set { validation = value; NotifyPropertyChanged(); }
        }


        private ComboBoxItem selectedEnergyUnit;

        public ComboBoxItem SelectedEnergyUnit
        {
            get { return selectedEnergyUnit; }
            set
            {
                if (selectedEnergyUnit == value) return;
                selectedEnergyUnit = value; convertUnit(); NotifyPropertyChanged();
            }
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
        private (bool, double) CalcKineticEnergy(double Mass, double Velocity)
        {
            bool isValid = Mass >= 0 && Velocity >= 0;
            double ke = 0;

            if (isValid)
            {
                ke = half * Mass * Math.Pow(Velocity, 2);
            }
            return (isValid, ke);
        }

        private void convertUnit()
        {
            if (SelectedEnergyUnit.Name == "Jules")
            {
                Result = Result/julesToCalories;
            }
            else if (SelectedEnergyUnit.Name == "Calories")
            {
                Result = Result * julesToCalories;
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
