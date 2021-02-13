using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public partial class SaaScanCompleteEvent : EventBase
    {
        internal SaaScanCompleteEvent() { }

        [JsonProperty("BodyName")]
        public string BodyName { get; private set; }
        
        [JsonProperty("SystemAddress")]
        public string SystemAddress { get; private set; }

        [JsonProperty("BodyID")]
        public string BodyId { get; private set; }

        [JsonProperty("ProbesUsed")]
        public long ProbesUsed { get; private set; }

        [JsonProperty("EfficiencyTarget")]
        public long EfficiencyTarget { get; private set; }
    }

    public partial class SaaScanCompleteEvent
    {
        public static SaaScanCompleteEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SaaScanCompleteEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<SaaScanCompleteEvent> SaaScanCompleteEvent;

        internal void InvokeSaaScanCompleteEvent(SaaScanCompleteEvent arg)
        {
            SaaScanCompleteEvent?.Invoke(this, arg);
        }
    }
}