namespace Track.Models
{
    /// <summary>
    /// Represents a talk
    /// </summary>
    public class Talk
    {
        /// <summary>
        /// Duration in minutes
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Title of the talk
        /// </summary>
        public string Title { get; set; }

        public override string ToString()
        {
            return Duration != 15 ? string.Format("{0} {1}min", Title, Duration) : string.Format("{0} lightning", Title, Duration);
        }
    }
}