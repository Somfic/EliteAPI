using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class EngineerContributionEvent : EventBase<EngineerContributionEvent>
    {
        internal EngineerContributionEvent() { }

        [JsonProperty("Engineer")]
        public string Engineer { get; internal set; }

        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Material")]
        public string Material { get; internal set; }

        [JsonProperty("Quantity")]
        public long Quantity { get; internal set; }

        [JsonProperty("TotalQuantity")]
        public long TotalQuantity { get; internal set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<EngineerContributionEvent> EngineerContributionEvent;

    }
}