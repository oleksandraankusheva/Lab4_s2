using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Lab_4
{
    /// <summary>
    /// Interaction logic for ShortInfo.xaml
    /// </summary>
    public partial class ShortInfo : Window
    {
        private string _filePath;
        private string name;
        private string surname;
        public ShortInfo(string _filePath, string surname, string name)
        {
            InitializeComponent();
            this._filePath = _filePath;
            this.surname = surname;
            this.name = name;
            LoadStudentInfo();
        }
        private void LoadStudentInfo()
        {
            try
            {
                Student student = LoadStudentFromFile(_filePath);
                if (student != null)
                {
                    InfoTextBox.Text = student.ToStringShort();
                }
                else
                {
                    MessageBox.Show("Не вдалося завантажити інформацію про студента.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при завантаженні інформації: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private Student LoadStudentFromFile(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);

                string lastName = "";
                string firstName = "";
                string secondName = "";
                DateTime birthDate = DateTime.MinValue;
                EducationLevel educationLevel = EducationLevel.Бакалавр;
                List<Exam> exams = new List<Exam>();

                string currentSubject = "";
                int currentScore = 0;
                DateTime currentExamDate = DateTime.MinValue;

                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];

                    if (line.StartsWith("Прізвище:"))
                    {
                        lastName = line.Substring("Прізвище:".Length).Trim();
                    }
                    else if (line.StartsWith("Ім'я:"))
                    {
                        firstName = line.Substring("Ім'я:".Length).Trim();
                    }
                    else if (line.StartsWith("По батькові:"))
                    {
                        secondName = line.Substring("По батькові:".Length).Trim();
                    }
                    else if (line.StartsWith("Дата народження:"))
                    {
                        birthDate = DateTime.ParseExact(line.Substring("Дата народження:".Length).Trim(), "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else if (line.StartsWith("Освітній рівень:"))
                    {
                        string eduLevelStr = line.Substring("Освітній рівень:".Length).Trim();
                        educationLevel = (EducationLevel)Enum.Parse(typeof(EducationLevel), eduLevelStr);
                    }
                    else if (line.StartsWith("Предмет:"))
                    {
                        currentSubject = line.Substring("Предмет:".Length).Trim();

                        // Find corresponding "Оцінка:" and "Дата складання:" lines
                        if (i < lines.Length - 1 && lines[i + 1].StartsWith("Оцінка:"))
                        {
                            currentScore = int.Parse(lines[i + 1].Substring("Оцінка:".Length).Trim());
                        }
                        if (i < lines.Length - 2 && lines[i + 2].StartsWith("Дата складання:"))
                        {
                            currentExamDate = DateTime.ParseExact(lines[i + 2].Substring("Дата складання:".Length).Trim(), "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        }

                        exams.Add(new Exam(currentSubject, currentScore, currentExamDate));
                    }
                }

                Person person = new Person(lastName, firstName, secondName, birthDate);
                Student student = new Student(person, educationLevel);
                foreach (var exam in exams)
                {
                    student.AddExam(exam);
                }

                return student;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при завантаженні інформації про студента: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Ви впевнені, що хочете видалити цей файл?", "Підтвердження видалення", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    File.Delete(_filePath);
                    MessageBox.Show("Файл успішно видалено.", "Успіх", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close(); // Закрити вікно після видалення файлу
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при видаленні файлу: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
