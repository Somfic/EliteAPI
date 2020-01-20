using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class MusicInfo : IEvent
    {
        internal static MusicInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMusicEvent(JsonConvert.DeserializeObject<MusicInfo>(json, EliteAPI.Events.MusicConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("MusicTrack")]
        public string MusicTrack { get; internal set; }
    }
}
