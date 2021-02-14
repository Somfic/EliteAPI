using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class CarrierBankTransferEvent : EventBase<CarrierBankTransferEvent>
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

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CarrierBankTransferEvent> CarrierBankTransferEvent;

    }
}