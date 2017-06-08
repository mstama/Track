using System;
using System.Collections.Generic;
using System.Text;

namespace Track.Models
{
    public class TrackDay
    {
        public MorningSession Morning { get; set; } = new MorningSession();
        public AfternoonSession Afternoon { get; set; } = new AfternoonSession();

    }
}
