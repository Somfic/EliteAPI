using System.Collections.Generic;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class WingJoinEvent : EventBase
    {
        internal WingJoinEvent() { }

        public static WingJoinEvent FromJson(string json) => JsonConvert.DeserializeObject<WingJoinEvent>(json);


        [JsonProperty("Others")]
        public List<string> Others { get; internal set; }

        
    }
}