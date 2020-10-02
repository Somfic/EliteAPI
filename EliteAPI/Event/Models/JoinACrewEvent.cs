using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class JoinACrewEvent : EventBase
    {
        internal JoinACrewEvent() { }

        public static JoinACrewEvent FromJson(string json) => JsonConvert.DeserializeObject<JoinACrewEvent>(json);


        [JsonProperty("Captain")]
        public string Captain { get; internal set; }

        
    }
}