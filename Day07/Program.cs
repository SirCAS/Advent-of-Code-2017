using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Day07
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| Advent of Code - Day 07 |");
            Console.WriteLine("+-------------------------+");

            var input = File.ReadAllLines("input.1.txt");
            var tree = new DiscTree(input);

            // Part 1
            Console.WriteLine($"Bottom disc is {tree.Root.Name}");

            // Part 2
            var affectedChild = new HashSet<(TreeItem, int)>();
            tree.Traverse(tree.Root, ref affectedChild, 0);

            var badChilds = affectedChild.OrderByDescending(x => x.Item2).First().Item1.Parent.Childs;
            var badChild = badChilds.OrderByDescending(x => x.CalculatedWight).First();

            var weightSums = badChilds.Select(x => x.CalculatedWight);
            var adjusted = badChild.Weight - (weightSums.Max() - weightSums.Min());

            Console.WriteLine($"Adjusted weight af bad child is {adjusted}");

            Console.WriteLine($" - Glædelig jul");
        }
    }
}
