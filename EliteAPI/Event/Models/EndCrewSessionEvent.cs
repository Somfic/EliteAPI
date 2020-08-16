using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class EndCrewSessionEvent : EventBase
    {
        internal EndCrewSessionEvent() { }

        public static EndCrewSessionEvent FromJson(string json) => JsonConvert.DeserializeObject<EndCrewSessionEvent>(json);


        [JsonProperty("OnCrime")]
        public bool OnCrime { get; internal set; }

        
    }
}