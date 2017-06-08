using Track.Models;

namespace Track.Interfaces
{
    /// <summary>
    /// Interface for the parser
    /// </summary>
    public interface ITalkParser
    {
        /// <summary>
        /// Parse text to return a talk
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        Talk Parse(string text);
    }
}