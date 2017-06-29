using System;
using System.Text.RegularExpressions;
using Track.Interfaces;
using Track.Models;

namespace Track.Services
{
    /// <summary>
    /// Parser for talks using regex
    /// </summary>
    public class TalkRegexParser : ITalkParser
    {
        private const string _lightning = "lightning";
        private const string _talkPattern = @"(?<Title>.*) +(?<Duration>\d+(?=min)|lightning)";
        private static readonly Regex _talkExpression = new Regex(_talkPattern, RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

        /// <summary>
        /// Parse a text and return talk
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Talk Parse(string text)
        {
            var result = _talkExpression.Matches(text);
            int duration = result[0].Groups["Duration"].Value.Equals(_lightning, StringComparison.OrdinalIgnoreCase) ? 15 : int.Parse(result[0].Groups["Duration"].Value);
            return new Talk(result[0].Groups["Title"].Value, duration);
        }
    }
}