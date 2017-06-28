using Track.Models;
using Xunit;

namespace UnitTests
{
    public class MorningSessionTests
    {
        private const string _category = "MorningSession";

        [Fact]
        [Trait("Category", _category)]
        public void InvalidAddTalk()
        {
            // Arrange
            var talk1 = new Talk() { Title = "session 1", Duration = 180 };
            var talk2 = new Talk() { Title = "session 2", Duration = 1 };
            var target = new MorningSession();
            target.AddTalk(talk1);
            // Act
            var output = target.AddTalk(talk2);
            // Assert
            Assert.False(output);
            Assert.Equal<int>(180, target.TotalDuration);
        }

        [Fact]
        [Trait("Category", _category)]
        public void ValidAddTalk()
        {
            // Arrange
            var talk1 = new Talk() { Title = "session 1", Duration = 180 };
            var target = new MorningSession();
            // Act
            var output = target.AddTalk(talk1);
            // Assert
            Assert.True(output);
            Assert.Equal<int>(180, target.TotalDuration);
        }
    }
}