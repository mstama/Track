﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;

namespace Track.Models
{
    /// <summary>
    /// Abstract class for a session
    /// </summary>
    public abstract class Session
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="endTimeExtended"></param>
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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        protected Session(DateTime startTime, DateTime endTime) : this(startTime, endTime, endTime) { }

        /// <summary>
        /// Sum of all talks duration
        /// </summary>
        public int TotalDuration { get; private set; }

        /// <summary>
        /// Available minutes in session
        /// </summary>
        protected int AvailableMinutes { get; private set; }

        /// <summary>
        /// Available extended minutes in session
        /// </summary>
        protected int AvailableMinutesExtended { get; private set; }

        /// <summary>
        /// Session end time
        /// </summary>
        protected DateTime EndTime { get; set; }

        /// <summary>
        /// Session extended end time
        /// Time that the session can go if not finished until end time
        /// </summary>
        protected DateTime EndTimeExtended { get; set; }

        /// <summary>
        /// Session start time
        /// </summary>
        protected DateTime StartTime { get; set; }

        /// <summary>
        /// List of talks in a session
        /// </summary>
        protected IList<Talk> Talks { get; } = new ObservableCollection<Talk>();

        /// <summary>
        /// Add talks to session if time is available
        /// </summary>
        /// <param name="talk"></param>
        /// <param name="extended">Should consider extended time</param>
        /// <returns></returns>
        public bool AddTalk(Talk talk, bool extended)
        {
            if (CheckConstraint(talk, extended))
            {
                Talks.Add(talk);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Add talks to session if time is available
        /// It does not consider extended time
        /// </summary>
        /// <param name="talk"></param>
        /// <returns></returns>
        public bool AddTalk(Talk talk)
        {
            return AddTalk(talk, false);
        }

        /// <summary>
        /// Return available minutes in session
        /// </summary>
        /// <param name="extended">Should consider extended time</param>
        /// <returns></returns>
        public int CalculatedAvailableMinutes(bool extended)
        {
            return extended ? AvailableMinutesExtended : AvailableMinutes;
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

        /// <summary>
        /// Check whether talk is within availble time
        /// </summary>
        /// <param name="talk"></param>
        /// <param name="extended">Should consider extended time</param>
        /// <returns></returns>
        protected bool CheckConstraint(Talk talk, bool extended)
        {
            if (talk == null) return false;
            var end = StartTime.AddMinutes(TotalDuration + talk.Duration);
            return extended ? end <= EndTimeExtended : end <= EndTime;
        }

        /// <summary>
        /// Updates statistics whether collection is changed
        /// </summary>
        /// <remarks>
        /// It does not handle deletes.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        }
    }
}