using System;
using System.Collections.Generic;
using System.Text;
using Track.Models;
using Track.Interfaces;
using System.Linq;

namespace Track.Services
{
    public class TalkParser : ITalkParser
    {
        private static readonly char[] _separator = { ' ' };
        private const string _lightning = "lightning";
        private const string _min = "min";

        public Talk Parse(string text)
        {
            string[] words = text.Split(_separator, StringSplitOptions.RemoveEmptyEntries);
            // Title
            string title = string.Join(" ",words.Take(words.Length - 1));

            // Last one is the length
            string textDuration = words.Last();
            int duration = 0;
            if (textDuration == _lightning) duration = 15;
            else duration=int.Parse(textDuration.Replace(_min,""));
            return new Talk() { Title = title, Duration = duration };
        }
    }
}
