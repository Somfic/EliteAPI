using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class Parent
    {
        [JsonProperty("Null")]
        public long Null { get; internal set; }
    }
}