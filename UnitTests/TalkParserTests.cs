// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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
        public void ParseEmpty()
        {
            // Arrange
            string input = " ";
            // Act
            var output = _target.Parse(input);
            // Assert
            Assert.Equal(-1, output.Duration);
            Assert.Equal("", output.Title);
        }

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