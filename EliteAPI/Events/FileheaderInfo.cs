using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class FileheaderInfo : EventBase
    {
        internal static FileheaderInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeFileheaderEvent(JsonConvert.DeserializeObject<FileheaderInfo>(json, JsonSettings.Settings));

        [JsonProperty("part")]
        public long Part { get; internal set; }
        [JsonProperty("language")]
        public string Language { get; internal set; }
        [JsonProperty("gameversion")]
        public string Gameversion { get; internal set; }
        [JsonProperty("build")]
        public string Build { get; internal set; }
    }
}
