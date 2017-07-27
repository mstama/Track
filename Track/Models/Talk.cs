// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Track.Models
{
    /// <summary>
    /// Represents a talk
    /// </summary>
    public class Talk
    {
        /// <summary>
        /// Duration in minutes
        /// </summary>
        public int Duration { get; }

        /// <summary>
        /// Title of the talk
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="title"></param>
        /// <param name="duration"></param>
        public Talk(string title, int duration)
        {
            Title = title;
            Duration = duration;
        }

        public override string ToString()
        {
            return Duration != 15 ? string.Format("{0} {1}min", Title, Duration) : string.Format("{0} lightning", Title);
        }
    }
}