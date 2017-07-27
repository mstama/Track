// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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