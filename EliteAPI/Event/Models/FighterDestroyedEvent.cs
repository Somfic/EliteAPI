using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class FighterDestroyedEvent : EventBase
    {
        internal FighterDestroyedEvent() { }

        public static FighterDestroyedEvent FromJson(string json) => JsonConvert.DeserializeObject<FighterDestroyedEvent>(json);


        
    }
}