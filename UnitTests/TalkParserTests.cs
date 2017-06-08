using System;
using Track.Services;
using Xunit;

namespace UnitTests
{
    public class TalkParserTests
    {
        private const string Category = "TalkParser";

        private TalkParser target = new TalkParser();

        [Fact]
        [Trait("Category", Category)]
        public void ParseLightning()
        {
            // Arrange
            string input = "Rails for Python Developers lightning";
            // Act
            var output = target.Parse(input);
            // Assert
            Assert.Equal(15, output.Duration);
            Assert.Equal("Rails for Python Developers", output.Title);
        }

        [Fact]
        [Trait("Category", Category)]
        public void ParseMinutes()
        {
            // Arrange
            string input = "Rails for Python Developers 20min";
            // Act
            var output = target.Parse(input);
            // Assert
            Assert.Equal(20, output.Duration);
            Assert.Equal("Rails for Python Developers", output.Title);
        }
    }
}
