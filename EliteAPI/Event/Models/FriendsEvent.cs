using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class FriendsEvent : EventBase
    {
        internal FriendsEvent() { }
        [JsonProperty("Status")]
        public string Status { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        
    }
}