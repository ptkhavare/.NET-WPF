using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace ExamScoresReport
{


    internal class ExamVM : INotifyPropertyChanged
    {
        #region Const and Var
        private const string filePath = "C:\\Users\\prana\\Workspace\\PROG8010\\ExamsScoresReport\\ExamScoresReport\\scores";


        private string validation = "No Errors Yet";

        private int sec1Avg = 0;
        private int sec2Avg = 0;
        private int sec3Avg = 0;
        private int allSectionAvg = 0;
        private int highest = 0;
        private int lowest = 0;


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
        #endregion

        static int numOfFiles = Directory.GetFiles(filePath).Length;

        public ObservableCollection<StudentScore> studentScoresSection1 { get; set; } = new ObservableCollection<StudentScore>();
        public ObservableCollection<StudentScore> studentScoresSection2 { get; set; } = new ObservableCollection<StudentScore>();
        public ObservableCollection<StudentScore> studentScoresSection3 { get; set; } = new ObservableCollection<StudentScore>();

        StudentScore[][] studentScores = new StudentScore[numOfFiles][];

        public ExamVM()
        {
            (bool isError, studentScores) = FilesToArray(filePath);

            if (!isError)
            {
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
            else
            {
                Validation = "Error in Reading Files";
            }
        }

        public void GenerateReport()
        {
            

           
                Sec1Avg = CalculateAverage(studentScoresSection1);
                Sec2Avg = CalculateAverage(studentScoresSection2);
                Sec3Avg = CalculateAverage(studentScoresSection3);
                AllSectionAvg = CalculateAllSectionAverage(studentScores);
                (int[] highestvalue, int[] lowestValues) = CalculateHighestAndLowest(studentScores);
           
          
        }


        public int CalculateAverage(ObservableCollection<StudentScore> studentScoresSection)
        {
            int total = 0;
            if (studentScoresSection1.Count > 0)
            {
                foreach (StudentScore studentScore in studentScoresSection)
                {
                    total += studentScore.Score;
                }
                return total / studentScoresSection.Count;
            }
            return 0;
        }

        public int CalculateAllSectionAverage(StudentScore[][] studentScores)
        {
            int total = 0;
            int totalCount = 0;
            for (int i = 0; i < studentScores.Length; i++)
            {
                for (int j = 0; j < studentScores[i].Length; j++)
                {
                    if (studentScores[i][j].Score > highest)
                    {
                        total += studentScores[i][j].Score;
                    }
                }
            }
            for (int i = 0; i < studentScores.Length; i++)
            {
                totalCount += studentScores[i].Length;
            }
            return total / totalCount;
        }

        public (int[], int[]) CalculateHighestAndLowest(StudentScore[][] studentScores)
        {
            int[] highest = new int[2];
            int[] lowest = new int[2];
            lowest[0] = 100;

            for (int i = 0; i < studentScores.Length; i++)
            {
                for (int j = 0; j < studentScores[i].Length; j++)
                {
                    if (studentScores[i][j].Score > highest[0])
                    {
                        highest[0] = studentScores[i][j].Score;
                        highest[1] = studentScores[i][j].Section;
                    }
                }
            }
            for (int i = 0; i < studentScores.Length; i++)
            {
                for (int j = 0; j < studentScores[i].Length; j++)
                {
                    if (studentScores[i][j].Score < lowest[0])
                    {
                        lowest[0] = studentScores[i][j].Score;
                        lowest[1] = studentScores[i][j].Section;
                    }
                }
            }
            return (highest, lowest);
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

        #region Property Changed
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
