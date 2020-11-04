using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class LeaveBodyEvent : EventBase
    {
        internal LeaveBodyEvent() { }

        public static LeaveBodyEvent FromJson(string json) => JsonConvert.DeserializeObject<LeaveBodyEvent>(json);


        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("SystemAddress")]
        public string SystemAddress { get; internal set; }

        [JsonProperty("Body")]
        public string Body { get; internal set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; internal set; }

        
    }
}