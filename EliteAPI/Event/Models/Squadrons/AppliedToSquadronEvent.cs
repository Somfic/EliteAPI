using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class AppliedToSquadronEvent : EventBase
    {
        internal AppliedToSquadronEvent() { }

        [JsonProperty("SquadronName")]
        public string Name { get; internal set; }
    }

    public partial class AppliedToSquadronEvent
    {
        public static AppliedToSquadronEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<AppliedToSquadronEvent>(json);
        }
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