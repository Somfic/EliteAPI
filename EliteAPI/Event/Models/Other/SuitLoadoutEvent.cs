using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class SuitLoadoutEvent : EventBase<SuitLoadoutEvent>
    {
        internal SuitLoadoutEvent() { }

        [JsonProperty("SuitID")]
        public string SuitId { get; private set; }

        [JsonProperty("SuitName")]
        public string SuitName { get; private set; }

        [JsonProperty("SuitName_Localised")]
        public string SuitNameLocalised { get; private set; }

        [JsonProperty("LoadoutID")]
        public string LoadoutId { get; private set; }

        [JsonProperty("LoadoutName")]
        public string LoadoutName { get; private set; }

        [JsonProperty("Modules")]
        public IReadOnlyList<LoadoutModuleInfo> Modules { get; private set; }

        [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
        public class LoadoutModuleInfo
        {
            internal LoadoutModuleInfo() { }

            [JsonProperty("SlotName")]
            public string SlotName { get; private set; }

            [JsonProperty("SuitModuleID")]
            public string SuitModuleId { get; private set; }

            [JsonProperty("ModuleName")]
            public string ModuleName { get; private set; }

            [JsonProperty("ModuleName_Localised")]
            public string ModuleNameLocalised { get; private set; }
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<SuitLoadoutEvent> SuitLoadoutEvent;

        internal void InvokeSuitLoadoutEvent(SuitLoadoutEvent arg)
        {
            SuitLoadoutEvent?.Invoke(this, arg);
        }
    }
}