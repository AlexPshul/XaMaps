using System.Collections.Generic;

namespace XaMaps.Models
{
    public class SingleFuzzyResult
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public double Score { get; set; }
        public string Info { get; set; }
        public string EntityType { get; set; }
        public Address Address { get; set; }
        public Position Position { get; set; }
        public Viewport Viewport { get; set; }
        public Poi Poi { get; set; }
        public List<EntryPoint> EntryPoints { get; set; }
    }
}