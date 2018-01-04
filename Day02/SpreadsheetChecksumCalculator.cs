using System.Linq;

namespace Day02
{
    public static class SpreadsheetChecksumCalculator
    {
        public static int CheckSum(string[] spreadSheet)
        {
            return spreadSheet.Select(row => row.Split('\t').Select(numberString => int.Parse(numberString))).Sum(x => x.Max() - x.Min());
        }

        public static int Sum(string[] spreadSheet)
        {
            int sum = 0;
            var rows = spreadSheet.Select(row => row.Split('\t').Select(numberString => int.Parse(numberString)));

            foreach(var row in rows)
            {
                sum += SumRow(row.ToArray());
            }

            return sum;
        }

        private static int SumRow(int[] row)
        {
            var halfRow = row.Count() / 2;
            var numbers = row.OrderByDescending(x => x).ToArray();

            for(int leftIndex = 0; leftIndex < halfRow; ++leftIndex)
            {
                for(int rightIndex = 0; rightIndex < halfRow; ++rightIndex)
                {
                    var left = numbers[leftIndex];
                    var right = numbers[rightIndex + halfRow];
                    
                    if(left % right == 0)
                    {
                        return left / right;
                    }
                }
            }

            return 0;
        }
    }
}
