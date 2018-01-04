using System;
using System.IO;

namespace Day03
{
    class Program
    {
        static void Main(string[] args)
        {
            long input = 325489;

            var steps = SpiralMemory.GetSteps(input);

            Console.WriteLine($"Number of requried steps is {steps}");
        }
    }
}
