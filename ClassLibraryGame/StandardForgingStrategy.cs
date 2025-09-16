using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGame
{
    public class StandardForgingStrategy : IForgingStrategy
    {
        private readonly Random rnd = new Random();

        public bool TryForge(ItemBase item, int blacksmithSkill)
        {
            int difficulty = item.Quality * 10;
            int successChance = Math.Max(10, Math.Min(90, blacksmithSkill * 5 - difficulty));
            return rnd.Next(100) < successChance;
        }
        public string GetResultMessage(ItemBase item, bool success)
        {
            return success ?
                $"Успешно улучшено до качества {item.Quality}!" :
                $"Не удалось улучшить {item.Name}. Требуется более опытный кузнец.";
        }
    }
}
