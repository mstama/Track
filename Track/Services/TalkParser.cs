using System;
using System.Linq;
using Track.Extensions;
using Track.Interfaces;
using Track.Models;

namespace Track.Services
{
    /// <summary>
    /// Parser for talks
    /// </summary>
    public class TalkParser : ITalkParser
    {
        private const string _lightning = "lightning";
        private const string _min = "min";
        private static readonly char[] _separator = { ' ' };

        /// <summary>
        /// Parse a text and return a talk
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Talk Parse(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return new Talk("", -1);

            string[] words = text.Split(_separator, StringSplitOptions.RemoveEmptyEntries);
            // Title
            string title = string.Join(" ", words.Take(words.Length - 1));

            // Last one is the length
            string textDuration = words.Last();
            int duration = textDuration.Equals(_lightning, StringComparison.OrdinalIgnoreCase) ? 15 : int.Parse(textDuration.ReplaceInsensitive(_min, ""));

            return new Talk(title, duration);
        }
    }
}