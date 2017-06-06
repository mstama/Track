﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Track.Models
{
    public abstract class Session
    {
        protected List<Talk> Talks { get; } = new List<Talk>();
        public int TotalDuration { get; protected set; } = 0;
        public int AvailableMinutes { get; protected set; } = 0;
        public DateTime StartTime { get; protected set; }
        public DateTime MaxEndTime { get; protected set; }

        public bool AddTalk(Talk talk)
        {
            if (CheckConstraint(talk))
            {
                Talks.Add(talk);
                TotalDuration += talk.Duration;
                AvailableMinutes -= talk.Duration;
                return true;
            }
            else return false;
        }

        protected bool CheckConstraint(Talk talk)
        {
            var end = StartTime.AddMinutes(TotalDuration + talk.Duration);
            if (end <= MaxEndTime) return true;
            return false;
        }

        public bool SessionFull()
        {
            var end = StartTime.AddMinutes(TotalDuration );
            if (end == MaxEndTime) return true;
            return false;
        }

        public abstract bool CheckAdditionalConstraint();

        public Talk ReturnLast()
        {
            var last = Talks.LastOrDefault();
            if(Talks.Count>0)
            Talks.RemoveAt(Talks.Count - 1);
            return last;
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            var start = StartTime;
            foreach(var talk in Talks)
            {
                text.Append(string.Format("{0:hh:mmtt} {1}\n", start, talk));
                start = start.AddMinutes(talk.Duration);
            }
            return text.ToString();
        }
    }
}
