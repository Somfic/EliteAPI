using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class QuitACrewEvent : EventBase
    {
        internal QuitACrewEvent() { }

        public static QuitACrewEvent FromJson(string json) => JsonConvert.DeserializeObject<QuitACrewEvent>(json);


        [JsonProperty("Captain")]
        public string Captain { get; internal set; }

        
    }
}