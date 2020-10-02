using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class CockpitBreachedEvent : EventBase
    {
        internal CockpitBreachedEvent() { }

        public static CockpitBreachedEvent FromJson(string json) => JsonConvert.DeserializeObject<CockpitBreachedEvent>(json);


        
    }
}