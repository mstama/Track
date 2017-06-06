using System;
using System.Collections.Generic;
using System.Text;

namespace Track.Models
{
    public class MorningSession : Session
    {
        public MorningSession()
        {
            // 9AM
            StartTime = new DateTime(2017,6,6,9,0,0,0);
            MaxEndTime = new DateTime(2017, 6, 6, 12, 0, 0, 0);
            AvailableMinutes = MaxEndTime.Subtract(StartTime).Minutes;
        }

        public override bool CheckAdditionalConstraint()
        {
            return true;
        }
    }
}
