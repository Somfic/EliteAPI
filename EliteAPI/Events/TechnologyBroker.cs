namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class TechnologyBrokerInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("BrokerType")]
        public string BrokerType { get; set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; set; }

        [JsonProperty("ItemsUnlocked")]
        public List<ItemsUnlocked> ItemsUnlocked { get; set; }

        [JsonProperty("Commodities")]
        public List<Commodity> Commodities { get; set; }

        [JsonProperty("Materials")]
        public List<Commodity> Materials { get; set; }
    }

    public partial class Commodity
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; set; }

        [JsonProperty("Count")]
        public long Count { get; set; }

        [JsonProperty("Category", NullValueHandling = NullValueHandling.Ignore)]
        public string Category { get; set; }
    }

    public partial class ItemsUnlocked
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; set; }
    }

    public partial class TechnologyBrokerInfo
    {
        public static TechnologyBrokerInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeTechnologyBrokerEvent(JsonConvert.DeserializeObject<TechnologyBrokerInfo>(json, EliteAPI.Events.TechnologyBrokerConverter.Settings));
    }

    public static class TechnologyBrokerSerializer
    {
        public static string ToJson(this TechnologyBrokerInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.TechnologyBrokerConverter.Settings);
    }

    internal static class TechnologyBrokerConverter
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
