using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class AppliedToSquadronEvent : EventBase<AppliedToSquadronEvent>
    {
        internal AppliedToSquadronEvent() { }

        [JsonProperty("SquadronName")]
        public string Name { get; internal set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<AppliedToSquadronEvent> AppliedToSquadronEvent;

        internal void InvokeAppliedToSquadronEvent(AppliedToSquadronEvent arg)
        {
            AppliedToSquadronEvent?.Invoke(this, arg);
        }
    }
}