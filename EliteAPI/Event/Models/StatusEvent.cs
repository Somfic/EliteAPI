using System;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class StatusEvent : EventBase
    {
        internal StatusEvent() { }

        public static StatusEvent FromJson(string json) => JsonConvert.DeserializeObject<StatusEvent>(json);

        public StatusEvent(string @event, object value)
        {
            this.Event = @event;
            this.Value = value;
            this.Timestamp = DateTime.Now;
        }

        public dynamic Value { get; set; }
    }
}