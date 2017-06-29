using Track.Services;
using Xunit;

namespace UnitTests
{
    public class TalkParserTests
    {
        private const string _category = "TalkParser";

        private readonly TalkParser _target = new TalkParser();

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
        public void ParseLightning2()
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
        public void ParseMinutes2()
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