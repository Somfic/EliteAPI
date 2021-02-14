using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class InvitedToSquadronEvent : EventBase<InvitedToSquadronEvent>
    {
        internal InvitedToSquadronEvent() { }

        [JsonProperty("SquadronName")]
        public string Names { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<InvitedToSquadronEvent> InvitedToSquadronEvent;

        internal void InvokeInvitedToSquadronEvent(InvitedToSquadronEvent arg)
        {
            InvitedToSquadronEvent?.Invoke(this, arg);
        }
    }
}