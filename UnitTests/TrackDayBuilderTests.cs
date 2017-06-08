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
