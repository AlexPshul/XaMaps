namespace XaMaps.Models
{
    public class Instruction
    {
        public int RouteOffsetInMeters { get; set; }
        public int TravelTimeInSeconds { get; set; }
        public Point Point { get; set; }
        public string InstructionType { get; set; }
        public string Street { get; set; }
        public bool PossibleCombineWithNext { get; set; }
        public string DrivingSide { get; set; }
        public string Maneuver { get; set; }
        public string Message { get; set; }
        public string JunctionType { get; set; }
        public int? TurnAngleInDecimalDegrees { get; set; }
    }
}