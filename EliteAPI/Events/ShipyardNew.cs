namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ShipyardNewInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("ShipType")]
        public string ShipType { get; internal set; }

        [JsonProperty("ShipType_Localised")]
        public string ShipTypeLocalised { get; internal set; }

        [JsonProperty("NewShipID")]
        public long NewShipId { get; internal set; }
    }

    public partial class ShipyardNewInfo
    {
        public static ShipyardNewInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeShipyardNewEvent(JsonConvert.DeserializeObject<ShipyardNewInfo>(json, EliteAPI.Events.ShipyardNewConverter.Settings));
    }

    public static class ShipyardNewSerializer
    {
        public static string ToJson(this ShipyardNewInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ShipyardNewConverter.Settings);
    }

    internal static class ShipyardNewConverter
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
