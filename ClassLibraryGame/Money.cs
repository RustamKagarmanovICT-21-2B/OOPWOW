using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGame
{
    
    
    public class Money
    {
        // Определяем делегат для операций с деньгами
        public delegate void MoneyOperation(ref int currentMoney, int amount);
        
        public event MoneyOperation? Notify;
        // Поле для хранения текущего баланса денег
        private int CurrentMoney;

        // Метод для добавления денег
        public static void AddMoney(ref int currentMoney, int amount)
        {
            currentMoney += amount;
            //Console.WriteLine($"Добавлено {amount} монет. Текущий баланс: {currentMoney}");
            //Notify?.Invoke($"На счет поступило: {amount}");   // 2.Вызов события 
        }

        // Метод для вычитания денег
        public static void DelMoney(ref int currentMoney, int amount)
        {
            if (amount > currentMoney)
            {
                Console.WriteLine("Недостаточно средств для совершения операции.");
            }
            else
            {
                currentMoney -= amount;
                Console.WriteLine($"Вычтено {amount} монет. Текущий баланс: {currentMoney}");
            }
        }
        public int GetMoney()
        {
            return CurrentMoney;
        }
        

        // Конструктор Money
        public Money(int startingBalance)
        {
            CurrentMoney = startingBalance;
        }

        // Метод для выполнения операции с деньгами
        public void PerformMoneyOperation(MoneyOperation operation, int amount)
        {
            operation(ref CurrentMoney, amount);
        }
    }
}
