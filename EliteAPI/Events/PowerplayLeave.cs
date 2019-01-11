namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class PowerplayLeaveInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Power")]
        public string Power { get; set; }
    }

    public partial class PowerplayLeaveInfo
    {
        public static PowerplayLeaveInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokePowerplayLeaveEvent(JsonConvert.DeserializeObject<PowerplayLeaveInfo>(json, EliteAPI.Events.PowerplayLeaveConverter.Settings));
    }

    public static class PowerplayLeaveSerializer
    {
        public static string ToJson(this PowerplayLeaveInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.PowerplayLeaveConverter.Settings);
    }

    internal static class PowerplayLeaveConverter
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
