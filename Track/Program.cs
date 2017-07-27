// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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
        private static readonly ITalkParser _parser;
        private static readonly ITrackDayBuilder _sessionBuilder;

        // Composition root
        static Program()
        {
            _parser = new TalkRegexParser();
            _sessionBuilder = new TrackDayBuilder();
        }

        private static void Main(string[] args)
        {
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