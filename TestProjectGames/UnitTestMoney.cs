using ClassLibraryGame;
using Xunit;

namespace ClassLibraryGame.Tests
{
    public class MoneyTests
    {
        [Fact]
        public void Add_ShouldIncreaseBalance()
        {
            // Arrange
            Money money = new Money(100);

            // Act
            money.Add(50);

            // Assert
            Assert.Equal(150, money.GetBalance());
        }

        [Fact]
        public void TrySubtract_WithSufficientFunds_ShouldDecreaseBalanceAndReturnTrue()
        {
            // Arrange
            Money money = new Money(100);

            // Act
            bool result = money.TrySubtract(30);

            // Assert
            Assert.True(result);
            Assert.Equal(70, money.GetBalance());
        }

        [Fact]
        public void TrySubtract_WithInsufficientFunds_ShouldNotChangeBalanceAndReturnFalse()
        {
            // Arrange
            Money money = new Money(30);

            // Act
            bool result = money.TrySubtract(50);

            // Assert
            Assert.False(result);
            Assert.Equal(30, money.GetBalance());
        }

        [Fact]
        public void PerformMoneyOperation_WithAddMoney_ShouldIncreaseBalance()
        {
            // Arrange
            Money money = new Money(100);

            // Act
            money.PerformMoneyOperation(Money.AddMoney, 50);

            // Assert
            Assert.Equal(150, money.GetBalance());
        }

        [Fact]
        public void PerformMoneyOperation_WithDelMoney_ShouldDecreaseBalance()
        {
            // Arrange
            Money money = new Money(100);

            // Act
            money.PerformMoneyOperation(Money.DelMoney, 30);

            // Assert
            Assert.Equal(70, money.GetBalance());
        }
    }
}