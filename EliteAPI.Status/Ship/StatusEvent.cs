using EliteAPI.Abstractions.Events;
using EliteAPI.Status.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EliteAPI.Status.Ship;

public readonly struct StatusEvent : IEvent
{

    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Flags")]
    public ShipFlags Flags { get; init; }
    
    public bool Available => Flags != ShipFlags.None || Flags2 != CommanderFlags.None;
    public bool Docked => GetShipFlag(0);
    public bool Landed => GetShipFlag(1);
    public bool Gear => GetShipFlag(2);
    public bool Shields => GetShipFlag(3);
    public bool Supercruise => GetShipFlag(4);
    public bool FlightAssist => !GetShipFlag(5);
    public bool Hardpoints => GetShipFlag(6);
    public bool Winging => GetShipFlag(7);
    public bool Lights => GetShipFlag(8);
    public bool CargoScoop => GetShipFlag(9);
    public bool SilentRunning => GetShipFlag(10);
    public bool Scooping => GetShipFlag(11);
    public bool SrvHandbrake => GetShipFlag(12);
    public bool SrvTurret => GetShipFlag(13);
    public bool SrvNearShip => GetShipFlag(14);
    public bool SrvDriveAssist => GetShipFlag(15);
    public bool MassLocked => GetShipFlag(16);
    public bool FsdCharging => GetShipFlag(17);
    public bool FsdCooldown => GetShipFlag(18);
    public bool LowFuel => GetShipFlag(19);
    public bool Overheating => GetShipFlag(20);
    public bool HasLatLong => GetShipFlag(21);
    public bool InDanger => GetShipFlag(22);
    public bool InInterdiction => GetShipFlag(23);
    public bool InMothership => GetShipFlag(24);
    public bool InFighter => GetShipFlag(25);
    public bool InSrv => GetShipFlag(26);
    public bool AnalysisMode => GetShipFlag(27);
    public bool NightVision => GetShipFlag(28);
    public bool AltitudeFromAverageRadius => GetShipFlag(29);
    public bool FsdJump => GetShipFlag(30);
    public bool SrvHighBeam => GetShipFlag(31);

    [JsonProperty("Flags2")]
    public CommanderFlags Flags2 { get; init; }
    public bool IsOnFoot => GetCommanderFlag(0);
    public bool InTaxi => GetCommanderFlag(1);
    public bool InMultiCrew => GetCommanderFlag(2);
    public bool IsOnFootInStation => GetCommanderFlag(3);
    public bool IsOnFootOnPlanet => GetCommanderFlag(4);
    public bool AimDownSight => GetCommanderFlag(5);
    public bool LowOxygen => GetCommanderFlag(6);
    public bool LowHealth => GetCommanderFlag(7);
    public bool IsCold => GetCommanderFlag(8);
    public bool IsHot => GetCommanderFlag(9);
    public bool VeryCold => GetCommanderFlag(10);
    public bool VeryHot => GetCommanderFlag(11);
    public bool Gliding => GetCommanderFlag(12);
    public bool IsOnFootInHangar => GetCommanderFlag(13);
    public bool IsOnFootInSocialSpace => GetCommanderFlag(14);
    public bool IsOnFootInExterior => GetCommanderFlag(15);
    public bool BreathableAtmosphere => GetCommanderFlag(16);

    [JsonProperty("Pips")]
    [JsonConverter(typeof(PipsConverter))]
    public ShipPips Pips { get; init; }

    [JsonProperty("FireGroup")]
    public long FireGroup { get; init; }

    [JsonProperty("GuiFocus")]
    [JsonConverter(typeof(StringEnumConverter))]
    public GuiFocus GuiFocus { get; init; }

    [JsonProperty("Fuel")]
    public ShipFuel Fuel { get; init; }

    [JsonProperty("Cargo")]
    [JsonConverter(typeof(DecimalToIntegerConverter))]
    public long Cargo { get; init; }

    [JsonProperty("LegalState")]
    [JsonConverter(typeof(StringEnumConverter))]
    public LegalState LegalState { get; init; }

    [JsonProperty("Balance")]
    public long Balance { get; init; }

    [JsonProperty("Destination")]
    public ShipDestination Destination { get; init; }

    [JsonProperty("PlanetRadius")]
    public double BodyRadius { get; init; }

    [JsonProperty("Oxygen")]
    public double Oxygen { get; init; }

    [JsonProperty("Health")]
    public double Health { get; init; }

    [JsonProperty("Temperature")]
    public double Temperature { get; init; }

    [JsonProperty("SelectedWeapon")]
    public Localised SelectedWeapon { get; init; }

    [JsonProperty("Gravity")]
    public double Gravity { get; init; }
    
    [JsonProperty("Latitude")]
    public double Latitude { get; init; }
    
    [JsonProperty("Longitude")]
    public double Longitude { get; init; }
    
    [JsonProperty("Heading")]
    public double Heading { get; init; }
    
    [JsonProperty("Altitude")]
    public double Altitude { get; init; }
    
    [JsonProperty("BodyName")]
    public string Body { get; init; }

    private bool GetShipFlag(int bit)
    {
        return Flags.HasFlag((ShipFlags) (1 << bit));
    }

    private bool GetCommanderFlag(int bit)
    {
        return Flags2.HasFlag((CommanderFlags) (1 << bit));
    }
}

public enum GuiFocus
{
    NoFocus,
    InternalPanel,
    ExternalPanel,
    CommsPanel,
    RolePanel,
    StationServices,
    GalaxyMap,
    SystemMap,
    Orrery,
    FssMode,
    SaaMode,
    Codex,
}