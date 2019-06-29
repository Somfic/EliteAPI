namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class PayBountiesInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Amount")]
        public long Amount { get; internal set; }

        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("Faction_Localised")]
        public string FactionLocalised { get; internal set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        [JsonProperty("BrokerPercentage")]
        public double BrokerPercentage { get; internal set; }
    }

    public partial class PayBountiesInfo
    {
        public static PayBountiesInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePayBountiesEvent(JsonConvert.DeserializeObject<PayBountiesInfo>(json, EliteAPI.Events.PayBountiesConverter.Settings));
    }

    

    internal static class PayBountiesConverter
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
