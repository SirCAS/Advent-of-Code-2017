using System;
using System.Linq;

namespace Day03
{
    public static class SpiralMemory
    {
        public enum Moves {
            Right, Up, Left, Down
        }

        public static long GetSteps(long position)
        {
            long currentPosition = 1;

            long x = 0;
            long y = 0;

            
            long stepsTaken = 0;
            long stepsNeeded = 1;

            bool needsNewStep = false;

            var direction = Moves.Right;

            while(currentPosition < position)
            {
                ++currentPosition;

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
                    } else {
                        needsNewStep = true;
                    }

                    stepsTaken = 0;
                }
            }

            return Math.Abs(x) + Math.Abs(y);
        }

        // Right, Up, Left, Down
        /*1, 1, 2, 2
        3, 3, 4, 4
        5, 5, 6, 6
        7, 7, 8, 8*/
    }
}


// 25 => 5x5
// 9 => 3x3