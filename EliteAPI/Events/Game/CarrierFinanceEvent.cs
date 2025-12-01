using System;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct CarrierFinanceEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("CarrierID")]
    public string CarrierId { get; init; }

    [JsonProperty("TaxRate")]
    public long TaxRate { get; init; }

    [JsonProperty("CarrierBalance")]
    public long Balance { get; init; }

    [JsonProperty("ReserveBalance")]
    public long ReserveBalance { get; init; }

    [JsonProperty("AvailableBalance")]
    public long AvailableBalance { get; init; }

    [JsonProperty("ReservePercent")]
    public long ReservePercent { get; init; }

    [JsonProperty("TaxRate_pioneersupplies")]
    public int TaxRatePioneerSupplies { get; init; }

    [JsonProperty("TaxRate_shipyard")]
    public int TaxRateShipyard { get; init; }

    [JsonProperty("TaxRate_rearm")]
    public int TaxRateRearm { get; init; }

    [JsonProperty("TaxRate_outfitting")]
    public int TaxRateOutfitting { get; init; }

    [JsonProperty("TaxRate_refuel")]
    public int TaxRateRefuel { get; init; }

    [JsonProperty("TaxRate_repair")]
    public int TaxRateRepair { get; init; }
}
