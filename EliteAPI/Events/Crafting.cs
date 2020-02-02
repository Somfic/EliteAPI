using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class Crafting
    {
        [JsonProperty("Count_Of_Used_Engineers")]
        public long CountOfUsedEngineers { get; internal set; }

        [JsonProperty("Recipes_Generated")]
        public long RecipesGenerated { get; internal set; }

        [JsonProperty("Recipes_Generated_Rank_1")]
        public long RecipesGeneratedRank1 { get; internal set; }

        [JsonProperty("Recipes_Generated_Rank_2")]
        public long RecipesGeneratedRank2 { get; internal set; }

        [JsonProperty("Recipes_Generated_Rank_3")]
        public long RecipesGeneratedRank3 { get; internal set; }

        [JsonProperty("Recipes_Generated_Rank_4")]
        public long RecipesGeneratedRank4 { get; internal set; }

        [JsonProperty("Recipes_Generated_Rank_5")]
        public long RecipesGeneratedRank5 { get; internal set; }
    }
}