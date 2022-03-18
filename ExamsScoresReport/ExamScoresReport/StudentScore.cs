using System;

namespace ExamScoresReport
{
    internal class StudentScore
    {
        private long rollNum;
        private int score;
        private int section;

        public long RollNum
        {
            get { return rollNum; }
            set { rollNum = value; }
        }

        public int Section
        {
            get { return section; }
            set { section = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public StudentScore()
        {
        }
        public StudentScore(long rollNum, string score, int section)
        {
            this.rollNum = rollNum + 1;
            this.score = Int32.Parse(score);
            this.section = section + 1;
        }
    }
}
