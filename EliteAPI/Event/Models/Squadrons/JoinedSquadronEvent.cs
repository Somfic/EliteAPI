using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class JoinedSquadronEvent : EventBase
    {
        internal JoinedSquadronEvent() { }

        [JsonProperty("SquadronName")]
        public string Name { get; internal set; }
    }

    public partial class JoinedSquadronEvent
    {
        public static JoinedSquadronEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<JoinedSquadronEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<JoinedSquadronEvent> JoinedSquadronEvent;

        internal void InvokeJoinedSquadronEvent(JoinedSquadronEvent arg)
        {
            JoinedSquadronEvent?.Invoke(this, arg);
        }
    }
}