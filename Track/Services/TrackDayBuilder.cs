﻿// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Track.Interfaces;
using Track.Models;
using Track.Extensions;

namespace Track.Services
{
    /// <summary>
    /// Track builder
    /// </summary>
    public class TrackDayBuilder : ITrackDayBuilder
    {
        /// <summary>
        /// Receives a list of talks and return a list of track days
        /// </summary>
        /// <param name="talks"></param>
        /// <returns></returns>
        public IList<TrackDay> Build(IList<Talk> talks)
        {
            var trackDays = new List<TrackDay>();
            // Better fitting
            var orderedTalks = talks.OrderByDescending(t => t.Duration).ToList();
            int trackNumber = 0;
            // While there are talks...
            while (orderedTalks.NotEmpty())
            {
                // Create track day
                trackNumber++;
                var day = new TrackDay(trackNumber.ToString());
                bool morning = true;
                do
                {
                    var session = morning ? day.Morning : (Session)day.Afternoon;
                    FillSlots(orderedTalks, session, false);
                    morning = !morning;
                } while (!morning);
                trackDays.Add(day);
                //Have to deal with extended.
                if (orderedTalks.Sum(t => t.Duration) <= trackDays.Sum(t => t.Afternoon.CalculatedAvailableMinutes(true)))
                {
                    foreach (var trackDay in trackDays)
                    {
                        FillSlots(orderedTalks, trackDay.Afternoon, true);
                    }
                }
            }
            return trackDays;
        }

        /// <summary>
        /// Fill slots in a given session
        /// </summary>
        /// <param name="talks"></param>
        /// <param name="session"></param>
        /// <param name="extended">Should use extended time</param>
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