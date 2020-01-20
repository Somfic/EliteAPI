using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public partial class Parent
    {
        [JsonProperty("Null")]
        public long Null { get; internal set; }
    }
}