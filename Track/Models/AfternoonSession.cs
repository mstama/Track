using System;
using System.Collections.Generic;
using System.Text;

namespace Track.Models
{
    public class AfternoonSession : Session
    {
        protected DateTime MinNetworkingTime { get; } = new DateTime(2017, 6, 6, 16, 0, 0, 0);

        public AfternoonSession()
        {
            // 9AM
            StartTime = new DateTime(2017, 6, 6, 13, 0, 0, 0);
            MaxEndTime = new DateTime(2017, 6, 6, 17, 0, 0, 0);
            AvailableMinutes = MaxEndTime.Subtract(StartTime).Minutes;
        }

        public override bool CheckAdditionalConstraint()
        {
            var end = StartTime.AddMinutes(TotalDuration);
            if (end >= MinNetworkingTime) return true;
            return false;
        }
    }
}
