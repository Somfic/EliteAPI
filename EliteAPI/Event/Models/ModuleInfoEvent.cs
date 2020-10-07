using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class ModuleInfoEvent : EventBase
    {
        internal ModuleInfoEvent() { }

        public static ModuleInfoEvent FromJson(string json) => JsonConvert.DeserializeObject<ModuleInfoEvent>(json);


        
    }
}