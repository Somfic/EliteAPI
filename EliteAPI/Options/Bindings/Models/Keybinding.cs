using System.Collections.Generic;
using System.Xml.Serialization;

// Generated with https://json2csharp.com/xml-to-csharp
namespace EliteAPI.Options.Bindings.Models
{
    [XmlRoot(ElementName = "Root")]
    public class KeyBindings
    {
        internal KeyBindings() { }

        [XmlElement(ElementName = "KeyboardLayout")]
        public string KeyboardLayout { get; private set; }

        [XmlAttribute(AttributeName = "PresetName")]
        public string PresetName { get; private set; }

        [XmlAttribute(AttributeName = "MajorVersion")]
        public int MajorVersion { get; private set; }

        [XmlAttribute(AttributeName = "MinorVersion")]
        public int MinorVersion { get; private set; }

        [XmlText]
        public string Text { get; private set; }

        [XmlElement(ElementName = "MouseXMode")]
        public MouseXModeBinding MouseXMode { get; private set; }

        [XmlElement(ElementName = "MouseXDecay")]
        public MouseXDecayBinding MouseXDecay { get; private set; }

        [XmlElement(ElementName = "MouseYMode")]
        public MouseYModeBinding MouseYMode { get; private set; }

        [XmlElement(ElementName = "MouseYDecay")]
        public MouseYDecayBinding MouseYDecay { get; private set; }

        [XmlElement(ElementName = "MouseReset")]
        public MouseResetBinding MouseReset { get; private set; }

        [XmlElement(ElementName = "MouseSensitivity")]
        public MouseSensitivityBinding MouseSensitivity { get; private set; }

        [XmlElement(ElementName = "MouseDecayRate")]
        public MouseDecayRateBinding MouseDecayRate { get; private set; }

        [XmlElement(ElementName = "MouseDeadzone")]
        public MouseDeadzoneBinding MouseDeadzone { get; private set; }

        [XmlElement(ElementName = "MouseLinearity")]
        public MouseLinearityBinding MouseLinearity { get; private set; }

        [XmlElement(ElementName = "MouseGUI")]
        public IReadOnlyList<MouseGUIBinding> MouseGUI { get; private set; }

        [XmlElement(ElementName = "YawAxisRaw")]
        public YawAxisRawBinding YawAxisRaw { get; private set; }

        [XmlElement(ElementName = "YawLeftButton")]
        public YawLeftButtonBinding YawLeftButton { get; private set; }

        [XmlElement(ElementName = "YawRightButton")]
        public YawRightButtonBinding YawRightButton { get; private set; }

        [XmlElement(ElementName = "YawToRollMode")]
        public YawToRollModeBinding YawToRollMode { get; private set; }

        [XmlElement(ElementName = "YawToRollSensitivity")]
        public YawToRollSensitivityBinding YawToRollSensitivity { get; private set; }

        [XmlElement(ElementName = "YawToRollMode_FAOff")]
        public YawToRollModeFAOffBinding YawToRollModeFAOff { get; private set; }

        [XmlElement(ElementName = "YawToRollButton")]
        public YawToRollButtonBinding YawToRollButton { get; private set; }

        [XmlElement(ElementName = "RollAxisRaw")]
        public RollAxisRawBinding RollAxisRaw { get; private set; }

        [XmlElement(ElementName = "RollLeftButton")]
        public RollLeftButtonBinding RollLeftButton { get; private set; }

        [XmlElement(ElementName = "RollRightButton")]
        public RollRightButtonBinding RollRightButton { get; private set; }

        [XmlElement(ElementName = "PitchAxisRaw")]
        public PitchAxisRawBinding PitchAxisRaw { get; private set; }

        [XmlElement(ElementName = "PitchUpButton")]
        public PitchUpButtonBinding PitchUpButton { get; private set; }

        [XmlElement(ElementName = "PitchDownButton")]
        public PitchDownButtonBinding PitchDownButton { get; private set; }

        [XmlElement(ElementName = "LateralThrustRaw")]
        public LateralThrustRawBinding LateralThrustRaw { get; private set; }

        [XmlElement(ElementName = "LeftThrustButton")]
        public LeftThrustButtonBinding LeftThrustButton { get; private set; }

        [XmlElement(ElementName = "RightThrustButton")]
        public RightThrustButtonBinding RightThrustButton { get; private set; }

        [XmlElement(ElementName = "VerticalThrustRaw")]
        public VerticalThrustRawBinding VerticalThrustRaw { get; private set; }

        [XmlElement(ElementName = "UpThrustButton")]
        public UpThrustButtonBinding UpThrustButton { get; private set; }

        [XmlElement(ElementName = "DownThrustButton")]
        public DownThrustButtonBinding DownThrustButton { get; private set; }

        [XmlElement(ElementName = "AheadThrust")]
        public AheadThrustBinding AheadThrust { get; private set; }

        [XmlElement(ElementName = "ForwardThrustButton")]
        public ForwardThrustButtonBinding ForwardThrustButton { get; private set; }

        [XmlElement(ElementName = "BackwardThrustButton")]
        public BackwardThrustButtonBinding BackwardThrustButton { get; private set; }

        [XmlElement(ElementName = "UseAlternateFlightValuesToggle")]
        public UseAlternateFlightValuesToggleBinding UseAlternateFlightValuesToggle { get; private set; }

        [XmlElement(ElementName = "YawAxisAlternate")]
        public YawAxisAlternateBinding YawAxisAlternate { get; private set; }

        [XmlElement(ElementName = "RollAxisAlternate")]
        public RollAxisAlternateBinding RollAxisAlternate { get; private set; }

        [XmlElement(ElementName = "PitchAxisAlternate")]
        public PitchAxisAlternateBinding PitchAxisAlternate { get; private set; }

        [XmlElement(ElementName = "LateralThrustAlternate")]
        public LateralThrustAlternateBinding LateralThrustAlternate { get; private set; }

        [XmlElement(ElementName = "VerticalThrustAlternate")]
        public VerticalThrustAlternateBinding VerticalThrustAlternate { get; private set; }

        [XmlElement(ElementName = "ThrottleAxis")]
        public ThrottleAxisBinding ThrottleAxis { get; private set; }

        [XmlElement(ElementName = "ThrottleRange")]
        public ThrottleRangeBinding ThrottleRange { get; private set; }

        [XmlElement(ElementName = "ToggleReverseThrottleInput")]
        public ToggleReverseThrottleInputBinding ToggleReverseThrottleInput { get; private set; }

        [XmlElement(ElementName = "ForwardKey")]
        public ForwardKeyBinding ForwardKey { get; private set; }

        [XmlElement(ElementName = "BackwardKey")]
        public BackwardKeyBinding BackwardKey { get; private set; }

        [XmlElement(ElementName = "ThrottleIncrement")]
        public ThrottleIncrementBinding ThrottleIncrement { get; private set; }

        [XmlElement(ElementName = "SetSpeedMinus100")]
        public SetSpeedMinus100Binding SetSpeedMinus100 { get; private set; }

        [XmlElement(ElementName = "SetSpeedMinus75")]
        public SetSpeedMinus75Binding SetSpeedMinus75 { get; private set; }

        [XmlElement(ElementName = "SetSpeedMinus50")]
        public SetSpeedMinus50Binding SetSpeedMinus50 { get; private set; }

        [XmlElement(ElementName = "SetSpeedMinus25")]
        public SetSpeedMinus25Binding SetSpeedMinus25 { get; private set; }

        [XmlElement(ElementName = "SetSpeedZero")]
        public SetSpeedZeroBinding SetSpeedZero { get; private set; }

        [XmlElement(ElementName = "SetSpeed25")]
        public SetSpeed25Binding SetSpeed25 { get; private set; }

        [XmlElement(ElementName = "SetSpeed50")]
        public SetSpeed50Binding SetSpeed50 { get; private set; }

        [XmlElement(ElementName = "SetSpeed75")]
        public SetSpeed75Binding SetSpeed75 { get; private set; }

        [XmlElement(ElementName = "SetSpeed100")]
        public SetSpeed100Binding SetSpeed100 { get; private set; }

        [XmlElement(ElementName = "YawAxis_Landing")]
        public YawAxisLandingBinding YawAxisLanding { get; private set; }

        [XmlElement(ElementName = "YawLeftButton_Landing")]
        public YawLeftButtonLandingBinding YawLeftButtonLanding { get; private set; }

        [XmlElement(ElementName = "YawRightButton_Landing")]
        public YawRightButtonLandingBinding YawRightButtonLanding { get; private set; }

        [XmlElement(ElementName = "YawToRollMode_Landing")]
        public YawToRollModeLandingBinding YawToRollModeLanding { get; private set; }

        [XmlElement(ElementName = "PitchAxis_Landing")]
        public PitchAxisLandingBinding PitchAxisLanding { get; private set; }

        [XmlElement(ElementName = "PitchUpButton_Landing")]
        public PitchUpButtonLandingBinding PitchUpButtonLanding { get; private set; }

        [XmlElement(ElementName = "PitchDownButton_Landing")]
        public PitchDownButtonLandingBinding PitchDownButtonLanding { get; private set; }

        [XmlElement(ElementName = "RollAxis_Landing")]
        public RollAxisLandingBinding RollAxisLanding { get; private set; }

        [XmlElement(ElementName = "RollLeftButton_Landing")]
        public RollLeftButtonLandingBinding RollLeftButtonLanding { get; private set; }

        [XmlElement(ElementName = "RollRightButton_Landing")]
        public RollRightButtonLandingBinding RollRightButtonLanding { get; private set; }

        [XmlElement(ElementName = "LateralThrust_Landing")]
        public LateralThrustLandingBinding LateralThrustLanding { get; private set; }

        [XmlElement(ElementName = "LeftThrustButton_Landing")]
        public LeftThrustButtonLandingBinding LeftThrustButtonLanding { get; private set; }

        [XmlElement(ElementName = "RightThrustButton_Landing")]
        public RightThrustButtonLandingBinding RightThrustButtonLanding { get; private set; }

        [XmlElement(ElementName = "VerticalThrust_Landing")]
        public VerticalThrustLandingBinding VerticalThrustLanding { get; private set; }

        [XmlElement(ElementName = "UpThrustButton_Landing")]
        public UpThrustButtonLandingBinding UpThrustButtonLanding { get; private set; }

        [XmlElement(ElementName = "DownThrustButton_Landing")]
        public DownThrustButtonLandingBinding DownThrustButtonLanding { get; private set; }

        [XmlElement(ElementName = "AheadThrust_Landing")]
        public AheadThrustLandingBinding AheadThrustLanding { get; private set; }

        [XmlElement(ElementName = "ForwardThrustButton_Landing")]
        public ForwardThrustButtonLandingBinding ForwardThrustButtonLanding { get; private set; }

        [XmlElement(ElementName = "BackwardThrustButton_Landing")]
        public BackwardThrustButtonLandingBinding BackwardThrustButtonLanding { get; private set; }

        [XmlElement(ElementName = "ToggleFlightAssist")]
        public ToggleFlightAssistBinding ToggleFlightAssist { get; private set; }

        [XmlElement(ElementName = "UseBoostJuice")]
        public UseBoostJuiceBinding UseBoostJuice { get; private set; }

        [XmlElement(ElementName = "HyperSuperCombination")]
        public HyperSuperCombinationBinding HyperSuperCombination { get; private set; }

        [XmlElement(ElementName = "Supercruise")]
        public SupercruiseBinding Supercruise { get; private set; }

        [XmlElement(ElementName = "Hyperspace")]
        public HyperspaceBinding Hyperspace { get; private set; }

        [XmlElement(ElementName = "DisableRotationCorrectToggle")]
        public DisableRotationCorrectToggleBinding DisableRotationCorrectToggle { get; private set; }

        [XmlElement(ElementName = "OrbitLinesToggle")]
        public OrbitLinesToggleBinding OrbitLinesToggle { get; private set; }

        [XmlElement(ElementName = "SelectTarget")]
        public SelectTargetBinding SelectTarget { get; private set; }

        [XmlElement(ElementName = "CycleNextTarget")]
        public CycleNextTargetBinding CycleNextTarget { get; private set; }

        [XmlElement(ElementName = "CyclePreviousTarget")]
        public CyclePreviousTargetBinding CyclePreviousTarget { get; private set; }

        [XmlElement(ElementName = "SelectHighestThreat")]
        public SelectHighestThreatBinding SelectHighestThreat { get; private set; }

        [XmlElement(ElementName = "CycleNextHostileTarget")]
        public CycleNextHostileTargetBinding CycleNextHostileTarget { get; private set; }

        [XmlElement(ElementName = "CyclePreviousHostileTarget")]
        public CyclePreviousHostileTargetBinding CyclePreviousHostileTarget { get; private set; }

        [XmlElement(ElementName = "TargetWingman0")]
        public TargetWingman0Binding TargetWingman0 { get; private set; }

        [XmlElement(ElementName = "TargetWingman1")]
        public TargetWingman1Binding TargetWingman1 { get; private set; }

        [XmlElement(ElementName = "TargetWingman2")]
        public TargetWingman2Binding TargetWingman2 { get; private set; }

        [XmlElement(ElementName = "SelectTargetsTarget")]
        public SelectTargetsTargetBinding SelectTargetsTarget { get; private set; }

        [XmlElement(ElementName = "WingNavLock")]
        public WingNavLockBinding WingNavLock { get; private set; }

        [XmlElement(ElementName = "CycleNextSubsystem")]
        public CycleNextSubsystemBinding CycleNextSubsystem { get; private set; }

        [XmlElement(ElementName = "CyclePreviousSubsystem")]
        public CyclePreviousSubsystemBinding CyclePreviousSubsystem { get; private set; }

        [XmlElement(ElementName = "TargetNextRouteSystem")]
        public TargetNextRouteSystemBinding TargetNextRouteSystem { get; private set; }

        [XmlElement(ElementName = "PrimaryFire")]
        public PrimaryFireBinding PrimaryFire { get; private set; }

        [XmlElement(ElementName = "SecondaryFire")]
        public SecondaryFireBinding SecondaryFire { get; private set; }

        [XmlElement(ElementName = "CycleFireGroupNext")]
        public CycleFireGroupNextBinding CycleFireGroupNext { get; private set; }

        [XmlElement(ElementName = "CycleFireGroupPrevious")]
        public CycleFireGroupPreviousBinding CycleFireGroupPrevious { get; private set; }

        [XmlElement(ElementName = "DeployHardpointToggle")]
        public DeployHardpointToggleBinding DeployHardpointToggle { get; private set; }

