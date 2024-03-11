using Newtonsoft.Json;

namespace EliteAPI.Status.Outfitting;

public readonly struct OutfittingItem
{
    /// <summary>
    /// The id of this outfitting deal
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; init; }

    /// <summary>
    /// The name of the module
    /// </summary>
    [JsonProperty("Name")]
    public string Name { get; init; }

    /// <summary>
    /// The price of this module
    /// </summary>
    [JsonProperty("BuyPrice")]
    public long Price { get; init; }
}