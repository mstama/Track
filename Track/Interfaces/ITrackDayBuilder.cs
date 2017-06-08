using System.Collections.Generic;
using Track.Models;

namespace Track.Interfaces
{
    /// <summary>
    /// Interface for track builder
    /// </summary>
    internal interface ITrackDayBuilder
    {
        /// <summary>
        /// Distribute the talks within the track
        /// </summary>
        /// <param name="talks"></param>
        /// <returns></returns>
        IList<TrackDay> Build(IList<Talk> talks);
    }
}