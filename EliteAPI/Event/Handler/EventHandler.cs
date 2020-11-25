using System;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<EventBase> AllEvent;

        internal void InvokeAllEvent(EventBase arg)
        {
            AllEvent?.Invoke(this, arg);
        }
    }
}