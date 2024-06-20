using System;
using System.IO;
using System.Windows;
using System.Linq;

namespace Lab_4
{
    /// <summary>
    /// Interaction logic for ExamForm.xaml
    /// </summary>
    public partial class ExamForm : Window
    {
        private string _filePath;
        private string name;
        private string surname;
        private bool isDataSaved = false;
        public ExamForm(string _filePath, string surname, string name)
        {
            InitializeComponent();
            this._filePath = _filePath;
            this.surname = surname;
            this.name = name;
            LoadExamInfo();
            Closing += ExamForm_Closing;
        }
        private void LoadExamInfo()
        {
            try
            {
                string fileContent = File.ReadAllText(_filePath);
                InfoTextBox.Text = fileContent;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при завантаженні інформації: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddExam_Click(object sender, RoutedEventArgs e)
        {
            string subject = Exam_Text.Text;
            int score = 0;
            DateTime examDate = DateTime.Now;

            // Перевірка правильності введених даних і їх конвертація
            if (!int.TryParse(Score_Text.Text, out score))
            {
                MessageBox.Show("Некоректно введена оцінка!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!DateTime.TryParse(ExamDatePicker.Text, out examDate))
            {
                MessageBox.Show("Некоректно введена дата!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Exam exam = new Exam(subject, score, examDate);

            try
            {
                using (StreamWriter writer = File.AppendText(_filePath))
                {
                    writer.WriteLine(); // Порожній рядок для розділення записів
                    writer.WriteLine($"Предмет: {exam.Subject}");
                    writer.WriteLine($"Оцінка: {exam.Score}");
                    writer.WriteLine($"Дата складання: {exam.ExamDate.ToShortDateString()}");
                    
                }
                isDataSaved = true;
                MessageBox.Show("Інформацію про екзамен додано до файлу.", "Успішно", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при дописуванні до файлу: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ExamForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (isDataSaved == false)
            {
                MessageBoxResult result = MessageBox.Show("Бажаєте зберегти зміни перед закриттям?",
                    "Зберегти файл", MessageBoxButton.YesNoCancel);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        AddExam_Click(sender, null);
                        break;
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }
    }
}
