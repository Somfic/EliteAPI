using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(500, typeof(EventBase))]
    public partial class SharedBookmarkToSquadronEvent : EventBase
    {
        internal SharedBookmarkToSquadronEvent() { }

        [JsonProperty("SquadronName")]
        public string Name { get; private set; }
    }

    public partial class SharedBookmarkToSquadronEvent
    {
        public static SharedBookmarkToSquadronEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SharedBookmarkToSquadronEvent>(json);
        }
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