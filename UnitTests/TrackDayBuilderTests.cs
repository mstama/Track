// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Collections.Generic;
using Track.Models;
using Track.Services;
using Xunit;

namespace UnitTests
{
    public class TrackDayBuilderTests
    {
        private const string _category = "TrackDayBuilder";

        private readonly TrackDayBuilder _target = new TrackDayBuilder();

        [Fact]
        [Trait("Category", _category)]
        public void TestBuild()
        {
            // Arrange
            var talks = BuildTalks(12, 30);

            // Act
            var output = _target.Build(talks);

            // Assert
            Assert.Equal<int>(1, output.Count);
        }

        [Fact]
        [Trait("Category", _category)]
        public void TestBuildExtended()
        {
            // Arrange
            var talks = BuildTalks(14, 30);

            // Act
            var output = _target.Build(talks);

            // Assert
            Assert.Equal<int>(1, output.Count);
        }

        [Fact]
        [Trait("Category", _category)]
        public void TestBuildExtended2()
        {
            // Arrange
            var talks = BuildTalks(28, 30);

            // Act
            var output = _target.Build(talks);

            // Assert
            Assert.Equal<int>(2, output.Count);
        }

        private IList<Talk> BuildTalks(int count, int duration)
        {
            List<Talk> talks = new List<Talk>(count);
            for (int i = 0; i < count; i++)
            {
                talks.Add(new Talk(string.Format("Title {0}", i), duration));
            }
            return talks;
        }
    }
}