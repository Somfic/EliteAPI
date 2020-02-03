using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using EliteAPI.Status;
using Newtonsoft.Json.Converters;

namespace EliteAPI.Events.Startup
{
    /// <summary>
    /// This event is written when the game has started, after switching ships, after outfitting, and after docking a SRV.
    /// </summary>
    public class LoadoutInfo : EventBase
    {
        internal LoadoutInfo() { }

        /// <summary>
        /// The type of ship.
        /// </summary>
        [JsonProperty("Ship")]
        //[JsonConverter(typeof(StringEnumConverter))]
        public string Ship { get; internal set; }

        /// <summary>
        /// The id of the ship.
        /// </summary>
        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        /// <summary>
        /// The user-defined name of the ship.
        /// </summary>

        [JsonProperty("ShipName")]
        public string ShipName { get; internal set; }

        /// <summary>
        /// The user-defined id of the ship.
        /// </summary>
        [JsonProperty("ShipIdent")]
        public string ShipIdent { get; internal set; }

        /// <summary>
        /// The value of the integrity of the hull.
        /// </summary>
        [JsonProperty("HullValue")]
        public long HullValue { get; internal set; }

        /// <summary>
        /// The value of the integrity of the modules.
        /// </summary>
        [JsonProperty("ModulesValue")]
        public long ModulesValue { get; internal set; }

        /// <summary>
        /// The health of the hull.
        /// </summary>
        [JsonProperty("HullHealth")]
        public float HullHealth { get; internal set; }

        /// <summary>
        /// The mass of the hull and all modules. Fuel and cargo are not included.
        /// </summary>
        [JsonProperty("UnladenMass")]
        public int UnladenMass { get; internal set; }

        /// <summary>
        /// Information on the fuel of the ship.
        /// </summary>
        /// <see cref="FuelInfo"/>
        [JsonProperty("FuelCapacity")]
        public FuelInfo FuelCapacity { get; internal set; }

        /// <summary>
        /// The maximum amount of cargo this ship can carry.
        /// </summary>
        [JsonProperty("CargoCapacity")]
        public int CargoCapacity { get; internal set; }

        /// <summary>
        /// The maximum jump range of the ship.
        /// </summary>
        /// <remarks>
        /// This value is based on no cargo and limited fuel.
        /// </remarks>
        [JsonProperty("MaxJumpRange")]
        public float MaxJumpRange { get; internal set; }

        /// <summary>
        /// The cost of rebuy.
        /// </summary>
        [JsonProperty("Rebuy")]
        public long Rebuy { get; internal set; }

        /// <summary>
        /// Whether the ship is wanted.
        /// </summary>
        [JsonProperty("Hot")]
        public bool Hot { get; internal set; }

        /// <summary>
        /// A list of installed items on the ship.
        /// </summary>
        /// <see cref="ModuleInfo"/>
        [JsonProperty("Modules")]
        public IReadOnlyList<ModuleInfo> Modules { get; internal set; }

