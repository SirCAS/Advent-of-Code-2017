using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Day09
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| Advent of Code - Day 09 |");
            Console.WriteLine("+-------------------------+");

            var input = File.ReadAllText("input.1.txt");

            var score = GarbageCollector.GetScore(input);
            Console.WriteLine($"Group score is {score}");

            var garbage = GarbageCollector.RemovedGarbage(input);
            Console.WriteLine($"Removed garbage is {garbage}");

            Console.WriteLine($" - Glædelig jul");
        }
    }
}
