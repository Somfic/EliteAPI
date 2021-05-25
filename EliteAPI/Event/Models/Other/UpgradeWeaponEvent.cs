using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class UpgradeWeaponEvent : EventBase<UpgradeWeaponEvent>
    {
        internal UpgradeWeaponEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; private set; }

        [JsonProperty("Class")]
        public long Class { get; private set; }

        [JsonProperty("SuitModuleID")]
        public string SuitModuleID { get; private set; }

        [JsonProperty("Cost")]
        public long Cost { get; private set; }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<UpgradeWeaponEvent> UpgradeWeaponEvent;

        internal void InvokeUpgradeWeaponEvent(UpgradeWeaponEvent arg)
        {
            UpgradeWeaponEvent?.Invoke(this, arg);
        }
    }
}