using System;
using System.Collections.Generic;
using System.Text;
using Track.Models;
using Track.Services;
using Xunit;

namespace UnitTests
{
    public class TrackDayBuilderTests
    {
        private const string Category = "TrackDayBuilder";

        private TrackDayBuilder target = new TrackDayBuilder();

        [Fact]
        [Trait("Category", Category)]
        public void TestBuild()
        {
            // Arrange
            var talks = BuildTalks(12, 30);

            // Act
            var output = target.Build(talks);

            // Assert
            Assert.Equal<int>(1, output.Count);
        }

        [Fact]
        [Trait("Category", Category)]
        public void TestBuildExtended()
        {
            // Arrange
            var talks = BuildTalks(14, 30);

            // Act
            var output = target.Build(talks);

            // Assert
            Assert.Equal<int>(1, output.Count);
        }

        [Fact]
        [Trait("Category", Category)]
        public void TestBuildExtended2()
        {
            // Arrange
            var talks = BuildTalks(28, 30);

            // Act
            var output = target.Build(talks);

            // Assert
            Assert.Equal<int>(2, output.Count);
        }

        private IList<Talk> BuildTalks(int count, int duration)
        {
            List<Talk> talks = new List<Talk>(count);
            for(int i = 0; i < count; i++)
            {
                talks.Add(new Talk() { Title = string.Format("Title {0}", i), Duration = duration });
            }
            return talks;
        }
    }
}
