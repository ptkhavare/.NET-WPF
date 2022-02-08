using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TimeCalculator
{
    internal class TimeLogicManager : INotifyPropertyChanged
    {
        #region Properties
        private long seconds;
        public long Seconds
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
        #endregion

        #region logic
        public void calcTime()
        {
            TimeSpan ts = TimeSpan.FromSeconds(Seconds);
            Result = ts.Days + " Days " + ts.Hours + " Hours " + ts.Minutes + " Minutes " + ts.Seconds + " Seconds ";
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
