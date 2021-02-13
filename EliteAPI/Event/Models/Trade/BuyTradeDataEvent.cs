using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class BuyTradeDataEvent : EventBase
    {
        internal BuyTradeDataEvent() { }

        [JsonProperty("System")]
        public string System { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }
    }

    public partial class BuyTradeDataEvent
    {
        public static BuyTradeDataEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<BuyTradeDataEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<BuyTradeDataEvent> BuyTradeDataEvent;

        internal void InvokeBuyTradeDataEvent(BuyTradeDataEvent arg)
        {
            BuyTradeDataEvent?.Invoke(this, arg);
        }
    }
}