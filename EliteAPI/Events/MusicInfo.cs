using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class MusicInfo : EventBase
    {
        internal static MusicInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMusicEvent(JsonConvert.DeserializeObject<MusicInfo>(json, JsonSettings.Settings));

        [JsonProperty("MusicTrack")]
        public string MusicTrack { get; internal set; }
    }
}
