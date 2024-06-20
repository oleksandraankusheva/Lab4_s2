using System;

namespace Lab_4
{
    public class Person : ICloneable, IComparable<Person>
    {
        private string Name;
        private string Surname;
        private string NameD;
        private DateTime birthDate;

        // Конструктор класу для ініціалізації полів
        public Person(string Surname, string Name, string NameD, DateTime birthDate)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.NameD = NameD;
            this.birthDate = birthDate;
        }
        // Конструктор за замовчуванням
        public Person()
        {
            // Встановлюємо значення за замовчуванням або за потреби
            this.Name = "";
            this.Surname = "";
            this.NameD = "";
            this.birthDate = DateTime.MinValue;
        }
        // Властивість для доступу до імені
        public string FirstName
        {
            get { return Name; }
            set { Name = value; }
        }

        // Властивість для доступу до прізвища
        public string LastName
        {
            get { return Surname; }
            set { Surname = value; }
        }
        public string SecondName
        {
            get { return NameD; }
            set { NameD = value; }
        }

        // Властивість для доступу до дати народження
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }
        public object Clone()
        {
            return new Person(FirstName, LastName, SecondName, BirthDate);
        }

        public int CompareTo(Person other)
        {
            if (other == null) return 1;
            return string.Compare(LastName, other.LastName, StringComparison.Ordinal);
        }
    }
}

