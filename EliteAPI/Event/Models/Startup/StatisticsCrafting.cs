using Newtonsoft.Json;

namespace EliteAPI.Event.Models.Startup
{
    /// <summary>
    /// Contains statistics on the commander's crafting with engineers.
    /// </summary>
    /// <see cref="StatisticsInfo"/>
    public class StatisticsCrafting
    {
        internal StatisticsCrafting() { }

        /// <summary>
        /// The amount of unique engineers used.
        /// </summary>
        [JsonProperty("Count_Of_Used_Engineers")]
        public int CountOfUsedEngineers { get; internal set; }

        /// <summary>
        /// The amount of recipes generated with engineers.
        /// </summary>
        [JsonProperty("Recipes_Generated")]
        public int RecipesGenerated { get; internal set; }

        /// <summary>
        /// The amount of recipes generated at rank 1.
        /// </summary>
        [JsonProperty("Recipes_Generated_Rank_1")]
        public int RecipesGeneratedRank1 { get; internal set; }

        /// <summary>
        /// The amount of recipes generated at rank 2.
        /// </summary>
        [JsonProperty("Recipes_Generated_Rank_2")]
        public int RecipesGeneratedRank2 { get; internal set; }

        /// <summary>
        /// The amount of recipes generated at rank 3.
        /// </summary>
        [JsonProperty("Recipes_Generated_Rank_3")]
        public int RecipesGeneratedRank3 { get; internal set; }

        /// <summary>
        /// The amount of recipes generated at rank 4.
        /// </summary>
        [JsonProperty("Recipes_Generated_Rank_4")]
        public int RecipesGeneratedRank4 { get; internal set; }

        /// <summary>
        /// The amount of recipes generated at rank 5.
        /// </summary>
        [JsonProperty("Recipes_Generated_Rank_5")]
        public int RecipesGeneratedRank5 { get; internal set; }
    }
}