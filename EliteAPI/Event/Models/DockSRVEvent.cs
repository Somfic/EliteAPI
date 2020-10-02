using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class DockSRVEvent : EventBase
    {
        internal DockSRVEvent() { }

        public static DockSRVEvent FromJson(string json) => JsonConvert.DeserializeObject<DockSRVEvent>(json);


        
    }
}