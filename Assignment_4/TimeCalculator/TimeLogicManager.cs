using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TimeCalculator
{
    internal class TimeLogicManager : INotifyPropertyChanged
    {
        private int seconds = 0;
        public int Seconds
        {
            get { return seconds; }
            set { seconds = value; NotifyPropertyChanged(); }
        }

        private string result = "Enter Seconds";
        public string Result
        {
            get { return result; }
            set { result = value; NotifyPropertyChanged(); }
        }




        public void calcTime()
        {
            if (seconds > 60 && seconds < 3600)
            {
                int min = seconds / 60;
                int sec = seconds % 60;
                Result = min + "Minutes" + sec + "Seconds";
            }
            else if (seconds < 86400)
            {
                int hours = seconds / 3600;
                int sec = (seconds % 3600);
                int min = (sec / 60);
                sec = (min * 60) % 60;
                Result = hours + "Hours" + min + "Minutes" + sec + "Seconds";
            }
            else
            {
                int days = seconds / 86400;
                int sec = seconds % 86400;
                int hour = sec / 3600;
                sec %= (hour * 3600);
                int min = sec / 60;
                sec %= 60;
                Result = days + "Days" + hour + "Hour" + min + "Minutes" + sec + "Seconds";
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
