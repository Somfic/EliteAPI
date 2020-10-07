using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class HeatDamageEvent : EventBase
    {
        internal HeatDamageEvent() { }

        public static HeatDamageEvent FromJson(string json) => JsonConvert.DeserializeObject<HeatDamageEvent>(json);


        
    }
}