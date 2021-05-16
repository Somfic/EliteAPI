using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class EndCrewSessionEvent : EventBase<EndCrewSessionEvent>
    {
        internal EndCrewSessionEvent() { }

        [JsonProperty("OnCrime")]
        public bool IsCrime { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<EndCrewSessionEvent> EndCrewSessionEvent;

        internal void InvokeEndCrewSessionEvent(EndCrewSessionEvent arg)
        {
            EndCrewSessionEvent?.Invoke(this, arg);
        }
    }
}