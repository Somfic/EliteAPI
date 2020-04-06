using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace EliteAPI.Inara.Events
{
    public class DelCommanderInventoryMaterialsItem : IInaraEventData
    {
        public DelCommanderInventoryMaterialsItem(string itemName, long itemCount)
        {
            ItemName = itemName;
            ItemCount = itemCount;
        }
        [JsonProperty("itemName")]
        public string ItemName { get; set; }
        [JsonProperty("itemCount")]
        public long ItemCount { get; set; }
    }
}
