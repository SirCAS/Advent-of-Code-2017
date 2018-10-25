namespace Day11
{
    public struct Cube
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public static Cube operator +(Cube a, Cube b)
        {
            return new Cube { X = a.X + b.X, Y = a.Y + b.Y, Z = a.Z + b.Z };
        }
    }
}
