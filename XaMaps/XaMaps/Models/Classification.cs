using System.Collections.Generic;
using Newtonsoft.Json;

namespace XaMaps.Models
{
    public class Classification
    {
        public string Code { get; set; }

        [JsonProperty("names")]
        public List<NameDetails> Names { get; set; }
    }
}