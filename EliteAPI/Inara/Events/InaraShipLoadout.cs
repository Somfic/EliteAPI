using Newtonsoft.Json;

namespace EliteAPI.Inara.Events
{
    public class InaraShipLoadout
    {
        [JsonProperty("slotName")]
        public string SlotName { get; internal set; }
        [JsonProperty("itemName")]
        public string ItemName { get; internal set; }
        [JsonProperty("itemValue")]
        public long ItemValue { get; internal set; }
        [JsonProperty("itemHealth")]
        public float ItemHealth { get; internal set; }
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
}