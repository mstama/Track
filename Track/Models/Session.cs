using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Track.Models
{
    public abstract class Session
    {
        protected List<Talk> Talks { get; } = new List<Talk>();
        public int TotalDuration { get; protected set; } = 0;
        public int AvailableMinutes
        {
            get
            {
                return EndTime.Subtract(StartTime).Minutes - TotalDuration;
            }
        }
        public int AvailableMinutesExtended
        {
            get
            {
                return EndTimeExtended.Subtract(StartTime).Minutes - TotalDuration;
            }
        }
        public DateTime StartTime { get; protected set; }
        public DateTime EndTime { get; protected set; }
        public DateTime EndTimeExtended { get; protected set; }


        protected Session(DateTime startTime, DateTime endTime, DateTime endTimeExtended)
        {
            StartTime = startTime;
            EndTime = endTime;
            EndTimeExtended = endTimeExtended;
        }

        protected Session(DateTime startTime, DateTime endTime):this(startTime, endTime,endTime){

        }


        public bool AddTalk(Talk talk)
        {
            if (CheckConstraint(talk))
            {
                Talks.Add(talk);
                TotalDuration += talk.Duration;
                return true;
            }
            else return false;
        }

        protected bool CheckConstraint(Talk talk)
        {
            var end = StartTime.AddMinutes(TotalDuration + talk.Duration);
            if (end <= EndTime) return true;
            return false;
        }

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