        [XmlElement(ElementName = "DeployHardpointsOnFire")]
        public DeployHardpointsOnFireBinding DeployHardpointsOnFire { get; private set; }

        [XmlElement(ElementName = "ToggleButtonUpInput")]
        public ToggleButtonUpInputBinding ToggleButtonUpInput { get; private set; }

        [XmlElement(ElementName = "DeployHeatSink")]
        public DeployHeatSinkBinding DeployHeatSink { get; private set; }

        [XmlElement(ElementName = "ShipSpotLightToggle")]
        public ShipSpotLightToggleBinding ShipSpotLightToggle { get; private set; }

        [XmlElement(ElementName = "RadarRangeAxis")]
        public RadarRangeAxisBinding RadarRangeAxis { get; private set; }

        [XmlElement(ElementName = "RadarIncreaseRange")]
        public RadarIncreaseRangeBinding RadarIncreaseRange { get; private set; }

        [XmlElement(ElementName = "RadarDecreaseRange")]
        public RadarDecreaseRangeBinding RadarDecreaseRange { get; private set; }

        [XmlElement(ElementName = "IncreaseEnginesPower")]
        public IncreaseEnginesPowerBinding IncreaseEnginesPower { get; private set; }

        [XmlElement(ElementName = "IncreaseWeaponsPower")]
        public IncreaseWeaponsPowerBinding IncreaseWeaponsPower { get; private set; }

        [XmlElement(ElementName = "IncreaseSystemsPower")]
        public IncreaseSystemsPowerBinding IncreaseSystemsPower { get; private set; }

        [XmlElement(ElementName = "ResetPowerDistribution")]
        public ResetPowerDistributionBinding ResetPowerDistribution { get; private set; }

        [XmlElement(ElementName = "HMDReset")]
        public HMDResetBinding HMDReset { get; private set; }

        [XmlElement(ElementName = "ToggleCargoScoop")]
        public ToggleCargoScoopBinding ToggleCargoScoop { get; private set; }

        [XmlElement(ElementName = "EjectAllCargo")]
        public EjectAllCargoBinding EjectAllCargo { get; private set; }

        [XmlElement(ElementName = "LandingGearToggle")]
        public LandingGearToggleBinding LandingGearToggle { get; private set; }

        [XmlElement(ElementName = "MicrophoneMute")]
        public MicrophoneMuteBinding MicrophoneMute { get; private set; }

        [XmlElement(ElementName = "MuteButtonMode")]
        public MuteButtonModeBinding MuteButtonMode { get; private set; }

        [XmlElement(ElementName = "CqcMuteButtonMode")]
        public CqcMuteButtonModeBinding CqcMuteButtonMode { get; private set; }

        [XmlElement(ElementName = "UseShieldCell")]
        public UseShieldCellBinding UseShieldCell { get; private set; }

        [XmlElement(ElementName = "FireChaffLauncher")]
        public FireChaffLauncherBinding FireChaffLauncher { get; private set; }

        [XmlElement(ElementName = "ChargeECM")]
        public ChargeECMBinding ChargeECM { get; private set; }

        [XmlElement(ElementName = "EnableRumbleTrigger")]
        public EnableRumbleTriggerBinding EnableRumbleTrigger { get; private set; }

        [XmlElement(ElementName = "EnableMenuGroups")]
        public EnableMenuGroupsBinding EnableMenuGroups { get; private set; }

        [XmlElement(ElementName = "WeaponColourToggle")]
        public WeaponColourToggleBinding WeaponColourToggle { get; private set; }

        [XmlElement(ElementName = "EngineColourToggle")]
        public EngineColourToggleBinding EngineColourToggle { get; private set; }

        [XmlElement(ElementName = "NightVisionToggle")]
        public NightVisionToggleBinding NightVisionToggle { get; private set; }

        [XmlElement(ElementName = "UIFocus")]
        public UIFocusBinding UIFocus { get; private set; }

        [XmlElement(ElementName = "UIFocusMode")]
        public UIFocusModeBinding UIFocusMode { get; private set; }

        [XmlElement(ElementName = "FocusLeftPanel")]
        public FocusLeftPanelBinding FocusLeftPanel { get; private set; }

        [XmlElement(ElementName = "FocusCommsPanel")]
        public FocusCommsPanelBinding FocusCommsPanel { get; private set; }

        [XmlElement(ElementName = "FocusOnTextEntryField")]
        public FocusOnTextEntryFieldBinding FocusOnTextEntryField { get; private set; }

        [XmlElement(ElementName = "QuickCommsPanel")]
        public QuickCommsPanelBinding QuickCommsPanel { get; private set; }

        [XmlElement(ElementName = "FocusRadarPanel")]
        public FocusRadarPanelBinding FocusRadarPanel { get; private set; }

        [XmlElement(ElementName = "FocusRightPanel")]
        public FocusRightPanelBinding FocusRightPanel { get; private set; }

        [XmlElement(ElementName = "LeftPanelFocusOptions")]
        public LeftPanelFocusOptionsBinding LeftPanelFocusOptions { get; private set; }

        [XmlElement(ElementName = "CommsPanelFocusOptions")]
        public CommsPanelFocusOptionsBinding CommsPanelFocusOptions { get; private set; }

        [XmlElement(ElementName = "RolePanelFocusOptions")]
        public RolePanelFocusOptionsBinding RolePanelFocusOptions { get; private set; }

        [XmlElement(ElementName = "RightPanelFocusOptions")]
        public RightPanelFocusOptionsBinding RightPanelFocusOptions { get; private set; }

        [XmlElement(ElementName = "EnableCameraLockOn")]
        public EnableCameraLockOnBinding EnableCameraLockOn { get; private set; }

        [XmlElement(ElementName = "GalaxyMapOpen")]
        public GalaxyMapOpenBinding GalaxyMapOpen { get; private set; }

        [XmlElement(ElementName = "SystemMapOpen")]
        public SystemMapOpenBinding SystemMapOpen { get; private set; }

        [XmlElement(ElementName = "ShowPGScoreSummaryInput")]
        public ShowPGScoreSummaryInputBinding ShowPGScoreSummaryInput { get; private set; }

        [XmlElement(ElementName = "HeadLookToggle")]
        public HeadLookToggleBinding HeadLookToggle { get; private set; }

        [XmlElement(ElementName = "Pause")]
        public PauseBinding Pause { get; private set; }

        [XmlElement(ElementName = "FriendsMenu")]
        public FriendsMenuBinding FriendsMenu { get; private set; }

        [XmlElement(ElementName = "OpenCodexGoToDiscovery")]
        public OpenCodexGoToDiscoveryBinding OpenCodexGoToDiscovery { get; private set; }

        [XmlElement(ElementName = "PlayerHUDModeToggle")]
        public PlayerHUDModeToggleBinding PlayerHUDModeToggle { get; private set; }

        [XmlElement(ElementName = "ExplorationFSSEnter")]
        public ExplorationFSSEnterBinding ExplorationFSSEnter { get; private set; }

        [XmlElement(ElementName = "UI_Up")]
        public UIUpBinding UIUp { get; private set; }

        [XmlElement(ElementName = "UI_Down")]
        public UIDownBinding UIDown { get; private set; }

        [XmlElement(ElementName = "UI_Left")]
        public UILeftBinding UILeft { get; private set; }

        [XmlElement(ElementName = "UI_Right")]
        public UIRightBinding UIRight { get; private set; }

        [XmlElement(ElementName = "UI_Select")]
        public UISelectBinding UISelect { get; private set; }

        [XmlElement(ElementName = "UI_Back")]
        public UIBackBinding UIBack { get; private set; }

        [XmlElement(ElementName = "UI_Toggle")]
        public UIToggleBinding UIToggle { get; private set; }

        [XmlElement(ElementName = "CycleNextPanel")]
        public CycleNextPanelBinding CycleNextPanel { get; private set; }

        [XmlElement(ElementName = "CyclePreviousPanel")]
        public CyclePreviousPanelBinding CyclePreviousPanel { get; private set; }

        [XmlElement(ElementName = "CycleNextPage")]
        public CycleNextPageBinding CycleNextPage { get; private set; }

        [XmlElement(ElementName = "CyclePreviousPage")]
        public CyclePreviousPageBinding CyclePreviousPage { get; private set; }

        [XmlElement(ElementName = "MouseHeadlook")]
        public MouseHeadlookBinding MouseHeadlook { get; private set; }

        [XmlElement(ElementName = "MouseHeadlookInvert")]
        public MouseHeadlookInvertBinding MouseHeadlookInvert { get; private set; }

        [XmlElement(ElementName = "MouseHeadlookSensitivity")]
        public MouseHeadlookSensitivityBinding MouseHeadlookSensitivity { get; private set; }

        [XmlElement(ElementName = "HeadlookDefault")]
        public HeadlookDefaultBinding HeadlookDefault { get; private set; }

        [XmlElement(ElementName = "HeadlookIncrement")]
        public HeadlookIncrementBinding HeadlookIncrement { get; private set; }

        [XmlElement(ElementName = "HeadlookMode")]
        public HeadlookModeBinding HeadlookMode { get; private set; }

        [XmlElement(ElementName = "HeadlookResetOnToggle")]
        public HeadlookResetOnToggleBinding HeadlookResetOnToggle { get; private set; }

        [XmlElement(ElementName = "HeadlookSensitivity")]
        public HeadlookSensitivityBinding HeadlookSensitivity { get; private set; }

        [XmlElement(ElementName = "HeadlookSmoothing")]
        public HeadlookSmoothingBinding HeadlookSmoothing { get; private set; }

        [XmlElement(ElementName = "HeadLookReset")]
        public HeadLookResetBinding HeadLookReset { get; private set; }

        [XmlElement(ElementName = "HeadLookPitchUp")]
        public HeadLookPitchUpBinding HeadLookPitchUp { get; private set; }

        [XmlElement(ElementName = "HeadLookPitchDown")]
        public HeadLookPitchDownBinding HeadLookPitchDown { get; private set; }

        [XmlElement(ElementName = "HeadLookPitchAxisRaw")]
        public HeadLookPitchAxisRawBinding HeadLookPitchAxisRaw { get; private set; }

        [XmlElement(ElementName = "HeadLookYawLeft")]
        public HeadLookYawLeftBinding HeadLookYawLeft { get; private set; }

        [XmlElement(ElementName = "HeadLookYawRight")]
        public HeadLookYawRightBinding HeadLookYawRight { get; private set; }

        [XmlElement(ElementName = "HeadLookYawAxis")]
        public HeadLookYawAxisBinding HeadLookYawAxis { get; private set; }

        [XmlElement(ElementName = "MotionHeadlook")]
        public MotionHeadlookBinding MotionHeadlook { get; private set; }

        [XmlElement(ElementName = "HeadlookMotionSensitivity")]
        public HeadlookMotionSensitivityBinding HeadlookMotionSensitivity { get; private set; }

        [XmlElement(ElementName = "yawRotateHeadlook")]
        public YawRotateHeadlookBinding YawRotateHeadlook { get; private set; }

        [XmlElement(ElementName = "CamPitchAxis")]
        public CamPitchAxisBinding CamPitchAxis { get; private set; }

        [XmlElement(ElementName = "CamPitchUp")]
        public CamPitchUpBinding CamPitchUp { get; private set; }

        [XmlElement(ElementName = "CamPitchDown")]
        public CamPitchDownBinding CamPitchDown { get; private set; }

        [XmlElement(ElementName = "CamYawAxis")]
        public CamYawAxisBinding CamYawAxis { get; private set; }

        [XmlElement(ElementName = "CamYawLeft")]
        public CamYawLeftBinding CamYawLeft { get; private set; }

        [XmlElement(ElementName = "CamYawRight")]
        public CamYawRightBinding CamYawRight { get; private set; }

        [XmlElement(ElementName = "CamTranslateYAxis")]
        public CamTranslateYAxisBinding CamTranslateYAxis { get; private set; }

        [XmlElement(ElementName = "CamTranslateForward")]
        public CamTranslateForwardBinding CamTranslateForward { get; private set; }

        [XmlElement(ElementName = "CamTranslateBackward")]
        public CamTranslateBackwardBinding CamTranslateBackward { get; private set; }

        [XmlElement(ElementName = "CamTranslateXAxis")]
        public CamTranslateXAxisBinding CamTranslateXAxis { get; private set; }

        [XmlElement(ElementName = "CamTranslateLeft")]
        public CamTranslateLeftBinding CamTranslateLeft { get; private set; }

        [XmlElement(ElementName = "CamTranslateRight")]
        public CamTranslateRightBinding CamTranslateRight { get; private set; }

        [XmlElement(ElementName = "CamTranslateZAxis")]
        public CamTranslateZAxisBinding CamTranslateZAxis { get; private set; }

        [XmlElement(ElementName = "CamTranslateUp")]
        public CamTranslateUpBinding CamTranslateUp { get; private set; }

        [XmlElement(ElementName = "CamTranslateDown")]
        public CamTranslateDownBinding CamTranslateDown { get; private set; }

        [XmlElement(ElementName = "CamZoomAxis")]
        public CamZoomAxisBinding CamZoomAxis { get; private set; }

        [XmlElement(ElementName = "CamZoomIn")]
        public CamZoomInBinding CamZoomIn { get; private set; }

        [XmlElement(ElementName = "CamZoomOut")]
        public CamZoomOutBinding CamZoomOut { get; private set; }

        [XmlElement(ElementName = "CamTranslateZHold")]
        public CamTranslateZHoldBinding CamTranslateZHold { get; private set; }

        [XmlElement(ElementName = "GalaxyMapHome")]
        public GalaxyMapHomeBinding GalaxyMapHome { get; private set; }

        [XmlElement(ElementName = "ToggleDriveAssist")]
        public ToggleDriveAssistBinding ToggleDriveAssist { get; private set; }

        [XmlElement(ElementName = "DriveAssistDefault")]
        public DriveAssistDefaultBinding DriveAssistDefault { get; private set; }

        [XmlElement(ElementName = "MouseBuggySteeringXMode")]
        public MouseBuggySteeringXModeBinding MouseBuggySteeringXMode { get; private set; }

        [XmlElement(ElementName = "MouseBuggySteeringXDecay")]
        public MouseBuggySteeringXDecayBinding MouseBuggySteeringXDecay { get; private set; }

        [XmlElement(ElementName = "MouseBuggyRollingXMode")]
        public MouseBuggyRollingXModeBinding MouseBuggyRollingXMode { get; private set; }

        [XmlElement(ElementName = "MouseBuggyRollingXDecay")]
        public MouseBuggyRollingXDecayBinding MouseBuggyRollingXDecay { get; private set; }

