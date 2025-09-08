using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGame
{
    public class MasterForgingStrategy : IForgingStrategy
    {
        private readonly Random rnd = new Random();

        public bool TryForge(Item item, int blacksmithSkill)
        {
            // Другая логика расчета для мастерского улучшения
            int baseChance = 70;
            int qualityPenalty = item.Quality * 5;
            int skillBonus = blacksmithSkill * 3;

            int successChance = baseChance - qualityPenalty + skillBonus;
            successChance = Math.Max(10, Math.Min(90, successChance));

            return rnd.Next(0, 100) < successChance;
        }
        public string GetResultMessage(Item item, bool success)
        {
            return success ?
                $"Успешно улучшено до качества {item.Quality}!" :
                $"Не удалось улучшить {item.Name}. Требуется более опытный кузнец.";
        }
    }
}
