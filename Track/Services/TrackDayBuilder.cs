using System;
using System.Collections.Generic;
using System.Text;
using Track.Interfaces;
using Track.Models;
using System.Linq;

namespace Track.Services
{
    public class TrackDayBuilder : ITrackDayBuilder
    {

        public IList<TrackDay> Build(IList<Talk> talks)
        {
            List<TrackDay> trackDays = new List<TrackDay>();
            // Better fitting
            talks = talks.OrderByDescending(t => t.Duration).ToList();
            // While there are talks...
            while (talks.Count > 0)
            {
                // Create track day
                TrackDay day = new TrackDay();
                bool morning = true;
                do
                {
                    var session = morning ? day.Morning : (Session)day.Afternoon;
                    FillSlots(talks, session, false);
                    morning = !morning;
                } while (!morning);
                trackDays.Add(day);
                //Have to deal with extended.
                if (talks.Sum(t => t.Duration) <= trackDays.Sum(t => t.Afternoon.CalculatedAvailableMinutes(true)))
                {
                    foreach (var trakDay in trackDays)
                    {
                        FillSlots(talks, trakDay.Afternoon, true);
                    }
                }
            }
            return trackDays;
        }

        private static void FillSlots(IList<Talk> talks, Session session, bool extended)
        {
            while (session.AddTalk(talks.FirstOrDefault(), extended))
            {
                talks.RemoveAt(0);
            }

            // There is time available 
            while (session.CalculatedAvailableMinutes(extended) > 0)
            {
                // Find a session to fill the remainer slot
                var equalLessTime = talks.SingleOrDefault(t => t.Duration == session.CalculatedAvailableMinutes(extended)) ?? talks.SingleOrDefault(t => t.Duration < session.CalculatedAvailableMinutes(extended));
                if (equalLessTime != null)
                {
                    session.AddTalk(equalLessTime, extended);
                    talks.Remove(equalLessTime);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
