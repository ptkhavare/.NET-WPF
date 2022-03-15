using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace ExamScoresReport
{


    internal class ExamVM : INotifyPropertyChanged
    {
        private const string filePath = "C:\\Users\\prana\\Workspace\\PROG8010\\ExamsScoresReport\\ExamScoresReport\\scores";

        private string result = "Result here";

        public string Result
        {
            get { return result; }
            set { result = value; NotifyPropertyChanged(); }
        }

        static int numOfFiles = Directory.GetFiles(filePath).Length;

        public ObservableCollection<StudentScore> studentScoresSection1 { get; set; } = new ObservableCollection<StudentScore>();
        public ObservableCollection<StudentScore> studentScoresSection2 { get; set; } = new ObservableCollection<StudentScore>();
        public ObservableCollection<StudentScore> studentScoresSection3 { get; set; } = new ObservableCollection<StudentScore>();

        public void GenerateReport()
        {
            (bool isError, StudentScore[][] studentScores) = FilesToArray("filePath");

            ObservableCollection<StudentScore>[] ss = new ObservableCollection<StudentScore>[]
                            { studentScoresSection1,
                              studentScoresSection2,
                              studentScoresSection3 };

            for (int i = 0; i < studentScores.Length; i++)
            {
                for (int j = 0; j < studentScores[i].Length; j++)
                {
                    ss[i].Add(studentScores[i][j]);
                }
            }

        }

        public (bool, StudentScore[][]) FilesToArray(string filePath)
        {
            string[] files = Directory.GetFiles("C:\\Users\\prana\\Workspace\\PROG8010\\ExamsScoresReport\\ExamScoresReport\\scores");

            StudentScore[][] studentScores = new StudentScore[numOfFiles][];


            for (int i = 0; i < files.Length; i++)
            {
                string text;
                try
                {
                    text = File.ReadAllText(files[i]);
                }
                catch
                {
                    return (true, studentScores);
                }

                string[] lines = text.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                studentScores[i] = new StudentScore[lines.Length];
                int j;
                for (j = 0; j < lines.Length; j++)
                {
                    StudentScore studentScore = new StudentScore(j, lines[j], i);
                    studentScores[i][j] = studentScore;
                }
            }

            return (false, studentScores);
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
