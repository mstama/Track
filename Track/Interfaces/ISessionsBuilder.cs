using System;
using System.Collections.Generic;
using System.Text;
using Track.Models;

namespace Track.Interfaces
{
    interface ISessionsBuilder
    {
        IList<Session> Build(IList<Talk> talks);
    }
}
