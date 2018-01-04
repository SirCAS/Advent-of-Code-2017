namespace Day01
{
    public static class CaptchaSummer
    {
        public static double Sum(string input)
        {
            double sum = 0;

            if(input[0] == input[input.Length - 1])
            {
                sum += char.GetNumericValue(input[0]);
            }

            for(int x = 0; x < input.Length - 1; ++x)
            {
                if(input[x] == input[x+1])
                {
                    sum += char.GetNumericValue(input[x]);
                }
            }

            return sum;
        }

        public static double SumHalfway(string input)
        {
            double sum = 0;
            int steps = input.Length / 2;

            for(int x = 0; x < input.Length - steps; ++x)
            {
                var left = char.GetNumericValue(input[x]);
                var right = char.GetNumericValue(input[x + steps]);

                if(left == right)
                {
                    sum += left + right;
                }
            }

            return sum;
        }
    }
}
