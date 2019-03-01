namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class VehicleSwitchInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("To")]
        public string To { get; internal set; }
    }

    public partial class VehicleSwitchInfo
    {
        public static VehicleSwitchInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeVehicleSwitchEvent(JsonConvert.DeserializeObject<VehicleSwitchInfo>(json, EliteAPI.Events.VehicleSwitchConverter.Settings));
    }

    public static class VehicleSwitchSerializer
    {
        public static string ToJson(this VehicleSwitchInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.VehicleSwitchConverter.Settings);
    }

    internal static class VehicleSwitchConverter
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
