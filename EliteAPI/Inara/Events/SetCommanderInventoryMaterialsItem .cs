using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace EliteAPI.Inara.Events
{
    public class SetCommanderInventoryMaterialsItem : IInaraEventData
    {
        public SetCommanderInventoryMaterialsItem(string itemName, long itemCount)
        {
            ItemName = itemName;
            ItemCount = itemCount;
        }
        [JsonProperty("itemName")]
        public string ItemName { get; internal set; }
        [JsonProperty("itemCount")]
        public long ItemCount { get; internal set; }
    }
}
