
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class UssDropEvent : EventBase
    {
        internal UssDropEvent() { }

        [JsonProperty("USSType")]
        public string UssType { get; private set; }

        [JsonProperty("USSType_Localised")]
        public string UssTypeLocalised { get; private set; }

        [JsonProperty("USSThreat")]
        public long UssThreat { get; private set; }
    }

    public partial class UssDropEvent
    {
        public static UssDropEvent FromJson(string json) => JsonConvert.DeserializeObject<UssDropEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<UssDropEvent> UssDropEvent;
        internal void InvokeUssDropEvent(UssDropEvent arg) => UssDropEvent?.Invoke(this, arg);
    }
}
