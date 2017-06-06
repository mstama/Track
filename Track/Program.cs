using System;
using System.IO;
using Track.Interfaces;
using Track.Parsers;

namespace Track
{
    class Program
    {
        private static ITalkParser _parser;

        // Composition root
        private static void Init()
        {
            _parser = new TalkParser();
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

            foreach (var line in lines)
            {
                var talk = _parser.Parse(line);
                Console.WriteLine(talk);
            }


            Console.ReadLine();
        }
    }
}