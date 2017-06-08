using System;
using System.Collections.Generic;
using System.Text;
using Track.Models;
using Xunit;

namespace UnitTests
{
    public class AfternoonSessionTests
    {
        private const string Category = "AfternoonSession";

        [Fact]
        [Trait("Category", Category)]
        public void ValidAddTalkExtended()
        {
            // Arrange
            var talk1 = new Talk() { Title = "session 1", Duration = 240 };
            var target = new AfternoonSession();
            // Act
            var output = target.AddTalk(talk1,true);
            // Assert
            Assert.True(output);
            Assert.Equal<int>(240, target.TotalDuration);
        }

        [Fact]
        [Trait("Category", Category)]
        public void ValidAddTalkNotExtended()
        {
            // Arrange
            var talk1 = new Talk() { Title = "session 1", Duration = 180 };
            var target = new AfternoonSession();
            // Act
            var output = target.AddTalk(talk1, false);
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
            var target = new AfternoonSession();
            target.AddTalk(talk1);
            // Act
            var output = target.AddTalk(talk2, false);
            // Assert
            Assert.False(output);
            Assert.Equal<int>(180, target.TotalDuration);
        }

        [Fact]
        [Trait("Category", Category)]
        public void InvalidAddTalkExtended()
        {
            // Arrange
            var talk1 = new Talk() { Title = "session 1", Duration = 240 };
            var talk2 = new Talk() { Title = "session 2", Duration = 1 };
            var target = new AfternoonSession();
            target.AddTalk(talk1, true);
            // Act
            var output = target.AddTalk(talk2, true);
            // Assert
            Assert.False(output);
            Assert.Equal<int>(240, target.TotalDuration);
        }
    }
}
