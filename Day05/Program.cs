using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Day05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| Advent of Code - Day 05 |");
            Console.WriteLine("+-------------------------+");

            Part1();
            Part2();

            Console.WriteLine($" - Glædelig jul");
        }

        private static void Part1()
        {
            var input = File.ReadAllLines("input.1.txt").Select(x => int.Parse(x)).ToList();

            int sp = 0;
            int steps = 0;

            while (sp < input.Count && sp > -1)
            {
                var delta = input[sp];
                ++input[sp];
                sp += delta;
                ++steps;
            }

            Console.WriteLine($"Part1: Used {steps} steps before out of range");
        }

        private static void Part2()
        {
            var input = File.ReadAllLines("input.1.txt").Select(x => int.Parse(x)).ToList();

            int sp = 0;
            int steps = 0;

            while (sp < input.Count && sp > -1)
            {
                var delta = input[sp];
                
                if(delta>= 3)
                {
                    --input[sp];
                } else {
                    ++input[sp];
                }

                sp += delta;
                ++steps;
            }

            Console.WriteLine($"Part2: Used {steps} steps before out of range");
        }
    }
}
