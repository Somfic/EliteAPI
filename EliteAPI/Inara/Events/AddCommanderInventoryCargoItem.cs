using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EliteAPI.Inara.Events
{
    public class AddCommanderInventoryCargoItem : IInaraEventData
    {
        public AddCommanderInventoryCargoItem(string itemName, int itemCount)
        {
            ItemName = itemName;
            ItemCount = itemCount;
        }

        [JsonProperty("itemName")]
        public string ItemName { get; set; }

        [JsonProperty("itemCount")]
        public int ItemCount { get; set; }

        [JsonProperty("isStolen")]
        public bool? IsStolen { get; set; }

        [JsonProperty("missionGameID")]
        public int? MissionID { get; set; }
    }
}
