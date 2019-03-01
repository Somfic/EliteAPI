namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class LaunchDroneInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Type")]
        public string Type { get; internal set; }
    }

    public partial class LaunchDroneInfo
    {
        public static LaunchDroneInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeLaunchDroneEvent(JsonConvert.DeserializeObject<LaunchDroneInfo>(json, EliteAPI.Events.LaunchDroneConverter.Settings));
    }

    public static class LaunchDroneSerializer
    {
        public static string ToJson(this LaunchDroneInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.LaunchDroneConverter.Settings);
    }

    internal static class LaunchDroneConverter
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
