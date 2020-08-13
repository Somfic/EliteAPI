using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class WingJoinEvent : EventBase
    {
        internal WingJoinEvent() { }
        [JsonProperty("Others")]
        public List<string> Others { get; internal set; }

        
    }
}