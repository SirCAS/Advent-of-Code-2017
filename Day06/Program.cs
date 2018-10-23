using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Day06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| Advent of Code - Day 06 |");
            Console.WriteLine("+-------------------------+");

            var memoryBank =
                File
                    .ReadAllText("input.1.txt")
                    .Split('\t')
                    .Select(x => int.Parse(x))
                    .ToList();

            var memory = new CircleMemory(memoryBank);

            var cycles = memory.FindCollisions();

            Console.WriteLine($"First collision was found at cycle no {cycles.Item1}");
            Console.WriteLine($"Recollision was found at cycle no {cycles.Item2}");

            Console.WriteLine($" - Glædelig jul");
        }
    }

}
