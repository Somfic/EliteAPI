using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class BuyDronesEvent : EventBase
    {
        internal BuyDronesEvent() { }

        [JsonProperty("Type")]
        public string Type { get; private set; }

        [JsonProperty("Count")]
        public long Count { get; private set; }

        [JsonProperty("BuyPrice")]
        public long BuyPrice { get; private set; }

        [JsonProperty("TotalCost")]
        public long TotalCost { get; private set; }
    }

    public partial class BuyDronesEvent
    {
        public static BuyDronesEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<BuyDronesEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<BuyDronesEvent> BuyDronesEvent;

        internal void InvokeBuyDronesEvent(BuyDronesEvent arg)
        {
            BuyDronesEvent?.Invoke(this, arg);
        }
    }
}