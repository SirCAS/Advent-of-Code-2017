using System;

namespace Day01
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "91212129";

            int sum = CaptchaSummer.Sum(input);

            Console.WriteLine($"Sum is {sum}");
        }
    }
}
