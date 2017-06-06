using System;
using System.Collections.Generic;
using System.Text;
using Track.Interfaces;
using Track.Models;
using System.Linq;

namespace Track
{
    public class SessionsBuilder : ISessionsBuilder
    {

        public IList<Session> Build(IList<Talk> talks)
        {
            List<Session> sessions = new List<Session>();
            bool morning = true;
            Session session;
            talks = talks.OrderByDescending(t => t.Duration).ToList();
            while (talks.Count > 0)
            {
                // Create session
                session = morning ? (Session)new MorningSession() : (Session)new AfternoonSession();
                morning = !morning;

                do
                {
                    // Fill with talks
                    if (session.AddTalk(talks.First()))
                    {
                        talks.RemoveAt(0);
                    }
                    else
                    {
                        // There is time available 
                        if (session.AvailableMinutes > 0)
                        {
                            var equalTime = talks.SingleOrDefault(t => t.Duration == session.AvailableMinutes);
                            if (equalTime != null)
                            {
                                session.AddTalk(equalTime);
                                talks.Remove(equalTime);
                            }
                            else { 
                                var lessTime = talks.SingleOrDefault(t => t.Duration < session.AvailableMinutes);
                                if (lessTime != null)
                                {
                                    session.AddTalk(lessTime);
                                    talks.Remove(lessTime);
                                }
                            }
                        }
                        break;
                    }
                } while (talks.Count > 0);
                sessions.Add(session);
            }
            return sessions;
        }
    }
}
