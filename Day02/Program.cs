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
            var sum = SpreadsheetChecksumCalculator.Sum(input);

            Console.WriteLine($"Checksum is {checksum} and sum is {sum}");
        }
    }
}
