using System;

namespace EliteAPI.Event.Models
{
    public class StatusEvent : EventBase
    {
        internal StatusEvent() { }

        public StatusEvent(string @event, object value)
        {
            this.Event = @event;
            this.Value = value;
            this.Timestamp = DateTime.Now;
        }

        public dynamic Value { get; set; }
    }
}