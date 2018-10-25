using System;
using System.Collections.Generic;

namespace Day11
{
    public static class HexGrid
    {
        private static IDictionary<string, Cube> directionLookup = new Dictionary<string, Cube>
        {
            {"n",  new Cube { X=0,  Y=1,  Z=-1 }},
            {"ne", new Cube { X=-1, Y=1,  Z=0 }},
            {"se", new Cube { X=-1, Y=0,  Z=1 }},
            {"s",  new Cube { X=0,  Y=-1, Z=1 }},
            {"sw", new Cube { X=1,  Y=-1, Z=0 }},
            {"nw", new Cube { X=1,  Y=0,  Z=-1 }},
        };

        public static Cube Move(Cube start, string direction)
        {
            return start + directionLookup[direction];
        }

        public static int Distance(Cube a, Cube b)
        {
            return (Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y) + Math.Abs(a.Z - b.Z)) / 2;
        }
    }
}
