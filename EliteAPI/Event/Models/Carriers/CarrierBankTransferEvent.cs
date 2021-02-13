using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class CarrierBankTransferEvent : EventBase
    {
        internal CarrierBankTransferEvent() { }

        [JsonProperty("CarrierID")]
        public string CarrierId { get; private set; }

        [JsonProperty("Deposit")]
        public long Deposit { get; private set; }
        
        [JsonProperty("Withdraw")]
        public long Withdraw { get; private set; }

        [JsonProperty("PlayerBalance")]
        public long PlayerBalance { get; private set; }

        [JsonProperty("CarrierBalance")]
        public long CarrierBalance { get; private set; }
    }

    public partial class CarrierBankTransferEvent
    {
        public static CarrierBankTransferEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CarrierBankTransferEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CarrierBankTransferEvent> CarrierBankTransferEvent;

        internal void InvokeCarrierBankTransferEvent(CarrierBankTransferEvent arg)
        {
            CarrierBankTransferEvent?.Invoke(this, arg);
        }
    }
}