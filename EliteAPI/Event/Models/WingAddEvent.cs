using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class WingAddEvent : EventBase
    {
        internal WingAddEvent() { }

        public static WingAddEvent FromJson(string json) => JsonConvert.DeserializeObject<WingAddEvent>(json);


        [JsonProperty("Name")]
        public string Name { get; internal set; }

        
    }
}