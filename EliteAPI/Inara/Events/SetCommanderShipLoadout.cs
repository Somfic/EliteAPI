using System.Collections.Generic;

using Newtonsoft.Json;

namespace EliteAPI.Inara.Events
{
    public class SetCommanderShipLoadout : IInaraEventData
    {
        public SetCommanderShipLoadout(string shipType, long shipGameId)
        {
            ShipType = shipType;
            ShipGameId = shipGameId;
        }

        [JsonProperty("shipType")]
        public string ShipType { get; internal set; }

        [JsonProperty("shipGameID")]
        public long ShipGameId { get; internal set; }

        [JsonProperty("shipLoadout")]
        public List<InaraShipLoadout> ShipLoadout { get; internal set; }
    }

    public class InaraShipLoadout
    {
        [JsonProperty("slotName")]
        public string SlotName { get; internal set; }

        [JsonProperty("itemName")]
        public string ItemName { get; internal set; }

        [JsonProperty("itemValue")]
        public long ItemValue { get; internal set; }

        [JsonProperty("itemHealth")]
        public double ItemHealth { get; internal set; }

        [JsonProperty("isOn")]
        public bool IsOn { get; internal set; }

        [JsonProperty("isHot")]
        public bool IsHot { get; internal set; }

        [JsonProperty("itemPriority")]
        public long ItemPriority { get; internal set; }

        [JsonProperty("itemAmmoClip", NullValueHandling = NullValueHandling.Ignore)]
        public long? ItemAmmoClip { get; internal set; }

        [JsonProperty("itemAmmoHopper", NullValueHandling = NullValueHandling.Ignore)]
        public long? ItemAmmoHopper { get; internal set; }

        [JsonProperty("engineering", NullValueHandling = NullValueHandling.Ignore)]
        public InaraLoadoutEngineering Engineering { get; internal set; }
    }

    public class InaraLoadoutEngineering
    {
        [JsonProperty("blueprintName")]
        public string BlueprintName { get; internal set; }

        [JsonProperty("blueprintLevel")]
        public long BlueprintLevel { get; internal set; }

        [JsonProperty("blueprintQuality")]
        public long BlueprintQuality { get; internal set; }

        [JsonProperty("experimentalEffect")]
        public string ExperimentalEffect { get; internal set; }

        [JsonProperty("modifiers")]
        public List<InaraModifier> Modifiers { get; internal set; }
    }

    public class InaraModifier
    {
        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("value")]
        public decimal Value { get; internal set; }

        [JsonProperty("originalValue", NullValueHandling = NullValueHandling.Ignore)]
        public double? OriginalValue { get; internal set; }

        [JsonProperty("lessIsGood", NullValueHandling = NullValueHandling.Ignore)]
        public bool? LessIsGood { get; internal set; }
    }
}
