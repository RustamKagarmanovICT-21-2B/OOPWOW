using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGame
{
    public class EnhancedBlacksmith 
    {
        public string Name { get; }
        public int SkillLevel { get; private set; }
        public int Experience { get; private set; }
        public int ForgesCompleted { get; private set; }

        public IForgingStrategy _forgingStrategy;

        public EnhancedBlacksmith(string name, int skillLevel, IForgingStrategy strategy)
        {
            Name = name;
            SkillLevel = skillLevel;
            _forgingStrategy = strategy;
        }

        public bool CanForge(ItemBase item)
        {
            return item.Quality < SkillLevel / 2;
        }

        public ItemBase Forge(ItemBase item)
        {
            if (!CanForge(item))
            {
                Console.WriteLine($"{Name} не может улучшить {item.Name} - недостаточно навыка!");
                return item;
            }

            bool success = _forgingStrategy.TryForge(item, SkillLevel);

            if (success)
            {
                item.ApplyImprovement();
                GainExperience(10);
                ForgesCompleted++;
            }

            Console.WriteLine(_forgingStrategy.GetResultMessage(item, success));
            return item;
        }

        private void GainExperience(int exp)
        {
            Experience += exp;
            if (Experience >= SkillLevel * 20)
            {
                SkillLevel++;
                Experience = 0;
                Console.WriteLine($"🎉 {Name} повысил уровень навыка до {SkillLevel}!");
            }
        }
    }
}
