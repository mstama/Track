using Track.Services;
using Xunit;

namespace UnitTests
{
    public class TalkRegexParserTests
    {
        private const string _category = "TalkRegexParser";

        private readonly TalkRegexParser _target = new TalkRegexParser();

        [Fact]
        [Trait("Category", _category)]
        public void ParseLightning()
        {
            // Arrange
            string input = "Rails for Python Developers lightning";
            // Act
            var output = _target.Parse(input);
            // Assert
            Assert.Equal(15, output.Duration);
            Assert.Equal("Rails for Python Developers", output.Title);
        }

        [Fact]
        [Trait("Category", _category)]
        public void ParseLightningUpper()
        {
            // Arrange
            string input = "RAILS FOR PYTHON DEVELOPERS LIGHTNING";
            // Act
            var output = _target.Parse(input);
            // Assert
            Assert.Equal(15, output.Duration);
            Assert.Equal("RAILS FOR PYTHON DEVELOPERS", output.Title);
        }

        [Fact]
        [Trait("Category", _category)]
        public void ParseMinutes()
        {
            // Arrange
            string input = "Rails for Python Developers 20min";
            // Act
            var output = _target.Parse(input);
            // Assert
            Assert.Equal(20, output.Duration);
            Assert.Equal("Rails for Python Developers", output.Title);
        }

        [Fact]
        [Trait("Category", _category)]
        public void ParseMinutesUpper()
        {
            // Arrange
            string input = "RAILS FOR PYTHON DEVELOPERS 20MIN";
            // Act
            var output = _target.Parse(input);
            // Assert
            Assert.Equal(20, output.Duration);
            Assert.Equal("RAILS FOR PYTHON DEVELOPERS", output.Title);
        }
    }
}