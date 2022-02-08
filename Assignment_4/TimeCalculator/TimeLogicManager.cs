using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

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
            StringBuilder stringBuilder = new StringBuilder();
            TimeSpan ts = TimeSpan.FromSeconds(Seconds);
            if (ts.Days != 0)
            {
                if (ts.Days == 1)
                {
                    stringBuilder.Append(ts.Days + " Day ");
                }
                else
                {
                    stringBuilder.Append(ts.Days + " Days ");
                }
            }
            if (ts.Hours != 0)
            {
                if (ts.Hours == 1)
                {
                    stringBuilder.Append(ts.Hours + " Hour ");
                }
                else
                {
                    stringBuilder.Append(ts.Hours + " Hours ");
                }
            }
            if (ts.Minutes != 0)
            {
                if (ts.Minutes == 1)
                {
                    stringBuilder.Append(ts.Minutes + " Minute ");
                }
                else
                {
                    stringBuilder.Append(ts.Minutes + " Minutes ");
                }
            }
            if (ts.Seconds != 0)
            {
                if (ts.Seconds == 1)
                {
                    stringBuilder.Append(ts.Seconds + " Second ");
                }
                else
                {
                    stringBuilder.Append(ts.Seconds + " Seconds ");
                }
            }
            Result = stringBuilder.ToString();
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
