using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class BuyExplorationDataEvent : EventBase<BuyExplorationDataEvent>
    {
        internal BuyExplorationDataEvent() { }

        [JsonProperty("System")]
        public string System { get; private set; }

        [JsonProperty("Cost")]
        public long Cost { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<BuyExplorationDataEvent> BuyExplorationDataEvent;

        internal void InvokeBuyExplorationDataEvent(BuyExplorationDataEvent arg)
        {
            BuyExplorationDataEvent?.Invoke(this, arg);
        }
    }
}