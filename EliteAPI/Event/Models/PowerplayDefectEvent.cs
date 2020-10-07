using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class PowerplayDefectEvent : EventBase
    {
        internal PowerplayDefectEvent() { }

        public static PowerplayDefectEvent FromJson(string json) => JsonConvert.DeserializeObject<PowerplayDefectEvent>(json);


        [JsonProperty("FromPower")]
        public string FromPower { get; internal set; }

        [JsonProperty("ToPower")]
        public string ToPower { get; internal set; }

        
    }
}