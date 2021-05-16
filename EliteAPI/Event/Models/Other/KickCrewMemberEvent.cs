using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class KickCrewMemberEvent : EventBase<KickCrewMemberEvent>
    {
        internal KickCrewMemberEvent() { }

        [JsonProperty("Crew")]
        public string Crew { get; private set; }

        [JsonProperty("OnCrime")]
        public bool IsCrime { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<KickCrewMemberEvent> KickCrewMemberEvent;

        internal void InvokeKickCrewMemberEvent(KickCrewMemberEvent arg)
        {
            KickCrewMemberEvent?.Invoke(this, arg);
        }
    }
}