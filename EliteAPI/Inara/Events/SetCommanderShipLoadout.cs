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
        public string ShipType { get; set; }

        [JsonProperty("shipGameID")]
        public long ShipGameId { get; set; }

        [JsonProperty("shipLoadout")]
        public List<InaraShipLoadout> ShipLoadout { get; set; }
    }

    public class InaraShipLoadout
    {
        [JsonProperty("slotName")]
        public string SlotName { get; set; }

        [JsonProperty("itemName")]
        public string ItemName { get; set; }

        [JsonProperty("itemValue")]
        public long ItemValue { get; set; }

        [JsonProperty("itemHealth")]
        public double ItemHealth { get; set; }

        [JsonProperty("isOn")]
        public bool IsOn { get; set; }

        [JsonProperty("isHot")]
        public bool IsHot { get; set; }

        [JsonProperty("itemPriority")]
        public long ItemPriority { get; set; }

        [JsonProperty("itemAmmoClip", NullValueHandling = NullValueHandling.Ignore)]
        public long? ItemAmmoClip { get; set; }

        [JsonProperty("itemAmmoHopper", NullValueHandling = NullValueHandling.Ignore)]
        public long? ItemAmmoHopper { get; set; }

        [JsonProperty("engineering", NullValueHandling = NullValueHandling.Ignore)]
        public InaraLoadoutEngineering Engineering { get; set; }
    }

    public class InaraLoadoutEngineering
    {
        [JsonProperty("blueprintName")]
        public string BlueprintName { get; set; }

        [JsonProperty("blueprintLevel")]
        public long BlueprintLevel { get; set; }

        [JsonProperty("blueprintQuality")]
        public long BlueprintQuality { get; set; }

        [JsonProperty("experimentalEffect")]
        public string ExperimentalEffect { get; set; }

        [JsonProperty("modifiers")]
        public List<InaraModifier> Modifiers { get; set; }
    }

    public class InaraModifier
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public decimal Value { get; set; }

        [JsonProperty("originalValue", NullValueHandling = NullValueHandling.Ignore)]
        public double? OriginalValue { get; set; }

        [JsonProperty("lessIsGood", NullValueHandling = NullValueHandling.Ignore)]
        public bool? LessIsGood { get; set; }
    }
}
