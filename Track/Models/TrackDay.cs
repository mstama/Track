using System;
using System.Collections.Generic;
using System.Text;

namespace Track.Models
{
    public class TrackDay
    {
        public MorningSession Morning { get; set; } = new MorningSession();
        public AfternoonSession Afternoon { get; set; } = new AfternoonSession();
        public string Name { get; set; }

        public TrackDay() { }

        public TrackDay(string name) : this()
        {
            Name = name;
        }

        public override string ToString()
        {
            return string.Format("Track {0}\n{1}{2}", Name, Morning, Afternoon);
        }
    }
}
