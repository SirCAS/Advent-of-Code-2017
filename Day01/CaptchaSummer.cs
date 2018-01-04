namespace Day01
{
    public static class CaptchaSummer
    {
        public static int Sum(string input)
        {
            int sum = 0;

            if(input[0] == input[input.Length - 1])
            {
                sum += int.Parse(input[0].ToString());
            }

            for(int x = 0; x < input.Length - 1; ++x)
            {
                if(input[x] == input[x+1])
                {
                    sum += int.Parse(input[x].ToString());
                }
            }

            return sum;
        }
    }
}