        [XmlElement(ElementName = "MouseBuggyYMode")]
        public MouseBuggyYModeBinding MouseBuggyYMode { get; private set; }

        [XmlElement(ElementName = "MouseBuggyYDecay")]
        public MouseBuggyYDecayBinding MouseBuggyYDecay { get; private set; }

        [XmlElement(ElementName = "SteeringAxis")]
        public SteeringAxisBinding SteeringAxis { get; private set; }

        [XmlElement(ElementName = "SteerLeftButton")]
        public SteerLeftButtonBinding SteerLeftButton { get; private set; }

        [XmlElement(ElementName = "SteerRightButton")]
        public SteerRightButtonBinding SteerRightButton { get; private set; }

        [XmlElement(ElementName = "BuggyRollAxisRaw")]
        public BuggyRollAxisRawBinding BuggyRollAxisRaw { get; private set; }

        [XmlElement(ElementName = "BuggyRollLeftButton")]
        public BuggyRollLeftButtonBinding BuggyRollLeftButton { get; private set; }

        [XmlElement(ElementName = "BuggyRollRightButton")]
        public BuggyRollRightButtonBinding BuggyRollRightButton { get; private set; }

        [XmlElement(ElementName = "BuggyPitchAxis")]
        public BuggyPitchAxisBinding BuggyPitchAxis { get; private set; }

        [XmlElement(ElementName = "BuggyPitchUpButton")]
        public BuggyPitchUpButtonBinding BuggyPitchUpButton { get; private set; }

        [XmlElement(ElementName = "BuggyPitchDownButton")]
        public BuggyPitchDownButtonBinding BuggyPitchDownButton { get; private set; }

        [XmlElement(ElementName = "VerticalThrustersButton")]
        public VerticalThrustersButtonBinding VerticalThrustersButton { get; private set; }

        [XmlElement(ElementName = "BuggyPrimaryFireButton")]
        public BuggyPrimaryFireButtonBinding BuggyPrimaryFireButton { get; private set; }

        [XmlElement(ElementName = "BuggySecondaryFireButton")]
        public BuggySecondaryFireButtonBinding BuggySecondaryFireButton { get; private set; }

        [XmlElement(ElementName = "AutoBreakBuggyButton")]
        public AutoBreakBuggyButtonBinding AutoBreakBuggyButton { get; private set; }

        [XmlElement(ElementName = "HeadlightsBuggyButton")]
        public HeadlightsBuggyButtonBinding HeadlightsBuggyButton { get; private set; }

        [XmlElement(ElementName = "ToggleBuggyTurretButton")]
        public ToggleBuggyTurretButtonBinding ToggleBuggyTurretButton { get; private set; }

        [XmlElement(ElementName = "BuggyCycleFireGroupNext")]
        public BuggyCycleFireGroupNextBinding BuggyCycleFireGroupNext { get; private set; }

        [XmlElement(ElementName = "BuggyCycleFireGroupPrevious")]
        public BuggyCycleFireGroupPreviousBinding BuggyCycleFireGroupPrevious { get; private set; }

        [XmlElement(ElementName = "SelectTarget_Buggy")]
        public SelectTargetBuggyBinding SelectTargetBuggy { get; private set; }

        [XmlElement(ElementName = "MouseTurretXMode")]
        public MouseTurretXModeBinding MouseTurretXMode { get; private set; }

        [XmlElement(ElementName = "MouseTurretXDecay")]
        public MouseTurretXDecayBinding MouseTurretXDecay { get; private set; }

        [XmlElement(ElementName = "MouseTurretYMode")]
        public MouseTurretYModeBinding MouseTurretYMode { get; private set; }

        [XmlElement(ElementName = "MouseTurretYDecay")]
        public MouseTurretYDecayBinding MouseTurretYDecay { get; private set; }

        [XmlElement(ElementName = "BuggyTurretYawAxisRaw")]
        public BuggyTurretYawAxisRawBinding BuggyTurretYawAxisRaw { get; private set; }

        [XmlElement(ElementName = "BuggyTurretYawLeftButton")]
        public BuggyTurretYawLeftButtonBinding BuggyTurretYawLeftButton { get; private set; }

        [XmlElement(ElementName = "BuggyTurretYawRightButton")]
        public BuggyTurretYawRightButtonBinding BuggyTurretYawRightButton { get; private set; }

        [XmlElement(ElementName = "BuggyTurretPitchAxisRaw")]
        public BuggyTurretPitchAxisRawBinding BuggyTurretPitchAxisRaw { get; private set; }

        [XmlElement(ElementName = "BuggyTurretPitchUpButton")]
        public BuggyTurretPitchUpButtonBinding BuggyTurretPitchUpButton { get; private set; }

        [XmlElement(ElementName = "BuggyTurretPitchDownButton")]
        public BuggyTurretPitchDownButtonBinding BuggyTurretPitchDownButton { get; private set; }

        [XmlElement(ElementName = "BuggyTurretMouseSensitivity")]
        public BuggyTurretMouseSensitivityBinding BuggyTurretMouseSensitivity { get; private set; }

        [XmlElement(ElementName = "BuggyTurretMouseDeadzone")]
        public BuggyTurretMouseDeadzoneBinding BuggyTurretMouseDeadzone { get; private set; }

        [XmlElement(ElementName = "BuggyTurretMouseLinearity")]
        public BuggyTurretMouseLinearityBinding BuggyTurretMouseLinearity { get; private set; }

        [XmlElement(ElementName = "DriveSpeedAxis")]
        public DriveSpeedAxisBinding DriveSpeedAxis { get; private set; }

        [XmlElement(ElementName = "BuggyThrottleRange")]
        public BuggyThrottleRangeBinding BuggyThrottleRange { get; private set; }

        [XmlElement(ElementName = "BuggyToggleReverseThrottleInput")]
        public BuggyToggleReverseThrottleInputBinding BuggyToggleReverseThrottleInput { get; private set; }

        [XmlElement(ElementName = "BuggyThrottleIncrement")]
        public BuggyThrottleIncrementBinding BuggyThrottleIncrement { get; private set; }

        [XmlElement(ElementName = "IncreaseSpeedButtonMax")]
        public IncreaseSpeedButtonMaxBinding IncreaseSpeedButtonMax { get; private set; }

        [XmlElement(ElementName = "DecreaseSpeedButtonMax")]
        public DecreaseSpeedButtonMaxBinding DecreaseSpeedButtonMax { get; private set; }

        [XmlElement(ElementName = "IncreaseSpeedButtonPartial")]
        public IncreaseSpeedButtonPartialBinding IncreaseSpeedButtonPartial { get; private set; }

        [XmlElement(ElementName = "DecreaseSpeedButtonPartial")]
        public DecreaseSpeedButtonPartialBinding DecreaseSpeedButtonPartial { get; private set; }

        [XmlElement(ElementName = "IncreaseEnginesPower_Buggy")]
        public IncreaseEnginesPowerBuggyBinding IncreaseEnginesPowerBuggy { get; private set; }

        [XmlElement(ElementName = "IncreaseWeaponsPower_Buggy")]
        public IncreaseWeaponsPowerBuggyBinding IncreaseWeaponsPowerBuggy { get; private set; }

        [XmlElement(ElementName = "IncreaseSystemsPower_Buggy")]
        public IncreaseSystemsPowerBuggyBinding IncreaseSystemsPowerBuggy { get; private set; }

        [XmlElement(ElementName = "ResetPowerDistribution_Buggy")]
        public ResetPowerDistributionBuggyBinding ResetPowerDistributionBuggy { get; private set; }

        [XmlElement(ElementName = "ToggleCargoScoop_Buggy")]
        public ToggleCargoScoopBuggyBinding ToggleCargoScoopBuggy { get; private set; }

        [XmlElement(ElementName = "EjectAllCargo_Buggy")]
        public EjectAllCargoBuggyBinding EjectAllCargoBuggy { get; private set; }

        [XmlElement(ElementName = "RecallDismissShip")]
        public RecallDismissShipBinding RecallDismissShip { get; private set; }

        [XmlElement(ElementName = "UIFocus_Buggy")]
        public UIFocusBuggyBinding UIFocusBuggy { get; private set; }

        [XmlElement(ElementName = "FocusLeftPanel_Buggy")]
        public FocusLeftPanelBuggyBinding FocusLeftPanelBuggy { get; private set; }

        [XmlElement(ElementName = "FocusCommsPanel_Buggy")]
        public FocusCommsPanelBuggyBinding FocusCommsPanelBuggy { get; private set; }

        [XmlElement(ElementName = "QuickCommsPanel_Buggy")]
        public QuickCommsPanelBuggyBinding QuickCommsPanelBuggy { get; private set; }

        [XmlElement(ElementName = "FocusRadarPanel_Buggy")]
        public FocusRadarPanelBuggyBinding FocusRadarPanelBuggy { get; private set; }

        [XmlElement(ElementName = "FocusRightPanel_Buggy")]
        public FocusRightPanelBuggyBinding FocusRightPanelBuggy { get; private set; }

        [XmlElement(ElementName = "GalaxyMapOpen_Buggy")]
        public GalaxyMapOpenBuggyBinding GalaxyMapOpenBuggy { get; private set; }

        [XmlElement(ElementName = "SystemMapOpen_Buggy")]
        public SystemMapOpenBuggyBinding SystemMapOpenBuggy { get; private set; }

        [XmlElement(ElementName = "OpenCodexGoToDiscovery_Buggy")]
        public OpenCodexGoToDiscoveryBuggyBinding OpenCodexGoToDiscoveryBuggy { get; private set; }

        [XmlElement(ElementName = "PlayerHUDModeToggle_Buggy")]
        public PlayerHUDModeToggleBuggyBinding PlayerHUDModeToggleBuggy { get; private set; }

        [XmlElement(ElementName = "HeadLookToggle_Buggy")]
        public HeadLookToggleBuggyBinding HeadLookToggleBuggy { get; private set; }

        [XmlElement(ElementName = "MultiCrewToggleMode")]
        public MultiCrewToggleModeBinding MultiCrewToggleMode { get; private set; }

        [XmlElement(ElementName = "MultiCrewPrimaryFire")]
        public MultiCrewPrimaryFireBinding MultiCrewPrimaryFire { get; private set; }

        [XmlElement(ElementName = "MultiCrewSecondaryFire")]
        public MultiCrewSecondaryFireBinding MultiCrewSecondaryFire { get; private set; }

        [XmlElement(ElementName = "MultiCrewPrimaryUtilityFire")]
        public MultiCrewPrimaryUtilityFireBinding MultiCrewPrimaryUtilityFire { get; private set; }

        [XmlElement(ElementName = "MultiCrewSecondaryUtilityFire")]
        public MultiCrewSecondaryUtilityFireBinding MultiCrewSecondaryUtilityFire { get; private set; }

        [XmlElement(ElementName = "MultiCrewThirdPersonMouseXMode")]
        public MultiCrewThirdPersonMouseXModeBinding MultiCrewThirdPersonMouseXMode { get; private set; }

        [XmlElement(ElementName = "MultiCrewThirdPersonMouseXDecay")]
        public MultiCrewThirdPersonMouseXDecayBinding MultiCrewThirdPersonMouseXDecay { get; private set; }

        [XmlElement(ElementName = "MultiCrewThirdPersonMouseYMode")]
        public MultiCrewThirdPersonMouseYModeBinding MultiCrewThirdPersonMouseYMode { get; private set; }

        [XmlElement(ElementName = "MultiCrewThirdPersonMouseYDecay")]
        public MultiCrewThirdPersonMouseYDecayBinding MultiCrewThirdPersonMouseYDecay { get; private set; }

        [XmlElement(ElementName = "MultiCrewThirdPersonYawAxisRaw")]
        public MultiCrewThirdPersonYawAxisRawBinding MultiCrewThirdPersonYawAxisRaw { get; private set; }

        [XmlElement(ElementName = "MultiCrewThirdPersonYawLeftButton")]
        public MultiCrewThirdPersonYawLeftButtonBinding MultiCrewThirdPersonYawLeftButton { get; private set; }

        [XmlElement(ElementName = "MultiCrewThirdPersonYawRightButton")]
        public MultiCrewThirdPersonYawRightButtonBinding MultiCrewThirdPersonYawRightButton { get; private set; }

        [XmlElement(ElementName = "MultiCrewThirdPersonPitchAxisRaw")]
        public MultiCrewThirdPersonPitchAxisRawBinding MultiCrewThirdPersonPitchAxisRaw { get; private set; }

        [XmlElement(ElementName = "MultiCrewThirdPersonPitchUpButton")]
        public MultiCrewThirdPersonPitchUpButtonBinding MultiCrewThirdPersonPitchUpButton { get; private set; }

        [XmlElement(ElementName = "MultiCrewThirdPersonPitchDownButton")]
        public MultiCrewThirdPersonPitchDownButtonBinding MultiCrewThirdPersonPitchDownButton { get; private set; }

        [XmlElement(ElementName = "MultiCrewThirdPersonMouseSensitivity")]
        public MultiCrewThirdPersonMouseSensitivityBinding MultiCrewThirdPersonMouseSensitivity { get; private set; }

        [XmlElement(ElementName = "MultiCrewThirdPersonFovAxisRaw")]
        public MultiCrewThirdPersonFovAxisRawBinding MultiCrewThirdPersonFovAxisRaw { get; private set; }

        [XmlElement(ElementName = "MultiCrewThirdPersonFovOutButton")]
        public MultiCrewThirdPersonFovOutButtonBinding MultiCrewThirdPersonFovOutButton { get; private set; }

        [XmlElement(ElementName = "MultiCrewThirdPersonFovInButton")]
        public MultiCrewThirdPersonFovInButtonBinding MultiCrewThirdPersonFovInButton { get; private set; }

        [XmlElement(ElementName = "MultiCrewCockpitUICycleForward")]
        public MultiCrewCockpitUICycleForwardBinding MultiCrewCockpitUICycleForward { get; private set; }

        [XmlElement(ElementName = "MultiCrewCockpitUICycleBackward")]
        public MultiCrewCockpitUICycleBackwardBinding MultiCrewCockpitUICycleBackward { get; private set; }

        [XmlElement(ElementName = "OrderRequestDock")]
        public OrderRequestDockBinding OrderRequestDock { get; private set; }

        [XmlElement(ElementName = "OrderDefensiveBehaviour")]
        public OrderDefensiveBehaviourBinding OrderDefensiveBehaviour { get; private set; }

        [XmlElement(ElementName = "OrderAggressiveBehaviour")]
        public OrderAggressiveBehaviourBinding OrderAggressiveBehaviour { get; private set; }

