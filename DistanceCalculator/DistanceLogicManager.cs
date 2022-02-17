using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace DistanceCalculator
{
    internal class DistanceLogicManager : INotifyPropertyChanged
    {
        #region Properties
        private const int secInHour = 3600;
        private const int kmInMeters = 1000;

        private int speed;
        private int time;
        public BindingList<string> Distances { get; set; } = new BindingList<string>();

        public int Speed
        {
            get { return speed; }
            set { speed = value; NotifyPropertyChanged(); }
        }

        public int Time
        {
            get { return time; }
            set { time = value; NotifyPropertyChanged(); }
        }
        #endregion

        #region Class Properties & I/O properties
        static readonly string fileName = "result.txt";
        static readonly string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DistanceCalculator");
        private readonly string fullName = Path.Combine(filePath, fileName);
        #endregion

        #region Logic
        public void CalcDistance(bool unitKM)
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            File.AppendAllText(fullName, $"{Environment.NewLine}New Calculation at - {DateTime.Now:MMMM dd, yyyy HH:.mm:ss}{Environment.NewLine}");
            if (Distances.Count > 0)
            {
                Distances.Clear();
            }
            StringBuilder stringBuilder = new StringBuilder();
            int time = Time;
            int speed = Speed;
            stringBuilder.Append("Speed = " + speed + " Time = " + time);
            for (int i = 1; i <= time; i++)
            {
                string result;
                if (unitKM)
                {
                    if (i == 1)
                    {
                        result = "Distance after " + i + " hour " + speed * i + "km";
                    }
                    else
                    {
                        result = "Distance after " + i + " hours " + speed * i + "km";
                    }
                }
                else
                {
                        result = "Distance after " + i*(secInHour) + " seconds " + (speed * i)*(kmInMeters) + "meters";
                }
                Distances.Add(result);
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append(result);
                stringBuilder.Append(Environment.NewLine);
            }
            File.AppendAllText(fullName, stringBuilder.ToString());
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