        internal static LoadoutInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeLoadoutEvent(JsonConvert.DeserializeObject<LoadoutInfo>(json, JsonSettings.Settings));
        }
    }

    public enum ShipType
    {
        //TODO: Get list of all ships
    }

    /// <summary>
    /// Contains information about the fuel of the ship.
    /// </summary>
    /// <see cref="LoadoutInfo"/>
    public class FuelInfo
    {
        internal FuelInfo() { }

        /// <summary>
        /// The amount of fuel in the main tank.
        /// </summary>
        public float Main { get; internal set; }

        /// <summary>
        /// The amount of fuel in the reserve tank.
        /// </summary>
        public float Reserve { get; internal set; }
    }

    /// <summary>
    /// An installed item on the ship.
    /// </summary>
    /// <see cref="LoadoutInfo"/>
    public class ModuleInfo
    {
        internal ModuleInfo() { }

        /// <summary>
        /// The name of the slot.
        /// </summary>
        [JsonProperty("Slot")]
        public string Slot { get; internal set; }

        /// <summary>
        /// The name of the module in this slow in lowercase.
        /// </summary>
        [JsonProperty("Item")]
        public string Item { get; internal set; }

        /// <summary>
        /// Whether this module is turned on.
        /// </summary>
        [JsonProperty("On")]
        public bool On { get; internal set; }

        /// <summary>
        /// The priority group of power for this module.
        /// </summary>
        [JsonProperty("Priority")]
        public int Priority { get; internal set; }

        /// <summary>
        /// The health of the module.
        /// </summary>
        [JsonProperty("Health")]
        public float Health { get; internal set; }

        /// <summary>
        /// The value of the module.
        /// </summary>
        [JsonProperty("Value", NullValueHandling = NullValueHandling.Ignore)]
        public long? Value { get; internal set; }

        /// <summary>
        /// Amount of ammunition in the clip.
        /// Can also be amount of places in a passenger cabin.
        /// </summary>
        [JsonProperty("AmmoInClip", NullValueHandling = NullValueHandling.Ignore)]
        public long? AmmoInClip { get; internal set; }

        /// <summary>
        /// The amount of ammunition in the hopper.
        /// </summary>
        [JsonProperty("AmmoInHopper", NullValueHandling = NullValueHandling.Ignore)]
        public long? AmmoInHopper { get; internal set; }

        /// <summary>
        /// The engineering that has been done on this module.
        /// </summary>
        /// <see cref="EngineeringInfo"/>
        [JsonProperty("Engineering", NullValueHandling = NullValueHandling.Ignore)]
        public EngineeringInfo EngineeringInfo { get; internal set; }
    }

    /// <summary>
    /// The engineering that has been done on a module.
    /// </summary>
    public class EngineeringInfo
    {
        internal EngineeringInfo() { }

        /// <summary>
        /// The name of the engineer.
        /// </summary>
        [JsonProperty("Engineer")]
        public string Engineer { get; internal set; }

        /// <summary>
        /// The id of the engineer.
        /// </summary>
        [JsonProperty("EngineerID")]
        public int EngineerId { get; internal set; }

        /// <summary>
        /// The id of the blueprint.
        /// </summary>
        [JsonProperty("BlueprintID")]
        public int BlueprintId { get; internal set; }

        /// <summary>
        /// The name of the blueprint.
        /// </summary>
        [JsonProperty("BlueprintName")]
        public string BlueprintName { get; internal set; }

        /// <summary>
        /// The level of the modification.
        /// </summary>
        [JsonProperty("Level")]
        public int Level { get; internal set; }

        /// <summary>
        /// The quality of the modification.
        /// </summary>
        [JsonProperty("Quality")]
        public float Quality { get; internal set; }

        /// <summary>
        /// The experimental effect of the modification, if any.
        /// </summary>
        [JsonProperty("ExperimentalEffect", NullValueHandling = NullValueHandling.Ignore)]
        public string ExperimentalEffect { get; internal set; }

        /// <summary>
        /// The localised experimental effect of the modification, if any.
        /// </summary>
        [JsonProperty("ExperimentalEffect_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string ExperimentalEffectLocalised { get; internal set; }

        /// <summary>
        /// A list of modifiers for this modification, if any.
        /// </summary>
        [JsonProperty("Modifiers")]
        public IReadOnlyList<LoadOutModifier> Modifiers { get; internal set; }
    }

    /// <summary>
    /// The modifier applied on a modification.
    /// </summary>
    public class LoadOutModifier
    {
        internal LoadOutModifier() { }

        /// <summary>
        /// The label of this modifier.
        /// </summary>
        /// <see cref="ModifierLabel"/>
        [JsonProperty("Label")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ModifierLabel Label { get; internal set; }

        /// <summary>
        /// The value of this modifier.
        /// </summary>
        [JsonProperty("Value")]
        public float Value { get; internal set; }

        /// <summary>
        /// The value of this modifier as a string.
        /// </summary>
        [JsonProperty("Value")]
        public string ValueStr { get; internal set; }

        /// <summary>
        /// The original value before this modifier.
        /// </summary>
        [JsonProperty("OriginalValue")]
        public float OriginalValue { get; internal set; }

        /// <summary>
        /// Whether a lower value means better.
        /// </summary>
        /// <see cref="Value"/>
        [JsonProperty("LessIsGood")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool LessIsGood { get; internal set; }
    }

    /// <summary>
    /// The label of the modifier.
    /// </summary>
    /// <see cref="LoadOutModifier"/>
    public enum ModifierLabel
    {
        Size,
        Class,
        Mass,
        Integrity,
        PowerDraw,
        BootTime,
        ShieldBankSpinUp,
        ShieldBankDuration,
        ShieldBankReinforcement,
        ShieldBankHeat,
        DamagePerSecond,
        Damage,
        DistributorDraw,
        ThermalLoad,
        ArmourPenetration,
        MaximumRange,
        ShotSpeed,
        RateOfFire,
        BurstRateOfFire,
        BurstSize,
        AmmoClipSize,
        AmmoMaximum,
        RoundsPerShot,
        ReloadTime,
        BreachDamage,
        MinBreachChance,
        MaxBreachChance,
        Jitter,
        WeaponMode,
        DamageType,
        ShieldGenMinimumMass,
        ShieldGenOptimalMass,
        ShieldGenMaximumMass,
        ShieldGenMinStrength,
        ShieldGenStrength,
        ShieldGenMaxStrength,
        RegenRate,
        BrokenRegenRate,
        EnergyPerRegen,
        FSDOptimalMass,
        FSDHeatRate,
        MaxFuelPerJump,
        EngineMinimumMass,
        EngineOptimalMass,
        MaximumMass,
        EngineMinPerformance,
        EngineOptPerformance,
        EngineMaxPerformance,
        EngineHeatRate,
        PowerCapacity,
        HeatEfficiency,
        WeaponsCapacity,
        WeaponsRecharge,
        EnginesCapacity,
        EnginesRecharge,
        SystemsCapacity,
        SystemsRecharge,
        DefenceModifierHealthMultiplier,
        DefenceModifierHealthAddition,
        DefenceModifierShieldMultiplier,
        DefenceModifierShieldAddition,
        KineticResistance,
        ThermicResistance,
        ExplosiveResistance,
        CausticResistance,
        FSDInterdictorRange,
        FSDInterdictorFacingLimit,
        ScannerRange,
        DiscoveryScannerRange,
        DiscoveryScannerPassiveRange,
        MaxAngle,
        ScannerTimeToScan,
        ChaffJamDuration,
        ECMRange,
        ECMTimeToCharge,
        ECMActivePowerConsumption,
        ECMHeat,
        ECMCooldown,
        HeatSinkDuration,
        ThermalDrain,
        NumBuggySlots,
        CargoCapacity,
        MaxActiveDrones,
        DroneTargetRange,
        DroneLifeTime,
        DroneSpeed,
        DroneMultiTargetSpeed,
        DroneFuelCapacity,
        DroneRepairCapacity,
        DroneHackingTime,
        DroneMinJettisonedCargo,
        DroneMaxJettisonedCargo,
        FuelScoopRate,
        FuelCapacity,
        OxygenTimeCapacity,
        RefineryBins,
        AFMRepairCapacity,
        AFMRepairConsumption,
        AFMRepairPerAmmo,
        MaxRange,
        SensorTargetScanAngle,
        Range,
        VehicleCargoCapacity,
        VehicleHullMass,
        VehicleFuelCapacity,
        VehicleArmourHealth,
        VehicleShieldHealth,
        FighterMaxSpeed,
        FighterBoostSpeed,
        FighterPitchRate,
        FighterDPS,
        FighterYawRate,
        FighterRollRate,
        CabinCapacity,
        CabinClass,
        DisruptionBarrierRange,
        DisruptionBarrierChargeDuration,
        DisruptionBarrierActivePower,
        DisruptionBarrierCooldown,
        WingDamageReduction,
        WingMinDuration,
        WingMaxDuration,
        ShieldSacrificeAmountRemoved,
        ShieldSacrificeAmountGiven,
        FSDJumpRangeBoost,
        FSDFuelUseIncrease,
        BoostSpeedMultiplier,
        BoostAugmenterPowerUse,
        ModuleDefenceAbsorption,
        FalloffRange,
        DSS_RangeMult,
        DSS_AngleMult,
        DSS_RateMult
    }
}