using System;
using System.Collections.Generic;
using System.Text;

namespace Track.Models
{
    public class MorningSession : Session
    {
        public MorningSession() : base(new DateTime(2017, 6, 6, 9, 0, 0, 0), new DateTime(2017, 6, 6, 12, 0, 0, 0)) { }

        public override string ToString()
        {
            var text= base.ToString();
            var lunchTime = StartTime.AddMinutes(TotalDuration);
            return string.Format("{0}{1:hh:mmtt} Lunch\n", text, lunchTime);
        }
    }
}
