using System;
using System.IO;

namespace Day02
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");

            var checksum = SpreadsheetChecksumCalculator.CheckSum(input);

            Console.WriteLine($"Part1: Checksum is {checksum}");
        }
    }
}
