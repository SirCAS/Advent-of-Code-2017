using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| Advent of Code - Day 10 |");
            Console.WriteLine("+-------------------------+");

            var testInput = "97,167,54,178,2,11,209,174,119,248,254,0,255,1,64,190";
            var sparseHash = KnotHash.SparseHash(256, testInput.Split(',').Select(x => int.Parse(x)).ToList());
            Console.WriteLine($"The first two hash numbers of the sparse hash mutiplied is {sparseHash[0] * sparseHash[1]}");

            var denseHash = KnotHash.DenseHash(testInput);
            Console.WriteLine($"The dense hash is {denseHash}");
            Console.WriteLine();

            Console.WriteLine($" - Glædelig jul");
        }
    }
}
