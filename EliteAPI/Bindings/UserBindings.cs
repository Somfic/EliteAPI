using System.Collections.Generic;

namespace EliteAPI.Bindings
{
    public class UserBindings
    {
        public Xml Xml { get; internal set; }
        public KeysInfo Root { get; internal set; }
    }

    public partial class KeysInfo
    {
        public string PresetName { get; internal set; }
        public long MajorVersion { get; internal set; }
        public long MinorVersion { get; internal set; }
        public string KeyboardLayout { get; internal set; }
        public string LockedDevice { get; internal set; }
        public ValueInfo MouseXMode { get; internal set; }
        public ValueInfo MouseXDecay { get; internal set; }
        public ValueInfo MouseYMode { get; internal set; }
        public ValueInfo MouseYDecay { get; internal set; }
        public StandardBindingInfo MouseReset { get; internal set; }
        public ValueInfo MouseSensitivity { get; internal set; }
        public ValueInfo MouseDecayRate { get; internal set; }
        public ValueInfo MouseDeadzone { get; internal set; }
        public ValueInfo MouseLinearity { get; internal set; }
        public ValueInfo MouseGui { get; internal set; }
        public AxisBindingInfo YawAxisRaw { get; internal set; }
        public StandardBindingInfo YawLeftButton { get; internal set; }
        public StandardBindingInfo YawRightButton { get; internal set; }
        public ValueInfo YawToRollMode { get; internal set; }
        public ValueInfo YawToRollSensitivity { get; internal set; }
        public ToggleBindingInfo YawToRollButton { get; internal set; }
        public AxisBindingInfo RollAxisRaw { get; internal set; }
        public StandardBindingInfo RollLeftButton { get; internal set; }
        public StandardBindingInfo RollRightButton { get; internal set; }
        public AxisBindingInfo PitchAxisRaw { get; internal set; }
        public StandardBindingInfo PitchUpButton { get; internal set; }
        public StandardBindingInfo PitchDownButton { get; internal set; }
        public AxisBindingInfo LateralThrustRaw { get; internal set; }
        public PrimaryBindingInfo LeftThrustButton { get; internal set; }
        public PrimaryBindingInfo RightThrustButton { get; internal set; }
        public AxisBindingInfo VerticalThrustRaw { get; internal set; }
        public PrimaryBindingInfo UpThrustButton { get; internal set; }
        public PrimaryBindingInfo DownThrustButton { get; internal set; }
        public AxisBindingInfo AheadThrust { get; internal set; }
        public StandardBindingInfo ForwardThrustButton { get; internal set; }
        public PrimaryBindingInfo BackwardThrustButton { get; internal set; }
        public AxisBindingInfo YawAxisAlternate { get; internal set; }
        public AxisBindingInfo RollAxisAlternate { get; internal set; }
        public AxisBindingInfo PitchAxisAlternate { get; internal set; }
        public AxisBindingInfo LateralThrustAlternate { get; internal set; }
        public AxisBindingInfo VerticalThrustAlternate { get; internal set; }
        public ToggleBindingInfo UseAlternateFlightValuesToggle { get; internal set; }
        public AxisBindingInfo ThrottleAxis { get; internal set; }
        public ValueInfo ThrottleRange { get; internal set; }
        public ToggleBindingInfo ToggleReverseThrottleInput { get; internal set; }
        public StandardBindingInfo ForwardKey { get; internal set; }
        public StandardBindingInfo BackwardKey { get; internal set; }
        public ValueInfo ThrottleIncrement { get; internal set; }
        public StandardBindingInfo SetSpeedMinus100 { get; internal set; }
        public StandardBindingInfo SetSpeedMinus75 { get; internal set; }
        public StandardBindingInfo SetSpeedMinus50 { get; internal set; }
        public StandardBindingInfo SetSpeedMinus25 { get; internal set; }
        public StandardBindingInfo SetSpeedZero { get; internal set; }
        public StandardBindingInfo SetSpeed25 { get; internal set; }
        public StandardBindingInfo SetSpeed50 { get; internal set; }
        public StandardBindingInfo SetSpeed75 { get; internal set; }
        public StandardBindingInfo SetSpeed100 { get; internal set; }
        public AxisBindingInfo YawAxisLanding { get; internal set; }
        public StandardBindingInfo YawLeftButtonLanding { get; internal set; }
        public StandardBindingInfo YawRightButtonLanding { get; internal set; }
        public ValueInfo YawToRollModeLanding { get; internal set; }
        public AxisBindingInfo PitchAxisLanding { get; internal set; }
        public StandardBindingInfo PitchUpButtonLanding { get; internal set; }
        public StandardBindingInfo PitchDownButtonLanding { get; internal set; }
        public AxisBindingInfo RollAxisLanding { get; internal set; }
        public StandardBindingInfo RollLeftButtonLanding { get; internal set; }
        public StandardBindingInfo RollRightButtonLanding { get; internal set; }
        public AxisBindingInfo LateralThrustLanding { get; internal set; }
        public StandardBindingInfo LeftThrustButtonLanding { get; internal set; }
        public StandardBindingInfo RightThrustButtonLanding { get; internal set; }
        public AxisBindingInfo VerticalThrustLanding { get; internal set; }
        public StandardBindingInfo UpThrustButtonLanding { get; internal set; }
        public StandardBindingInfo DownThrustButtonLanding { get; internal set; }
        public AxisBindingInfo AheadThrustLanding { get; internal set; }
        public StandardBindingInfo ForwardThrustButtonLanding { get; internal set; }
        public StandardBindingInfo BackwardThrustButtonLanding { get; internal set; }
        public ToggleBindingInfo ToggleFlightAssist { get; internal set; }
        public ValueInfo YawToRollModeFaOff { get; internal set; }
        public PrimaryBindingInfo UseBoostJuice { get; internal set; }
        public StandardBindingInfo HyperSuperCombination { get; internal set; }
        public PrimaryBindingInfo Supercruise { get; internal set; }
        public PrimaryBindingInfo Hyperspace { get; internal set; }
        public ToggleBindingInfo DisableRotationCorrectToggle { get; internal set; }
        public StandardBindingInfo OrbitLinesToggle { get; internal set; }
        public StandardBindingInfo SelectTarget { get; internal set; }
        public PrimaryBindingInfo CycleNextTarget { get; internal set; }
        public StandardBindingInfo CyclePreviousTarget { get; internal set; }
        public StandardBindingInfo SelectHighestThreat { get; internal set; }
        public PrimaryBindingInfo CycleNextHostileTarget { get; internal set; }
        public PrimaryBindingInfo CyclePreviousHostileTarget { get; internal set; }
        public PrimaryBindingInfo TargetWingman0 { get; internal set; }
        public PrimaryBindingInfo TargetWingman1 { get; internal set; }
        public PrimaryBindingInfo TargetWingman2 { get; internal set; }
        public PrimaryBindingInfo SelectTargetsTarget { get; internal set; }
        public PrimaryBindingInfo WingNavLock { get; internal set; }
        public StandardBindingInfo CycleNextSubsystem { get; internal set; }
        public StandardBindingInfo CyclePreviousSubsystem { get; internal set; }
        public PrimaryBindingInfo TargetNextRouteSystem { get; internal set; }
        public StandardBindingInfo PrimaryFire { get; internal set; }
        public StandardBindingInfo SecondaryFire { get; internal set; }
        public PrimaryBindingInfo CycleFireGroupNext { get; internal set; }
        public PrimaryBindingInfo CycleFireGroupPrevious { get; internal set; }
        public PrimaryBindingInfo DeployHardpointToggle { get; internal set; }
        public ValueInfo DeployHardpointsOnFire { get; internal set; }
        public SecondaryToggleBindingInfo ToggleButtonUpInput { get; internal set; }
        public PrimaryBindingInfo DeployHeatSink { get; internal set; }
        public PrimaryBindingInfo ShipSpotLightToggle { get; internal set; }
        public AxisBindingInfo RadarRangeAxis { get; internal set; }
        public PrimaryBindingInfo RadarIncreaseRange { get; internal set; }
        public PrimaryBindingInfo RadarDecreaseRange { get; internal set; }
        public PrimaryBindingInfo IncreaseEnginesPower { get; internal set; }
        public PrimaryBindingInfo IncreaseWeaponsPower { get; internal set; }
        public PrimaryBindingInfo IncreaseSystemsPower { get; internal set; }
        public PrimaryBindingInfo ResetPowerDistribution { get; internal set; }
        public StandardBindingInfo HmdReset { get; internal set; }
        public SecondaryToggleBindingInfo ToggleCargoScoop { get; internal set; }
        public PrimaryBindingInfo EjectAllCargo { get; internal set; }
        public PrimaryBindingInfo LandingGearToggle { get; internal set; }
        public PrimaryBindingInfo MicrophoneMute { get; internal set; }
        public ValueInfo MuteButtonMode { get; internal set; }
        public ValueInfo CqcMuteButtonMode { get; internal set; }
        public PrimaryBindingInfo UseShieldCell { get; internal set; }
        public StandardBindingInfo FireChaffLauncher { get; internal set; }
        public StandardInfoBindingInfo PhotoCameraToggle { get; internal set; }
        public ValueInfo EnableMenuGroups { get; internal set; }
        public StandardBindingInfo UiFocus { get; internal set; }
        public ValueInfo UiFocusMode { get; internal set; }
        public StandardBindingInfo FocusLeftPanel { get; internal set; }
        public StandardBindingInfo FocusCommsPanel { get; internal set; }
        public ValueInfo FocusOnTextEntryField { get; internal set; }
        public StandardBindingInfo QuickCommsPanel { get; internal set; }
        public StandardBindingInfo FocusRadarPanel { get; internal set; }
        public StandardBindingInfo FocusRightPanel { get; internal set; }
        public ValueInfo LeftPanelFocusOptions { get; internal set; }
        public ValueInfo CommsPanelFocusOptions { get; internal set; }
        public ValueInfo RolePanelFocusOptions { get; internal set; }
        public ValueInfo RightPanelFocusOptions { get; internal set; }
        public ValueInfo EnableCameraLockOn { get; internal set; }
        public PrimaryBindingInfo GalaxyMapOpen { get; internal set; }
        public PrimaryBindingInfo SystemMapOpen { get; internal set; }
        public ToggleBindingInfo ShowPgScoreSummaryInput { get; internal set; }
        public ToggleBindingInfo HeadLookToggle { get; internal set; }
        public StandardBindingInfo Pause { get; internal set; }
        public StandardBindingInfo UiUp { get; internal set; }
        public StandardBindingInfo UiDown { get; internal set; }
        public StandardBindingInfo UiLeft { get; internal set; }
        public StandardBindingInfo UiRight { get; internal set; }
        public StandardBindingInfo UiSelect { get; internal set; }
        public StandardBindingInfo UiBack { get; internal set; }
        public StandardBindingInfo UiToggle { get; internal set; }
        public PrimaryBindingInfo CycleNextPanel { get; internal set; }
        public PrimaryBindingInfo CyclePreviousPanel { get; internal set; }
        public ValueInfo MouseHeadlook { get; internal set; }
        public ValueInfo MouseHeadlookInvert { get; internal set; }
        public ValueInfo MouseHeadlookSensitivity { get; internal set; }
        public ValueInfo HeadlookDefault { get; internal set; }
        public ValueInfo HeadlookIncrement { get; internal set; }
        public ValueInfo HeadlookMode { get; internal set; }
        public ValueInfo HeadlookResetOnToggle { get; internal set; }
        public ValueInfo HeadlookSensitivity { get; internal set; }
        public StandardBindingInfo HeadLookReset { get; internal set; }
        public StandardBindingInfo HeadLookPitchUp { get; internal set; }
        public StandardBindingInfo HeadLookPitchDown { get; internal set; }
        public AxisBindingInfo HeadLookPitchAxisRaw { get; internal set; }
        public StandardBindingInfo HeadLookYawLeft { get; internal set; }
        public StandardBindingInfo HeadLookYawRight { get; internal set; }
        public AxisBindingInfo HeadLookYawAxis { get; internal set; }
        public AxisBindingInfo CamPitchAxis { get; internal set; }
        public StandardBindingInfo CamPitchUp { get; internal set; }
        public StandardBindingInfo CamPitchDown { get; internal set; }
        public AxisBindingInfo CamYawAxis { get; internal set; }
        public StandardBindingInfo CamYawLeft { get; internal set; }
        public StandardBindingInfo CamYawRight { get; internal set; }
        public AxisBindingInfo CamTranslateYAxis { get; internal set; }
        public StandardBindingInfo CamTranslateForward { get; internal set; }
        public StandardBindingInfo CamTranslateBackward { get; internal set; }
        public AxisBindingInfo CamTranslateXAxis { get; internal set; }
        public StandardBindingInfo CamTranslateLeft { get; internal set; }
        public StandardBindingInfo CamTranslateRight { get; internal set; }
        public AxisBindingInfo CamTranslateZAxis { get; internal set; }
        public PrimaryBindingInfo CamTranslateUp { get; internal set; }
        public PrimaryBindingInfo CamTranslateDown { get; internal set; }
        public AxisBindingInfo CamZoomAxis { get; internal set; }
        public StandardBindingInfo CamZoomIn { get; internal set; }
        public StandardBindingInfo CamZoomOut { get; internal set; }
        public ToggleBindingInfo CamTranslateZHold { get; internal set; }
        public ToggleBindingInfo ToggleDriveAssist { get; internal set; }
        public ValueInfo DriveAssistDefault { get; internal set; }
        public ValueInfo MouseBuggySteeringXMode { get; internal set; }
        public ValueInfo MouseBuggySteeringXDecay { get; internal set; }
        public ValueInfo MouseBuggyRollingXMode { get; internal set; }
        public ValueInfo MouseBuggyRollingXDecay { get; internal set; }
        public ValueInfo MouseBuggyYMode { get; internal set; }
        public ValueInfo MouseBuggyYDecay { get; internal set; }
        public AxisBindingInfo SteeringAxis { get; internal set; }
        public StandardBindingInfo SteerLeftButton { get; internal set; }
        public StandardBindingInfo SteerRightButton { get; internal set; }
        public AxisBindingInfo BuggyRollAxisRaw { get; internal set; }
        public StandardBindingInfo BuggyRollLeftButton { get; internal set; }
        public StandardBindingInfo BuggyRollRightButton { get; internal set; }
        public AxisBindingInfo BuggyPitchAxis { get; internal set; }
        public StandardBindingInfo BuggyPitchUpButton { get; internal set; }
        public StandardBindingInfo BuggyPitchDownButton { get; internal set; }
        public ToggleBindingInfo VerticalThrustersButton { get; internal set; }
        public StandardBindingInfo BuggyPrimaryFireButton { get; internal set; }
        public StandardBindingInfo BuggySecondaryFireButton { get; internal set; }
        public PrimaryToggleBindingInfo AutoBreakBuggyButton { get; internal set; }
        public StandardBindingInfo HeadlightsBuggyButton { get; internal set; }
        public StandardBindingInfo ToggleBuggyTurretButton { get; internal set; }
        public StandardBindingInfo SelectTargetBuggy { get; internal set; }
        public ValueInfo MouseTurretXMode { get; internal set; }
        public ValueInfo MouseTurretXDecay { get; internal set; }
        public ValueInfo MouseTurretYMode { get; internal set; }
        public ValueInfo MouseTurretYDecay { get; internal set; }
        public AxisBindingInfo BuggyTurretYawAxisRaw { get; internal set; }
        public StandardBindingInfo BuggyTurretYawLeftButton { get; internal set; }
        public StandardBindingInfo BuggyTurretYawRightButton { get; internal set; }
        public AxisBindingInfo BuggyTurretPitchAxisRaw { get; internal set; }
        public StandardBindingInfo BuggyTurretPitchUpButton { get; internal set; }
        public StandardBindingInfo BuggyTurretPitchDownButton { get; internal set; }
        public AxisBindingInfo DriveSpeedAxis { get; internal set; }
        public ValueInfo BuggyThrottleRange { get; internal set; }
        public SecondaryToggleBindingInfo BuggyToggleReverseThrottleInput { get; internal set; }
        public ValueInfo BuggyThrottleIncrement { get; internal set; }
        public StandardBindingInfo IncreaseSpeedButtonMax { get; internal set; }
        public StandardBindingInfo DecreaseSpeedButtonMax { get; internal set; }
        public AxisBindingInfo IncreaseSpeedButtonPartial { get; internal set; }
        public AxisBindingInfo DecreaseSpeedButtonPartial { get; internal set; }
        public PrimaryBindingInfo IncreaseEnginesPowerBuggy { get; internal set; }
        public PrimaryBindingInfo IncreaseWeaponsPowerBuggy { get; internal set; }
        public PrimaryBindingInfo IncreaseSystemsPowerBuggy { get; internal set; }
        public PrimaryBindingInfo ResetPowerDistributionBuggy { get; internal set; }
        public SecondaryToggleBindingInfo ToggleCargoScoopBuggy { get; internal set; }
        public PrimaryBindingInfo EjectAllCargoBuggy { get; internal set; }
        public SecondaryToggleBindingInfo PhotoCameraToggleBuggy { get; internal set; }
        public PrimaryBindingInfo UiFocusBuggy { get; internal set; }
        public PrimaryBindingInfo FocusLeftPanelBuggy { get; internal set; }
        public StandardBindingInfo FocusCommsPanelBuggy { get; internal set; }
        public PrimaryBindingInfo QuickCommsPanelBuggy { get; internal set; }
        public PrimaryBindingInfo FocusRadarPanelBuggy { get; internal set; }
        public PrimaryBindingInfo FocusRightPanelBuggy { get; internal set; }
        public PrimaryBindingInfo GalaxyMapOpenBuggy { get; internal set; }
        public PrimaryBindingInfo SystemMapOpenBuggy { get; internal set; }
        public ToggleBindingInfo HeadLookToggleBuggy { get; internal set; }
    }

