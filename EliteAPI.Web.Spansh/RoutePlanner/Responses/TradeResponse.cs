using EliteAPI.Web.Models;
using Newtonsoft.Json;

namespace EliteAPI.Web.Spansh.RoutePlanner.Responses;

public class TradeResponse : IWebApiResponse
{
    [JsonProperty("commodities")] public IReadOnlyCollection<Commodity> Commodities { get; set; }

    [JsonProperty("cumulative_profit")] public long CumulativeProfit { get; set; }

    [JsonProperty("destination")]public SystemInfo Destination { get; set; }

    [JsonProperty("distance")] public double Distance { get; set; }

    [JsonProperty("source")] public SystemInfo System { get; set; }

    [JsonProperty("total_profit")] public long TotalProfit { get; set; }

    public class Commodity
    {
        [JsonProperty("amount")] public long Amount { get; set; }

        [JsonProperty("destination_commodity")]
        public TradeCommodity DestinationCommodity { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("profit")] public long Profit { get; set; }

        [JsonProperty("source_commodity")] public TradeCommodity SourceCommodity { get; set; }

        [JsonProperty("total_profit")] public long TotalProfit { get; set; }
    }

    public class TradeCommodity
    {
        [JsonProperty("buy_price")] public long BuyPrice { get; set; }

        [JsonProperty("demand")] public long Demand { get; set; }

        [JsonProperty("sell_price")] public long SellPrice { get; set; }

        [JsonProperty("supply")] public long Supply { get; set; }
    }

    public class SystemInfo
    {
        [JsonProperty("distance_to_arrival")] public long DistanceToArrival { get; set; }

        [JsonProperty("market_id")] public long MarketId { get; set; }

        [JsonProperty("market_updated_at")] public long MarketUpdatedAt { get; set; }

        [JsonProperty("station")] public string Station { get; set; }

        [JsonProperty("system")] public string Name { get; set; }

        [JsonProperty("system_id64")] public long Id { get; set; }

        [JsonProperty("x")] public double X { get; set; }

        [JsonProperty("y")] public double Y { get; set; }

        [JsonProperty("z")] public double Z { get; set; }
    }
}