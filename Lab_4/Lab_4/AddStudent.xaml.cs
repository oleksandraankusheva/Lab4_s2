using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Lab_4
{
    /// <summary>
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        private bool isDataSaved = false;
        private int DateSub;
        public EducationLevel Level { get; set; }
        public AddStudent(string surname, string name, string date)
        {
            InitializeComponent();
            Surname_Text.Text = surname;
            Name_Text.Text = name;
            Date_Text.Text = date;
            Closing += AddStudent_Closing;
        }

        private void SaveDoc_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person();
            DateTime now = DateTime.Now;
            int year = now.Year;
            int date = Convert.ToInt32(Date_Text.Text);
            DateSub = year - date;

            DateTime birth = Convert.ToDateTime(DateBTH_Text.Text);
            
            person.LastName = Surname_Text.Text;
            person.FirstName = Name_Text.Text;
            person.SecondName = NameD_Text.Text;
            person.BirthDate = birth;

            if (DateSub <= 4)
            {
                Level = EducationLevel.Бакалавр;
                SaveDataToFile(person, date, Level);

                //бакалавр
            }
            else if (DateSub <= 6)
            {
                Level = EducationLevel.Спеціаліст;
                SaveDataToFile(person, date, Level);
                //спеціаліст
            }
            else if (DateSub > 6)
            {
                Level = EducationLevel.Магістр;
                SaveDataToFile(person, date, Level);
                //магістр
            }


            MessageBox.Show("Дані збережено успішно.", "Інформація", MessageBoxButton.OK, MessageBoxImage.Information);
            isDataSaved = true;
        }
        private void SaveDataToFile(Person person, int date, EducationLevel level)
        {
            try
            {
                string directoryPath = Path.Combine(Environment.CurrentDirectory, level.ToString());

                // Перевіряємо, чи існує відповідна папка для освітнього рівня
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string fileName = $"{person.LastName} {person.FirstName}.txt";
                string filePath = Path.Combine(directoryPath, fileName);

                // Відкриваємо файл для запису замість створення нового файлу, якщо папка вже існує
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    writer.WriteLine($"Прізвище: {person.LastName}");
                    writer.WriteLine($"Ім'я: {person.FirstName}");
                    writer.WriteLine($"По батькові: {person.SecondName}");
                    writer.WriteLine($"Дата народження: {person.BirthDate.ToShortDateString()}");
                    writer.WriteLine($"Освітній рівень: {level}");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при збереженні даних: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void AddStudent_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (isDataSaved == false)
            {
                MessageBoxResult result = MessageBox.Show("Бажаєте зберегти зміни перед закриттям?",
                    "Зберегти файл", MessageBoxButton.YesNoCancel);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        SaveDoc_Click(sender, null);
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
