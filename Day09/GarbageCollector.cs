using System.Linq;

namespace Day09
{
    public static class GarbageCollector
    {
        public static int GetScore(string input)
        {
            return GroupScore(RemoveGarbage(input));
        }

        public static int GroupScore(string input)
        {
            int mutiplier = 0, score = 0;

            for(var i=0; i<input.Length; i++)
            {
                if(input[i] == '{')
                {
                    mutiplier++;
                    score += mutiplier;
                }

                if(input[i] == '}')
                {
                    mutiplier--;
                }
            }
            
            return score;
        }

        public static int RemovedGarbage(string input)
        {
            var counter = 0;
            while (input.Contains('<'))
            {
                var len = 1;
                var start = input.IndexOf('<');
                while (!IsSelfcontained(input.Substring(start, ++len))) ;

                var garbage = input.Substring(start+1, len-2).Replace("!!", "");
                while(garbage.Contains("!!"))
                    garbage = garbage.Replace("!!", "");
                while(garbage.Contains('!'))
                    garbage = garbage.Remove(garbage.IndexOf('!'), 2);
                counter += garbage.Length;

                input = input.Remove(start, len);
            }

            return counter;
        }

        public static string RemoveGarbage(string input)
        {
            while(input.Contains('<'))
            {
                var len = 1;
                var start = input.IndexOf('<');
                
                while(!IsSelfcontained(input.Substring(start, ++len)));

                input = input.Remove(start, len);
            }

            while(input.Contains(",,"))
                input = input.Replace(",,", ",");

            while (input.Contains("{,}"))
                input = input.Replace("{,}", "{}");

            return input;
        }

        public static bool IsSelfcontained(string input)
        {
            if (input[0] != '<')
                return false;

            while(input.Contains("!!"))
                input = input.Replace("!!", "  ");

            while(input.Contains("!>"))
                input = input.Replace("!>", "  ");

            var end = input.IndexOf('>');

            return end == input.Length - 1;
        }
    }
}