    public partial class AxisBindingInfo
    {
        public Binding Binding { get; internal set; }
        public ValueInfo Inverted { get; internal set; }
        public ValueInfo Deadzone { get; internal set; }
    }

    public partial class Binding
    {
        public string Device { get; internal set; }
        public string Key { get; internal set; }
    }

    public partial class ValueInfo
    {
        public string Value { get; internal set; }
    }

    public partial class PrimaryToggleBindingInfo
    {
        public PrimaryInfo Primary { get; internal set; }
        public Binding Secondary { get; internal set; }
        public ValueInfo ToggleOn { get; internal set; }
    }

    public partial class PrimaryBindingInfo
    {
        public Binding Primary { get; internal set; }
        public SecondaryInfo Secondary { get; internal set; }
    }

    public partial class StandardBindingInfo
    {
        public Binding Primary { get; internal set; }
        public Binding Secondary { get; internal set; }
    }

    public partial class SecondaryToggleBindingInfo
    {
        public Binding Primary { get; internal set; }
        public SecondaryInfo Secondary { get; internal set; }
        public ValueInfo ToggleOn { get; internal set; }
    }

    public partial class ToggleBindingInfo
    {
        public Binding Primary { get; internal set; }
        public Binding Secondary { get; internal set; }
        public ValueInfo ToggleOn { get; internal set; }
    }

    public partial class StandardInfoBindingInfo
    {
        public PrimaryInfo Primary { get; internal set; }
        public SecondaryInfo Secondary { get; internal set; }
    }

    public partial class PrimaryInfo
    {
        public string Device { get; internal set; }
        public string Key { get; internal set; }
        public List<Binding> Modifier { get; internal set; }
    }

    public partial class SecondaryInfo
    {
        public string Device { get; internal set; }
        public string Key { get; internal set; }
        public Binding Modifier { get; internal set; }
    }

    public partial class Xml
    {
        public string Version { get; internal set; }
        public string Encoding { get; internal set; }
    }
}
