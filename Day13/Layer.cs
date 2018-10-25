namespace Day13
{
    public class Layer
    {
        public int ScannerPos { get; set; }
        public int Range { get; set; }
        public bool DirectionIsUp { get; set; }

        public void Tick()
        {
            if (DirectionIsUp)
            {
                ScannerPos--;
            }
            else
            {
                ScannerPos++;
            }

            if (ScannerPos == Range - 1 || ScannerPos == 0)
            {
                this.DirectionIsUp = !this.DirectionIsUp;
            }
        }
    }
}
