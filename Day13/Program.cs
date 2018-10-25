using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Day13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| Advent of Code - Day 13 |");
            Console.WriteLine("+-------------------------+");            

            Part1();
            Part2();

            Console.WriteLine($" - Glædelig jul");
        }

        private static IDictionary<int, Layer> GetLayers()
        {
            return
                File
                    .ReadAllLines("input.1.txt")
                    .Select(x => x.Split(':'))
                    .ToDictionary(
                        x => int.Parse(x[0]),
                        x => new Layer { Range = int.Parse(x[1].Trim()) }
                    );
        }

        private static void Part1()
        {
            var firewall = new Firewall(GetLayers());
            while (firewall.Tick()) ;
            Console.WriteLine($"Severity is {firewall.Severity}");
        }

        private static void Part2()
        {
            var delay = 0;
            do
            {
                var firewall = new Firewall(GetLayers());

                foreach(var i in Enumerable.Range(0, delay))
                    firewall.TickLayers();

                while (firewall.Tick());

                if (firewall.Caught.Count == 0)
                {
                    Console.WriteLine($"Lowest delay possible is {delay}");
                    return;
                }
                else
                {
                    delay++;
                }
                if(delay%1000 == 0)
                    Console.WriteLine($"Now at delay of {delay}");

            } while(true);
        }
    }
}
