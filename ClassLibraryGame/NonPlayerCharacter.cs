using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGame
{
    public abstract class NonPlayerCharacter
    {
        public string Name { get; set; }
        public int Age { get; set; }

        protected NonPlayerCharacter(string name, int age)
        {
            Name = name;
            Age = age;
        }
        protected NonPlayerCharacter(string name)
        {
            Name = name;
        }


        // Абстрактный метод Interact, который должен быть реализован в производных классах
        public abstract void Interact();
        public override string ToString()
        {
            return $"NPC: {Name}";
        }

        // Переопределение метода Equals() для сравнения NPC по имени
        public override bool Equals(object obj)
        {
            if (obj is NonPlayerCharacter npc)
            {
                return this.Name == npc.Name;
            }
            return false;
        }

        // Переопределение метода GetHashCode() для генерации хеш-кода на основе имени
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
