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
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("FID")]
        public string Fid { get; set; }

        [JsonProperty("Commander")]
        public string Commander { get; set; }

        [JsonProperty("Horizons")]
        public bool Horizons { get; set; }

        [JsonProperty("Ship")]
        public string Ship { get; set; }

        [JsonProperty("Ship_Localised")]
        public string ShipLocalised { get; set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; set; }

        [JsonProperty("ShipName")]
        public string ShipName { get; set; }

        [JsonProperty("ShipIdent")]
        public string ShipIdent { get; set; }

        [JsonProperty("FuelLevel")]
        public double FuelLevel { get; set; }

        [JsonProperty("FuelCapacity")]
        public double FuelCapacity { get; set; }

        [JsonProperty("GameMode")]
        public string GameMode { get; set; }

        [JsonProperty("Group")]
        public string Group { get; set; }

        [JsonProperty("Credits")]
        public long Credits { get; set; }

        [JsonProperty("Loan")]
        public long Loan { get; set; }
    }

    public partial class LoadGameInfo
    {
        public static LoadGameInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeLoadGameEvent(JsonConvert.DeserializeObject<LoadGameInfo>(json, EliteAPI.Events.LoadGameConverter.Settings));
    }

    public static class LoadGameSerializer
    {
        public static string ToJson(this LoadGameInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.LoadGameConverter.Settings);
    }

    internal static class LoadGameConverter
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
