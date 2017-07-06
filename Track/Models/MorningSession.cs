using System;
using System.Globalization;

namespace Track.Models
{
    /// <summary>
    /// Represents a morning session
    /// </summary>
    public class MorningSession : Session
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MorningSession() : base(new DateTime(2017, 6, 6, 9, 0, 0, 0), new DateTime(2017, 6, 6, 12, 0, 0, 0)) { }

        public override string ToString()
        {
            var text = base.ToString();
            var lunchTime = StartTime.AddMinutes(TotalDuration);
            return string.Format("{0}{1} Lunch\n", text, lunchTime.ToString("hh:mmtt",CultureInfo.InvariantCulture));
        }
    }
}