using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{
    
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class InvitedToSquadron : EventBase
    {
        internal InvitedToSquadron() { }

        [JsonProperty("SquadronName")]
        public string Names { get; private set; }
    }

    public partial class InvitedToSquadron
    {
        public static InvitedToSquadron FromJson(string json)
        {
            return JsonConvert.DeserializeObject<InvitedToSquadron>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<InvitedToSquadron> InvitedToSquadron;

        internal void InvokeInvitedToSquadron(InvitedToSquadron arg)
        {
            InvitedToSquadron?.Invoke(this, arg);
        }
    }
}