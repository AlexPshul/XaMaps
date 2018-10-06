namespace XaMaps.Models
{
    public class RouteDirectionsResult
    {
        public string FormatVersion { get; set; }
        public string Copyright { get; set; }
        public string Privacy { get; set; }
        public Route[] Routes { get; set; }
    }
}