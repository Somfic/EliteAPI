namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class LoadGameInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("FID")]
        public string Fid { get; internal set; }

        [JsonProperty("Commander")]
        public string Commander { get; internal set; }

        [JsonProperty("Horizons")]
        public bool Horizons { get; internal set; }

        [JsonProperty("Ship")]
        public string Ship { get; internal set; }

        [JsonProperty("Ship_Localised")]
        public string ShipLocalised { get; internal set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        [JsonProperty("ShipName")]
        public string ShipName { get; internal set; }

        [JsonProperty("ShipIdent")]
        public string ShipIdent { get; internal set; }

        [JsonProperty("FuelLevel")]
        public double FuelLevel { get; internal set; }

        [JsonProperty("FuelCapacity")]
        public double FuelCapacity { get; internal set; }

        [JsonProperty("GameMode")]
        public string GameMode { get; internal set; }

        [JsonProperty("Group")]
        public string Group { get; internal set; }

        [JsonProperty("Credits")]
        public long Credits { get; internal set; }

        [JsonProperty("Loan")]
        public long Loan { get; internal set; }
    }

    public partial class LoadGameInfo
    {
        public static LoadGameInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeLoadGameEvent(JsonConvert.DeserializeObject<LoadGameInfo>(json, EliteAPI.Events.LoadGameConverter.Settings));
    }

    public static class LoadGameSerializer
    {
        public static string ToJson(this LoadGameInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.LoadGameConverter.Settings);
    }

    internal static class LoadGameConverter
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
