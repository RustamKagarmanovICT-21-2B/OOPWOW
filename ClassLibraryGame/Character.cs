using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibraryGame
{
   
    public class Character
    {
        string[] names = ["Rubick", "Wardon", "Kupel Warrior", "Warlord Impel", "Okr Rezan"];
        Random rnd = new Random();


        string name = "Player";
        int strength = 10, agility = 10, intellect = 10, age = 21;

        public int Age { get; set; }
        public int Intellect { get; set; }
        public string Name { 
            get { return name; } 
            set { 
                if(IsValidName(name)) name = value;
            } 
        }
        public int Strength { get { return strength;} set { strength = value; } }
        public int Agility { get {  return agility;} set {  agility = value; } }

        //Конструктор без парамтеров
        public Character() {
            int index = rnd.Next(names.Length);

            name = names[index];
            strength = rnd.Next(1,10);
            agility = rnd.Next(1, 10);
            intellect = rnd.Next(1, 10);
            age = rnd.Next(14, 65);

            Console.WriteLine($"Появился новый герой {this.name}!\nЕго способности:\nСила: {this.strength}\nЛовкость: {this.agility}\nИнтеллект: {this.intellect}");
        }

        //Конструктор с параметрами
        public Character(string name, int age, int strength, int agility, int intellect)
        {
            int index = rnd.Next(names.Length);

            if (IsValidName(name)) { this.name = name; }
            else { this.name = names[index]; }
                
            this.age = age;
            this.strength = strength;
            this.agility = agility;
            this.intellect = intellect;
            Console.WriteLine($"Появился новый герой {this.name}!\nЕго способности:\nСила: {this.strength}\nЛовкость: {this.agility}\nИнтеллект: {this.intellect}");
        }
        //Функция вывода характеристик персонажа
        public virtual void printCharacterSkills()
        {
            Console.WriteLine($"Имя персонажа: {name}, его сила: {strength}, ловкость: {agility}, интеллект: {intellect}");
        }

        //Функция для ввода имени, пока имя введено неправмльно -> повторный ввод
        public string GetValidName()
        {
            string inputName;
            do
            {
                Console.WriteLine("Введите имя персонажа: ");
                inputName = Console.ReadLine();
            }
            while (!IsValidNameShowText(inputName));

            return inputName;
        }

        //Функция для проверки правильности ввода -> на выходе true или false
        private bool IsValidNameShowText(string name)
        {
            // Проверка имени
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Имя не может быть пустым.");
                return false;
            }

            // Проверяем, содержит ли имя только буквы и пробелы
            foreach (char c in name)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    Console.WriteLine("Имя должно содержать только буквы и пробелы.");
                    return false;
                }
            }

            // Если все ок
            return true;
        }
        private bool IsValidName(string name)
        {
            // Проверка имени
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            // Проверка, содержит ли имя только буквы и пробелы
            foreach (char c in name)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    return false;
                }
            }

            // Если все ок
            return true;
        }

    }

}
