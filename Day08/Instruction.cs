namespace Day08
{
    public class Instruction
    {
        public string Register { get; set; }
        public string Cmd { get; set; }
        public int Value { get; set; }
        public Condition Condition { get; set; }
    }
}
