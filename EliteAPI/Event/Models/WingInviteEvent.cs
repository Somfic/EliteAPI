using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class WingInviteEvent : EventBase
    {
        internal WingInviteEvent() { }
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        
    }
}