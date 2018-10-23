using System.Collections.Generic;
using System.Linq;

namespace Day06
{
    public class CircleMemory
    {
        HashSet<string> seen = new HashSet<string>();

        private IDictionary<int, int> memory;

        public CircleMemory(IList<int> initialMemory)
        {
            this.memory = initialMemory.Select((val, i) => (i, val)).ToDictionary(x => x.Item1, x=> x.Item2);
        }

        public (int, int) FindCollisions()
        {
            int firstCollisionCycles = 0, secondCollisionCycle = 0;
            string state;

            do
            {
                state = Redistribute();
                ++firstCollisionCycles;
            }
            while(seen.Add(state));

            string targetState = state;
            do
            {
                state = Redistribute();
                ++secondCollisionCycle;
            }
            while(state != targetState);


            return (firstCollisionCycles, secondCollisionCycle);
        }

        public string Redistribute()
        {
            var maxValue = memory.Max(x => x.Value);

            var start = memory.OrderBy(x => x.Value).First(x => x.Value == maxValue);

            // Clear memory bank for redistribution
            memory[start.Key] = 0;

            var spend = 0;
            var index = start.Key;
            
            while(maxValue > spend)
            {
                if(memory.Count <= index +1)
                {
                    index = 0;
                } else {
                    ++index;
                }

                ++memory[index];
                ++spend;
            }

            return string.Join(',', memory.OrderBy(x => x.Key).Select(x => x.Value));
        }

    }

}
