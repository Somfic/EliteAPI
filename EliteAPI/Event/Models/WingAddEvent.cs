using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class WingAddEvent : EventBase
    {
        internal WingAddEvent() { }
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        
    }
}