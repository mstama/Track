namespace Track.Models
{
    /// <summary>
    /// Represents a track day
    /// </summary>
    public class TrackDay
    {
        /// <summary>
        /// Afternoon session of a track day
        /// </summary>
        public AfternoonSession Afternoon { get; } = new AfternoonSession();

        /// <summary>
        /// Morning session of track day
        /// </summary>
        public MorningSession Morning { get; } = new MorningSession();

        /// <summary>
        /// Track name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public TrackDay() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        public TrackDay(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return string.Format("Track {0}\n{1}{2}", Name, Morning, Afternoon);
        }
    }
}