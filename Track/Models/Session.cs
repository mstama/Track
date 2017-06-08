using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Track.Models
{
    public abstract class Session
    {
        protected Session(DateTime startTime, DateTime endTime, DateTime endTimeExtended)
        {
            StartTime = startTime;
            EndTime = endTime;
            EndTimeExtended = endTimeExtended;

            AvailableMinutes = (int)EndTime.Subtract(StartTime).TotalMinutes;

            AvailableMinutesExtended = (int)EndTimeExtended.Subtract(StartTime).TotalMinutes;

            var collection = (ObservableCollection<Talk>)Talks;

            collection.CollectionChanged += OnCollectionChanged;
        }

        protected Session(DateTime startTime, DateTime endTime) : this(startTime, endTime, endTime)
        {
        }

        public int AvailableMinutes { get; private set; }

        public int AvailableMinutesExtended { get; private set; }

        public DateTime EndTime { get; protected set; }
        public DateTime EndTimeExtended { get; protected set; }
        public DateTime StartTime { get; protected set; }
        public int TotalDuration { get; private set; }
        protected IList<Talk> Talks { get; } = new ObservableCollection<Talk>();

        public bool AddTalk(Talk talk)
        {
            if (CheckConstraint(talk))
            {
                Talks.Add(talk);
                return true;
            }
            return false;
        }

        public Talk ReturnLast()
        {
            var last = Talks.LastOrDefault();
            if (Talks.Count > 0)
                Talks.RemoveAt(Talks.Count - 1);
            return last;
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            var start = StartTime;
            foreach (var talk in Talks)
            {
                text.Append(string.Format("{0:hh:mmtt} {1}\n", start, talk));
                start = start.AddMinutes(talk.Duration);
            }
            return text.ToString();
        }

        protected bool CheckConstraint(Talk talk)
        {
            if (talk == null) return false;
            var end = StartTime.AddMinutes(TotalDuration + talk.Duration);
            if (end <= EndTime) return true;
            return false;
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Talk newItem in e.NewItems)
                {
                    TotalDuration += newItem.Duration;
                    AvailableMinutes -= newItem.Duration;
                    AvailableMinutesExtended -= newItem.Duration;
                }
            }

            if (e.OldItems != null)
            {
                foreach (Talk oldItem in e.OldItems)
                {
                }
            }
        }
    }
}