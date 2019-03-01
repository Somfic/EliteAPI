namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class MusicInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("MusicTrack")]
        public string MusicTrack { get; internal set; }
    }

    public partial class MusicInfo
    {
        public static MusicInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMusicEvent(JsonConvert.DeserializeObject<MusicInfo>(json, EliteAPI.Events.MusicConverter.Settings));
    }

    public static class MusicSerializer
    {
        public static string ToJson(this MusicInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.MusicConverter.Settings);
    }

    internal static class MusicConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MissingMemberHandling = MissingMemberHandling.Ignore, MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
