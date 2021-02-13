using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class TechnologyBrokerEvent : EventBase
    {
        internal TechnologyBrokerEvent() { }

        [JsonProperty("BrokerType")]
        public string BrokerType { get; internal set; }

        [JsonProperty("MarketID")]
        public string MarketId { get; internal set; }

        [JsonProperty("ItemsUnlocked")]
        public IReadOnlyList<ItemsUnlockedInfo> ItemsUnlocked { get; internal set; }

        [JsonProperty("Commodities")]
        public IReadOnlyList<CommodityInfo> Commodities { get; internal set; }

        [JsonProperty("Materials")] //todo: own class
        public IReadOnlyList<CommodityInfo> Materials { get; internal set; }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class ItemsUnlockedInfo
        {
            internal ItemsUnlockedInfo()
            {
                
            }
            
            [JsonProperty("Name")]
            public string Name { get; internal set; }

            [JsonProperty("Name_Localised")]
            public string NameLocalised { get; internal set; }
        }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class CommodityInfo
        {
            CommodityInfo()
            {
                
            }
            
            [JsonProperty("Name")]
            public string Name { get; internal set; }

            [JsonProperty("Name_Localised")]
            public string NameLocalised { get; internal set; }

            [JsonProperty("Count")]
            public long Count { get; internal set; }

            [JsonProperty("Category", NullValueHandling = NullValueHandling.Ignore)]
            public string Category { get; internal set; }
        }
    }

    public partial class TechnologyBrokerEvent
    {
        public static TechnologyBrokerEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<TechnologyBrokerEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<TechnologyBrokerEvent> TechnologyBrokerEvent;

        internal void InvokeTechnologyBrokerEvent(TechnologyBrokerEvent arg)
        {
            TechnologyBrokerEvent?.Invoke(this, arg);
        }
    }
}