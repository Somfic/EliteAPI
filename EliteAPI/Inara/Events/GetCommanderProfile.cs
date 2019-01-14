using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EliteAPI.Inara.Events
{
    public class GetCommanderProfile : IInaraEventData
    {
        public GetCommanderProfile(string searchName)
        {
            SearchName = searchName;
        }

        [JsonProperty("searchName")]
        public string SearchName { get; set; }
    }
}
