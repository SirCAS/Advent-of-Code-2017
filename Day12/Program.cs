using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Day12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| Advent of Code - Day 12 |");
            Console.WriteLine("+-------------------------+");

            var mappings =
                File
                    .ReadAllLines("input.1.txt")
                    .ToDictionary(
                        x => x.Split(' ')[0],
                        x => x.Substring(x.IndexOf('>') + 1).Split(',').Select(y => y.Trim()).ToList()
                    );

            var pg = new ProgramGroups(mappings);

            var groupZero = pg.GetConnected("0");
            var groupCount = pg.GetUniqeGroups();

            Console.WriteLine($"Program ID 0 is connected with {groupZero.Count} programs");
            Console.WriteLine($"There is a total of {groupCount} groups");

            Console.WriteLine($" - Glædelig jul");
        }
    }
}
