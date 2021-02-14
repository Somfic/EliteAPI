using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class MusicEvent : EventBase<MusicEvent>
    {
        internal MusicEvent() { }

        [JsonProperty("MusicTrack")]
        public string MusicTrack { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<MusicEvent> MusicEvent;

        internal void InvokeMusicEvent(MusicEvent arg)
        {
            MusicEvent?.Invoke(this, arg);
        }
    }
}