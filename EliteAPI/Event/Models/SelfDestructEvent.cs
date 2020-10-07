using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class SelfDestructEvent : EventBase
    {
        internal SelfDestructEvent() { }

        public static SelfDestructEvent FromJson(string json) => JsonConvert.DeserializeObject<SelfDestructEvent>(json);


        
    }
}