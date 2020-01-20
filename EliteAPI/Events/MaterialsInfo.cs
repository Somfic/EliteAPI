using System;
using System.Collections.Generic;

namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class MaterialsInfo : IEvent
    {
        internal static MaterialsInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMaterialsEvent(JsonConvert.DeserializeObject<MaterialsInfo>(json, EliteAPI.Events.MaterialsConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Raw")]
        public List<Raw> Raw { get; internal set; }
        [JsonProperty("Manufactured")]
        public List<Encoded> Manufactured { get; internal set; }
        [JsonProperty("Encoded")]
        public List<Encoded> Encoded { get; internal set; }
    }
}
