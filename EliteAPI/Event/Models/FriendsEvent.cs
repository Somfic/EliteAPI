using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class FriendsEvent : EventBase
    {
        internal FriendsEvent() { }

        public static FriendsEvent FromJson(string json) => JsonConvert.DeserializeObject<FriendsEvent>(json);


        [JsonProperty("Status")]
        public string Status { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        
    }
}