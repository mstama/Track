// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Globalization;

namespace Track.Models
{
    /// <summary>
    /// Represents an afternoon session
    /// </summary>
    public class AfternoonSession : Session
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AfternoonSession() : base(new DateTime(2017, 6, 6, 13, 0, 0, 0), new DateTime(2017, 6, 6, 16, 0, 0, 0), new DateTime(2017, 6, 6, 17, 0, 0, 0)) { }

        public override string ToString()
        {
            var text = base.ToString();
            var networkingTime = StartTime.AddMinutes(TotalDuration);
            return string.Format("{0}{1} Networking Event\n", text, networkingTime.ToString("hh:mmtt",CultureInfo.InvariantCulture));
        }
    }
}