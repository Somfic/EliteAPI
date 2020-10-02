using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class SAAScanCompleteEvent : EventBase
    {
        internal SAAScanCompleteEvent() { }

        public static SAAScanCompleteEvent FromJson(string json) => JsonConvert.DeserializeObject<SAAScanCompleteEvent>(json);


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