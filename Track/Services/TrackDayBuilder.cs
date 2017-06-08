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
                    while (session.AddTalk(talks.FirstOrDefault()))
                    {
                        talks.RemoveAt(0);
                    }

                    // There is time available 
                    while (session.AvailableMinutes > 0)
                    {
                        // Find a session to fill the remainer slot
                        var equalLessTime = talks.SingleOrDefault(t => t.Duration == session.AvailableMinutes) ?? talks.SingleOrDefault(t => t.Duration < session.AvailableMinutes);
                        if (equalLessTime != null)
                        {
                            session.AddTalk(equalLessTime);
                            talks.Remove(equalLessTime);
                        }
                        else
                        {
                            break;
                        }
                    }
                    morning = !morning;
                } while (!morning);
                trackDays.Add(day);
                //Have to deal with extended.
            }
            return trackDays;
        }
    }
}
