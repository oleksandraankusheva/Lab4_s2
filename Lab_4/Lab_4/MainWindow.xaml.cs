using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Lab_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            string surname = Surname_Text.Text;
            string name = Name_Text.Text;
            string foundFilePath = FindFile();

            if (foundFilePath != null)
            {
                ShortInfo infoOfStudent = new ShortInfo(foundFilePath, surname, name);
                infoOfStudent.ShowDialog();
            }
            else
            {
                MessageBox.Show("Файл не знайдено.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            string surname = Surname_Text.Text;
            string name = Name_Text.Text;
            string date = Date_Text.Text;
            if (string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(date))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                AddStudent add = new AddStudent(surname, name, date);
                add.ShowDialog();
            }
        }

        private void Exam_Button_Click(object sender, RoutedEventArgs e)
        {
            string surname = Surname_Text.Text;
            string name = Name_Text.Text;
            string foundFilePath = FindFile();

            if (foundFilePath != null)
            {
                ExamForm viewWindow = new ExamForm(foundFilePath, surname, name);
                viewWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Файл не знайдено.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string FindFile()
        {
            string surname = Surname_Text.Text;
            string name = Name_Text.Text;
            string projectFolder = @"D:\source\repos\Lab_4\Lab_4\bin\Debug"; // Шлях до папки проекту
            string[] levelFolders = { "Бакалавр", "Спеціаліст", "Магістр" }; // Папки рівнів освіти

            foreach (string levelFolder in levelFolders)
            {
                string folderPath = Path.Combine(projectFolder, levelFolder);
                if (Directory.Exists(folderPath))
                {
                    string[] files = Directory.GetFiles(folderPath, $"{surname} {name}.txt", SearchOption.TopDirectoryOnly);
                    if (files.Length > 0)
                    {
                        return files[0];
                    }
                }
            
            }
            return null;
        }

    }
}