        [XmlElement(ElementName = "OrderFocusTarget")]
        public OrderFocusTargetBinding OrderFocusTarget { get; private set; }

        [XmlElement(ElementName = "OrderHoldFire")]
        public OrderHoldFireBinding OrderHoldFire { get; private set; }

        [XmlElement(ElementName = "OrderHoldPosition")]
        public OrderHoldPositionBinding OrderHoldPosition { get; private set; }

        [XmlElement(ElementName = "OrderFollow")]
        public OrderFollowBinding OrderFollow { get; private set; }

        [XmlElement(ElementName = "OpenOrders")]
        public OpenOrdersBinding OpenOrders { get; private set; }

        [XmlElement(ElementName = "PhotoCameraToggle")]
        public PhotoCameraToggleBinding PhotoCameraToggle { get; private set; }

        [XmlElement(ElementName = "PhotoCameraToggle_Buggy")]
        public PhotoCameraToggleBuggyBinding PhotoCameraToggleBuggy { get; private set; }

        [XmlElement(ElementName = "VanityCameraScrollLeft")]
        public VanityCameraScrollLeftBinding VanityCameraScrollLeft { get; private set; }

        [XmlElement(ElementName = "VanityCameraScrollRight")]
        public VanityCameraScrollRightBinding VanityCameraScrollRight { get; private set; }

        [XmlElement(ElementName = "ToggleFreeCam")]
        public ToggleFreeCamBinding ToggleFreeCam { get; private set; }

        [XmlElement(ElementName = "VanityCameraOne")]
        public VanityCameraOneBinding VanityCameraOne { get; private set; }

        [XmlElement(ElementName = "VanityCameraTwo")]
        public VanityCameraTwoBinding VanityCameraTwo { get; private set; }

        [XmlElement(ElementName = "VanityCameraThree")]
        public VanityCameraThreeBinding VanityCameraThree { get; private set; }

        [XmlElement(ElementName = "VanityCameraFour")]
        public VanityCameraFourBinding VanityCameraFour { get; private set; }

        [XmlElement(ElementName = "VanityCameraFive")]
        public VanityCameraFiveBinding VanityCameraFive { get; private set; }

        [XmlElement(ElementName = "VanityCameraSix")]
        public VanityCameraSixBinding VanityCameraSix { get; private set; }

        [XmlElement(ElementName = "VanityCameraSeven")]
        public VanityCameraSevenBinding VanityCameraSeven { get; private set; }

        [XmlElement(ElementName = "VanityCameraEight")]
        public VanityCameraEightBinding VanityCameraEight { get; private set; }

        [XmlElement(ElementName = "VanityCameraNine")]
        public VanityCameraNineBinding VanityCameraNine { get; private set; }

        [XmlElement(ElementName = "FreeCamToggleHUD")]
        public FreeCamToggleHUDBinding FreeCamToggleHUD { get; private set; }

        [XmlElement(ElementName = "FreeCamSpeedInc")]
        public FreeCamSpeedIncBinding FreeCamSpeedInc { get; private set; }

        [XmlElement(ElementName = "FreeCamSpeedDec")]
        public FreeCamSpeedDecBinding FreeCamSpeedDec { get; private set; }

        [XmlElement(ElementName = "MoveFreeCamY")]
        public MoveFreeCamYBinding MoveFreeCamY { get; private set; }

        [XmlElement(ElementName = "ThrottleRangeFreeCam")]
        public ThrottleRangeFreeCamBinding ThrottleRangeFreeCam { get; private set; }

        [XmlElement(ElementName = "ToggleReverseThrottleInputFreeCam")]
        public ToggleReverseThrottleInputFreeCamBinding ToggleReverseThrottleInputFreeCam { get; private set; }

        [XmlElement(ElementName = "MoveFreeCamForward")]
        public MoveFreeCamForwardBinding MoveFreeCamForward { get; private set; }

        [XmlElement(ElementName = "MoveFreeCamBackwards")]
        public MoveFreeCamBackwardsBinding MoveFreeCamBackwards { get; private set; }

        [XmlElement(ElementName = "MoveFreeCamX")]
        public MoveFreeCamXBinding MoveFreeCamX { get; private set; }

        [XmlElement(ElementName = "MoveFreeCamRight")]
        public MoveFreeCamRightBinding MoveFreeCamRight { get; private set; }

        [XmlElement(ElementName = "MoveFreeCamLeft")]
        public MoveFreeCamLeftBinding MoveFreeCamLeft { get; private set; }

        [XmlElement(ElementName = "MoveFreeCamZ")]
        public MoveFreeCamZBinding MoveFreeCamZ { get; private set; }

        [XmlElement(ElementName = "MoveFreeCamUpAxis")]
        public MoveFreeCamUpAxisBinding MoveFreeCamUpAxis { get; private set; }

        [XmlElement(ElementName = "MoveFreeCamDownAxis")]
        public MoveFreeCamDownAxisBinding MoveFreeCamDownAxis { get; private set; }

        [XmlElement(ElementName = "MoveFreeCamUp")]
        public MoveFreeCamUpBinding MoveFreeCamUp { get; private set; }

        [XmlElement(ElementName = "MoveFreeCamDown")]
        public MoveFreeCamDownBinding MoveFreeCamDown { get; private set; }

        [XmlElement(ElementName = "PitchCameraMouse")]
        public PitchCameraMouseBinding PitchCameraMouse { get; private set; }

        [XmlElement(ElementName = "YawCameraMouse")]
        public YawCameraMouseBinding YawCameraMouse { get; private set; }

        [XmlElement(ElementName = "PitchCamera")]
        public PitchCameraBinding PitchCamera { get; private set; }

        [XmlElement(ElementName = "FreeCamMouseSensitivity")]
        public FreeCamMouseSensitivityBinding FreeCamMouseSensitivity { get; private set; }

        [XmlElement(ElementName = "FreeCamMouseYDecay")]
        public FreeCamMouseYDecayBinding FreeCamMouseYDecay { get; private set; }

        [XmlElement(ElementName = "PitchCameraUp")]
        public PitchCameraUpBinding PitchCameraUp { get; private set; }

        [XmlElement(ElementName = "PitchCameraDown")]
        public PitchCameraDownBinding PitchCameraDown { get; private set; }

        [XmlElement(ElementName = "YawCamera")]
        public YawCameraBinding YawCamera { get; private set; }

        [XmlElement(ElementName = "FreeCamMouseXDecay")]
        public FreeCamMouseXDecayBinding FreeCamMouseXDecay { get; private set; }

        [XmlElement(ElementName = "YawCameraLeft")]
        public YawCameraLeftBinding YawCameraLeft { get; private set; }

        [XmlElement(ElementName = "YawCameraRight")]
        public YawCameraRightBinding YawCameraRight { get; private set; }

        [XmlElement(ElementName = "RollCamera")]
        public RollCameraBinding RollCamera { get; private set; }

        [XmlElement(ElementName = "RollCameraLeft")]
        public RollCameraLeftBinding RollCameraLeft { get; private set; }

        [XmlElement(ElementName = "RollCameraRight")]
        public RollCameraRightBinding RollCameraRight { get; private set; }

        [XmlElement(ElementName = "ToggleRotationLock")]
        public ToggleRotationLockBinding ToggleRotationLock { get; private set; }

        [XmlElement(ElementName = "FixCameraRelativeToggle")]
        public FixCameraRelativeToggleBinding FixCameraRelativeToggle { get; private set; }

        [XmlElement(ElementName = "FixCameraWorldToggle")]
        public FixCameraWorldToggleBinding FixCameraWorldToggle { get; private set; }

        [XmlElement(ElementName = "QuitCamera")]
        public QuitCameraBinding QuitCamera { get; private set; }

        [XmlElement(ElementName = "ToggleAdvanceMode")]
        public ToggleAdvanceModeBinding ToggleAdvanceMode { get; private set; }

        [XmlElement(ElementName = "FreeCamZoomIn")]
        public FreeCamZoomInBinding FreeCamZoomIn { get; private set; }

        [XmlElement(ElementName = "FreeCamZoomOut")]
        public FreeCamZoomOutBinding FreeCamZoomOut { get; private set; }

        [XmlElement(ElementName = "FStopDec")]
        public FStopDecBinding FStopDec { get; private set; }

        [XmlElement(ElementName = "FStopInc")]
        public FStopIncBinding FStopInc { get; private set; }

        [XmlElement(ElementName = "StoreEnableRotation")]
        public StoreEnableRotationBinding StoreEnableRotation { get; private set; }

        [XmlElement(ElementName = "StorePitchCamera")]
        public StorePitchCameraBinding StorePitchCamera { get; private set; }

        [XmlElement(ElementName = "StoreYawCamera")]
        public StoreYawCameraBinding StoreYawCamera { get; private set; }

        [XmlElement(ElementName = "StoreCamZoomIn")]
        public StoreCamZoomInBinding StoreCamZoomIn { get; private set; }

        [XmlElement(ElementName = "StoreCamZoomOut")]
        public StoreCamZoomOutBinding StoreCamZoomOut { get; private set; }

        [XmlElement(ElementName = "StoreToggle")]
        public StoreToggleBinding StoreToggle { get; private set; }

        [XmlElement(ElementName = "CommanderCreator_Undo")]
        public CommanderCreatorUndoBinding CommanderCreatorUndo { get; private set; }

        [XmlElement(ElementName = "CommanderCreator_Redo")]
        public CommanderCreatorRedoBinding CommanderCreatorRedo { get; private set; }

        [XmlElement(ElementName = "CommanderCreator_Rotation_MouseToggle")]
        public CommanderCreatorRotationMouseToggleBinding CommanderCreatorRotationMouseToggle { get; private set; }

        [XmlElement(ElementName = "CommanderCreator_Rotation")]
        public CommanderCreatorRotationBinding CommanderCreatorRotation { get; private set; }

        [XmlElement(ElementName = "GalnetAudio_Play_Pause")]
        public GalnetAudioPlayPauseBinding GalnetAudioPlayPause { get; private set; }

        [XmlElement(ElementName = "GalnetAudio_SkipForward")]
        public GalnetAudioSkipForwardBinding GalnetAudioSkipForward { get; private set; }

        [XmlElement(ElementName = "GalnetAudio_SkipBackward")]
        public GalnetAudioSkipBackwardBinding GalnetAudioSkipBackward { get; private set; }

        [XmlElement(ElementName = "GalnetAudio_ClearQueue")]
        public GalnetAudioClearQueueBinding GalnetAudioClearQueue { get; private set; }

        [XmlElement(ElementName = "ExplorationFSSCameraPitch")]
        public ExplorationFSSCameraPitchBinding ExplorationFSSCameraPitch { get; private set; }

        [XmlElement(ElementName = "ExplorationFSSCameraPitchIncreaseButton")]
        public ExplorationFSSCameraPitchIncreaseButtonBinding ExplorationFSSCameraPitchIncreaseButton { get; private set; }

        [XmlElement(ElementName = "ExplorationFSSCameraPitchDecreaseButton")]
        public ExplorationFSSCameraPitchDecreaseButtonBinding ExplorationFSSCameraPitchDecreaseButton { get; private set; }

        [XmlElement(ElementName = "ExplorationFSSCameraYaw")]
        public ExplorationFSSCameraYawBinding ExplorationFSSCameraYaw { get; private set; }

        [XmlElement(ElementName = "ExplorationFSSCameraYawIncreaseButton")]
        public ExplorationFSSCameraYawIncreaseButtonBinding ExplorationFSSCameraYawIncreaseButton { get; private set; }

        [XmlElement(ElementName = "ExplorationFSSCameraYawDecreaseButton")]
        public ExplorationFSSCameraYawDecreaseButtonBinding ExplorationFSSCameraYawDecreaseButton { get; private set; }

        [XmlElement(ElementName = "ExplorationFSSZoomIn")]
        public ExplorationFSSZoomInBinding ExplorationFSSZoomIn { get; private set; }

        [XmlElement(ElementName = "ExplorationFSSZoomOut")]
        public ExplorationFSSZoomOutBinding ExplorationFSSZoomOut { get; private set; }

        [XmlElement(ElementName = "ExplorationFSSMiniZoomIn")]
        public ExplorationFSSMiniZoomInBinding ExplorationFSSMiniZoomIn { get; private set; }

        [XmlElement(ElementName = "ExplorationFSSMiniZoomOut")]
        public ExplorationFSSMiniZoomOutBinding ExplorationFSSMiniZoomOut { get; private set; }

        [XmlElement(ElementName = "ExplorationFSSRadioTuningX_Raw")]
        public ExplorationFSSRadioTuningXRawBinding ExplorationFSSRadioTuningXRaw { get; private set; }

        [XmlElement(ElementName = "ExplorationFSSRadioTuningX_Increase")]
        public ExplorationFSSRadioTuningXIncreaseBinding ExplorationFSSRadioTuningXIncrease { get; private set; }

        [XmlElement(ElementName = "ExplorationFSSRadioTuningX_Decrease")]
        public ExplorationFSSRadioTuningXDecreaseBinding ExplorationFSSRadioTuningXDecrease { get; private set; }

        [XmlElement(ElementName = "ExplorationFSSRadioTuningAbsoluteX")]
        public ExplorationFSSRadioTuningAbsoluteXBinding ExplorationFSSRadioTuningAbsoluteX { get; private set; }

        [XmlElement(ElementName = "FSSTuningSensitivity")]
        public FSSTuningSensitivityBinding FSSTuningSensitivity { get; private set; }

        [XmlElement(ElementName = "ExplorationFSSDiscoveryScan")]
        public ExplorationFSSDiscoveryScanBinding ExplorationFSSDiscoveryScan { get; private set; }

        [XmlElement(ElementName = "ExplorationFSSQuit")]
        public ExplorationFSSQuitBinding ExplorationFSSQuit { get; private set; }

        [XmlElement(ElementName = "FSSMouseXMode")]
        public FSSMouseXModeBinding FSSMouseXMode { get; private set; }

        [XmlElement(ElementName = "FSSMouseXDecay")]
        public FSSMouseXDecayBinding FSSMouseXDecay { get; private set; }

        [XmlElement(ElementName = "FSSMouseYMode")]
        public FSSMouseYModeBinding FSSMouseYMode { get; private set; }

        [XmlElement(ElementName = "FSSMouseYDecay")]
        public FSSMouseYDecayBinding FSSMouseYDecay { get; private set; }

        [XmlElement(ElementName = "FSSMouseSensitivity")]
        public FSSMouseSensitivityBinding FSSMouseSensitivity { get; private set; }

