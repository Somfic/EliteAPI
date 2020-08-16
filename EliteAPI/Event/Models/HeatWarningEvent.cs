using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class HeatWarningEvent : EventBase
    {
        internal HeatWarningEvent() { }

        public static HeatWarningEvent FromJson(string json) => JsonConvert.DeserializeObject<HeatWarningEvent>(json);


        
    }
}