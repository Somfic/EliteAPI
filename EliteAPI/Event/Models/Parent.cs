using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class Parent
    {
        [JsonProperty("Null")]
        public long Null { get; internal set; }
    }
}