using Newtonsoft.Json;

namespace EliteAPI.Inara.Events
{
    public class InaraShipLoadout
    {
        [JsonProperty("slotName")]
        public string SlotName { get; set; }
        [JsonProperty("itemName")]
        public string ItemName { get; set; }
        [JsonProperty("itemValue")]
        public long ItemValue { get; set; }
        [JsonProperty("itemHealth")]
        public float ItemHealth { get; set; }
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
}