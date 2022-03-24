using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CarGame
{
    internal class Car : INotifyPropertyChanged
    {
        public enum Gear
        {
            NEUTRAL,
            FIRST,
            SECOND,
            THIRD,
            FOURTH,
            FIFTH
        }

        private const int speedChangeAccelarate = 5;
        private const int speedChangeBrake = 1;

        private const int firstGearSpeedChange = 10;
        private const int secondGearSpeedChange = 20;
        private const int thirdGearSpeedChange = 30;
        private const int fourthGearSpeedChange = 40;

        private const int firstGearMaxSpeed = 15;
        private const int secondftGearMaxSpeed = 30;
        private const int thirdGearMaxSpeed = 45;
        private const int fouthearMaxSpeed = 60;

        private const int initialSpeed = 0;
        private const int gearStep = 1;

        private int year;
        private string make;
        private int speed;
        private Gear carGear;

        public int Year
        {
            get { return year; }
            set { year = value; NotifyPropertyChanged(); }
        }

        public string Make
        {
            get { return make; }
            set { make = value; NotifyPropertyChanged(); }
        }

        public int Speed
        {
            get { return speed; }
            set
            {
                if (value >= 0)
                {
                    speed = value;
                }
                else
                {
                    speed = initialSpeed;
                };
                NotifyPropertyChanged();
            }

        }

        public Gear CarGear
        {
            get { return carGear; }
            set { carGear = value; NotifyPropertyChanged(); }
        }

        public Car(int year, string make)
        {
            this.year = year;
            this.make = make;
            this.speed = initialSpeed;
            this.carGear = Gear.NEUTRAL;
        }

        public void Accelarate()
        {
            if (this.CarGear == Gear.NEUTRAL)
            {
                this.Speed = initialSpeed;
            }
            else if (this.CarGear == Gear.FIRST && this.Speed < firstGearMaxSpeed)
            {
                this.Speed += speedChangeAccelarate;
            }
            else if (this.CarGear == Gear.SECOND && this.Speed < secondftGearMaxSpeed)
            {
                this.Speed += speedChangeAccelarate;
            }
            else if (this.CarGear == Gear.THIRD && this.Speed < thirdGearMaxSpeed)
            {
                this.Speed += speedChangeAccelarate;
            }
            else if (this.CarGear == Gear.FOURTH && this.Speed < fouthearMaxSpeed)
            {
                this.Speed += speedChangeAccelarate;
            }
            else if (this.CarGear == Gear.FIFTH)
            {
                this.Speed += speedChangeAccelarate;
            }
        }

        public void Brake()
        {
            this.Speed -= speedChangeBrake;
        }

        public void gearUp()
        {
            if (this.CarGear == Gear.NEUTRAL)
            {
                this.CarGear += gearStep;
            }
            else if (this.CarGear == Gear.FIRST && this.Speed == firstGearSpeedChange)
            {
                this.CarGear += gearStep;
            }
            else if (this.CarGear == Gear.SECOND && this.Speed == secondGearSpeedChange)
            {
                this.CarGear += gearStep;
            }
            else if (this.CarGear == Gear.THIRD && this.Speed == thirdGearSpeedChange)
            {
                this.CarGear += gearStep;
            }
            else if (this.CarGear == Gear.FOURTH && this.Speed == fourthGearSpeedChange)
            {
                this.CarGear += gearStep;
            }
        }

        public void gearDown()
        {
            if (this.CarGear > Gear.NEUTRAL)
            {
                this.CarGear -= gearStep;
            }
            else
            {
                this.CarGear = Gear.NEUTRAL;
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
