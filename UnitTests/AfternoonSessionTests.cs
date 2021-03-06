﻿// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Track.Models;
using Xunit;

namespace UnitTests
{
    public class AfternoonSessionTests
    {
        private const string _category = "AfternoonSession";

        [Fact]
        [Trait("Category", _category)]
        public void InvalidAddTalk()
        {
            // Arrange
            var talk1 = new Talk("session 1", 180);
            var talk2 = new Talk("session 2", 1);
            var target = new AfternoonSession();
            target.AddTalk(talk1);
            // Act
            var output = target.AddTalk(talk2, false);
            // Assert
            Assert.False(output);
            Assert.Equal<int>(180, target.TotalDuration);
        }

        [Fact]
        [Trait("Category", _category)]
        public void InvalidAddTalkExtended()
        {
            // Arrange
            var talk1 = new Talk("session 1", 240);
            var talk2 = new Talk("session 2", 1);
            var target = new AfternoonSession();
            target.AddTalk(talk1, true);
            // Act
            var output = target.AddTalk(talk2, true);
            // Assert
            Assert.False(output);
            Assert.Equal<int>(240, target.TotalDuration);
        }

        [Fact]
        [Trait("Category", _category)]
        public void ValidAddTalkExtended()
        {
            // Arrange
            var talk1 = new Talk("session 1", 240);
            var target = new AfternoonSession();
            // Act
            var output = target.AddTalk(talk1, true);
            // Assert
            Assert.True(output);
            Assert.Equal<int>(240, target.TotalDuration);
        }

        [Fact]
        [Trait("Category", _category)]
        public void ValidAddTalkNotExtended()
        {
            // Arrange
            var talk1 = new Talk("session 1", 180);
            var target = new AfternoonSession();
            // Act
            var output = target.AddTalk(talk1, false);
            // Assert
            Assert.True(output);
            Assert.Equal<int>(180, target.TotalDuration);
        }
    }
}