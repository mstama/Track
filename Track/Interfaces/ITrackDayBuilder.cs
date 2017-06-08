using System;
using System.Collections.Generic;
using System.Text;
using Track.Models;

namespace Track.Interfaces
{
    interface ITrackDayBuilder
    {
        IList<TrackDay> Build(IList<Talk> talks);
    }
}
