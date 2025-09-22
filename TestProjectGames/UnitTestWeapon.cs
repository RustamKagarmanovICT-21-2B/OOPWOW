using ClassLibraryGame;
using Xunit;

namespace ClassLibraryGame.Tests
{
    public class WeaponTests
    {
        [Fact]
        public void ApplyImprovementDamageUpTest()
        {
            // Arrange
           Weapon sword = new Weapon("sword", 1, 1);


            // Act
            sword.ApplyImprovement();

            // Assert
            Assert.Equal(3, sword.Damage);
        }
        [Fact]
        public void ApplyImprovementQualityUpTest()
        {
            // Arrange
            Weapon sword = new Weapon("sword", 1, 1);


            // Act
            sword.ApplyImprovement();

            // Assert
            Assert.Equal(1 + 1, sword.Quality);
        }
    }
}