using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class SharedBookmarkToSquadronEvent : EventBase<SharedBookmarkToSquadronEvent>
    {
        internal SharedBookmarkToSquadronEvent() { }

        [JsonProperty("SquadronName")]
        public string Name { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<SharedBookmarkToSquadronEvent> SharedBookmarkToSquadronEvent;

        internal void InvokeSharedBookmarkToSquadronEvent(SharedBookmarkToSquadronEvent arg)
        {
            SharedBookmarkToSquadronEvent?.Invoke(this, arg);
        }
    }
}