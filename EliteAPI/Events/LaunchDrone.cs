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
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }
    }

    public partial class LaunchDroneInfo
    {
        public static LaunchDroneInfo Process(string json) => EventHandler.InvokeLaunchDroneEvent(JsonConvert.DeserializeObject<LaunchDroneInfo>(json, EliteAPI.Events.LaunchDroneConverter.Settings));
    }

    public static class LaunchDroneSerializer
    {
        public static string ToJson(this LaunchDroneInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.LaunchDroneConverter.Settings);
    }

    internal static class LaunchDroneConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
