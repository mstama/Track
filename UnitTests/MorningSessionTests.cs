using System;
using System.Collections.Generic;
using System.Text;
using Track.Models;
using Xunit;

namespace UnitTests
{
    public class MorningSessionTests
    {
        private const string Category = "MorningSession";

        [Fact]
        [Trait("Category", Category)]
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

        [Fact]
        [Trait("Category", Category)]
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
    }
}
