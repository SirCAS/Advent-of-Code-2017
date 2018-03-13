using System;
using System.Linq;

namespace Day04
{
    public static class PassphraseValidator
    {
        public static int CountValidUsingLegacy(string[] input)
        {
            return input.Count(x => IsValid(x, true));
        }

        public static int CountValid(string[] input)
        {
            return input.Count(x => IsValid(x));
        }

        public static bool IsValid(string input, bool useLegacyValidation = false)
        {
            var result = input.Split(' ');

            if(!useLegacyValidation)
            {
                result = result
                            .Select(x => new string(x.OrderBy(y => y).ToArray())) // Order letters in words alpabetic
                            .ToArray();
            }

            return !result.GroupBy(x => x).ToDictionary(x => x, x => x.Count()).Any(x => x.Value > 1);
        }
    }
}