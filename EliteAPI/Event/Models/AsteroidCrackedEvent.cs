using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class AsteroidCrackedEvent : EventBase
    {
        internal AsteroidCrackedEvent() { }
        [JsonProperty("Body")]
        public string Body { get; internal set; }


    }
}