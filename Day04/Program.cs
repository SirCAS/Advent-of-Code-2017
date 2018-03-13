using System;
using System.IO;

namespace Day04
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");

            var validLegacyCount = PassphraseValidator.CountValidUsingLegacy(input);
            var validCount = PassphraseValidator.CountValid(input);

            Console.WriteLine($"The number of valid passphrases are {validCount} and {validLegacyCount} using legacy");
        }
    }
}
