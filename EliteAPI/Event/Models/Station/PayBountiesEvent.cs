using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class PayBountiesEvent : EventBase<PayBountiesEvent>
    {
        internal PayBountiesEvent() { }

        [JsonProperty("Amount")]
        public long Amount { get; internal set; }

        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("Faction_Localised")]
        public string FactionLocalised { get; internal set; }

        [JsonProperty("ShipID")]
        public string ShipId { get; internal set; }

        [JsonProperty("BrokerPercentage")]
        public double BrokerPercentage { get; internal set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<PayBountiesEvent> PayBountiesEvent;

    }
}