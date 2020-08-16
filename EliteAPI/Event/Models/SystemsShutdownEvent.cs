using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class SystemsShutdownEvent : EventBase
    {
        internal SystemsShutdownEvent() { }

        public static SystemsShutdownEvent FromJson(string json) => JsonConvert.DeserializeObject<SystemsShutdownEvent>(json);


        
    }
}