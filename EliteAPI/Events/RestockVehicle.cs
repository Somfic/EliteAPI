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
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Loadout")]
        public string Loadout { get; set; }

        [JsonProperty("Cost")]
        public long Cost { get; set; }

        [JsonProperty("Count")]
        public long Count { get; set; }
    }

    public partial class RestockVehicleInfo
    {
        public static RestockVehicleInfo Process(string json) => EventHandler.InvokeRestockVehicleEvent(JsonConvert.DeserializeObject<RestockVehicleInfo>(json, EliteAPI.Events.RestockVehicleConverter.Settings));
    }

    public static class RestockVehicleSerializer
    {
        public static string ToJson(this RestockVehicleInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.RestockVehicleConverter.Settings);
    }

    internal static class RestockVehicleConverter
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
