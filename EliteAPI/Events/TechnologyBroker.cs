namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class TechnologyBrokerInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("BrokerType")]
        public string BrokerType { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("ItemsUnlocked")]
        public List<ItemsUnlocked> ItemsUnlocked { get; internal set; }

        [JsonProperty("Commodities")]
        public List<Commodity> Commodities { get; internal set; }

        [JsonProperty("Materials")]
        public List<Commodity> Materials { get; internal set; }
    }

    public partial class Commodity
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        [JsonProperty("Category", NullValueHandling = NullValueHandling.Ignore)]
        public string Category { get; internal set; }
    }

    public partial class ItemsUnlocked
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }
    }

    public partial class TechnologyBrokerInfo
    {
        public static TechnologyBrokerInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeTechnologyBrokerEvent(JsonConvert.DeserializeObject<TechnologyBrokerInfo>(json, EliteAPI.Events.TechnologyBrokerConverter.Settings));
    }

    public static class TechnologyBrokerSerializer
    {
        public static string ToJson(this TechnologyBrokerInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.TechnologyBrokerConverter.Settings);
    }

    internal static class TechnologyBrokerConverter
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
