using System.Collections.Generic;
using Newtonsoft.Json;

namespace XaMaps.Models
{
    public class FuzzyResults
    {
        [JsonProperty("summary")]
        public FuzzySearchSummary Summary { get; set; }

        [JsonProperty("results")]
        public List<SingleFuzzyResult> Results { get; set; }
    }
}