using System;

namespace EliteAPI.Events
{
    public class StatusEvent : EventBase
    {
        public StatusEvent(string @event, object value)
        {
            this.Event = @event;
            this.Value = value;

            this.Timestamp = DateTime.Now;
        }
        public dynamic Value { get; set; }
    }
}