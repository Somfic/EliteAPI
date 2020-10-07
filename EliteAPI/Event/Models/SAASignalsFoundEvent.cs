using System.Collections.Generic;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class SAASignalsFoundEvent : EventBase
    {
        public static SAASignalsFoundEvent FromJson(string json) => JsonConvert.DeserializeObject<SAASignalsFoundEvent>(json);


        [JsonProperty("BodyName")]
        public string BodyName { get; set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; set; }

        [JsonProperty("Signals")]
        public IReadOnlyList<Signal> Signals { get; set; }
    }

    public class Signal
    {
        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Count")]
        public long Count { get; set; }
    }
}