        [XmlElement(ElementName = "FSSMouseDeadzone")]
        public FSSMouseDeadzoneBinding FSSMouseDeadzone { get; private set; }

        [XmlElement(ElementName = "FSSMouseLinearity")]
        public FSSMouseLinearityBinding FSSMouseLinearity { get; private set; }

        [XmlElement(ElementName = "ExplorationFSSTarget")]
        public ExplorationFSSTargetBinding ExplorationFSSTarget { get; private set; }

        [XmlElement(ElementName = "ExplorationFSSShowHelp")]
        public ExplorationFSSShowHelpBinding ExplorationFSSShowHelp { get; private set; }

        [XmlElement(ElementName = "ExplorationSAAChangeScannedAreaViewToggle")]
        public ExplorationSAAChangeScannedAreaViewToggleBinding ExplorationSAAChangeScannedAreaViewToggle { get; private set; }

        [XmlElement(ElementName = "ExplorationSAAExitThirdPerson")]
        public ExplorationSAAExitThirdPersonBinding ExplorationSAAExitThirdPerson { get; private set; }

        [XmlElement(ElementName = "SAAThirdPersonMouseXMode")]
        public SAAThirdPersonMouseXModeBinding SAAThirdPersonMouseXMode { get; private set; }

        [XmlElement(ElementName = "SAAThirdPersonMouseXDecay")]
        public SAAThirdPersonMouseXDecayBinding SAAThirdPersonMouseXDecay { get; private set; }

        [XmlElement(ElementName = "SAAThirdPersonMouseYMode")]
        public SAAThirdPersonMouseYModeBinding SAAThirdPersonMouseYMode { get; private set; }

        [XmlElement(ElementName = "SAAThirdPersonMouseYDecay")]
        public SAAThirdPersonMouseYDecayBinding SAAThirdPersonMouseYDecay { get; private set; }

        [XmlElement(ElementName = "SAAThirdPersonMouseSensitivity")]
        public SAAThirdPersonMouseSensitivityBinding SAAThirdPersonMouseSensitivity { get; private set; }

        [XmlElement(ElementName = "SAAThirdPersonYawAxisRaw")]
        public SAAThirdPersonYawAxisRawBinding SAAThirdPersonYawAxisRaw { get; private set; }

        [XmlElement(ElementName = "SAAThirdPersonYawLeftButton")]
        public SAAThirdPersonYawLeftButtonBinding SAAThirdPersonYawLeftButton { get; private set; }

        [XmlElement(ElementName = "SAAThirdPersonYawRightButton")]
        public SAAThirdPersonYawRightButtonBinding SAAThirdPersonYawRightButton { get; private set; }

        [XmlElement(ElementName = "SAAThirdPersonPitchAxisRaw")]
        public SAAThirdPersonPitchAxisRawBinding SAAThirdPersonPitchAxisRaw { get; private set; }

        [XmlElement(ElementName = "SAAThirdPersonPitchUpButton")]
        public SAAThirdPersonPitchUpButtonBinding SAAThirdPersonPitchUpButton { get; private set; }

        [XmlElement(ElementName = "SAAThirdPersonPitchDownButton")]
        public SAAThirdPersonPitchDownButtonBinding SAAThirdPersonPitchDownButton { get; private set; }

        [XmlElement(ElementName = "SAAThirdPersonFovAxisRaw")]
        public SAAThirdPersonFovAxisRawBinding SAAThirdPersonFovAxisRaw { get; private set; }

        [XmlElement(ElementName = "SAAThirdPersonFovOutButton")]
        public SAAThirdPersonFovOutButtonBinding SAAThirdPersonFovOutButton { get; private set; }

        [XmlElement(ElementName = "SAAThirdPersonFovInButton")]
        public SAAThirdPersonFovInButtonBinding SAAThirdPersonFovInButton { get; private set; }

        [XmlRoot(ElementName = "MouseXMode")]
        public class MouseXModeBinding
        {
            internal MouseXModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; private set; }
        }

