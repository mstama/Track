using System;
using System.Collections.Generic;
using System.Text;

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
            return string.Format("{0}{1:hh:mmtt} Networking Event\n", text, networkingTime);
        }
    }
}
