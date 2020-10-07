using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class USSDropEvent : EventBase
    {
        internal USSDropEvent() { }

        public static USSDropEvent FromJson(string json) => JsonConvert.DeserializeObject<USSDropEvent>(json);


        [JsonProperty("USSType")]
        public string UssType { get; internal set; }

        [JsonProperty("USSType_Localised")]
        public string UssTypeLocalised { get; internal set; }

        [JsonProperty("USSThreat")]
        public long UssThreat { get; internal set; }

        
    }
}