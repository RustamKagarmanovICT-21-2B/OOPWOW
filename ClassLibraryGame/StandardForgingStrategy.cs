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

        public bool TryForge(Item item, int blacksmithSkill)
        {
            int successRate = Math.Max(0, blacksmithSkill - item.Quality);
            int success = rnd.Next(0, 100);
            bool isSuccessful = success >= 50 - successRate * 5;

            if (isSuccessful)
            {
                item.Quality++;
            }

            return isSuccessful;
        }
        public string GetResultMessage(Item item, bool success)
        {
            return success ?
                $"Успешно улучшено до качества {item.Quality}!" :
                $"Не удалось улучшить {item.Name}. Требуется более опытный кузнец.";
        }
    }
}
