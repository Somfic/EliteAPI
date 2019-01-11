namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CargoInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Vessel")]
        public string Vessel { get; set; }

        [JsonProperty("Count")]
        public long Count { get; set; }

        [JsonProperty("Inventory")]
        public List<Inventory> Inventory { get; set; }
    }

    public partial class Inventory
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Name_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string NameLocalised { get; set; }

        [JsonProperty("Count")]
        public long Count { get; set; }

        [JsonProperty("Stolen")]
        public long Stolen { get; set; }
    }

    public partial class CargoInfo
    {
        public static CargoInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeCargoEvent(JsonConvert.DeserializeObject<CargoInfo>(json, EliteAPI.Events.CargoConverter.Settings));
    }

    public static class CargoSerializer
    {
        public static string ToJson(this CargoInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.CargoConverter.Settings);
    }

    internal static class CargoConverter
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
