namespace XaMaps.Models
{
    public class Route
    {
        public DirectionsSummary Summary { get; set; }
        public Leg[] Legs { get; set; }
        public Section[] Sections { get; set; }
    }
}