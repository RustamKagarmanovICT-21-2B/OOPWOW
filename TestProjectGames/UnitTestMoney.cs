using ClassLibraryGame;
using Xunit;

namespace ClassLibraryGame.Tests
{
    public class MoneyTests
    {
        [Fact]
        public void AddMoney_ShouldIncreaseBalance()
        {
            // Arrange
            Money money = new Money(100);
            int moneyBag = 100;
            int initialBalance = money.GetMoney();

            // Act
            Money.AddMoney(ref moneyBag, 50);

            // Assert
            Assert.Equal(initialBalance + 50, money.GetMoney());
        }

        [Fact]
        public void DelMoney_ShouldDecreaseBalance()
        {
            // Arrange
            Money money = new Money(100);
            int moneyBag = 100;
            int initialBalance = money.GetMoney();

            // Act
            Money.DelMoney(ref moneyBag, 30);

            // Assert
            Assert.Equal(initialBalance - 30, money.GetMoney());
        }

        [Fact]
        public void DelMoney_ShouldNotGoBelowZero()
        {
            // Arrange
            int moneyBag = 30;
            Money money = new Money(30);

            // Act
            Money.DelMoney(ref moneyBag, 50);

            // Assert
            Assert.Equal(0, money.GetMoney());
        }

        [Theory]
        [InlineData(100, 25, 125)]
        [InlineData(50, 10, 60)]
        [InlineData(0, 100, 100)]
        public void PerformMoneyOperation_ShouldWorkWithAdd(int initial, int addAmount, int expected)
        {
            // Arrange
            Money money = new Money(initial);

            // Act
            money.PerformMoneyOperation(Money.AddMoney, addAmount);

            // Assert
            Assert.Equal(expected, money.GetMoney());
        }
    }
}