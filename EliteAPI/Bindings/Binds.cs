using System.Collections.Generic;

namespace EliteAPI.Bindings
{

    public class BindingsInfo
    {
        public Xml Xml { get; set; }
        public KeysInfo Root { get; set; }
    }

    public partial class KeysInfo
    {
        public string PresetName { get; set; }
        public long MajorVersion { get; set; }
        public long MinorVersion { get; set; }
        public string KeyboardLayout { get; set; }
        public string LockedDevice { get; set; }
        public TartuGecko MouseXMode { get; set; }
        public TartuGecko MouseXDecay { get; set; }
        public TartuGecko MouseYMode { get; set; }
        public TartuGecko MouseYDecay { get; set; }
        public LivingstoneSouthernWhiteFacedOwl MouseReset { get; set; }
        public TartuGecko MouseSensitivity { get; set; }
        public TartuGecko MouseDecayRate { get; set; }
        public TartuGecko MouseDeadzone { get; set; }
        public TartuGecko MouseLinearity { get; set; }
        public TartuGecko MouseGui { get; set; }
        public PuneHedgehog YawAxisRaw { get; set; }
        public LivingstoneSouthernWhiteFacedOwl YawLeftButton { get; set; }
        public LivingstoneSouthernWhiteFacedOwl YawRightButton { get; set; }
        public TartuGecko YawToRollMode { get; set; }
        public TartuGecko YawToRollSensitivity { get; set; }
        public CamTranslateZHold YawToRollButton { get; set; }
        public PuneHedgehog RollAxisRaw { get; set; }
        public LivingstoneSouthernWhiteFacedOwl RollLeftButton { get; set; }
        public LivingstoneSouthernWhiteFacedOwl RollRightButton { get; set; }
        public PuneHedgehog PitchAxisRaw { get; set; }
        public LivingstoneSouthernWhiteFacedOwl PitchUpButton { get; set; }
        public LivingstoneSouthernWhiteFacedOwl PitchDownButton { get; set; }
        public PuneHedgehog LateralThrustRaw { get; set; }
        public HammerfestPonies LeftThrustButton { get; set; }
        public HammerfestPonies RightThrustButton { get; set; }
        public PuneHedgehog VerticalThrustRaw { get; set; }
        public HammerfestPonies UpThrustButton { get; set; }
        public HammerfestPonies DownThrustButton { get; set; }
        public PuneHedgehog AheadThrust { get; set; }
        public LivingstoneSouthernWhiteFacedOwl ForwardThrustButton { get; set; }
        public HammerfestPonies BackwardThrustButton { get; set; }
        public PuneHedgehog YawAxisAlternate { get; set; }
        public PuneHedgehog RollAxisAlternate { get; set; }
        public PuneHedgehog PitchAxisAlternate { get; set; }
        public PuneHedgehog LateralThrustAlternate { get; set; }
        public PuneHedgehog VerticalThrustAlternate { get; set; }
        public CamTranslateZHold UseAlternateFlightValuesToggle { get; set; }
        public PuneHedgehog ThrottleAxis { get; set; }
        public TartuGecko ThrottleRange { get; set; }
        public CamTranslateZHold ToggleReverseThrottleInput { get; set; }
        public LivingstoneSouthernWhiteFacedOwl ForwardKey { get; set; }
        public LivingstoneSouthernWhiteFacedOwl BackwardKey { get; set; }
        public TartuGecko ThrottleIncrement { get; set; }
        public LivingstoneSouthernWhiteFacedOwl SetSpeedMinus100 { get; set; }
        public LivingstoneSouthernWhiteFacedOwl SetSpeedMinus75 { get; set; }
        public LivingstoneSouthernWhiteFacedOwl SetSpeedMinus50 { get; set; }
        public LivingstoneSouthernWhiteFacedOwl SetSpeedMinus25 { get; set; }
        public LivingstoneSouthernWhiteFacedOwl SetSpeedZero { get; set; }
        public LivingstoneSouthernWhiteFacedOwl SetSpeed25 { get; set; }
        public LivingstoneSouthernWhiteFacedOwl SetSpeed50 { get; set; }
        public LivingstoneSouthernWhiteFacedOwl SetSpeed75 { get; set; }
        public LivingstoneSouthernWhiteFacedOwl SetSpeed100 { get; set; }
        public PuneHedgehog YawAxisLanding { get; set; }
        public LivingstoneSouthernWhiteFacedOwl YawLeftButtonLanding { get; set; }
        public LivingstoneSouthernWhiteFacedOwl YawRightButtonLanding { get; set; }
        public TartuGecko YawToRollModeLanding { get; set; }
        public PuneHedgehog PitchAxisLanding { get; set; }
        public LivingstoneSouthernWhiteFacedOwl PitchUpButtonLanding { get; set; }
        public LivingstoneSouthernWhiteFacedOwl PitchDownButtonLanding { get; set; }
        public PuneHedgehog RollAxisLanding { get; set; }
        public LivingstoneSouthernWhiteFacedOwl RollLeftButtonLanding { get; set; }
        public LivingstoneSouthernWhiteFacedOwl RollRightButtonLanding { get; set; }
        public PuneHedgehog LateralThrustLanding { get; set; }
        public LivingstoneSouthernWhiteFacedOwl LeftThrustButtonLanding { get; set; }
        public LivingstoneSouthernWhiteFacedOwl RightThrustButtonLanding { get; set; }
        public PuneHedgehog VerticalThrustLanding { get; set; }
        public LivingstoneSouthernWhiteFacedOwl UpThrustButtonLanding { get; set; }
        public LivingstoneSouthernWhiteFacedOwl DownThrustButtonLanding { get; set; }
        public PuneHedgehog AheadThrustLanding { get; set; }
        public LivingstoneSouthernWhiteFacedOwl ForwardThrustButtonLanding { get; set; }
        public LivingstoneSouthernWhiteFacedOwl BackwardThrustButtonLanding { get; set; }
        public CamTranslateZHold ToggleFlightAssist { get; set; }
        public TartuGecko YawToRollModeFaOff { get; set; }
        public HammerfestPonies UseBoostJuice { get; set; }
        public LivingstoneSouthernWhiteFacedOwl HyperSuperCombination { get; set; }
        public HammerfestPonies Supercruise { get; set; }
        public HammerfestPonies Hyperspace { get; set; }
        public CamTranslateZHold DisableRotationCorrectToggle { get; set; }
        public LivingstoneSouthernWhiteFacedOwl OrbitLinesToggle { get; set; }
        public LivingstoneSouthernWhiteFacedOwl SelectTarget { get; set; }
        public HammerfestPonies CycleNextTarget { get; set; }
        public LivingstoneSouthernWhiteFacedOwl CyclePreviousTarget { get; set; }
        public LivingstoneSouthernWhiteFacedOwl SelectHighestThreat { get; set; }
        public HammerfestPonies CycleNextHostileTarget { get; set; }
        public HammerfestPonies CyclePreviousHostileTarget { get; set; }
        public HammerfestPonies TargetWingman0 { get; set; }
        public HammerfestPonies TargetWingman1 { get; set; }
        public HammerfestPonies TargetWingman2 { get; set; }
        public HammerfestPonies SelectTargetsTarget { get; set; }
        public HammerfestPonies WingNavLock { get; set; }
        public LivingstoneSouthernWhiteFacedOwl CycleNextSubsystem { get; set; }
        public LivingstoneSouthernWhiteFacedOwl CyclePreviousSubsystem { get; set; }
        public HammerfestPonies TargetNextRouteSystem { get; set; }
        public LivingstoneSouthernWhiteFacedOwl PrimaryFire { get; set; }
        public LivingstoneSouthernWhiteFacedOwl SecondaryFire { get; set; }
        public HammerfestPonies CycleFireGroupNext { get; set; }
        public HammerfestPonies CycleFireGroupPrevious { get; set; }
        public HammerfestPonies DeployHardpointToggle { get; set; }
        public TartuGecko DeployHardpointsOnFire { get; set; }
        public BuggyToggleReverseThrottleInput ToggleButtonUpInput { get; set; }
        public HammerfestPonies DeployHeatSink { get; set; }
        public HammerfestPonies ShipSpotLightToggle { get; set; }
        public PuneHedgehog RadarRangeAxis { get; set; }
        public HammerfestPonies RadarIncreaseRange { get; set; }
        public HammerfestPonies RadarDecreaseRange { get; set; }
        public HammerfestPonies IncreaseEnginesPower { get; set; }
        public HammerfestPonies IncreaseWeaponsPower { get; set; }
        public HammerfestPonies IncreaseSystemsPower { get; set; }
        public HammerfestPonies ResetPowerDistribution { get; set; }
        public LivingstoneSouthernWhiteFacedOwl HmdReset { get; set; }
        public BuggyToggleReverseThrottleInput ToggleCargoScoop { get; set; }
        public HammerfestPonies EjectAllCargo { get; set; }
        public HammerfestPonies LandingGearToggle { get; set; }
        public HammerfestPonies MicrophoneMute { get; set; }
        public TartuGecko MuteButtonMode { get; set; }
        public TartuGecko CqcMuteButtonMode { get; set; }
        public HammerfestPonies UseShieldCell { get; set; }
        public LivingstoneSouthernWhiteFacedOwl FireChaffLauncher { get; set; }
        public PhotoCameraToggle PhotoCameraToggle { get; set; }
        public TartuGecko EnableMenuGroups { get; set; }
        public LivingstoneSouthernWhiteFacedOwl UiFocus { get; set; }
        public TartuGecko UiFocusMode { get; set; }
        public LivingstoneSouthernWhiteFacedOwl FocusLeftPanel { get; set; }
        public LivingstoneSouthernWhiteFacedOwl FocusCommsPanel { get; set; }
        public TartuGecko FocusOnTextEntryField { get; set; }
        public LivingstoneSouthernWhiteFacedOwl QuickCommsPanel { get; set; }
        public LivingstoneSouthernWhiteFacedOwl FocusRadarPanel { get; set; }
        public LivingstoneSouthernWhiteFacedOwl FocusRightPanel { get; set; }
        public TartuGecko LeftPanelFocusOptions { get; set; }
        public TartuGecko CommsPanelFocusOptions { get; set; }
        public TartuGecko RolePanelFocusOptions { get; set; }
        public TartuGecko RightPanelFocusOptions { get; set; }
        public TartuGecko EnableCameraLockOn { get; set; }
        public HammerfestPonies GalaxyMapOpen { get; set; }
        public HammerfestPonies SystemMapOpen { get; set; }
        public CamTranslateZHold ShowPgScoreSummaryInput { get; set; }
        public CamTranslateZHold HeadLookToggle { get; set; }
        public LivingstoneSouthernWhiteFacedOwl Pause { get; set; }
        public LivingstoneSouthernWhiteFacedOwl UiUp { get; set; }
        public LivingstoneSouthernWhiteFacedOwl UiDown { get; set; }
        public LivingstoneSouthernWhiteFacedOwl UiLeft { get; set; }
        public LivingstoneSouthernWhiteFacedOwl UiRight { get; set; }
        public LivingstoneSouthernWhiteFacedOwl UiSelect { get; set; }
        public LivingstoneSouthernWhiteFacedOwl UiBack { get; set; }
        public LivingstoneSouthernWhiteFacedOwl UiToggle { get; set; }
        public HammerfestPonies CycleNextPanel { get; set; }
        public HammerfestPonies CyclePreviousPanel { get; set; }
        public TartuGecko MouseHeadlook { get; set; }
        public TartuGecko MouseHeadlookInvert { get; set; }
        public TartuGecko MouseHeadlookSensitivity { get; set; }
        public TartuGecko HeadlookDefault { get; set; }
        public TartuGecko HeadlookIncrement { get; set; }
        public TartuGecko HeadlookMode { get; set; }
        public TartuGecko HeadlookResetOnToggle { get; set; }
        public TartuGecko HeadlookSensitivity { get; set; }
        public LivingstoneSouthernWhiteFacedOwl HeadLookReset { get; set; }
        public LivingstoneSouthernWhiteFacedOwl HeadLookPitchUp { get; set; }
        public LivingstoneSouthernWhiteFacedOwl HeadLookPitchDown { get; set; }
        public PuneHedgehog HeadLookPitchAxisRaw { get; set; }
        public LivingstoneSouthernWhiteFacedOwl HeadLookYawLeft { get; set; }
        public LivingstoneSouthernWhiteFacedOwl HeadLookYawRight { get; set; }
        public PuneHedgehog HeadLookYawAxis { get; set; }
        public PuneHedgehog CamPitchAxis { get; set; }
        public LivingstoneSouthernWhiteFacedOwl CamPitchUp { get; set; }
        public LivingstoneSouthernWhiteFacedOwl CamPitchDown { get; set; }
        public PuneHedgehog CamYawAxis { get; set; }
        public LivingstoneSouthernWhiteFacedOwl CamYawLeft { get; set; }
        public LivingstoneSouthernWhiteFacedOwl CamYawRight { get; set; }
        public PuneHedgehog CamTranslateYAxis { get; set; }
        public LivingstoneSouthernWhiteFacedOwl CamTranslateForward { get; set; }
        public LivingstoneSouthernWhiteFacedOwl CamTranslateBackward { get; set; }
        public PuneHedgehog CamTranslateXAxis { get; set; }
        public LivingstoneSouthernWhiteFacedOwl CamTranslateLeft { get; set; }
        public LivingstoneSouthernWhiteFacedOwl CamTranslateRight { get; set; }
        public PuneHedgehog CamTranslateZAxis { get; set; }
        public HammerfestPonies CamTranslateUp { get; set; }
        public HammerfestPonies CamTranslateDown { get; set; }
        public PuneHedgehog CamZoomAxis { get; set; }
        public LivingstoneSouthernWhiteFacedOwl CamZoomIn { get; set; }
        public LivingstoneSouthernWhiteFacedOwl CamZoomOut { get; set; }
        public CamTranslateZHold CamTranslateZHold { get; set; }
        public CamTranslateZHold ToggleDriveAssist { get; set; }
        public TartuGecko DriveAssistDefault { get; set; }
        public TartuGecko MouseBuggySteeringXMode { get; set; }
        public TartuGecko MouseBuggySteeringXDecay { get; set; }
        public TartuGecko MouseBuggyRollingXMode { get; set; }
        public TartuGecko MouseBuggyRollingXDecay { get; set; }
        public TartuGecko MouseBuggyYMode { get; set; }
        public TartuGecko MouseBuggyYDecay { get; set; }
        public PuneHedgehog SteeringAxis { get; set; }
        public LivingstoneSouthernWhiteFacedOwl SteerLeftButton { get; set; }
        public LivingstoneSouthernWhiteFacedOwl SteerRightButton { get; set; }
        public PuneHedgehog BuggyRollAxisRaw { get; set; }
        public LivingstoneSouthernWhiteFacedOwl BuggyRollLeftButton { get; set; }
        public LivingstoneSouthernWhiteFacedOwl BuggyRollRightButton { get; set; }
        public PuneHedgehog BuggyPitchAxis { get; set; }
        public LivingstoneSouthernWhiteFacedOwl BuggyPitchUpButton { get; set; }
        public LivingstoneSouthernWhiteFacedOwl BuggyPitchDownButton { get; set; }
        public CamTranslateZHold VerticalThrustersButton { get; set; }
        public LivingstoneSouthernWhiteFacedOwl BuggyPrimaryFireButton { get; set; }
        public LivingstoneSouthernWhiteFacedOwl BuggySecondaryFireButton { get; set; }
        public AutoBreakBuggyButton AutoBreakBuggyButton { get; set; }
        public LivingstoneSouthernWhiteFacedOwl HeadlightsBuggyButton { get; set; }
        public LivingstoneSouthernWhiteFacedOwl ToggleBuggyTurretButton { get; set; }
        public LivingstoneSouthernWhiteFacedOwl SelectTargetBuggy { get; set; }
        public TartuGecko MouseTurretXMode { get; set; }
        public TartuGecko MouseTurretXDecay { get; set; }
        public TartuGecko MouseTurretYMode { get; set; }
        public TartuGecko MouseTurretYDecay { get; set; }
        public PuneHedgehog BuggyTurretYawAxisRaw { get; set; }
        public LivingstoneSouthernWhiteFacedOwl BuggyTurretYawLeftButton { get; set; }
        public LivingstoneSouthernWhiteFacedOwl BuggyTurretYawRightButton { get; set; }
        public PuneHedgehog BuggyTurretPitchAxisRaw { get; set; }
        public LivingstoneSouthernWhiteFacedOwl BuggyTurretPitchUpButton { get; set; }
        public LivingstoneSouthernWhiteFacedOwl BuggyTurretPitchDownButton { get; set; }
        public PuneHedgehog DriveSpeedAxis { get; set; }
        public TartuGecko BuggyThrottleRange { get; set; }
        public BuggyToggleReverseThrottleInput BuggyToggleReverseThrottleInput { get; set; }
        public TartuGecko BuggyThrottleIncrement { get; set; }
        public LivingstoneSouthernWhiteFacedOwl IncreaseSpeedButtonMax { get; set; }
        public LivingstoneSouthernWhiteFacedOwl DecreaseSpeedButtonMax { get; set; }
        public PuneHedgehog IncreaseSpeedButtonPartial { get; set; }
        public PuneHedgehog DecreaseSpeedButtonPartial { get; set; }
        public HammerfestPonies IncreaseEnginesPowerBuggy { get; set; }
        public HammerfestPonies IncreaseWeaponsPowerBuggy { get; set; }
        public HammerfestPonies IncreaseSystemsPowerBuggy { get; set; }
        public HammerfestPonies ResetPowerDistributionBuggy { get; set; }
        public BuggyToggleReverseThrottleInput ToggleCargoScoopBuggy { get; set; }
        public HammerfestPonies EjectAllCargoBuggy { get; set; }
        public BuggyToggleReverseThrottleInput PhotoCameraToggleBuggy { get; set; }
        public HammerfestPonies UiFocusBuggy { get; set; }
        public HammerfestPonies FocusLeftPanelBuggy { get; set; }
        public LivingstoneSouthernWhiteFacedOwl FocusCommsPanelBuggy { get; set; }
        public HammerfestPonies QuickCommsPanelBuggy { get; set; }
        public HammerfestPonies FocusRadarPanelBuggy { get; set; }
        public HammerfestPonies FocusRightPanelBuggy { get; set; }
        public HammerfestPonies GalaxyMapOpenBuggy { get; set; }
        public HammerfestPonies SystemMapOpenBuggy { get; set; }
        public CamTranslateZHold HeadLookToggleBuggy { get; set; }
    }

