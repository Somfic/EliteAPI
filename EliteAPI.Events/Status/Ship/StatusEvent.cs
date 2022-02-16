using EliteAPI.Abstractions.Events;
using EliteAPI.Events.Status.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EliteAPI.Events.Status.Ship;

public struct StatusEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("Flags")]
    public ShipFlags Flags { get; set; }
    
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
    public bool SrvHandbreak => GetShipFlag(12);
    public bool SrvTurrent => GetShipFlag(13);
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
    public bool OnFoot => GetShipFlag(0);
    
    [JsonProperty("Flags2")]
    public CommanderFlags Flags2 { get; init; }
    public bool InTaxi => GetCommanderFlag(1);
    public bool InMultiCrew => GetCommanderFlag(2);
    public bool OnFootInStation => GetCommanderFlag(3);
    public bool OnFootOnPlanet => GetCommanderFlag(4);
    public bool AimDownSight => GetCommanderFlag(5);
    public bool LowOxygen => GetCommanderFlag(6);
    public bool LowHealth => GetCommanderFlag(7);
    public bool Cold => GetCommanderFlag(8);
    public bool Hot => GetCommanderFlag(9);
    public bool VeryCold => GetCommanderFlag(10);
    public bool VeryHot => GetCommanderFlag(11);
    public bool Gliding => GetCommanderFlag(12);
    public bool OnFootInHangar => GetCommanderFlag(13);
    public bool OnFootInSocialSpace => GetCommanderFlag(14);
    public bool OnFootInExterior => GetCommanderFlag(15);
    public bool BreathableAtmosphere => GetCommanderFlag(16);

    [JsonProperty("Pips")]
    [JsonConverter(typeof(PipsConverter))]
    public ShipPips Pips { get; init; }

    [JsonProperty("FireGroup")]
    public long FireGroup { get; init; }

    [JsonProperty("GuiFocus")]
    public long GuiFocus { get; init; }

    [JsonProperty("Fuel")]
    public ShipFuel Fuel { get; init; }

    [JsonProperty("Cargo")]
    public long Cargo { get; init; }

    [JsonProperty("LegalState")]
    [JsonConverter(typeof(StringEnumConverter))]
    public LegalState LegalState { get; init; }

    [JsonProperty("Balance")]
    public long Balance { get; init; }

    [JsonProperty("Destination")]
    public ShipDestination Destination { get; init; }

    [JsonProperty("PlanetRadius")]
    public float BodyRadius { get; init; }

    [JsonProperty("Oxygen")]
    public float Oxygen { get; init; }

    [JsonProperty("Health")]
    public float Health { get; init; }

    [JsonProperty("Temperature")]
    public float Temperature { get; init; }

    [JsonProperty("SelectedWeapon")]
    public Localised SelectedWeapon { get; init; }

    [JsonProperty("Gravity")]
    public float Gravity { get; init; }
    
    [JsonProperty("Latitude")]
    public float Latitude { get; init; }
    
    [JsonProperty("Longitude")]
    public float Longitude { get; init; }
    
    [JsonProperty("Heading")]
    public float Heading { get; init; }
    
    [JsonProperty("Altitude")]
    public long Altitude { get; init; }
    
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