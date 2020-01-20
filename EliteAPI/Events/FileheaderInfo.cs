using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class FileheaderInfo : IEvent
    {
        internal static FileheaderInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeFileheaderEvent(JsonConvert.DeserializeObject<FileheaderInfo>(json, EliteAPI.Events.FileheaderConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
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
