using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class AsteroidCrackedEvent : EventBase
    {
        internal AsteroidCrackedEvent() { }

        public static AsteroidCrackedEvent FromJson(string json) => JsonConvert.DeserializeObject<AsteroidCrackedEvent>(json);


        [JsonProperty("Body")]
        public string Body { get; internal set; }


    }
}