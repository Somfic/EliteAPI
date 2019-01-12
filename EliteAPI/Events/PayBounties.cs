namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class PayBountiesInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Amount")]
        public long Amount { get; set; }

        [JsonProperty("Faction")]
        public string Faction { get; set; }

        [JsonProperty("Faction_Localised")]
        public string FactionLocalised { get; set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; set; }

        [JsonProperty("BrokerPercentage")]
        public double BrokerPercentage { get; set; }
    }

    public partial class PayBountiesInfo
    {
        public static PayBountiesInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePayBountiesEvent(JsonConvert.DeserializeObject<PayBountiesInfo>(json, EliteAPI.Events.PayBountiesConverter.Settings));
    }

    public static class PayBountiesSerializer
    {
        public static string ToJson(this PayBountiesInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.PayBountiesConverter.Settings);
    }

    internal static class PayBountiesConverter
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
