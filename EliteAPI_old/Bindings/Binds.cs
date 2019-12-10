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
        public ValueInfo MouseXMode { get; set; }
        public ValueInfo MouseXDecay { get; set; }
        public ValueInfo MouseYMode { get; set; }
        public ValueInfo MouseYDecay { get; set; }
        public StandardBindingInfo MouseReset { get; set; }
        public ValueInfo MouseSensitivity { get; set; }
        public ValueInfo MouseDecayRate { get; set; }
        public ValueInfo MouseDeadzone { get; set; }
        public ValueInfo MouseLinearity { get; set; }
        public ValueInfo MouseGui { get; set; }
        public AxisBindingInfo YawAxisRaw { get; set; }
        public StandardBindingInfo YawLeftButton { get; set; }
        public StandardBindingInfo YawRightButton { get; set; }
        public ValueInfo YawToRollMode { get; set; }
        public ValueInfo YawToRollSensitivity { get; set; }
        public ToggleBindingInfo YawToRollButton { get; set; }
        public AxisBindingInfo RollAxisRaw { get; set; }
        public StandardBindingInfo RollLeftButton { get; set; }
        public StandardBindingInfo RollRightButton { get; set; }
        public AxisBindingInfo PitchAxisRaw { get; set; }
        public StandardBindingInfo PitchUpButton { get; set; }
        public StandardBindingInfo PitchDownButton { get; set; }
        public AxisBindingInfo LateralThrustRaw { get; set; }
        public PrimaryBindingInfo LeftThrustButton { get; set; }
        public PrimaryBindingInfo RightThrustButton { get; set; }
        public AxisBindingInfo VerticalThrustRaw { get; set; }
        public PrimaryBindingInfo UpThrustButton { get; set; }
        public PrimaryBindingInfo DownThrustButton { get; set; }
        public AxisBindingInfo AheadThrust { get; set; }
        public StandardBindingInfo ForwardThrustButton { get; set; }
        public PrimaryBindingInfo BackwardThrustButton { get; set; }
        public AxisBindingInfo YawAxisAlternate { get; set; }
        public AxisBindingInfo RollAxisAlternate { get; set; }
        public AxisBindingInfo PitchAxisAlternate { get; set; }
        public AxisBindingInfo LateralThrustAlternate { get; set; }
        public AxisBindingInfo VerticalThrustAlternate { get; set; }
        public ToggleBindingInfo UseAlternateFlightValuesToggle { get; set; }
        public AxisBindingInfo ThrottleAxis { get; set; }
        public ValueInfo ThrottleRange { get; set; }
        public ToggleBindingInfo ToggleReverseThrottleInput { get; set; }
        public StandardBindingInfo ForwardKey { get; set; }
        public StandardBindingInfo BackwardKey { get; set; }
        public ValueInfo ThrottleIncrement { get; set; }
        public StandardBindingInfo SetSpeedMinus100 { get; set; }
        public StandardBindingInfo SetSpeedMinus75 { get; set; }
        public StandardBindingInfo SetSpeedMinus50 { get; set; }
        public StandardBindingInfo SetSpeedMinus25 { get; set; }
        public StandardBindingInfo SetSpeedZero { get; set; }
        public StandardBindingInfo SetSpeed25 { get; set; }
        public StandardBindingInfo SetSpeed50 { get; set; }
        public StandardBindingInfo SetSpeed75 { get; set; }
        public StandardBindingInfo SetSpeed100 { get; set; }
        public AxisBindingInfo YawAxisLanding { get; set; }
        public StandardBindingInfo YawLeftButtonLanding { get; set; }
        public StandardBindingInfo YawRightButtonLanding { get; set; }
        public ValueInfo YawToRollModeLanding { get; set; }
        public AxisBindingInfo PitchAxisLanding { get; set; }
        public StandardBindingInfo PitchUpButtonLanding { get; set; }
        public StandardBindingInfo PitchDownButtonLanding { get; set; }
        public AxisBindingInfo RollAxisLanding { get; set; }
        public StandardBindingInfo RollLeftButtonLanding { get; set; }
        public StandardBindingInfo RollRightButtonLanding { get; set; }
        public AxisBindingInfo LateralThrustLanding { get; set; }
        public StandardBindingInfo LeftThrustButtonLanding { get; set; }
        public StandardBindingInfo RightThrustButtonLanding { get; set; }
        public AxisBindingInfo VerticalThrustLanding { get; set; }
        public StandardBindingInfo UpThrustButtonLanding { get; set; }
        public StandardBindingInfo DownThrustButtonLanding { get; set; }
        public AxisBindingInfo AheadThrustLanding { get; set; }
        public StandardBindingInfo ForwardThrustButtonLanding { get; set; }
        public StandardBindingInfo BackwardThrustButtonLanding { get; set; }
        public ToggleBindingInfo ToggleFlightAssist { get; set; }
        public ValueInfo YawToRollModeFaOff { get; set; }
        public PrimaryBindingInfo UseBoostJuice { get; set; }
        public StandardBindingInfo HyperSuperCombination { get; set; }
        public PrimaryBindingInfo Supercruise { get; set; }
        public PrimaryBindingInfo Hyperspace { get; set; }
        public ToggleBindingInfo DisableRotationCorrectToggle { get; set; }
        public StandardBindingInfo OrbitLinesToggle { get; set; }
        public StandardBindingInfo SelectTarget { get; set; }
        public PrimaryBindingInfo CycleNextTarget { get; set; }
        public StandardBindingInfo CyclePreviousTarget { get; set; }
        public StandardBindingInfo SelectHighestThreat { get; set; }
        public PrimaryBindingInfo CycleNextHostileTarget { get; set; }
        public PrimaryBindingInfo CyclePreviousHostileTarget { get; set; }
        public PrimaryBindingInfo TargetWingman0 { get; set; }
        public PrimaryBindingInfo TargetWingman1 { get; set; }
        public PrimaryBindingInfo TargetWingman2 { get; set; }
        public PrimaryBindingInfo SelectTargetsTarget { get; set; }
        public PrimaryBindingInfo WingNavLock { get; set; }
        public StandardBindingInfo CycleNextSubsystem { get; set; }
        public StandardBindingInfo CyclePreviousSubsystem { get; set; }
        public PrimaryBindingInfo TargetNextRouteSystem { get; set; }
        public StandardBindingInfo PrimaryFire { get; set; }
        public StandardBindingInfo SecondaryFire { get; set; }
        public PrimaryBindingInfo CycleFireGroupNext { get; set; }
        public PrimaryBindingInfo CycleFireGroupPrevious { get; set; }
        public PrimaryBindingInfo DeployHardpointToggle { get; set; }
        public ValueInfo DeployHardpointsOnFire { get; set; }
        public SecondaryToggleBindingInfo ToggleButtonUpInput { get; set; }
        public PrimaryBindingInfo DeployHeatSink { get; set; }
        public PrimaryBindingInfo ShipSpotLightToggle { get; set; }
        public AxisBindingInfo RadarRangeAxis { get; set; }
        public PrimaryBindingInfo RadarIncreaseRange { get; set; }
        public PrimaryBindingInfo RadarDecreaseRange { get; set; }
        public PrimaryBindingInfo IncreaseEnginesPower { get; set; }
        public PrimaryBindingInfo IncreaseWeaponsPower { get; set; }
        public PrimaryBindingInfo IncreaseSystemsPower { get; set; }
        public PrimaryBindingInfo ResetPowerDistribution { get; set; }
        public StandardBindingInfo HmdReset { get; set; }
        public SecondaryToggleBindingInfo ToggleCargoScoop { get; set; }
        public PrimaryBindingInfo EjectAllCargo { get; set; }
        public PrimaryBindingInfo LandingGearToggle { get; set; }
        public PrimaryBindingInfo MicrophoneMute { get; set; }
        public ValueInfo MuteButtonMode { get; set; }
        public ValueInfo CqcMuteButtonMode { get; set; }
        public PrimaryBindingInfo UseShieldCell { get; set; }
        public StandardBindingInfo FireChaffLauncher { get; set; }
        public StandardInfoBindingInfo PhotoCameraToggle { get; set; }
        public ValueInfo EnableMenuGroups { get; set; }
        public StandardBindingInfo UiFocus { get; set; }
        public ValueInfo UiFocusMode { get; set; }
        public StandardBindingInfo FocusLeftPanel { get; set; }
        public StandardBindingInfo FocusCommsPanel { get; set; }
        public ValueInfo FocusOnTextEntryField { get; set; }
        public StandardBindingInfo QuickCommsPanel { get; set; }
        public StandardBindingInfo FocusRadarPanel { get; set; }
        public StandardBindingInfo FocusRightPanel { get; set; }
        public ValueInfo LeftPanelFocusOptions { get; set; }
        public ValueInfo CommsPanelFocusOptions { get; set; }
        public ValueInfo RolePanelFocusOptions { get; set; }
        public ValueInfo RightPanelFocusOptions { get; set; }
        public ValueInfo EnableCameraLockOn { get; set; }
        public PrimaryBindingInfo GalaxyMapOpen { get; set; }
        public PrimaryBindingInfo SystemMapOpen { get; set; }
        public ToggleBindingInfo ShowPgScoreSummaryInput { get; set; }
        public ToggleBindingInfo HeadLookToggle { get; set; }
        public StandardBindingInfo Pause { get; set; }
        public StandardBindingInfo UiUp { get; set; }
        public StandardBindingInfo UiDown { get; set; }
        public StandardBindingInfo UiLeft { get; set; }
        public StandardBindingInfo UiRight { get; set; }
        public StandardBindingInfo UiSelect { get; set; }
        public StandardBindingInfo UiBack { get; set; }
        public StandardBindingInfo UiToggle { get; set; }
        public PrimaryBindingInfo CycleNextPanel { get; set; }
        public PrimaryBindingInfo CyclePreviousPanel { get; set; }
        public ValueInfo MouseHeadlook { get; set; }
        public ValueInfo MouseHeadlookInvert { get; set; }
        public ValueInfo MouseHeadlookSensitivity { get; set; }
        public ValueInfo HeadlookDefault { get; set; }
        public ValueInfo HeadlookIncrement { get; set; }
        public ValueInfo HeadlookMode { get; set; }
        public ValueInfo HeadlookResetOnToggle { get; set; }
        public ValueInfo HeadlookSensitivity { get; set; }
        public StandardBindingInfo HeadLookReset { get; set; }
        public StandardBindingInfo HeadLookPitchUp { get; set; }
        public StandardBindingInfo HeadLookPitchDown { get; set; }
        public AxisBindingInfo HeadLookPitchAxisRaw { get; set; }
        public StandardBindingInfo HeadLookYawLeft { get; set; }
        public StandardBindingInfo HeadLookYawRight { get; set; }
        public AxisBindingInfo HeadLookYawAxis { get; set; }
        public AxisBindingInfo CamPitchAxis { get; set; }
        public StandardBindingInfo CamPitchUp { get; set; }
        public StandardBindingInfo CamPitchDown { get; set; }
        public AxisBindingInfo CamYawAxis { get; set; }
        public StandardBindingInfo CamYawLeft { get; set; }
        public StandardBindingInfo CamYawRight { get; set; }
        public AxisBindingInfo CamTranslateYAxis { get; set; }
        public StandardBindingInfo CamTranslateForward { get; set; }
        public StandardBindingInfo CamTranslateBackward { get; set; }
        public AxisBindingInfo CamTranslateXAxis { get; set; }
        public StandardBindingInfo CamTranslateLeft { get; set; }
        public StandardBindingInfo CamTranslateRight { get; set; }
        public AxisBindingInfo CamTranslateZAxis { get; set; }
        public PrimaryBindingInfo CamTranslateUp { get; set; }
        public PrimaryBindingInfo CamTranslateDown { get; set; }
        public AxisBindingInfo CamZoomAxis { get; set; }
        public StandardBindingInfo CamZoomIn { get; set; }
        public StandardBindingInfo CamZoomOut { get; set; }
        public ToggleBindingInfo CamTranslateZHold { get; set; }
        public ToggleBindingInfo ToggleDriveAssist { get; set; }
        public ValueInfo DriveAssistDefault { get; set; }
        public ValueInfo MouseBuggySteeringXMode { get; set; }
        public ValueInfo MouseBuggySteeringXDecay { get; set; }
        public ValueInfo MouseBuggyRollingXMode { get; set; }
        public ValueInfo MouseBuggyRollingXDecay { get; set; }
        public ValueInfo MouseBuggyYMode { get; set; }
        public ValueInfo MouseBuggyYDecay { get; set; }
        public AxisBindingInfo SteeringAxis { get; set; }
        public StandardBindingInfo SteerLeftButton { get; set; }
        public StandardBindingInfo SteerRightButton { get; set; }
        public AxisBindingInfo BuggyRollAxisRaw { get; set; }
        public StandardBindingInfo BuggyRollLeftButton { get; set; }
        public StandardBindingInfo BuggyRollRightButton { get; set; }
        public AxisBindingInfo BuggyPitchAxis { get; set; }
        public StandardBindingInfo BuggyPitchUpButton { get; set; }
        public StandardBindingInfo BuggyPitchDownButton { get; set; }
        public ToggleBindingInfo VerticalThrustersButton { get; set; }
        public StandardBindingInfo BuggyPrimaryFireButton { get; set; }
        public StandardBindingInfo BuggySecondaryFireButton { get; set; }
        public PrimaryToggleBindingInfo AutoBreakBuggyButton { get; set; }
        public StandardBindingInfo HeadlightsBuggyButton { get; set; }
        public StandardBindingInfo ToggleBuggyTurretButton { get; set; }
        public StandardBindingInfo SelectTargetBuggy { get; set; }
        public ValueInfo MouseTurretXMode { get; set; }
        public ValueInfo MouseTurretXDecay { get; set; }
        public ValueInfo MouseTurretYMode { get; set; }
        public ValueInfo MouseTurretYDecay { get; set; }
        public AxisBindingInfo BuggyTurretYawAxisRaw { get; set; }
        public StandardBindingInfo BuggyTurretYawLeftButton { get; set; }
        public StandardBindingInfo BuggyTurretYawRightButton { get; set; }
        public AxisBindingInfo BuggyTurretPitchAxisRaw { get; set; }
        public StandardBindingInfo BuggyTurretPitchUpButton { get; set; }
        public StandardBindingInfo BuggyTurretPitchDownButton { get; set; }
        public AxisBindingInfo DriveSpeedAxis { get; set; }
        public ValueInfo BuggyThrottleRange { get; set; }
        public SecondaryToggleBindingInfo BuggyToggleReverseThrottleInput { get; set; }
        public ValueInfo BuggyThrottleIncrement { get; set; }
        public StandardBindingInfo IncreaseSpeedButtonMax { get; set; }
        public StandardBindingInfo DecreaseSpeedButtonMax { get; set; }
        public AxisBindingInfo IncreaseSpeedButtonPartial { get; set; }
        public AxisBindingInfo DecreaseSpeedButtonPartial { get; set; }
        public PrimaryBindingInfo IncreaseEnginesPowerBuggy { get; set; }
        public PrimaryBindingInfo IncreaseWeaponsPowerBuggy { get; set; }
        public PrimaryBindingInfo IncreaseSystemsPowerBuggy { get; set; }
        public PrimaryBindingInfo ResetPowerDistributionBuggy { get; set; }
        public SecondaryToggleBindingInfo ToggleCargoScoopBuggy { get; set; }
        public PrimaryBindingInfo EjectAllCargoBuggy { get; set; }
        public SecondaryToggleBindingInfo PhotoCameraToggleBuggy { get; set; }
        public PrimaryBindingInfo UiFocusBuggy { get; set; }
        public PrimaryBindingInfo FocusLeftPanelBuggy { get; set; }
        public StandardBindingInfo FocusCommsPanelBuggy { get; set; }
        public PrimaryBindingInfo QuickCommsPanelBuggy { get; set; }
        public PrimaryBindingInfo FocusRadarPanelBuggy { get; set; }
        public PrimaryBindingInfo FocusRightPanelBuggy { get; set; }
        public PrimaryBindingInfo GalaxyMapOpenBuggy { get; set; }
        public PrimaryBindingInfo SystemMapOpenBuggy { get; set; }
        public ToggleBindingInfo HeadLookToggleBuggy { get; set; }
    }

    public partial class AxisBindingInfo
    {
        public Binding Binding { get; set; }
        public ValueInfo Inverted { get; set; }
        public ValueInfo Deadzone { get; set; }
    }

    public partial class Binding
    {
        public string Device { get; set; }
        public string Key { get; set; }
    }

    public partial class ValueInfo
    {
        public string Value { get; set; }
    }

    public partial class PrimaryToggleBindingInfo
    {
        public PrimaryInfo Primary { get; set; }
        public Binding Secondary { get; set; }
        public ValueInfo ToggleOn { get; set; }
    }

    public partial class PrimaryBindingInfo
    {
        public Binding Primary { get; set; }
        public SecondaryInfo Secondary { get; set; }
    }

    public partial class StandardBindingInfo
    {
        public Binding Primary { get; set; }
        public Binding Secondary { get; set; }
    }

    public partial class SecondaryToggleBindingInfo
    {
        public Binding Primary { get; set; }
        public SecondaryInfo Secondary { get; set; }
        public ValueInfo ToggleOn { get; set; }
    }

    public partial class ToggleBindingInfo
    {
        public Binding Primary { get; set; }
        public Binding Secondary { get; set; }
        public ValueInfo ToggleOn { get; set; }
    }

    public partial class StandardInfoBindingInfo
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