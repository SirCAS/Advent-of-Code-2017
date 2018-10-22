using System;
using System.Diagnostics;
using System.IO;

namespace Day03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| Advent of Code - Day 03 |");
            Console.WriteLine("+-------------------------+");

            long input = 325489;
            
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var part1 = SpiralMemory.GetSteps(input);
            sw.Stop();
            Console.WriteLine($"Part 1: Number of requried steps is {part1} and was found in {sw.ElapsedMilliseconds} ms");
            sw.Reset();

            sw.Start();
            var part2 = AdvancedSpiralMemory.GetFirstValueAboveTarget(input);
            sw.Stop();
            Console.WriteLine($"Part 2: First value above target is {part2} and was found in {sw.ElapsedMilliseconds} ms");

            Console.WriteLine($" - Glædelig jul");
        }
    }
}
