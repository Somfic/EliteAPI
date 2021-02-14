using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class NpcCrewPaidWageEvent : EventBase<NpcCrewPaidWageEvent>
    {
        internal NpcCrewPaidWageEvent() { }

        [JsonProperty("NpcCrewName")]
        public string NpcCrewName { get; private set; }

        [JsonProperty("NpcCrewId")]
        public string NpcCrewId { get; private set; }

        [JsonProperty("Amount")]
        public long Amount { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<NpcCrewPaidWageEvent> NpcCrewPaidWageEvent;

        internal void InvokeNpcCrewPaidWageEvent(NpcCrewPaidWageEvent arg)
        {
            NpcCrewPaidWageEvent?.Invoke(this, arg);
        }
    }
}