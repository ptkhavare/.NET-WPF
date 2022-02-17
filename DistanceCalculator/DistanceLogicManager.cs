using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace DistanceCalculator
{
    internal class DistanceLogicManager : INotifyPropertyChanged
    {
        #region enums
        enum DistancUnit
        {
            KMH,
            MS,
            MILESH
        }
        #endregion

        #region Properties
        private const int secInHour = 3600;
        private const int kmInMeters = 1000;
        private const int roundingDigit = 2;

        private const float kmToMilesFactor = 0.6214F;

        private const string Filename = "result.txt";
        private const string FolderName = "DistanceCalculator";
        private const string ResultStartFormat = "Distance after ";
        private const string seconds = " seconds ";
        private const string hour = " hour ";
        private const string hours = " hours ";
        private const string KMS = "KMs";
        private const string Meters = "Meters";
        private const string Miles = "Miles";
        private const string SpeedFormat = "Speed ";
        private const string TimeFormat = " Time ";
        private const string ConcatSymbol = " = ";


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
        static readonly string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), FolderName);
        readonly string fullName = Path.Combine(filePath, Filename);
        #endregion

        #region Logic
        public void CalcDistance(int unitSelected)
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
            stringBuilder.Append(SpeedFormat + ConcatSymbol + Speed + TimeFormat + ConcatSymbol + Time);
            for (int i = 1; i <= Time; i++)
            {
                string result = "";
                if (unitSelected == (int)DistancUnit.KMH)
                {
                    if (i == 1)
                    {
                        result = ResultStartFormat + i + hour + ConcatSymbol + Speed * i + KMS;
                    }
                    else
                    {
                        result = ResultStartFormat + i + hours + ConcatSymbol + Speed * i + KMS;
                    }
                }
                else if (unitSelected == (int)DistancUnit.MS)
                {
                    result = ResultStartFormat + i * (secInHour) + seconds + ConcatSymbol + (Speed * i) * (kmInMeters) + Meters;
                }
                else if (unitSelected == (int)DistancUnit.MILESH)
                {
                    if (i == 1)
                    {
                        result = ResultStartFormat + i + hour + ConcatSymbol + Math.Round((Speed * i) * (kmToMilesFactor), roundingDigit) + Miles;
                    }
                    else
                    {
                        result = ResultStartFormat + i + hours + ConcatSymbol + Math.Round((Speed * i) * (kmToMilesFactor), roundingDigit) + Miles;
                    }
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
