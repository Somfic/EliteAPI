using Newtonsoft.Json;

namespace EliteAPI.Status.Market
{
    /// <summary>
    /// A commodity that is traded in a market
    /// </summary>
    public class Commodity
    {
        internal Commodity() { }

        /// <summary>
        /// The id of this commodity entry
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; init; }

        /// <summary>
        /// The name of the commodity
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; init; }

        /// <summary>
        /// The localised name of this commodity
        /// </summary>
        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; init; }

        /// <summary>
        /// The category of this commodity
        /// </summary>
        [JsonProperty("Category")]
        public string Category { get; init; }

        /// <summary>
        /// The localised category of this commodity
        /// </summary>
        [JsonProperty("Category_Localised")]
        public string CategoryLocalised { get; init; }

        /// <summary>
        /// The buy price of this commodity
        /// </summary>
        [JsonProperty("BuyPrice")]
        public long BuyPrice { get; init; }

        /// <summary>
        /// The sell price of this commodity
        /// </summary>
        [JsonProperty("SellPrice")]
        public long SellPrice { get; init; }

        /// <summary>
        /// The mean price of this commodity
        /// </summary>
        [JsonProperty("MeanPrice")]
        public long MeanPrice { get; init; }

        /// <summary>
        /// The bracket of stock for this commodity
        /// </summary>
        [JsonProperty("StockBracket")]
        public long StockBracket { get; init; }

        /// <summary>
        /// The bracket of demand for this commodity
        /// </summary>
        [JsonProperty("DemandBracket")]
        public long DemandBracket { get; init; }

        /// <summary>
        /// This market's stock for this commodity
        /// </summary>
        [JsonProperty("Stock")]
        public long Stock { get; init; }

        /// <summary>
        /// This market's demand for this commodity
        /// </summary>
        [JsonProperty("Demand")]
        public long Demand { get; init; }

        /// <summary>
        /// Whether this market is a consumer of this commodity
        /// </summary>
        [JsonProperty("Consumer")]
        public bool Consumer { get; init; }

        /// <summary>
        /// Whether this market is a producer of this commodity
        /// </summary>
        [JsonProperty("Producer")]
        public bool Producer { get; init; }

        /// <summary>
        /// Whether this commodity is rare
        /// </summary>
        [JsonProperty("Rare")]
        public bool Rare { get; init; }
    }
}