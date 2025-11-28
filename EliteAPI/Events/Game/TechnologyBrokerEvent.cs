using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct TechnologyBrokerEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("BrokerType")]
    public string BrokerType { get; init; }

    [JsonProperty("MarketID")]
    public string MarketId { get; init; }

    [JsonProperty("ItemsUnlocked")]
    public IReadOnlyCollection<ItemsUnlockedInfo> ItemsUnlocked { get; init; }

    [JsonProperty("Commodities")]
    public IReadOnlyCollection<CommodityInfo> Commodities { get; init; }

    [JsonProperty("Materials")] //todo: own readonly struct
    public IReadOnlyCollection<CommodityInfo> Materials { get; init; }


    public readonly struct ItemsUnlockedInfo
    {
        [JsonProperty("Name")]
        public LocalisedField Name { get; init; }
    }


    public readonly struct CommodityInfo
    {
        [JsonProperty("Name")]
        public string Name { get; init; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; init; }

        [JsonProperty("Count")]
        public long Count { get; init; }

        [JsonProperty("Category")]
        public string Category { get; init; }
    }
}
