using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public class Student
    {
        private Person person;
        private EducationLevel educationLevel;
        private List<Exam> exams;

        public Student(Person person, EducationLevel educationLevel)
        {
            this.person = person;
            this.educationLevel = educationLevel;
            this.exams = new List<Exam>();
        }

        public void AddExam(Exam exam)
        {
            exams.Add(exam);
        }

        public override string ToString()
        {
            return $"{person}\nОсвітній рівень: {educationLevel}\nІспити:\n{string.Join("\n", exams)}";
        }

        public string ToStringShort()
        {
            double averageScore = CalculateAverageScore();
            return $"Прізвище: {person.LastName}, Середній бал: {averageScore:F2}";
        }

        private double CalculateAverageScore()
        {
            int totalScore = 0;
            int examCount = 0;

            foreach (Exam exam in exams)
            {
                totalScore += exam.Score;
                examCount++;
            }

            if (examCount > 0)
            {
                return (double)totalScore / examCount;
            }
            else
            {
                return 0;
            }
        }

    }
}
