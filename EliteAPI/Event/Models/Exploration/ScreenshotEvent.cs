using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class ScreenshotEvent : EventBase<ScreenshotEvent>
    {
        internal ScreenshotEvent() { }

        [JsonProperty("Filename")]
        public string Filename { get; private set; }

        [JsonProperty("Width")]
        public long Width { get; private set; }

        [JsonProperty("Height")]
        public long Height { get; private set; }

        [JsonProperty("System")]
        public string System { get; private set; }

        [JsonProperty("Body")]
        public string Body { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ScreenshotEvent> ScreenshotEvent;

        internal void InvokeScreenshotEvent(ScreenshotEvent arg)
        {
            ScreenshotEvent?.Invoke(this, arg);
        }
    }
}