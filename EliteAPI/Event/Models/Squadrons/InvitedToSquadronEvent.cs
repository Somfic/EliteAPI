using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{
    
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class InvitedToSquadronEvent : EventBase
    {
        internal InvitedToSquadronEvent() { }

        [JsonProperty("SquadronName")]
        public string Names { get; private set; }
    }

    public partial class InvitedToSquadronEvent
    {
        public static InvitedToSquadronEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<InvitedToSquadronEvent>(json);
        }
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