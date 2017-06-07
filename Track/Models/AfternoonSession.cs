using System;
using System.Collections.Generic;
using System.Text;

namespace Track.Models
{
    public class AfternoonSession : Session
    {
        protected DateTime MinNetworkingTime { get; } = new DateTime(2017, 6, 6, 16, 0, 0, 0);

        public AfternoonSession():base(new DateTime(2017, 6, 6, 13, 0, 0, 0), new DateTime(2017, 6, 6, 17, 0, 0, 0), new DateTime(2017, 6, 6, 16, 0, 0, 0))
        {
        }
    }
}