        [XmlRoot(ElementName = "MouseXDecay")]
        public class MouseXDecayBinding
        {
            internal MouseXDecayBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "MouseYMode")]
        public class MouseYModeBinding
        {
            internal MouseYModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; private set; }
        }

        [XmlRoot(ElementName = "MouseYDecay")]
        public class MouseYDecayBinding
        {
            internal MouseYDecayBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "Primary")]
        public class PrimaryBinding
        {
            internal PrimaryBinding() { }

            [XmlAttribute(AttributeName = "Device")]
            public string Device { get; private set; }

            [XmlAttribute(AttributeName = "Key")]
            public object Key { get; private set; }

            [XmlElement(ElementName = "Modifier")]
            public ModifierBinding Modifier { get; private set; }
        }

        [XmlRoot(ElementName = "Secondary")]
        public class SecondaryBinding
        {
            internal SecondaryBinding() { }

            [XmlAttribute(AttributeName = "Device")]
            public string Device { get; private set; }

            [XmlAttribute(AttributeName = "Key")]
            public object Key { get; private set; }
        }

        [XmlRoot(ElementName = "MouseReset")]
        public class MouseResetBinding
        {
            internal MouseResetBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "MouseSensitivity")]
        public class MouseSensitivityBinding
        {
            internal MouseSensitivityBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; private set; }
        }

        [XmlRoot(ElementName = "MouseDecayRate")]
        public class MouseDecayRateBinding
        {
            internal MouseDecayRateBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; private set; }
        }

        [XmlRoot(ElementName = "MouseDeadzone")]
        public class MouseDeadzoneBinding
        {
            internal MouseDeadzoneBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; private set; }
        }

        [XmlRoot(ElementName = "MouseLinearity")]
        public class MouseLinearityBinding
        {
            internal MouseLinearityBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; private set; }
        }

        [XmlRoot(ElementName = "MouseGUI")]
        public class MouseGUIBinding
        {
            internal MouseGUIBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "Binding")]
        public class BindingBinding
        {
            internal BindingBinding() { }

            [XmlAttribute(AttributeName = "Device")]
            public string Device { get; private set; }

            [XmlAttribute(AttributeName = "Key")]
            public object Key { get; private set; }
        }

        [XmlRoot(ElementName = "Inverted")]
        public class InvertedBinding
        {
            internal InvertedBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "Deadzone")]
        public class DeadzoneBinding
        {
            internal DeadzoneBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; private set; }
        }

        [XmlRoot(ElementName = "YawAxisRaw")]
        public class YawAxisRawBinding
        {
            internal YawAxisRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "YawLeftButton")]
        public class YawLeftButtonBinding
        {
            internal YawLeftButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "YawRightButton")]
        public class YawRightButtonBinding
        {
            internal YawRightButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "YawToRollMode")]
        public class YawToRollModeBinding
        {
            internal YawToRollModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; private set; }
        }

        [XmlRoot(ElementName = "YawToRollSensitivity")]
        public class YawToRollSensitivityBinding
        {
            internal YawToRollSensitivityBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; private set; }
        }

        [XmlRoot(ElementName = "YawToRollMode_FAOff")]
        public class YawToRollModeFAOffBinding
        {
            internal YawToRollModeFAOffBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public object Value { get; private set; }
        }

        [XmlRoot(ElementName = "ToggleOn")]
        public class ToggleOnBinding
        {
            internal ToggleOnBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "YawToRollButton")]
        public class YawToRollButtonBinding
        {
            internal YawToRollButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; private set; }
        }

        [XmlRoot(ElementName = "RollAxisRaw")]
        public class RollAxisRawBinding
        {
            internal RollAxisRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "RollLeftButton")]
        public class RollLeftButtonBinding
        {
            internal RollLeftButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "RollRightButton")]
        public class RollRightButtonBinding
        {
            internal RollRightButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "PitchAxisRaw")]
        public class PitchAxisRawBinding
        {
            internal PitchAxisRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "PitchUpButton")]
        public class PitchUpButtonBinding
        {
            internal PitchUpButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "PitchDownButton")]
        public class PitchDownButtonBinding
        {
            internal PitchDownButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "LateralThrustRaw")]
        public class LateralThrustRawBinding
        {
            internal LateralThrustRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "LeftThrustButton")]
        public class LeftThrustButtonBinding
        {
            internal LeftThrustButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "RightThrustButton")]
        public class RightThrustButtonBinding
        {
            internal RightThrustButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "VerticalThrustRaw")]
        public class VerticalThrustRawBinding
        {
            internal VerticalThrustRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "UpThrustButton")]
        public class UpThrustButtonBinding
        {
            internal UpThrustButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "DownThrustButton")]
        public class DownThrustButtonBinding
        {
            internal DownThrustButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "AheadThrust")]
        public class AheadThrustBinding
        {
            internal AheadThrustBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "ForwardThrustButton")]
        public class ForwardThrustButtonBinding
        {
            internal ForwardThrustButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "BackwardThrustButton")]
        public class BackwardThrustButtonBinding
        {
            internal BackwardThrustButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "UseAlternateFlightValuesToggle")]
        public class UseAlternateFlightValuesToggleBinding
        {
            internal UseAlternateFlightValuesToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; private set; }
        }

        [XmlRoot(ElementName = "YawAxisAlternate")]
        public class YawAxisAlternateBinding
        {
            internal YawAxisAlternateBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "RollAxisAlternate")]
        public class RollAxisAlternateBinding
        {
            internal RollAxisAlternateBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "PitchAxisAlternate")]
        public class PitchAxisAlternateBinding
        {
            internal PitchAxisAlternateBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "LateralThrustAlternate")]
        public class LateralThrustAlternateBinding
        {
            internal LateralThrustAlternateBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "VerticalThrustAlternate")]
        public class VerticalThrustAlternateBinding
        {
            internal VerticalThrustAlternateBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "ThrottleAxis")]
        public class ThrottleAxisBinding
        {
            internal ThrottleAxisBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "ThrottleRange")]
        public class ThrottleRangeBinding
        {
            internal ThrottleRangeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public object Value { get; private set; }
        }

        [XmlRoot(ElementName = "ToggleReverseThrottleInput")]
        public class ToggleReverseThrottleInputBinding
        {
            internal ToggleReverseThrottleInputBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; private set; }
        }

        [XmlRoot(ElementName = "ForwardKey")]
        public class ForwardKeyBinding
        {
            internal ForwardKeyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "BackwardKey")]
        public class BackwardKeyBinding
        {
            internal BackwardKeyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "ThrottleIncrement")]
        public class ThrottleIncrementBinding
        {
            internal ThrottleIncrementBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; private set; }
        }

        [XmlRoot(ElementName = "Modifier")]
        public class ModifierBinding
        {
            internal ModifierBinding() { }

            [XmlAttribute(AttributeName = "Device")]
            public string Device { get; private set; }

            [XmlAttribute(AttributeName = "Key")]
            public string Key { get; private set; }
        }

        [XmlRoot(ElementName = "SetSpeedMinus100")]
        public class SetSpeedMinus100Binding
        {
            internal SetSpeedMinus100Binding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "SetSpeedMinus75")]
        public class SetSpeedMinus75Binding
        {
            internal SetSpeedMinus75Binding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "SetSpeedMinus50")]
        public class SetSpeedMinus50Binding
        {
            internal SetSpeedMinus50Binding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "SetSpeedMinus25")]
        public class SetSpeedMinus25Binding
        {
            internal SetSpeedMinus25Binding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "SetSpeedZero")]
        public class SetSpeedZeroBinding
        {
            internal SetSpeedZeroBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "SetSpeed25")]
        public class SetSpeed25Binding
        {
            internal SetSpeed25Binding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "SetSpeed50")]
        public class SetSpeed50Binding
        {
            internal SetSpeed50Binding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "SetSpeed75")]
        public class SetSpeed75Binding
        {
            internal SetSpeed75Binding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "SetSpeed100")]
        public class SetSpeed100Binding
        {
            internal SetSpeed100Binding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "YawAxis_Landing")]
        public class YawAxisLandingBinding
        {
            internal YawAxisLandingBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "YawLeftButton_Landing")]
        public class YawLeftButtonLandingBinding
        {
            internal YawLeftButtonLandingBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "YawRightButton_Landing")]
        public class YawRightButtonLandingBinding
        {
            internal YawRightButtonLandingBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "YawToRollMode_Landing")]
        public class YawToRollModeLandingBinding
        {
            internal YawToRollModeLandingBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public object Value { get; private set; }
        }

        [XmlRoot(ElementName = "PitchAxis_Landing")]
        public class PitchAxisLandingBinding
        {
            internal PitchAxisLandingBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "PitchUpButton_Landing")]
        public class PitchUpButtonLandingBinding
        {
            internal PitchUpButtonLandingBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "PitchDownButton_Landing")]
        public class PitchDownButtonLandingBinding
        {
            internal PitchDownButtonLandingBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "RollAxis_Landing")]
        public class RollAxisLandingBinding
        {
            internal RollAxisLandingBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "RollLeftButton_Landing")]
        public class RollLeftButtonLandingBinding
        {
            internal RollLeftButtonLandingBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "RollRightButton_Landing")]
        public class RollRightButtonLandingBinding
        {
            internal RollRightButtonLandingBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "LateralThrust_Landing")]
        public class LateralThrustLandingBinding
        {
            internal LateralThrustLandingBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "LeftThrustButton_Landing")]
        public class LeftThrustButtonLandingBinding
        {
            internal LeftThrustButtonLandingBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "RightThrustButton_Landing")]
        public class RightThrustButtonLandingBinding
        {
            internal RightThrustButtonLandingBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "VerticalThrust_Landing")]
        public class VerticalThrustLandingBinding
        {
            internal VerticalThrustLandingBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "UpThrustButton_Landing")]
        public class UpThrustButtonLandingBinding
        {
            internal UpThrustButtonLandingBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "DownThrustButton_Landing")]
        public class DownThrustButtonLandingBinding
        {
            internal DownThrustButtonLandingBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "AheadThrust_Landing")]
        public class AheadThrustLandingBinding
        {
            internal AheadThrustLandingBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "ForwardThrustButton_Landing")]
        public class ForwardThrustButtonLandingBinding
        {
            internal ForwardThrustButtonLandingBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "BackwardThrustButton_Landing")]
        public class BackwardThrustButtonLandingBinding
        {
            internal BackwardThrustButtonLandingBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "ToggleFlightAssist")]
        public class ToggleFlightAssistBinding
        {
            internal ToggleFlightAssistBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; private set; }
        }

        [XmlRoot(ElementName = "UseBoostJuice")]
        public class UseBoostJuiceBinding
        {
            internal UseBoostJuiceBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "HyperSuperCombination")]
        public class HyperSuperCombinationBinding
        {
            internal HyperSuperCombinationBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "Supercruise")]
        public class SupercruiseBinding
        {
            internal SupercruiseBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "Hyperspace")]
        public class HyperspaceBinding
        {
            internal HyperspaceBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "DisableRotationCorrectToggle")]
        public class DisableRotationCorrectToggleBinding
        {
            internal DisableRotationCorrectToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; private set; }
        }

        [XmlRoot(ElementName = "OrbitLinesToggle")]
        public class OrbitLinesToggleBinding
        {
            internal OrbitLinesToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "SelectTarget")]
        public class SelectTargetBinding
        {
            internal SelectTargetBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "CycleNextTarget")]
        public class CycleNextTargetBinding
        {
            internal CycleNextTargetBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "CyclePreviousTarget")]
        public class CyclePreviousTargetBinding
        {
            internal CyclePreviousTargetBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "SelectHighestThreat")]
        public class SelectHighestThreatBinding
        {
            internal SelectHighestThreatBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "CycleNextHostileTarget")]
        public class CycleNextHostileTargetBinding
        {
            internal CycleNextHostileTargetBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "CyclePreviousHostileTarget")]
        public class CyclePreviousHostileTargetBinding
        {
            internal CyclePreviousHostileTargetBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "TargetWingman0")]
        public class TargetWingman0Binding
        {
            internal TargetWingman0Binding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "TargetWingman1")]
        public class TargetWingman1Binding
        {
            internal TargetWingman1Binding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "TargetWingman2")]
        public class TargetWingman2Binding
        {
            internal TargetWingman2Binding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "SelectTargetsTarget")]
        public class SelectTargetsTargetBinding
        {
            internal SelectTargetsTargetBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "WingNavLock")]
        public class WingNavLockBinding
        {
            internal WingNavLockBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "CycleNextSubsystem")]
        public class CycleNextSubsystemBinding
        {
            internal CycleNextSubsystemBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "CyclePreviousSubsystem")]
        public class CyclePreviousSubsystemBinding
        {
            internal CyclePreviousSubsystemBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "TargetNextRouteSystem")]
        public class TargetNextRouteSystemBinding
        {
            internal TargetNextRouteSystemBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "PrimaryFire")]
        public class PrimaryFireBinding
        {
            internal PrimaryFireBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "SecondaryFire")]
        public class SecondaryFireBinding
        {
            internal SecondaryFireBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "CycleFireGroupNext")]
        public class CycleFireGroupNextBinding
        {
            internal CycleFireGroupNextBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "CycleFireGroupPrevious")]
        public class CycleFireGroupPreviousBinding
        {
            internal CycleFireGroupPreviousBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "DeployHardpointToggle")]
        public class DeployHardpointToggleBinding
        {
            internal DeployHardpointToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "DeployHardpointsOnFire")]
        public class DeployHardpointsOnFireBinding
        {
            internal DeployHardpointsOnFireBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "ToggleButtonUpInput")]
        public class ToggleButtonUpInputBinding
        {
            internal ToggleButtonUpInputBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; private set; }
        }

        [XmlRoot(ElementName = "DeployHeatSink")]
        public class DeployHeatSinkBinding
        {
            internal DeployHeatSinkBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "ShipSpotLightToggle")]
        public class ShipSpotLightToggleBinding
        {
            internal ShipSpotLightToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "RadarRangeAxis")]
        public class RadarRangeAxisBinding
        {
            internal RadarRangeAxisBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "RadarIncreaseRange")]
        public class RadarIncreaseRangeBinding
        {
            internal RadarIncreaseRangeBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "RadarDecreaseRange")]
        public class RadarDecreaseRangeBinding
        {
            internal RadarDecreaseRangeBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "IncreaseEnginesPower")]
        public class IncreaseEnginesPowerBinding
        {
            internal IncreaseEnginesPowerBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "IncreaseWeaponsPower")]
        public class IncreaseWeaponsPowerBinding
        {
            internal IncreaseWeaponsPowerBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "IncreaseSystemsPower")]
        public class IncreaseSystemsPowerBinding
        {
            internal IncreaseSystemsPowerBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "ResetPowerDistribution")]
        public class ResetPowerDistributionBinding
        {
            internal ResetPowerDistributionBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "HMDReset")]
        public class HMDResetBinding
        {
            internal HMDResetBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "ToggleCargoScoop")]
        public class ToggleCargoScoopBinding
        {
            internal ToggleCargoScoopBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; private set; }
        }

        [XmlRoot(ElementName = "EjectAllCargo")]
        public class EjectAllCargoBinding
        {
            internal EjectAllCargoBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "LandingGearToggle")]
        public class LandingGearToggleBinding
        {
            internal LandingGearToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "MicrophoneMute")]
        public class MicrophoneMuteBinding
        {
            internal MicrophoneMuteBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; private set; }
        }

        [XmlRoot(ElementName = "MuteButtonMode")]
        public class MuteButtonModeBinding
        {
            internal MuteButtonModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; private set; }
        }

        [XmlRoot(ElementName = "CqcMuteButtonMode")]
        public class CqcMuteButtonModeBinding
        {
            internal CqcMuteButtonModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; private set; }
        }

        [XmlRoot(ElementName = "UseShieldCell")]
        public class UseShieldCellBinding
        {
            internal UseShieldCellBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "FireChaffLauncher")]
        public class FireChaffLauncherBinding
        {
            internal FireChaffLauncherBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "ChargeECM")]
        public class ChargeECMBinding
        {
            internal ChargeECMBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "EnableRumbleTrigger")]
        public class EnableRumbleTriggerBinding
        {
            internal EnableRumbleTriggerBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "EnableMenuGroups")]
        public class EnableMenuGroupsBinding
        {
            internal EnableMenuGroupsBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "WeaponColourToggle")]
        public class WeaponColourToggleBinding
        {
            internal WeaponColourToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "EngineColourToggle")]
        public class EngineColourToggleBinding
        {
            internal EngineColourToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "NightVisionToggle")]
        public class NightVisionToggleBinding
        {
            internal NightVisionToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "UIFocus")]
        public class UIFocusBinding
        {
            internal UIFocusBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "UIFocusMode")]
        public class UIFocusModeBinding
        {
            internal UIFocusModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; private set; }
        }

        [XmlRoot(ElementName = "FocusLeftPanel")]
        public class FocusLeftPanelBinding
        {
            internal FocusLeftPanelBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "FocusCommsPanel")]
        public class FocusCommsPanelBinding
        {
            internal FocusCommsPanelBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "FocusOnTextEntryField")]
        public class FocusOnTextEntryFieldBinding
        {
            internal FocusOnTextEntryFieldBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "QuickCommsPanel")]
        public class QuickCommsPanelBinding
        {
            internal QuickCommsPanelBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "FocusRadarPanel")]
        public class FocusRadarPanelBinding
        {
            internal FocusRadarPanelBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "FocusRightPanel")]
        public class FocusRightPanelBinding
        {
            internal FocusRightPanelBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "LeftPanelFocusOptions")]
        public class LeftPanelFocusOptionsBinding
        {
            internal LeftPanelFocusOptionsBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; private set; }
        }

        [XmlRoot(ElementName = "CommsPanelFocusOptions")]
        public class CommsPanelFocusOptionsBinding
        {
            internal CommsPanelFocusOptionsBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; private set; }
        }

        [XmlRoot(ElementName = "RolePanelFocusOptions")]
        public class RolePanelFocusOptionsBinding
        {
            internal RolePanelFocusOptionsBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; private set; }
        }

        [XmlRoot(ElementName = "RightPanelFocusOptions")]
        public class RightPanelFocusOptionsBinding
        {
            internal RightPanelFocusOptionsBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; private set; }
        }

        [XmlRoot(ElementName = "EnableCameraLockOn")]
        public class EnableCameraLockOnBinding
        {
            internal EnableCameraLockOnBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "GalaxyMapOpen")]
        public class GalaxyMapOpenBinding
        {
            internal GalaxyMapOpenBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "SystemMapOpen")]
        public class SystemMapOpenBinding
        {
            internal SystemMapOpenBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "ShowPGScoreSummaryInput")]
        public class ShowPGScoreSummaryInputBinding
        {
            internal ShowPGScoreSummaryInputBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; private set; }
        }

        [XmlRoot(ElementName = "HeadLookToggle")]
        public class HeadLookToggleBinding
        {
            internal HeadLookToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; private set; }
        }

        [XmlRoot(ElementName = "Pause")]
        public class PauseBinding
        {
            internal PauseBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "FriendsMenu")]
        public class FriendsMenuBinding
        {
            internal FriendsMenuBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "OpenCodexGoToDiscovery")]
        public class OpenCodexGoToDiscoveryBinding
        {
            internal OpenCodexGoToDiscoveryBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "PlayerHUDModeToggle")]
        public class PlayerHUDModeToggleBinding
        {
            internal PlayerHUDModeToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSEnter")]
        public class ExplorationFSSEnterBinding
        {
            internal ExplorationFSSEnterBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "UI_Up")]
        public class UIUpBinding
        {
            internal UIUpBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "UI_Down")]
        public class UIDownBinding
        {
            internal UIDownBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "UI_Left")]
        public class UILeftBinding
        {
            internal UILeftBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "UI_Right")]
        public class UIRightBinding
        {
            internal UIRightBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "UI_Select")]
        public class UISelectBinding
        {
            internal UISelectBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "UI_Back")]
        public class UIBackBinding
        {
            internal UIBackBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "UI_Toggle")]
        public class UIToggleBinding
        {
            internal UIToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "CycleNextPanel")]
        public class CycleNextPanelBinding
        {
            internal CycleNextPanelBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "CyclePreviousPanel")]
        public class CyclePreviousPanelBinding
        {
            internal CyclePreviousPanelBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "CycleNextPage")]
        public class CycleNextPageBinding
        {
            internal CycleNextPageBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "CyclePreviousPage")]
        public class CyclePreviousPageBinding
        {
            internal CyclePreviousPageBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "MouseHeadlook")]
        public class MouseHeadlookBinding
        {
            internal MouseHeadlookBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "MouseHeadlookInvert")]
        public class MouseHeadlookInvertBinding
        {
            internal MouseHeadlookInvertBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "MouseHeadlookSensitivity")]
        public class MouseHeadlookSensitivityBinding
        {
            internal MouseHeadlookSensitivityBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; private set; }
        }

        [XmlRoot(ElementName = "HeadlookDefault")]
        public class HeadlookDefaultBinding
        {
            internal HeadlookDefaultBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "HeadlookIncrement")]
        public class HeadlookIncrementBinding
        {
            internal HeadlookIncrementBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; private set; }
        }

        [XmlRoot(ElementName = "HeadlookMode")]
        public class HeadlookModeBinding
        {
            internal HeadlookModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; private set; }
        }

        [XmlRoot(ElementName = "HeadlookResetOnToggle")]
        public class HeadlookResetOnToggleBinding
        {
            internal HeadlookResetOnToggleBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "HeadlookSensitivity")]
        public class HeadlookSensitivityBinding
        {
            internal HeadlookSensitivityBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; private set; }
        }

        [XmlRoot(ElementName = "HeadlookSmoothing")]
        public class HeadlookSmoothingBinding
        {
            internal HeadlookSmoothingBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "HeadLookReset")]
        public class HeadLookResetBinding
        {
            internal HeadLookResetBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "HeadLookPitchUp")]
        public class HeadLookPitchUpBinding
        {
            internal HeadLookPitchUpBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "HeadLookPitchDown")]
        public class HeadLookPitchDownBinding
        {
            internal HeadLookPitchDownBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "HeadLookPitchAxisRaw")]
        public class HeadLookPitchAxisRawBinding
        {
            internal HeadLookPitchAxisRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "HeadLookYawLeft")]
        public class HeadLookYawLeftBinding
        {
            internal HeadLookYawLeftBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "HeadLookYawRight")]
        public class HeadLookYawRightBinding
        {
            internal HeadLookYawRightBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "HeadLookYawAxis")]
        public class HeadLookYawAxisBinding
        {
            internal HeadLookYawAxisBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "MotionHeadlook")]
        public class MotionHeadlookBinding
        {
            internal MotionHeadlookBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "HeadlookMotionSensitivity")]
        public class HeadlookMotionSensitivityBinding
        {
            internal HeadlookMotionSensitivityBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; private set; }
        }

        [XmlRoot(ElementName = "yawRotateHeadlook")]
        public class YawRotateHeadlookBinding
        {
            internal YawRotateHeadlookBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "CamPitchAxis")]
        public class CamPitchAxisBinding
        {
            internal CamPitchAxisBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "CamPitchUp")]
        public class CamPitchUpBinding
        {
            internal CamPitchUpBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "CamPitchDown")]
        public class CamPitchDownBinding
        {
            internal CamPitchDownBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "CamYawAxis")]
        public class CamYawAxisBinding
        {
            internal CamYawAxisBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "CamYawLeft")]
        public class CamYawLeftBinding
        {
            internal CamYawLeftBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "CamYawRight")]
        public class CamYawRightBinding
        {
            internal CamYawRightBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "CamTranslateYAxis")]
        public class CamTranslateYAxisBinding
        {
            internal CamTranslateYAxisBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "CamTranslateForward")]
        public class CamTranslateForwardBinding
        {
            internal CamTranslateForwardBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "CamTranslateBackward")]
        public class CamTranslateBackwardBinding
        {
            internal CamTranslateBackwardBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "CamTranslateXAxis")]
        public class CamTranslateXAxisBinding
        {
            internal CamTranslateXAxisBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "CamTranslateLeft")]
        public class CamTranslateLeftBinding
        {
            internal CamTranslateLeftBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "CamTranslateRight")]
        public class CamTranslateRightBinding
        {
            internal CamTranslateRightBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "CamTranslateZAxis")]
        public class CamTranslateZAxisBinding
        {
            internal CamTranslateZAxisBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "CamTranslateUp")]
        public class CamTranslateUpBinding
        {
            internal CamTranslateUpBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "CamTranslateDown")]
        public class CamTranslateDownBinding
        {
            internal CamTranslateDownBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "CamZoomAxis")]
        public class CamZoomAxisBinding
        {
            internal CamZoomAxisBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "CamZoomIn")]
        public class CamZoomInBinding
        {
            internal CamZoomInBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "CamZoomOut")]
        public class CamZoomOutBinding
        {
            internal CamZoomOutBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "CamTranslateZHold")]
        public class CamTranslateZHoldBinding
        {
            internal CamTranslateZHoldBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; private set; }
        }

        [XmlRoot(ElementName = "GalaxyMapHome")]
        public class GalaxyMapHomeBinding
        {
            internal GalaxyMapHomeBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "ToggleDriveAssist")]
        public class ToggleDriveAssistBinding
        {
            internal ToggleDriveAssistBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; private set; }
        }

        [XmlRoot(ElementName = "DriveAssistDefault")]
        public class DriveAssistDefaultBinding
        {
            internal DriveAssistDefaultBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "MouseBuggySteeringXMode")]
        public class MouseBuggySteeringXModeBinding
        {
            internal MouseBuggySteeringXModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public object Value { get; private set; }
        }

        [XmlRoot(ElementName = "MouseBuggySteeringXDecay")]
        public class MouseBuggySteeringXDecayBinding
        {
            internal MouseBuggySteeringXDecayBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "MouseBuggyRollingXMode")]
        public class MouseBuggyRollingXModeBinding
        {
            internal MouseBuggyRollingXModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public object Value { get; private set; }
        }

        [XmlRoot(ElementName = "MouseBuggyRollingXDecay")]
        public class MouseBuggyRollingXDecayBinding
        {
            internal MouseBuggyRollingXDecayBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "MouseBuggyYMode")]
        public class MouseBuggyYModeBinding
        {
            internal MouseBuggyYModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public object Value { get; private set; }
        }

        [XmlRoot(ElementName = "MouseBuggyYDecay")]
        public class MouseBuggyYDecayBinding
        {
            internal MouseBuggyYDecayBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "SteeringAxis")]
        public class SteeringAxisBinding
        {
            internal SteeringAxisBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "SteerLeftButton")]
        public class SteerLeftButtonBinding
        {
            internal SteerLeftButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "SteerRightButton")]
        public class SteerRightButtonBinding
        {
            internal SteerRightButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "BuggyRollAxisRaw")]
        public class BuggyRollAxisRawBinding
        {
            internal BuggyRollAxisRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "BuggyRollLeftButton")]
        public class BuggyRollLeftButtonBinding
        {
            internal BuggyRollLeftButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "BuggyRollRightButton")]
        public class BuggyRollRightButtonBinding
        {
            internal BuggyRollRightButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "BuggyPitchAxis")]
        public class BuggyPitchAxisBinding
        {
            internal BuggyPitchAxisBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "BuggyPitchUpButton")]
        public class BuggyPitchUpButtonBinding
        {
            internal BuggyPitchUpButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "BuggyPitchDownButton")]
        public class BuggyPitchDownButtonBinding
        {
            internal BuggyPitchDownButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "VerticalThrustersButton")]
        public class VerticalThrustersButtonBinding
        {
            internal VerticalThrustersButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; private set; }
        }

        [XmlRoot(ElementName = "BuggyPrimaryFireButton")]
        public class BuggyPrimaryFireButtonBinding
        {
            internal BuggyPrimaryFireButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "BuggySecondaryFireButton")]
        public class BuggySecondaryFireButtonBinding
        {
            internal BuggySecondaryFireButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "AutoBreakBuggyButton")]
        public class AutoBreakBuggyButtonBinding
        {
            internal AutoBreakBuggyButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; private set; }
        }

        [XmlRoot(ElementName = "HeadlightsBuggyButton")]
        public class HeadlightsBuggyButtonBinding
        {
            internal HeadlightsBuggyButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "ToggleBuggyTurretButton")]
        public class ToggleBuggyTurretButtonBinding
        {
            internal ToggleBuggyTurretButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "BuggyCycleFireGroupNext")]
        public class BuggyCycleFireGroupNextBinding
        {
            internal BuggyCycleFireGroupNextBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "BuggyCycleFireGroupPrevious")]
        public class BuggyCycleFireGroupPreviousBinding
        {
            internal BuggyCycleFireGroupPreviousBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "SelectTarget_Buggy")]
        public class SelectTargetBuggyBinding
        {
            internal SelectTargetBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "MouseTurretXMode")]
        public class MouseTurretXModeBinding
        {
            internal MouseTurretXModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; private set; }
        }

        [XmlRoot(ElementName = "MouseTurretXDecay")]
        public class MouseTurretXDecayBinding
        {
            internal MouseTurretXDecayBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "MouseTurretYMode")]
        public class MouseTurretYModeBinding
        {
            internal MouseTurretYModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; private set; }
        }

        [XmlRoot(ElementName = "MouseTurretYDecay")]
        public class MouseTurretYDecayBinding
        {
            internal MouseTurretYDecayBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "BuggyTurretYawAxisRaw")]
        public class BuggyTurretYawAxisRawBinding
        {
            internal BuggyTurretYawAxisRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "BuggyTurretYawLeftButton")]
        public class BuggyTurretYawLeftButtonBinding
        {
            internal BuggyTurretYawLeftButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "BuggyTurretYawRightButton")]
        public class BuggyTurretYawRightButtonBinding
        {
            internal BuggyTurretYawRightButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "BuggyTurretPitchAxisRaw")]
        public class BuggyTurretPitchAxisRawBinding
        {
            internal BuggyTurretPitchAxisRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "BuggyTurretPitchUpButton")]
        public class BuggyTurretPitchUpButtonBinding
        {
            internal BuggyTurretPitchUpButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "BuggyTurretPitchDownButton")]
        public class BuggyTurretPitchDownButtonBinding
        {
            internal BuggyTurretPitchDownButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "BuggyTurretMouseSensitivity")]
        public class BuggyTurretMouseSensitivityBinding
        {
            internal BuggyTurretMouseSensitivityBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; private set; }
        }

        [XmlRoot(ElementName = "BuggyTurretMouseDeadzone")]
        public class BuggyTurretMouseDeadzoneBinding
        {
            internal BuggyTurretMouseDeadzoneBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; private set; }
        }

        [XmlRoot(ElementName = "BuggyTurretMouseLinearity")]
        public class BuggyTurretMouseLinearityBinding
        {
            internal BuggyTurretMouseLinearityBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; private set; }
        }

        [XmlRoot(ElementName = "DriveSpeedAxis")]
        public class DriveSpeedAxisBinding
        {
            internal DriveSpeedAxisBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "BuggyThrottleRange")]
        public class BuggyThrottleRangeBinding
        {
            internal BuggyThrottleRangeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; private set; }
        }

        [XmlRoot(ElementName = "BuggyToggleReverseThrottleInput")]
        public class BuggyToggleReverseThrottleInputBinding
        {
            internal BuggyToggleReverseThrottleInputBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; private set; }
        }

        [XmlRoot(ElementName = "BuggyThrottleIncrement")]
        public class BuggyThrottleIncrementBinding
        {
            internal BuggyThrottleIncrementBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; private set; }
        }

        [XmlRoot(ElementName = "IncreaseSpeedButtonMax")]
        public class IncreaseSpeedButtonMaxBinding
        {
            internal IncreaseSpeedButtonMaxBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "DecreaseSpeedButtonMax")]
        public class DecreaseSpeedButtonMaxBinding
        {
            internal DecreaseSpeedButtonMaxBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "IncreaseSpeedButtonPartial")]
        public class IncreaseSpeedButtonPartialBinding
        {
            internal IncreaseSpeedButtonPartialBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "DecreaseSpeedButtonPartial")]
        public class DecreaseSpeedButtonPartialBinding
        {
            internal DecreaseSpeedButtonPartialBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "IncreaseEnginesPower_Buggy")]
        public class IncreaseEnginesPowerBuggyBinding
        {
            internal IncreaseEnginesPowerBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "IncreaseWeaponsPower_Buggy")]
        public class IncreaseWeaponsPowerBuggyBinding
        {
            internal IncreaseWeaponsPowerBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "IncreaseSystemsPower_Buggy")]
        public class IncreaseSystemsPowerBuggyBinding
        {
            internal IncreaseSystemsPowerBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "ResetPowerDistribution_Buggy")]
        public class ResetPowerDistributionBuggyBinding
        {
            internal ResetPowerDistributionBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "ToggleCargoScoop_Buggy")]
        public class ToggleCargoScoopBuggyBinding
        {
            internal ToggleCargoScoopBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; private set; }
        }

        [XmlRoot(ElementName = "EjectAllCargo_Buggy")]
        public class EjectAllCargoBuggyBinding
        {
            internal EjectAllCargoBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "RecallDismissShip")]
        public class RecallDismissShipBinding
        {
            internal RecallDismissShipBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "UIFocus_Buggy")]
        public class UIFocusBuggyBinding
        {
            internal UIFocusBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "FocusLeftPanel_Buggy")]
        public class FocusLeftPanelBuggyBinding
        {
            internal FocusLeftPanelBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "FocusCommsPanel_Buggy")]
        public class FocusCommsPanelBuggyBinding
        {
            internal FocusCommsPanelBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "QuickCommsPanel_Buggy")]
        public class QuickCommsPanelBuggyBinding
        {
            internal QuickCommsPanelBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "FocusRadarPanel_Buggy")]
        public class FocusRadarPanelBuggyBinding
        {
            internal FocusRadarPanelBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "FocusRightPanel_Buggy")]
        public class FocusRightPanelBuggyBinding
        {
            internal FocusRightPanelBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "GalaxyMapOpen_Buggy")]
        public class GalaxyMapOpenBuggyBinding
        {
            internal GalaxyMapOpenBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "SystemMapOpen_Buggy")]
        public class SystemMapOpenBuggyBinding
        {
            internal SystemMapOpenBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "OpenCodexGoToDiscovery_Buggy")]
        public class OpenCodexGoToDiscoveryBuggyBinding
        {
            internal OpenCodexGoToDiscoveryBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "PlayerHUDModeToggle_Buggy")]
        public class PlayerHUDModeToggleBuggyBinding
        {
            internal PlayerHUDModeToggleBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "HeadLookToggle_Buggy")]
        public class HeadLookToggleBuggyBinding
        {
            internal HeadLookToggleBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; private set; }
        }

        [XmlRoot(ElementName = "MultiCrewToggleMode")]
        public class MultiCrewToggleModeBinding
        {
            internal MultiCrewToggleModeBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "MultiCrewPrimaryFire")]
        public class MultiCrewPrimaryFireBinding
        {
            internal MultiCrewPrimaryFireBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "MultiCrewSecondaryFire")]
        public class MultiCrewSecondaryFireBinding
        {
            internal MultiCrewSecondaryFireBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "MultiCrewPrimaryUtilityFire")]
        public class MultiCrewPrimaryUtilityFireBinding
        {
            internal MultiCrewPrimaryUtilityFireBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "MultiCrewSecondaryUtilityFire")]
        public class MultiCrewSecondaryUtilityFireBinding
        {
            internal MultiCrewSecondaryUtilityFireBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonMouseXMode")]
        public class MultiCrewThirdPersonMouseXModeBinding
        {
            internal MultiCrewThirdPersonMouseXModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; private set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonMouseXDecay")]
        public class MultiCrewThirdPersonMouseXDecayBinding
        {
            internal MultiCrewThirdPersonMouseXDecayBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonMouseYMode")]
        public class MultiCrewThirdPersonMouseYModeBinding
        {
            internal MultiCrewThirdPersonMouseYModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; private set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonMouseYDecay")]
        public class MultiCrewThirdPersonMouseYDecayBinding
        {
            internal MultiCrewThirdPersonMouseYDecayBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonYawAxisRaw")]
        public class MultiCrewThirdPersonYawAxisRawBinding
        {
            internal MultiCrewThirdPersonYawAxisRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonYawLeftButton")]
        public class MultiCrewThirdPersonYawLeftButtonBinding
        {
            internal MultiCrewThirdPersonYawLeftButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonYawRightButton")]
        public class MultiCrewThirdPersonYawRightButtonBinding
        {
            internal MultiCrewThirdPersonYawRightButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonPitchAxisRaw")]
        public class MultiCrewThirdPersonPitchAxisRawBinding
        {
            internal MultiCrewThirdPersonPitchAxisRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonPitchUpButton")]
        public class MultiCrewThirdPersonPitchUpButtonBinding
        {
            internal MultiCrewThirdPersonPitchUpButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonPitchDownButton")]
        public class MultiCrewThirdPersonPitchDownButtonBinding
        {
            internal MultiCrewThirdPersonPitchDownButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonMouseSensitivity")]
        public class MultiCrewThirdPersonMouseSensitivityBinding
        {
            internal MultiCrewThirdPersonMouseSensitivityBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; private set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonFovAxisRaw")]
        public class MultiCrewThirdPersonFovAxisRawBinding
        {
            internal MultiCrewThirdPersonFovAxisRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonFovOutButton")]
        public class MultiCrewThirdPersonFovOutButtonBinding
        {
            internal MultiCrewThirdPersonFovOutButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonFovInButton")]
        public class MultiCrewThirdPersonFovInButtonBinding
        {
            internal MultiCrewThirdPersonFovInButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "MultiCrewCockpitUICycleForward")]
        public class MultiCrewCockpitUICycleForwardBinding
        {
            internal MultiCrewCockpitUICycleForwardBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "MultiCrewCockpitUICycleBackward")]
        public class MultiCrewCockpitUICycleBackwardBinding
        {
            internal MultiCrewCockpitUICycleBackwardBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "OrderRequestDock")]
        public class OrderRequestDockBinding
        {
            internal OrderRequestDockBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "OrderDefensiveBehaviour")]
        public class OrderDefensiveBehaviourBinding
        {
            internal OrderDefensiveBehaviourBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "OrderAggressiveBehaviour")]
        public class OrderAggressiveBehaviourBinding
        {
            internal OrderAggressiveBehaviourBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "OrderFocusTarget")]
        public class OrderFocusTargetBinding
        {
            internal OrderFocusTargetBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "OrderHoldFire")]
        public class OrderHoldFireBinding
        {
            internal OrderHoldFireBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "OrderHoldPosition")]
        public class OrderHoldPositionBinding
        {
            internal OrderHoldPositionBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "OrderFollow")]
        public class OrderFollowBinding
        {
            internal OrderFollowBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "OpenOrders")]
        public class OpenOrdersBinding
        {
            internal OpenOrdersBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "PhotoCameraToggle")]
        public class PhotoCameraToggleBinding
        {
            internal PhotoCameraToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "PhotoCameraToggle_Buggy")]
        public class PhotoCameraToggleBuggyBinding
        {
            internal PhotoCameraToggleBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "VanityCameraScrollLeft")]
        public class VanityCameraScrollLeftBinding
        {
            internal VanityCameraScrollLeftBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "VanityCameraScrollRight")]
        public class VanityCameraScrollRightBinding
        {
            internal VanityCameraScrollRightBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "ToggleFreeCam")]
        public class ToggleFreeCamBinding
        {
            internal ToggleFreeCamBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "VanityCameraOne")]
        public class VanityCameraOneBinding
        {
            internal VanityCameraOneBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "VanityCameraTwo")]
        public class VanityCameraTwoBinding
        {
            internal VanityCameraTwoBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "VanityCameraThree")]
        public class VanityCameraThreeBinding
        {
            internal VanityCameraThreeBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "VanityCameraFour")]
        public class VanityCameraFourBinding
        {
            internal VanityCameraFourBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "VanityCameraFive")]
        public class VanityCameraFiveBinding
        {
            internal VanityCameraFiveBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "VanityCameraSix")]
        public class VanityCameraSixBinding
        {
            internal VanityCameraSixBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "VanityCameraSeven")]
        public class VanityCameraSevenBinding
        {
            internal VanityCameraSevenBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "VanityCameraEight")]
        public class VanityCameraEightBinding
        {
            internal VanityCameraEightBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "VanityCameraNine")]
        public class VanityCameraNineBinding
        {
            internal VanityCameraNineBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "FreeCamToggleHUD")]
        public class FreeCamToggleHUDBinding
        {
            internal FreeCamToggleHUDBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "FreeCamSpeedInc")]
        public class FreeCamSpeedIncBinding
        {
            internal FreeCamSpeedIncBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "FreeCamSpeedDec")]
        public class FreeCamSpeedDecBinding
        {
            internal FreeCamSpeedDecBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamY")]
        public class MoveFreeCamYBinding
        {
            internal MoveFreeCamYBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "ThrottleRangeFreeCam")]
        public class ThrottleRangeFreeCamBinding
        {
            internal ThrottleRangeFreeCamBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public object Value { get; private set; }
        }

        [XmlRoot(ElementName = "ToggleReverseThrottleInputFreeCam")]
        public class ToggleReverseThrottleInputFreeCamBinding
        {
            internal ToggleReverseThrottleInputFreeCamBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; private set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamForward")]
        public class MoveFreeCamForwardBinding
        {
            internal MoveFreeCamForwardBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamBackwards")]
        public class MoveFreeCamBackwardsBinding
        {
            internal MoveFreeCamBackwardsBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamX")]
        public class MoveFreeCamXBinding
        {
            internal MoveFreeCamXBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamRight")]
        public class MoveFreeCamRightBinding
        {
            internal MoveFreeCamRightBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamLeft")]
        public class MoveFreeCamLeftBinding
        {
            internal MoveFreeCamLeftBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamZ")]
        public class MoveFreeCamZBinding
        {
            internal MoveFreeCamZBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamUpAxis")]
        public class MoveFreeCamUpAxisBinding
        {
            internal MoveFreeCamUpAxisBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamDownAxis")]
        public class MoveFreeCamDownAxisBinding
        {
            internal MoveFreeCamDownAxisBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamUp")]
        public class MoveFreeCamUpBinding
        {
            internal MoveFreeCamUpBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamDown")]
        public class MoveFreeCamDownBinding
        {
            internal MoveFreeCamDownBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "PitchCameraMouse")]
        public class PitchCameraMouseBinding
        {
            internal PitchCameraMouseBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; private set; }
        }

        [XmlRoot(ElementName = "YawCameraMouse")]
        public class YawCameraMouseBinding
        {
            internal YawCameraMouseBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; private set; }
        }

        [XmlRoot(ElementName = "PitchCamera")]
        public class PitchCameraBinding
        {
            internal PitchCameraBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "FreeCamMouseSensitivity")]
        public class FreeCamMouseSensitivityBinding
        {
            internal FreeCamMouseSensitivityBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; private set; }
        }

        [XmlRoot(ElementName = "FreeCamMouseYDecay")]
        public class FreeCamMouseYDecayBinding
        {
            internal FreeCamMouseYDecayBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "PitchCameraUp")]
        public class PitchCameraUpBinding
        {
            internal PitchCameraUpBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "PitchCameraDown")]
        public class PitchCameraDownBinding
        {
            internal PitchCameraDownBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "YawCamera")]
        public class YawCameraBinding
        {
            internal YawCameraBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "FreeCamMouseXDecay")]
        public class FreeCamMouseXDecayBinding
        {
            internal FreeCamMouseXDecayBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "YawCameraLeft")]
        public class YawCameraLeftBinding
        {
            internal YawCameraLeftBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "YawCameraRight")]
        public class YawCameraRightBinding
        {
            internal YawCameraRightBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "RollCamera")]
        public class RollCameraBinding
        {
            internal RollCameraBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "RollCameraLeft")]
        public class RollCameraLeftBinding
        {
            internal RollCameraLeftBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "RollCameraRight")]
        public class RollCameraRightBinding
        {
            internal RollCameraRightBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "ToggleRotationLock")]
        public class ToggleRotationLockBinding
        {
            internal ToggleRotationLockBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "FixCameraRelativeToggle")]
        public class FixCameraRelativeToggleBinding
        {
            internal FixCameraRelativeToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "FixCameraWorldToggle")]
        public class FixCameraWorldToggleBinding
        {
            internal FixCameraWorldToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "QuitCamera")]
        public class QuitCameraBinding
        {
            internal QuitCameraBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "ToggleAdvanceMode")]
        public class ToggleAdvanceModeBinding
        {
            internal ToggleAdvanceModeBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "FreeCamZoomIn")]
        public class FreeCamZoomInBinding
        {
            internal FreeCamZoomInBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "FreeCamZoomOut")]
        public class FreeCamZoomOutBinding
        {
            internal FreeCamZoomOutBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "FStopDec")]
        public class FStopDecBinding
        {
            internal FStopDecBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "FStopInc")]
        public class FStopIncBinding
        {
            internal FStopIncBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "StoreEnableRotation")]
        public class StoreEnableRotationBinding
        {
            internal StoreEnableRotationBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "StorePitchCamera")]
        public class StorePitchCameraBinding
        {
            internal StorePitchCameraBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "StoreYawCamera")]
        public class StoreYawCameraBinding
        {
            internal StoreYawCameraBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "StoreCamZoomIn")]
        public class StoreCamZoomInBinding
        {
            internal StoreCamZoomInBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "StoreCamZoomOut")]
        public class StoreCamZoomOutBinding
        {
            internal StoreCamZoomOutBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "StoreToggle")]
        public class StoreToggleBinding
        {
            internal StoreToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "CommanderCreator_Undo")]
        public class CommanderCreatorUndoBinding
        {
            internal CommanderCreatorUndoBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "CommanderCreator_Redo")]
        public class CommanderCreatorRedoBinding
        {
            internal CommanderCreatorRedoBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "CommanderCreator_Rotation_MouseToggle")]
        public class CommanderCreatorRotationMouseToggleBinding
        {
            internal CommanderCreatorRotationMouseToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "CommanderCreator_Rotation")]
        public class CommanderCreatorRotationBinding
        {
            internal CommanderCreatorRotationBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "GalnetAudio_Play_Pause")]
        public class GalnetAudioPlayPauseBinding
        {
            internal GalnetAudioPlayPauseBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "GalnetAudio_SkipForward")]
        public class GalnetAudioSkipForwardBinding
        {
            internal GalnetAudioSkipForwardBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "GalnetAudio_SkipBackward")]
        public class GalnetAudioSkipBackwardBinding
        {
            internal GalnetAudioSkipBackwardBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "GalnetAudio_ClearQueue")]
        public class GalnetAudioClearQueueBinding
        {
            internal GalnetAudioClearQueueBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSCameraPitch")]
        public class ExplorationFSSCameraPitchBinding
        {
            internal ExplorationFSSCameraPitchBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSCameraPitchIncreaseButton")]
        public class ExplorationFSSCameraPitchIncreaseButtonBinding
        {
            internal ExplorationFSSCameraPitchIncreaseButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSCameraPitchDecreaseButton")]
        public class ExplorationFSSCameraPitchDecreaseButtonBinding
        {
            internal ExplorationFSSCameraPitchDecreaseButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSCameraYaw")]
        public class ExplorationFSSCameraYawBinding
        {
            internal ExplorationFSSCameraYawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSCameraYawIncreaseButton")]
        public class ExplorationFSSCameraYawIncreaseButtonBinding
        {
            internal ExplorationFSSCameraYawIncreaseButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSCameraYawDecreaseButton")]
        public class ExplorationFSSCameraYawDecreaseButtonBinding
        {
            internal ExplorationFSSCameraYawDecreaseButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSZoomIn")]
        public class ExplorationFSSZoomInBinding
        {
            internal ExplorationFSSZoomInBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSZoomOut")]
        public class ExplorationFSSZoomOutBinding
        {
            internal ExplorationFSSZoomOutBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSMiniZoomIn")]
        public class ExplorationFSSMiniZoomInBinding
        {
            internal ExplorationFSSMiniZoomInBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSMiniZoomOut")]
        public class ExplorationFSSMiniZoomOutBinding
        {
            internal ExplorationFSSMiniZoomOutBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSRadioTuningX_Raw")]
        public class ExplorationFSSRadioTuningXRawBinding
        {
            internal ExplorationFSSRadioTuningXRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSRadioTuningX_Increase")]
        public class ExplorationFSSRadioTuningXIncreaseBinding
        {
            internal ExplorationFSSRadioTuningXIncreaseBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSRadioTuningX_Decrease")]
        public class ExplorationFSSRadioTuningXDecreaseBinding
        {
            internal ExplorationFSSRadioTuningXDecreaseBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSRadioTuningAbsoluteX")]
        public class ExplorationFSSRadioTuningAbsoluteXBinding
        {
            internal ExplorationFSSRadioTuningAbsoluteXBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "FSSTuningSensitivity")]
        public class FSSTuningSensitivityBinding
        {
            internal FSSTuningSensitivityBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; private set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSDiscoveryScan")]
        public class ExplorationFSSDiscoveryScanBinding
        {
            internal ExplorationFSSDiscoveryScanBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSQuit")]
        public class ExplorationFSSQuitBinding
        {
            internal ExplorationFSSQuitBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "FSSMouseXMode")]
        public class FSSMouseXModeBinding
        {
            internal FSSMouseXModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; private set; }
        }

        [XmlRoot(ElementName = "FSSMouseXDecay")]
        public class FSSMouseXDecayBinding
        {
            internal FSSMouseXDecayBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "FSSMouseYMode")]
        public class FSSMouseYModeBinding
        {
            internal FSSMouseYModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; private set; }
        }

        [XmlRoot(ElementName = "FSSMouseYDecay")]
        public class FSSMouseYDecayBinding
        {
            internal FSSMouseYDecayBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "FSSMouseSensitivity")]
        public class FSSMouseSensitivityBinding
        {
            internal FSSMouseSensitivityBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; private set; }
        }

        [XmlRoot(ElementName = "FSSMouseDeadzone")]
        public class FSSMouseDeadzoneBinding
        {
            internal FSSMouseDeadzoneBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; private set; }
        }

        [XmlRoot(ElementName = "FSSMouseLinearity")]
        public class FSSMouseLinearityBinding
        {
            internal FSSMouseLinearityBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; private set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSTarget")]
        public class ExplorationFSSTargetBinding
        {
            internal ExplorationFSSTargetBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSShowHelp")]
        public class ExplorationFSSShowHelpBinding
        {
            internal ExplorationFSSShowHelpBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "ExplorationSAAChangeScannedAreaViewToggle")]
        public class ExplorationSAAChangeScannedAreaViewToggleBinding
        {
            internal ExplorationSAAChangeScannedAreaViewToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; private set; }
        }

        [XmlRoot(ElementName = "ExplorationSAAExitThirdPerson")]
        public class ExplorationSAAExitThirdPersonBinding
        {
            internal ExplorationSAAExitThirdPersonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "SAAThirdPersonMouseXMode")]
        public class SAAThirdPersonMouseXModeBinding
        {
            internal SAAThirdPersonMouseXModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public object Value { get; private set; }
        }

        [XmlRoot(ElementName = "SAAThirdPersonMouseXDecay")]
        public class SAAThirdPersonMouseXDecayBinding
        {
            internal SAAThirdPersonMouseXDecayBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "SAAThirdPersonMouseYMode")]
        public class SAAThirdPersonMouseYModeBinding
        {
            internal SAAThirdPersonMouseYModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public object Value { get; private set; }
        }

        [XmlRoot(ElementName = "SAAThirdPersonMouseYDecay")]
        public class SAAThirdPersonMouseYDecayBinding
        {
            internal SAAThirdPersonMouseYDecayBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; private set; }
        }

        [XmlRoot(ElementName = "SAAThirdPersonMouseSensitivity")]
        public class SAAThirdPersonMouseSensitivityBinding
        {
            internal SAAThirdPersonMouseSensitivityBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; private set; }
        }

        [XmlRoot(ElementName = "SAAThirdPersonYawAxisRaw")]
        public class SAAThirdPersonYawAxisRawBinding
        {
            internal SAAThirdPersonYawAxisRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "SAAThirdPersonYawLeftButton")]
        public class SAAThirdPersonYawLeftButtonBinding
        {
            internal SAAThirdPersonYawLeftButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "SAAThirdPersonYawRightButton")]
        public class SAAThirdPersonYawRightButtonBinding
        {
            internal SAAThirdPersonYawRightButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "SAAThirdPersonPitchAxisRaw")]
        public class SAAThirdPersonPitchAxisRawBinding
        {
            internal SAAThirdPersonPitchAxisRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "SAAThirdPersonPitchUpButton")]
        public class SAAThirdPersonPitchUpButtonBinding
        {
            internal SAAThirdPersonPitchUpButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "SAAThirdPersonPitchDownButton")]
        public class SAAThirdPersonPitchDownButtonBinding
        {
            internal SAAThirdPersonPitchDownButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "SAAThirdPersonFovAxisRaw")]
        public class SAAThirdPersonFovAxisRawBinding
        {
            internal SAAThirdPersonFovAxisRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; private set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; private set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; private set; }
        }

        [XmlRoot(ElementName = "SAAThirdPersonFovOutButton")]
        public class SAAThirdPersonFovOutButtonBinding
        {
            internal SAAThirdPersonFovOutButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }

        [XmlRoot(ElementName = "SAAThirdPersonFovInButton")]
        public class SAAThirdPersonFovInButtonBinding
        {
            internal SAAThirdPersonFovInButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; private set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; private set; }
        }
    }
}