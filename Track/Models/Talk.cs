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
            return Duration != 15?string.Format("{0} {1}min", Title, Duration):string.Format("{0} lightning", Title, Duration);
        }
    }
}
