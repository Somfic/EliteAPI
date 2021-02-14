using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class CodexEntryEvent : EventBase<CodexEntryEvent>
    {
        internal CodexEntryEvent() { }

        [JsonProperty("EntryID")]
        public string EntryId { get; private set; }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; private set; }

        [JsonProperty("SubCategory")]
        public string SubCategory { get; private set; }

        [JsonProperty("SubCategory_Localised")]
        public string SubCategoryLocalised { get; private set; }

        [JsonProperty("Category")]
        public string Category { get; private set; }

        [JsonProperty("Category_Localised")]
        public string CategoryLocalised { get; private set; }

        [JsonProperty("Region")]
        public string Region { get; private set; }

        [JsonProperty("Region_Localised")]
        public string RegionLocalised { get; private set; }

        [JsonProperty("System")]
        public string System { get; private set; }

        [JsonProperty("SystemAddress")]
        public string SystemAddress { get; private set; }

        [JsonProperty("IsNewEntry")]
        public bool IsNewEntry { get; private set; }
        
        [JsonProperty("NearestDestination")]
        public string NearestDestination { get; private set; }
        
        [JsonProperty("NearestDestination_Localised")]
        public string NearestDestinationLocalised { get; private set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CodexEntryEvent> CodexEntryEvent;

    }
}