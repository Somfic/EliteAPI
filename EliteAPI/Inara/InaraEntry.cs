using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Inara
{
    public class InaraEntry
    {
        public InaraEntry(InaraConfiguration configuration, List<InaraEvent> events)
        {
            Configuration = configuration;
            Events = events;
        }
        [JsonProperty("header")]
        public InaraConfiguration Configuration { get; internal set; }
        [JsonProperty("events")]
        public List<InaraEvent> Events { get; internal set; }
    }
}