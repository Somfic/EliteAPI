using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class KickCrewMemberEvent : EventBase
    {
        internal KickCrewMemberEvent() { }

        [JsonProperty("Crew")]
        public string Crew { get; private set; }

        [JsonProperty("OnCrime")]
        public bool OnCrime { get; private set; }
    }

    public partial class KickCrewMemberEvent
    {
        public static KickCrewMemberEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<KickCrewMemberEvent>(json);
        }
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