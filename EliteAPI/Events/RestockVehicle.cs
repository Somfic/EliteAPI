namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class RestockVehicleInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Loadout")]
        public string Loadout { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }
    }

    public partial class RestockVehicleInfo
    {
        public static RestockVehicleInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeRestockVehicleEvent(JsonConvert.DeserializeObject<RestockVehicleInfo>(json, EliteAPI.Events.RestockVehicleConverter.Settings));
    }

    public static class RestockVehicleSerializer
    {
        public static string ToJson(this RestockVehicleInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.RestockVehicleConverter.Settings);
    }

    internal static class RestockVehicleConverter
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
