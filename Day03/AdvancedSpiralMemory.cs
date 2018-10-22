using System;
using System.Collections.Generic;
using System.Linq;

namespace Day03
{
    public static class AdvancedSpiralMemory
    {
        public static long GetFirstValueAboveTarget(long target)
        {
            long x = 0, y = 0, stepsTaken = 0, stepsNeeded = 1, posValue = 1;
            bool needsNewStep = false;
            Moves direction = Moves.Right;

            IDictionary<(long, long), long> gridData = new Dictionary<(long, long), long>
            {
                { (x, y) , 1 }
            };

            do
            {
                switch(direction)
                {
                    case Moves.Right:
                        ++x;
                    break;
                    case Moves.Up:
                        ++y;
                    break;
                    case Moves.Left:
                        --x;
                    break;
                    case Moves.Down:
                        --y;
                    break;
                }

                ++stepsTaken;

                if(stepsTaken == stepsNeeded)
                {
                    switch(direction)
                    {
                        case Moves.Right: direction = Moves.Up;    break;
                        case Moves.Up:    direction = Moves.Left;  break;
                        case Moves.Left:  direction = Moves.Down;  break;
                        case Moves.Down:  direction = Moves.Right; break;
                    }

                    if(needsNewStep)
                    {
                        ++stepsNeeded;
                        needsNewStep = false;
                    }
                    else
                    {
                        needsNewStep = true;
                    }

                    stepsTaken = 0;
                }

                posValue = new List<long>
                {
                    Get(gridData, x,   y-1),
                    Get(gridData, x-1, y),
                    Get(gridData, x,   y+1),
                    Get(gridData, x+1, y),
                    Get(gridData, x+1, y-1),
                    Get(gridData, x-1, y+1),
                    Get(gridData, x+1, y+1),
                    Get(gridData, x-1, y-1),
                }
                .Sum();

                if(target < posValue)
                    return posValue;

                gridData.Add((x,y), posValue);

            } while(posValue < target);

            return posValue;
        }

        private static Func<IDictionary<(long,long), long>, long, long, long> Get = (dic, x, y) =>
        {
            long value;
            if(dic.TryGetValue((x, y), out value))
            {
                return value;
            }

            return 0;
        };

        private enum Moves {
            Right, Up, Left, Down
        }
    }
}