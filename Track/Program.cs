using System;
using System.Collections.Generic;
using System.IO;
using Track.Interfaces;
using Track.Models;
using Track.Services;

namespace Track
{
    class Program
    {
        private static ITalkParser _parser;
        private static ITrackDayBuilder _sessionBuilder;

        // Composition root
        private static void Init()
        {
            _parser = new TalkRegexParser();
            _sessionBuilder = new TrackDayBuilder();
        }

        static void Main(string[] args)
        {
            Init();

            if (args.Length == 0)
            {
                Console.WriteLine("Input file required!");
                return;
            }
            string filePath = args[0];
            if (!File.Exists(filePath)) Console.WriteLine("File does not exist!");
            Console.WriteLine("Processing file {0}.", args[0]);
            var lines = File.ReadLines(filePath);
            List<Talk> talks = new List<Talk>();


            foreach (var line in lines)
            {
                var talk = _parser.Parse(line);
                talks.Add(talk);
            }
            var sessions = _sessionBuilder.Build(talks);
            foreach(var session in sessions)
            {
                Console.WriteLine(session);
            }
        }
    }
}