using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class SwitchSuitLoadoutEvent : EventBase<SwitchSuitLoadoutEvent>
    {
        internal SwitchSuitLoadoutEvent() { }

        [JsonProperty("SuitID")]
        public string SuitId { get; private set; }

        [JsonProperty("SuitName")]
        public string SuitName { get; private set; }

        [JsonProperty("SuitName_Localised")]
        public string SuitNameLocalised{ get; private set; }

        [JsonProperty("LoadoutID")]
        public string LoadoutId { get; private set; }

        [JsonProperty("LoadoutName")]
        public string LoadoutName { get; private set; }

        [JsonProperty("Modules")]
        public IReadOnlyList<SuitLoadoutEvent.LoadoutModuleInfo> Modules { get; private set; }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<SwitchSuitLoadoutEvent> SwitchSuitLoadoutEvent;

        internal void InvokeSwitchSuitLoadoutEvent(SwitchSuitLoadoutEvent arg)
        {
            SwitchSuitLoadoutEvent?.Invoke(this, arg);
        }
    }
}