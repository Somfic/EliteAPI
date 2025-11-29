using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events.Game;

public readonly struct CarrierStatsEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("CarrierID")]
    public string CarrierId { get; init; }

    [JsonProperty("Callsign")]
    public string Callsign { get; init; }

    [JsonProperty("Name")]
    public string Name { get; init; }

    [JsonProperty("DockingAccess")]
    public string DockingAccess { get; init; }

    [JsonProperty("AllowNotorious")]
    public bool AllowsNotorious { get; init; }

    [JsonProperty("FuelLevel")]
    public long FuelLevel { get; init; }

    [JsonProperty("JumpRangeCurr")]
    public double JumpRangeCurr { get; init; }

    [JsonProperty("JumpRangeMax")]
    public double JumpRangeMax { get; init; }

    [JsonProperty("PendingDecommission")]
    public bool IsPendingDecommission { get; init; }

    [JsonProperty("SpaceUsage")]
    public SpaceUsageInfo SpaceUsage { get; init; }

    [JsonProperty("Finance")]
    public FinanceInfo Finance { get; init; }

    [JsonProperty("Crew")]
    public IReadOnlyCollection<CrewInfo> Crew { get; init; }

    [JsonProperty("ShipPacks")]
    public IReadOnlyCollection<PackInfo> ShipPacks { get; init; }

    [JsonProperty("ModulePacks")]
    public IReadOnlyCollection<PackInfo> ModulePacks { get; init; }


    public readonly struct PackInfo
    {
        [JsonProperty("PackTheme")]
        public string Theme { get; init; }

        [JsonProperty("PackTier")]
        public string Tier { get; init; }
    }


    public readonly struct CrewInfo
    {
        [JsonProperty("CrewRole")]
        public string CrewRole { get; init; }

        [JsonProperty("Activated")]
        public bool IsActivated { get; init; }

        [JsonProperty("Enabled")]
        public bool IsEnabled { get; init; }

        [JsonProperty("CrewName")]
        public string CrewName { get; init; }
    }


    public readonly struct FinanceInfo
    {
        [JsonProperty("CarrierBalance")]
        public long CarrierBalance { get; init; }

        [JsonProperty("ReserveBalance")]
        public long ReserveBalance { get; init; }

        [JsonProperty("AvailableBalance")]
        public long AvailableBalance { get; init; }

        [JsonProperty("ReservePercent")]
        public long ReservePercent { get; init; }

        [JsonProperty("TaxRate")]
        public long TaxRate { get; init; }
    }


    public readonly struct SpaceUsageInfo
    {
        [JsonProperty("TotalCapacity")]
        public long TotalCapacity { get; init; }

        [JsonProperty("Crew")]
        public long Crew { get; init; }

        [JsonProperty("Cargo")]
        public long Cargo { get; init; }

        [JsonProperty("CargoSpaceReserved")]
        public long CargoSpaceReserved { get; init; }

        [JsonProperty("ShipPacks")]
        public long ShipPacks { get; init; }

        [JsonProperty("ModulePacks")]
        public long ModulePacks { get; init; }

        [JsonProperty("FreeSpace")]
        public long FreeSpace { get; init; }
    }
}
