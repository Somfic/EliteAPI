namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class StartJumpInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("JumpType")]
        public string JumpType { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("StarClass")]
        public string StarClass { get; internal set; }
    }

    public partial class StartJumpInfo
    {
        public static StartJumpInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeStartJumpEvent(JsonConvert.DeserializeObject<StartJumpInfo>(json, EliteAPI.Events.StartJumpConverter.Settings));
    }

    public static class StartJumpSerializer
    {
        public static string ToJson(this StartJumpInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.StartJumpConverter.Settings);
    }

    internal static class StartJumpConverter
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
