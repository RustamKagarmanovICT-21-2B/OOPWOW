using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGame
{
    public class Money
    {
        private int _balance;

        public Money(int startingBalance)
        {
            _balance = startingBalance;
        }

        public void Add(int amount)
        {
            _balance += amount;
        }

        public bool TrySubtract(int amount)
        {
            if (amount > _balance)
            {
                Console.WriteLine("Недостаточно средств для совершения операции.");
                return false;
            }

            _balance -= amount;
            return true;
        }

        public int GetBalance()
        {
            return _balance;
        }

        // Для обратной совместимости с делегатами
        public static void AddMoney(Money money, int amount)
        {
            money.Add(amount);
        }

        public static void DelMoney(Money money, int amount)
        {
            money.TrySubtract(amount);
        }

        public void PerformMoneyOperation(Action<Money, int> operation, int amount)
        {
            operation(this, amount);
        }
    }
}