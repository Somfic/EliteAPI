using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class ApproachBodyEvent : EventBase
    {
        internal ApproachBodyEvent() { }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; private set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; private set; }

        [JsonProperty("Body")]
        public string Body { get; private set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; private set; }
    }

    public partial class ApproachBodyEvent
    {
        public static ApproachBodyEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ApproachBodyEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<ApproachBodyEvent> ApproachBodyEvent;

        internal void InvokeApproachBodyEvent(ApproachBodyEvent arg)
        {
            ApproachBodyEvent?.Invoke(this, arg);
        }
    }
}