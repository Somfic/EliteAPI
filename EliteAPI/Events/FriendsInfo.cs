using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class FriendsInfo : IEvent
    {
        internal static FriendsInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeFriendsEvent(JsonConvert.DeserializeObject<FriendsInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Status")]
        public string Status { get; internal set; }
        [JsonProperty("Name")]
        public string Name { get; internal set; }
    }
}
