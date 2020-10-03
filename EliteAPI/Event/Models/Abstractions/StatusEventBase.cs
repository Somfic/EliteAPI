using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models.Abstractions
{
    public abstract class StatusEventBase<T> : EventBase
    {
        [JsonProperty("Value")]
        public T Value { get; private set; }
    }

}
