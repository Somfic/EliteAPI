using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class KickedFromSquadronEvent : EventBase<KickedFromSquadronEvent>
    {
        internal KickedFromSquadronEvent() { }

        [JsonProperty("SquadronName")]
        public string Name { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<KickedFromSquadronEvent> KickedFromSquadronEvent;

    }
}