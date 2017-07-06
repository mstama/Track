using System;
using System.Collections.Generic;
using System.IO;
using Track.Interfaces;
using Track.Models;
using Track.Services;
using Track.Extensions;

namespace Track
{
    internal static class Program
    {
        private static ITalkParser _parser;
        private static ITrackDayBuilder _sessionBuilder;

        // Composition root
        private static void Init()
        {
            _parser = new TalkRegexParser();
            _sessionBuilder = new TrackDayBuilder();
        }

        private static void Main(string[] args)
        {
            Init();

            if (args.Length == 0)
            {
                Console.WriteLine("Input file required!");
                return;
            }
            string filePath = args[0];
            if (!File.Exists(filePath)) { Console.WriteLine("File does not exist!"); }
            Console.WriteLine("Processing file {0}.", args[0]);
            var lines = File.ReadLines(filePath);
            var talks = new List<Talk>();

            foreach (var line in lines)
            {
                var talk = _parser.Parse(line);
                // Check returned talk
                talks.AddCheck(talk);
            }

            foreach (var session in _sessionBuilder.Build(talks))
            {
                Console.WriteLine(session);
            }
        }
    }
}