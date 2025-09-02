using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGame
{
    public class Blacksmith : NonPlayerCharacter
    {
        Random rnd = new Random();
        public int ForgeQuality { get; private set; }
        public Money BlacksmithMoney { get; set; }

        public Blacksmith(string name, int age, int forgeQuality, int startingBalance) : base(name, age)
        {
            ForgeQuality = forgeQuality;
            BlacksmithMoney = new Money(startingBalance);
        }
        public Blacksmith(string name) : base(name)
        {
        }
        public Blacksmith(string name, int age, int startingBalance) : base(name, age)
        {
            BlacksmithMoney = new Money(startingBalance);
        }
        // Реализация метода Interact для кузнеца, который должен быть реализован
        //
        public override void Interact()
        {
            Console.WriteLine($"{Name}, кузнец с {Age} лет опыта, приветствует вас.");
            Console.WriteLine($"Качество его кузницы: {ChooseQuality(ForgeQuality)}.");
            // Здесь могут быть дополнительные действия, связанные с кузнецом
        }

        public Item Forge(Item item)
        {
            // Проверяем, что item не равен null
            if (item == null)
            {
                Console.WriteLine("Ошибка: передан null объект предмета.");
                return null;
            }

            // Проверяем, что свойство Quality инициализировано
            if (item.Quality == null)
            {
                Console.WriteLine("Ошибка: качество предмета не установлено.");
                return item;
            }

            // Улучшение качества предмета
            int successRate = EnsureNonNegative(ForgeQuality - item.Quality);
            int success = rnd.Next(successRate * 10, 100);

            if (success >= 50)
            {
                item.Quality++;
                Console.WriteLine($"{Name} улучшил {item.Name} до качества {item.Quality}.");
                return item;
            }
            else
            {
                Console.WriteLine($"{Name} НЕ улучшил {item.Name} до качества {item.Quality + 1}.");
            }

            return item;
        }








        ///////////////////////Методы/////////////////////////////////

        // торговля
        public void TradeItem(int salePrice)
        {
            // Вызываем делегат для добавления денег от продажи предмета
            BlacksmithMoney.PerformMoneyOperation(Money.AddMoney, salePrice);
        }

        //покупка материалов
        public void BuyMaterials(int purchasePrice)
        {
            // Вызываем делегат для вычитания денег при покупке материалов
            BlacksmithMoney.PerformMoneyOperation(Money.DelMoney, purchasePrice);
        }
        private static int EnsureNonNegative(int number)
        {
            return number < 0 ? 0 : number;
        }

        static private string  ChooseQuality(int quality)
        {
            switch (quality)
            {
                case 1:
                    return "ужасное";
                case 2:
                    return "плохое";
                case 3:
                    return "неудовлетворительное";
                case 4:
                    return "среднее";
                case 5:
                    return "нормальное";
                case 6:
                    return "хорошее";
                case 7:
                    return "очень хорошее";
                case 8:
                    return "отличное";
                case 9:
                    return "выдающееся";
                case 10:
                    return "исключительное";
                default:
                    return "неопределенное";
            }
        }
    }
}
