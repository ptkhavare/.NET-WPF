using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ExamScoresReport
{
    internal class ExamVM : INotifyPropertyChanged
    {
        #region Const and Var

        private const int maxMarks = 100;
        private const string section = "Section ";
        private const string rollNum = " Roll No. ";

        private static readonly string filePath = Environment.CurrentDirectory + "\\scores";
        private static readonly int numOfFiles = Directory.GetFiles(filePath).Length;

        StudentScore[][] studentScores = new StudentScore[numOfFiles][];

        private int sec1Avg = 0;
        private int sec2Avg = 0;
        private int sec3Avg = 0;
        private int allSectionAvg = 0;
        private int highest = 0;
        private int lowest = 0;
        private int sec1AbvAvg = 0;
        private int sec2AbvAvg = 0;
        private int sec3AbvAvg = 0;

        private string validation = "Files Not Read";
        private string lowestSection = "";
        private string highestSection = "";

        private Visibility resutlVisibility = Visibility.Collapsed;

        public Visibility ResutlVisibility
        {
            get { return resutlVisibility; }
            set { resutlVisibility = value; NotifyPropertyChanged(); }
        }

        public int Sec1Avg
        {
            get { return sec1Avg; }
            set { sec1Avg = value; NotifyPropertyChanged(); }
        }

        public int Sec2Avg
        {
            get { return sec2Avg; }
            set { sec2Avg = value; NotifyPropertyChanged(); }
        }

        public int Sec3Avg
        {
            get { return sec3Avg; }
            set { sec3Avg = value; NotifyPropertyChanged(); }
        }

        public int AllSectionAvg
        {
            get { return allSectionAvg; }
            set { allSectionAvg = value; NotifyPropertyChanged(); }
        }

        public int Higehest
        {
            get { return highest; }
            set { highest = value; NotifyPropertyChanged(); }
        }

        public int Lowest
        {
            get { return lowest; }
            set { lowest = value; NotifyPropertyChanged(); }
        }

        public string Validation
        {
            get { return validation; }
            set { validation = value; NotifyPropertyChanged(); }
        }

        public string HighestSection
        {
            get { return highestSection; }
            set { highestSection = value; NotifyPropertyChanged(); }
        }

        public string LowestSection
        {
            get { return lowestSection; }
            set { lowestSection = value; NotifyPropertyChanged(); }
        }

        public int Sec1AbvAvg
        {
            get { return sec1AbvAvg; }
            set { sec1AbvAvg = value; NotifyPropertyChanged(); }
        }

        public int Sec2AbvAvg
        {
            get { return sec2AbvAvg; }
            set { sec2AbvAvg = value; NotifyPropertyChanged(); }
        }

        public int Sec3AbvAvg
        {
            get { return sec3AbvAvg; }
            set { sec3AbvAvg = value; NotifyPropertyChanged(); }
        }

        public ObservableCollection<StudentScore> studentScoresSection1 { get; set; } = new ObservableCollection<StudentScore>();
        public ObservableCollection<StudentScore> studentScoresSection2 { get; set; } = new ObservableCollection<StudentScore>();
        public ObservableCollection<StudentScore> studentScoresSection3 { get; set; } = new ObservableCollection<StudentScore>();
        #endregion

        #region constructors
        public ExamVM()
        {
            (bool isError, studentScores) = FilesToArray(filePath);
            if (!isError)
            {
                ObservableCollection<StudentScore>[] allSectionStudentScores = new ObservableCollection<StudentScore>[]
                                { studentScoresSection1,
                              studentScoresSection2,
                              studentScoresSection3 };
                for (int i = 0; i < studentScores.Length; i++)
                {
                    for (int j = 0; j < studentScores[i].Length; j++)
                    {
                        allSectionStudentScores[i].Add(studentScores[i][j]);
                    }
                }
                Validation = "Files Read Succesfully";
            }
            else
            {
                Validation = "Error in Reading Files";
            }
        }
        #endregion

        #region main logic
        public void GenerateReport()
        {
            Sec1Avg = CalculateAverage(studentScoresSection1);
            Sec2Avg = CalculateAverage(studentScoresSection2);
            Sec3Avg = CalculateAverage(studentScoresSection3);
            AllSectionAvg = CalculateAllSectionAverage(studentScores);
            (StudentScore highestStudentScore,StudentScore lowestStudentScore) = CalculateHighestAndLowest(studentScores);
            Higehest = highestStudentScore.Score;
            Lowest = lowestStudentScore.Score;
            HighestSection = section + highestStudentScore.Section + rollNum +highestStudentScore.RollNum;
            LowestSection = section + lowestStudentScore.Section + rollNum +lowestStudentScore.RollNum;
            Sec1AbvAvg = CalculateAboveAverageStudents(AllSectionAvg, studentScoresSection1);
            Sec2AbvAvg = CalculateAboveAverageStudents(AllSectionAvg, studentScoresSection2);
            Sec3AbvAvg = CalculateAboveAverageStudents(AllSectionAvg, studentScoresSection3);
            Validation = "Report Generated Succesfully";
            ResutlVisibility = Visibility.Visible;
        }
        #endregion

        #region helper logic
        public int CalculateAverage(ObservableCollection<StudentScore> studentScoresSection)
        {
            int total = 0;
            if (studentScoresSection1.Count > 0)
            {
                total = studentScoresSection.Sum(element => element.Score);
                return total / studentScoresSection.Count;
            }
            return 0;
        }

        public int CalculateAllSectionAverage(StudentScore[][] studentScores)
        {
            if (studentScores.Length > 0)
            {
                int total = 0;
                int totalCount = 0;
                for (int i = 0; i < studentScores.Length; i++)
                {
                    total += studentScores[i].Sum(element => element.Score);
                    totalCount += studentScores[i].Length;
                }
                return total / totalCount;
            }
            else
            {
                return 0;
            }
        }

        public (StudentScore highestStudentScore, StudentScore lowestStudentScore) CalculateHighestAndLowest(StudentScore[][] studentScores)
        {
            StudentScore highestStudentScore = new StudentScore();
            StudentScore lowestStudentScore = new StudentScore();
            int lowest = maxMarks;
            int highest = 0;

            for (int i = 0; i < studentScores.Length; i++)
            {
                for (int j = 0; j < studentScores[i].Length; j++)
                {
                    if (studentScores[i][j].Score > highest)
                    {
                        highest = studentScores[i][j].Score;
                        highestStudentScore = studentScores[i][j];
                    }
                }
            }
            for (int i = 0; i < studentScores.Length; i++)
            {
                for (int j = 0; j < studentScores[i].Length; j++)
                {
                    if (studentScores[i][j].Score < lowest)
                    {
                        lowest = studentScores[i][j].Score;
                        lowestStudentScore = studentScores[i][j];
                    }
                }
            }
            return (highestStudentScore, lowestStudentScore);
        }

        public int CalculateAboveAverageStudents(int classAverage, ObservableCollection<StudentScore> studentScoresSection)
        {
            int num = 0;
            if (studentScoresSection.Count > 0)
                return studentScoresSection.Count(e => e.Score > classAverage);
            return num;
        }


        public (bool, StudentScore[][]) FilesToArray(string filePath)
        {
            string[] files = Directory.GetFiles(filePath);
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
                for (int j = 0; j < lines.Length; j++)
                {
                    StudentScore studentScore = new StudentScore(j, lines[j], i);
                    studentScores[i][j] = studentScore;
                }
            }
            return (false, studentScores);
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
