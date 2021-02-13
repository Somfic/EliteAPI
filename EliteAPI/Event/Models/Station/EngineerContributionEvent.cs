using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class EngineerContributionEvent : EventBase
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

    public partial class EngineerContributionEvent
    {
        public static EngineerContributionEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<EngineerContributionEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<EngineerContributionEvent> EngineerContributionEvent;

        internal void InvokeEngineerContributionEvent(EngineerContributionEvent arg)
        {
            EngineerContributionEvent?.Invoke(this, arg);
        }
    }
}