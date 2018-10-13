namespace XaMaps.Models
{
    public class InstructionGroup
    {
        public int FirstInstructionIndex { get; set; }
        public int LastInstructionIndex { get; set; }
        public string GroupMessage { get; set; }
        public int GroupLengthInMeters { get; set; }
    }
}