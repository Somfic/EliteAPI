using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EliteAPI.Events.Startup
{
    /// <summary>
    /// This event is written when the commander chooses to clear their save.
    /// </summary>
    public class ClearSavedGameInfo : EventBase
    {
        internal ClearSavedGameInfo() { }

        /// <summary>
        /// The commander's name.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        /// <summary>
        /// The commander's Frontier ID.
        /// </summary>
        [JsonProperty("FID")]
        public string FID { get; internal set; }

        internal static ClearSavedGameInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeClearSavedGameEvent(JsonConvert.DeserializeObject<ClearSavedGameInfo>(json, JsonSettings.Settings));
        }
    }
}
