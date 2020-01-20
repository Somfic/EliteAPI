using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class FriendsInfo : EventBase
    {
        internal static FriendsInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeFriendsEvent(JsonConvert.DeserializeObject<FriendsInfo>(json, JsonSettings.Settings));

        [JsonProperty("Status")]
        public string Status { get; internal set; }
        [JsonProperty("Name")]
        public string Name { get; internal set; }
    }
}
