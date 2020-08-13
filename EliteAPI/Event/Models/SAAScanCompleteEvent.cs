using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class SAAScanCompleteEvent : EventBase
    {
        internal SAAScanCompleteEvent() { }
        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("BodyName")]
        public string BodyName { get; internal set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; internal set; }

        [JsonProperty("ProbesUsed")]
        public long ProbesUsed { get; internal set; }

        [JsonProperty("EfficiencyTarget")]
        public long EfficiencyTarget { get; internal set; }

        
    }
}