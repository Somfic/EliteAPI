using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class SRVDestroyedEvent : EventBase
    {
        internal SRVDestroyedEvent() { }

        public static SRVDestroyedEvent FromJson(string json) => JsonConvert.DeserializeObject<SRVDestroyedEvent>(json);


        
    }
}