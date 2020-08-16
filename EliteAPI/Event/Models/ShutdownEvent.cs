using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class ShutdownEvent : EventBase
    {
        internal ShutdownEvent() { }

        public static ShutdownEvent FromJson(string json) => JsonConvert.DeserializeObject<ShutdownEvent>(json);


        
    }
}