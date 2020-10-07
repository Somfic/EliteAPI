using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class WingInviteEvent : EventBase
    {
        internal WingInviteEvent() { }

        public static WingInviteEvent FromJson(string json) => JsonConvert.DeserializeObject<WingInviteEvent>(json);


        [JsonProperty("Name")]
        public string Name { get; internal set; }

        
    }
}