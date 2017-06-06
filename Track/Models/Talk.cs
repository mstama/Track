using System;
using System.Collections.Generic;
using System.Text;

namespace Track.Models
{
    public class Talk
    {
        public string Title { get; set; }
        public int Duration { get; set; }

        public override string ToString()
        {
            if(Duration!=15) return string.Format("{0} {1}min", Title, Duration);
            else return string.Format("{0} lightning", Title, Duration);
        }

        public static bool operator <(Talk a, Talk b)
        {
            if (b == null) return false;
            if (a == null) return true;
            return a.Duration < b.Duration;
        }

        public static bool operator >(Talk a, Talk b)
        {
            if (a == null) return false;
            if (b == null) return true;
            return a.Duration > b.Duration;
        }
    }
}
