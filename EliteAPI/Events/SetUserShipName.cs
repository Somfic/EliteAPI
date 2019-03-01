namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class SetUserShipNameInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Ship")]
        public string Ship { get; internal set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        [JsonProperty("UserShipName")]
        public string UserShipName { get; internal set; }

        [JsonProperty("UserShipId")]
        public string UserShipId { get; internal set; }
    }

    public partial class SetUserShipNameInfo
    {
        public static SetUserShipNameInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSetUserShipNameEvent(JsonConvert.DeserializeObject<SetUserShipNameInfo>(json, EliteAPI.Events.SetUserShipNameConverter.Settings));
    }

    public static class SetUserShipNameSerializer
    {
        public static string ToJson(this SetUserShipNameInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.SetUserShipNameConverter.Settings);
    }

    internal static class SetUserShipNameConverter
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
