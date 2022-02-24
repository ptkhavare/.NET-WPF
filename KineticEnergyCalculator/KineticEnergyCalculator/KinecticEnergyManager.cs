using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace KineticEnergyCalculator
{
    internal class KinecticEnergyManager : INotifyPropertyChanged
    {

        #region Constants
        private const double half = 0.5d;
        private const double joulesToCalories = 0.239006;
        private const double joulesToMegaJoules = 1000000d;
        private const double joulesToBTU = 0.000948d;
        private const string joules = "Joules";
        private const string megaJoules = "MegaJoules";
        private const string calories = "Calories";
        private const string btu = "BTU";
        private const string joulesUnit = " J";
        private const string megaJoulesUnit = " MJ";
        private const string caloriesUnit = " cal";
        private const string btuUnit = " BTU";

        private const int roundingDigit = 2;
        #endregion

        #region Properties
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

        private double kineticEnergyInJoules = 0;

        public double KineticEnergyInJoules
        {
            get { return kineticEnergyInJoules; }
            set { kineticEnergyInJoules = value; NotifyPropertyChanged(); }
        }

        private string result = "";

        public string Result
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
                selectedEnergyUnit = value; ConvertUnit(); NotifyPropertyChanged();
            }
        }
        #endregion

        #region logic
        public void calcKE()
        {
            SelectedEnergyUnit = null;
            Validation = "";
            (bool isValid, double ke) = CalcKineticEnergy(Mass, Velocity);
            if (isValid)
            {
                KineticEnergyInJoules = ke;
                Result = Math.Round(KineticEnergyInJoules, 2).ToString() + (joulesUnit);
            }
            else
            {
                Validation = "Mass and Velocity should be greater than 0";
                KineticEnergyInJoules = 0;
                Result = "";
                
            }
        }
        private (bool, double) CalcKineticEnergy(double Mass, double Velocity)
        {
            bool isValid = Mass > 0 && Velocity > 0;
            double ke = 0;

            if (isValid)
            {
                ke = half * Mass * Math.Pow(Velocity, roundingDigit);
            }
            return (isValid, ke);
        }

        private void ConvertUnit()
        {
            if (SelectedEnergyUnit!= null && SelectedEnergyUnit.Name == megaJoules)
            {
                Result = Math.Round((KineticEnergyInJoules / joulesToMegaJoules), roundingDigit).ToString() + (megaJoulesUnit);
            }
            else if (SelectedEnergyUnit != null && SelectedEnergyUnit.Name == joules)
            {
                Result = Math.Round(KineticEnergyInJoules, roundingDigit).ToString() + (joulesUnit);
            }
            else if (SelectedEnergyUnit != null && SelectedEnergyUnit.Name == calories)
            {
                Result = Math.Round((KineticEnergyInJoules * joulesToCalories), roundingDigit).ToString() + (caloriesUnit);
            }
            else if (SelectedEnergyUnit != null && SelectedEnergyUnit.Name == btu)
            {
                Result = Math.Round((KineticEnergyInJoules * joulesToBTU), roundingDigit).ToString() + (btuUnit);
            }
        }
        #endregion

        #region Property Changed
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
