using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Day11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| Advent of Code - Day 11 |");
            Console.WriteLine("+-------------------------+");

            var directions = File.ReadAllText("input.1.txt").Split(',').ToList();

            var start = new Cube();
            var end = new Cube();
            
            var maxDistance = 0;
            foreach(var direction in directions)
            {
                end = HexGrid.Move(end, direction);
                
                var distance = HexGrid.Distance(start, end);
                if(distance > maxDistance)
                {
                    maxDistance = distance;
                }
            }

            var minDistance = HexGrid.Distance(start, end);

            Console.WriteLine($"Min distance is {minDistance} and furtherst distance is {maxDistance}");

            Console.WriteLine($" - Glædelig jul");
        }
    }
}
