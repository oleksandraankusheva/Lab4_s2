using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public class Exam : ICloneable, IComparable<Exam>
    {
        private string subject;
        private int score;
        private DateTime examDate;

        public Exam(string subject, int score, DateTime examDate)
        {
            this.subject = subject;
            this.score = score;
            this.examDate = examDate;
        }

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public DateTime ExamDate
        {
            get { return examDate; }
            set { examDate = value; }
        }

        public object Clone()
        {
            return new Exam(subject, score, examDate);
        }

        public int CompareTo(Exam other)
        {
            if (other == null) return 1;
            return examDate.CompareTo(other.examDate);
        }

        public override string ToString()
        {
            return $"Предмет: {subject}, Оцінка: {score}, Дата складання: {examDate.ToShortDateString()}";
        }
    }

}
