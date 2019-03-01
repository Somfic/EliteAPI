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
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Vessel")]
        public string Vessel { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        [JsonProperty("Inventory")]
        public List<Inventory> Inventory { get; internal set; }
    }

    public partial class Inventory
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string NameLocalised { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        [JsonProperty("Stolen")]
        public long Stolen { get; internal set; }
    }

    public partial class CargoInfo
    {
        public static CargoInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCargoEvent(JsonConvert.DeserializeObject<CargoInfo>(json, EliteAPI.Events.CargoConverter.Settings));
    }

    public static class CargoSerializer
    {
        public static string ToJson(this CargoInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.CargoConverter.Settings);
    }

    internal static class CargoConverter
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
