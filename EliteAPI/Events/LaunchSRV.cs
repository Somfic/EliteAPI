namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class LaunchSRVInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Loadout")]
        public string Loadout { get; set; }

        [JsonProperty("PlayerControlled")]
        public bool PlayerControlled { get; set; }
    }

    public partial class LaunchSRVInfo
    {
        public static LaunchSRVInfo Process(string json) => EventHandler.InvokeLaunchSRVEvent(JsonConvert.DeserializeObject<LaunchSRVInfo>(json, EliteAPI.Events.LaunchSRVConverter.Settings));
    }

    public static class LaunchSRVSerializer
    {
        public static string ToJson(this LaunchSRVInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.LaunchSRVConverter.Settings);
    }

    internal static class LaunchSRVConverter
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
