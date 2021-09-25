using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class FileheaderEvent : EventBase<FileheaderEvent>
    {
        internal FileheaderEvent() { }

        [JsonProperty("part")]
        public long Part { get; private set; }

        [JsonProperty("language")]
        public string Language { get; private set; }

        [JsonProperty("gameversion")]
        public string Gameversion { get; private set; }

        [JsonProperty("build")]
        public string Build { get; private set; }

        [JsonProperty("Odyssey")]
        public bool IsOdyssey { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<FileheaderEvent> FileheaderEvent;

        internal void InvokeFileheaderEvent(FileheaderEvent arg)
        {
            FileheaderEvent?.Invoke(this, arg);
        }
    }
}