using System.Linq;

namespace Day02
{
    public static class SpreadsheetChecksumCalculator
    {
        public static double CheckSum(string[] spreadSheet)
        {
            return spreadSheet.Select(row => row.Split('\t').Select(numberString => int.Parse(numberString))).Sum(x => x.Max() - x.Min());
        }
    }
}
