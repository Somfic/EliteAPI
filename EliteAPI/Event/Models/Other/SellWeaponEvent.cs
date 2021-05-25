using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class SellWeaponEvent : EventBase<SellWeaponEvent>
    {
        internal SellWeaponEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; private set; }

        [JsonProperty("Price")]
        public long Price { get; private set; }

        [JsonProperty("SuitModuleID")]
        public string SuitModuleID { get; private set; }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<SellWeaponEvent> SellWeaponEvent;

        internal void InvokeSellWeaponEvent(SellWeaponEvent arg)
        {
            SellWeaponEvent?.Invoke(this, arg);
        }
    }
}