    public partial class PuneHedgehog
    {
        public Binding Binding { get; set; }
        public TartuGecko Inverted { get; set; }
        public TartuGecko Deadzone { get; set; }
    }

    public partial class Binding
    {
        public string Device { get; set; }
        public string Key { get; set; }
    }

    public partial class TartuGecko
    {
        public string Value { get; set; }
    }

    public partial class AutoBreakBuggyButton
    {
        public SecondaryInfo Primary { get; set; }
        public Binding Secondary { get; set; }
        public TartuGecko ToggleOn { get; set; }
    }

    public partial class LivingstoneSouthernWhiteFacedOwl
    {
        public Binding Primary { get; set; }
        public Binding Secondary { get; set; }
    }

    public partial class HammerfestPonies
    {
        public Binding Primary { get; set; }
        public SecondaryInfo Secondary { get; set; }
    }

    public partial class BuggyToggleReverseThrottleInput
    {
        public Binding Primary { get; set; }
        public SecondaryInfo Secondary { get; set; }
        public TartuGecko ToggleOn { get; set; }
    }

    public partial class CamTranslateZHold
    {
        public Binding Primary { get; set; }
        public Binding Secondary { get; set; }
        public TartuGecko ToggleOn { get; set; }
    }

    public partial class PhotoCameraToggle
    {
        public PrimaryInfo Primary { get; set; }
        public SecondaryInfo Secondary { get; set; }
    }

    public partial class PrimaryInfo
    {
        public string Device { get; set; }
        public string Key { get; set; }
        public List<Binding> Modifier { get; set; }
    }

    public partial class SecondaryInfo
    {
        public string Device { get; set; }
        public string Key { get; set; }
        public Binding Modifier { get; set; }
    }

    public partial class Xml
    {
        public string Version { get; set; }
        public string Encoding { get; set; }
    }
}