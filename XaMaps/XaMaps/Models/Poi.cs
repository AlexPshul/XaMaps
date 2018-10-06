using System.Collections.Generic;

namespace XaMaps.Models
{
    public class Poi
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Url { get; set; }
        public List<string> Categories { get; set; }
        public List<Classification> Classifications { get; set; }
    }
}