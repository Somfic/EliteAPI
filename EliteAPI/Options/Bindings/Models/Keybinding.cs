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
        public string KeyboardLayout { get; set; }

        [XmlAttribute(AttributeName = "PresetName")]
        public string PresetName { get; set; }

        [XmlAttribute(AttributeName = "MajorVersion")]
        public int MajorVersion { get; set; }

        [XmlAttribute(AttributeName = "MinorVersion")]
        public int MinorVersion { get; set; }

        [XmlText]
        public string Text { get; set; }

        [XmlElement(ElementName = "MouseXMode")]
        public MouseXModeBinding MouseXMode { get; set; }

        [XmlElement(ElementName = "MouseXDecay")]
        public MouseXDecayBinding MouseXDecay { get; set; }

        [XmlElement(ElementName = "MouseYMode")]
        public MouseYModeBinding MouseYMode { get; set; }

        [XmlElement(ElementName = "MouseYDecay")]
        public MouseYDecayBinding MouseYDecay { get; set; }

        [XmlElement(ElementName = "MouseReset")]
        public MouseResetBinding MouseReset { get; set; }

        [XmlElement(ElementName = "MouseSensitivity")]
        public MouseSensitivityBinding MouseSensitivity { get; set; }

        [XmlElement(ElementName = "MouseDecayRate")]
        public MouseDecayRateBinding MouseDecayRate { get; set; }

        [XmlElement(ElementName = "MouseDeadzone")]
        public MouseDeadzoneBinding MouseDeadzone { get; set; }

        [XmlElement(ElementName = "MouseLinearity")]
        public MouseLinearityBinding MouseLinearity { get; set; }

        [XmlElement(ElementName = "MouseGUI")]
        public MouseGUIBinding MouseGUI { get; set; }

        [XmlElement(ElementName = "YawAxisRaw")]
        public YawAxisRawBinding YawAxisRaw { get; set; }

        [XmlElement(ElementName = "YawLeftButton")]
        public YawLeftButtonBinding YawLeftButton { get; set; }

        [XmlElement(ElementName = "YawRightButton")]
        public YawRightButtonBinding YawRightButton { get; set; }

        [XmlElement(ElementName = "YawToRollMode")]
        public YawToRollModeBinding YawToRollMode { get; set; }

        [XmlElement(ElementName = "YawToRollSensitivity")]
        public YawToRollSensitivityBinding YawToRollSensitivity { get; set; }

        [XmlElement(ElementName = "YawToRollMode_FAOff")]
        public YawToRollModeFAOffBinding YawToRollModeFAOff { get; set; }

        [XmlElement(ElementName = "YawToRollButton")]
        public YawToRollButtonBinding YawToRollButton { get; set; }

        [XmlElement(ElementName = "RollAxisRaw")]
        public RollAxisRawBinding RollAxisRaw { get; set; }

        [XmlElement(ElementName = "RollLeftButton")]
        public RollLeftButtonBinding RollLeftButton { get; set; }

        [XmlElement(ElementName = "RollRightButton")]
        public RollRightButtonBinding RollRightButton { get; set; }

        [XmlElement(ElementName = "PitchAxisRaw")]
        public PitchAxisRawBinding PitchAxisRaw { get; set; }

        [XmlElement(ElementName = "PitchUpButton")]
        public PitchUpButtonBinding PitchUpButton { get; set; }

        [XmlElement(ElementName = "PitchDownButton")]
        public PitchDownButtonBinding PitchDownButton { get; set; }

        [XmlElement(ElementName = "LateralThrustRaw")]
        public LateralThrustRawBinding LateralThrustRaw { get; set; }

        [XmlElement(ElementName = "LeftThrustButton")]
        public LeftThrustButtonBinding LeftThrustButton { get; set; }

        [XmlElement(ElementName = "RightThrustButton")]
        public RightThrustButtonBinding RightThrustButton { get; set; }

        [XmlElement(ElementName = "VerticalThrustRaw")]
        public VerticalThrustRawBinding VerticalThrustRaw { get; set; }

        [XmlElement(ElementName = "UpThrustButton")]
        public UpThrustButtonBinding UpThrustButton { get; set; }

        [XmlElement(ElementName = "DownThrustButton")]
        public DownThrustButtonBinding DownThrustButton { get; set; }

        [XmlElement(ElementName = "AheadThrust")]
        public AheadThrustBinding AheadThrust { get; set; }

        [XmlElement(ElementName = "ForwardThrustButton")]
        public ForwardThrustButtonBinding ForwardThrustButton { get; set; }

        [XmlElement(ElementName = "BackwardThrustButton")]
        public BackwardThrustButtonBinding BackwardThrustButton { get; set; }

        [XmlElement(ElementName = "UseAlternateFlightValuesToggle")]
        public UseAlternateFlightValuesToggleBinding UseAlternateFlightValuesToggle { get; set; }

        [XmlElement(ElementName = "YawAxisAlternate")]
        public YawAxisAlternateBinding YawAxisAlternate { get; set; }

        [XmlElement(ElementName = "RollAxisAlternate")]
        public RollAxisAlternateBinding RollAxisAlternate { get; set; }

        [XmlElement(ElementName = "PitchAxisAlternate")]
        public PitchAxisAlternateBinding PitchAxisAlternate { get; set; }

        [XmlElement(ElementName = "LateralThrustAlternate")]
        public LateralThrustAlternateBinding LateralThrustAlternate { get; set; }

        [XmlElement(ElementName = "VerticalThrustAlternate")]
        public VerticalThrustAlternateBinding VerticalThrustAlternate { get; set; }

        [XmlElement(ElementName = "ThrottleAxis")]
        public ThrottleAxisBinding ThrottleAxis { get; set; }

        [XmlElement(ElementName = "ThrottleRange")]
        public ThrottleRangeBinding ThrottleRange { get; set; }

        [XmlElement(ElementName = "ToggleReverseThrottleInput")]
        public ToggleReverseThrottleInputBinding ToggleReverseThrottleInput { get; set; }

        [XmlElement(ElementName = "ForwardKey")]
        public ForwardKeyBinding ForwardKey { get; set; }

        [XmlElement(ElementName = "BackwardKey")]
        public BackwardKeyBinding BackwardKey { get; set; }

        [XmlElement(ElementName = "ThrottleIncrement")]
        public ThrottleIncrementBinding ThrottleIncrement { get; set; }

        [XmlElement(ElementName = "SetSpeedMinus100")]
        public SetSpeedMinus100Binding SetSpeedMinus100 { get; set; }

        [XmlElement(ElementName = "SetSpeedMinus75")]
        public SetSpeedMinus75Binding SetSpeedMinus75 { get; set; }

        [XmlElement(ElementName = "SetSpeedMinus50")]
        public SetSpeedMinus50Binding SetSpeedMinus50 { get; set; }

        [XmlElement(ElementName = "SetSpeedMinus25")]
        public SetSpeedMinus25Binding SetSpeedMinus25 { get; set; }

        [XmlElement(ElementName = "SetSpeedZero")]
        public SetSpeedZeroBinding SetSpeedZero { get; set; }

        [XmlElement(ElementName = "SetSpeed25")]
        public SetSpeed25Binding SetSpeed25 { get; set; }

        [XmlElement(ElementName = "SetSpeed50")]
        public SetSpeed50Binding SetSpeed50 { get; set; }

        [XmlElement(ElementName = "SetSpeed75")]
        public SetSpeed75Binding SetSpeed75 { get; set; }

        [XmlElement(ElementName = "SetSpeed100")]
        public SetSpeed100Binding SetSpeed100 { get; set; }

        [XmlElement(ElementName = "YawAxis_Landing")]
        public YawAxisLandingBinding YawAxisLanding { get; set; }

        [XmlElement(ElementName = "YawLeftButton_Landing")]
        public YawLeftButtonLandingBinding YawLeftButtonLanding { get; set; }

        [XmlElement(ElementName = "YawRightButton_Landing")]
        public YawRightButtonLandingBinding YawRightButtonLanding { get; set; }

        [XmlElement(ElementName = "YawToRollMode_Landing")]
        public YawToRollModeLandingBinding YawToRollModeLanding { get; set; }

        [XmlElement(ElementName = "PitchAxis_Landing")]
        public PitchAxisLandingBinding PitchAxisLanding { get; set; }

        [XmlElement(ElementName = "PitchUpButton_Landing")]
        public PitchUpButtonLandingBinding PitchUpButtonLanding { get; set; }

        [XmlElement(ElementName = "PitchDownButton_Landing")]
        public PitchDownButtonLandingBinding PitchDownButtonLanding { get; set; }

        [XmlElement(ElementName = "RollAxis_Landing")]
        public RollAxisLandingBinding RollAxisLanding { get; set; }

        [XmlElement(ElementName = "RollLeftButton_Landing")]
        public RollLeftButtonLandingBinding RollLeftButtonLanding { get; set; }

        [XmlElement(ElementName = "RollRightButton_Landing")]
        public RollRightButtonLandingBinding RollRightButtonLanding { get; set; }

        [XmlElement(ElementName = "LateralThrust_Landing")]
        public LateralThrustLandingBinding LateralThrustLanding { get; set; }

        [XmlElement(ElementName = "LeftThrustButton_Landing")]
        public LeftThrustButtonLandingBinding LeftThrustButtonLanding { get; set; }

        [XmlElement(ElementName = "RightThrustButton_Landing")]
        public RightThrustButtonLandingBinding RightThrustButtonLanding { get; set; }

        [XmlElement(ElementName = "VerticalThrust_Landing")]
        public VerticalThrustLandingBinding VerticalThrustLanding { get; set; }

        [XmlElement(ElementName = "UpThrustButton_Landing")]
        public UpThrustButtonLandingBinding UpThrustButtonLanding { get; set; }

        [XmlElement(ElementName = "DownThrustButton_Landing")]
        public DownThrustButtonLandingBinding DownThrustButtonLanding { get; set; }

        [XmlElement(ElementName = "AheadThrust_Landing")]
        public AheadThrustLandingBinding AheadThrustLanding { get; set; }

        [XmlElement(ElementName = "ForwardThrustButton_Landing")]
        public ForwardThrustButtonLandingBinding ForwardThrustButtonLanding { get; set; }

        [XmlElement(ElementName = "BackwardThrustButton_Landing")]
        public BackwardThrustButtonLandingBinding BackwardThrustButtonLanding { get; set; }

        [XmlElement(ElementName = "ToggleFlightAssist")]
        public ToggleFlightAssistBinding ToggleFlightAssist { get; set; }

        [XmlElement(ElementName = "UseBoostJuice")]
        public UseBoostJuiceBinding UseBoostJuice { get; set; }

        [XmlElement(ElementName = "HyperSuperCombination")]
        public HyperSuperCombinationBinding HyperSuperCombination { get; set; }

        [XmlElement(ElementName = "Supercruise")]
        public SupercruiseBinding Supercruise { get; set; }

        [XmlElement(ElementName = "Hyperspace")]
        public HyperspaceBinding Hyperspace { get; set; }

        [XmlElement(ElementName = "DisableRotationCorrectToggle")]
        public DisableRotationCorrectToggleBinding DisableRotationCorrectToggle { get; set; }

        [XmlElement(ElementName = "OrbitLinesToggle")]
        public OrbitLinesToggleBinding OrbitLinesToggle { get; set; }

        [XmlElement(ElementName = "SelectTarget")]
        public SelectTargetBinding SelectTarget { get; set; }

        [XmlElement(ElementName = "CycleNextTarget")]
        public CycleNextTargetBinding CycleNextTarget { get; set; }

        [XmlElement(ElementName = "CyclePreviousTarget")]
        public CyclePreviousTargetBinding CyclePreviousTarget { get; set; }

        [XmlElement(ElementName = "SelectHighestThreat")]
        public SelectHighestThreatBinding SelectHighestThreat { get; set; }

        [XmlElement(ElementName = "CycleNextHostileTarget")]
        public CycleNextHostileTargetBinding CycleNextHostileTarget { get; set; }

        [XmlElement(ElementName = "CyclePreviousHostileTarget")]
        public CyclePreviousHostileTargetBinding CyclePreviousHostileTarget { get; set; }

        [XmlElement(ElementName = "TargetWingman0")]
        public TargetWingman0Binding TargetWingman0 { get; set; }

        [XmlElement(ElementName = "TargetWingman1")]
        public TargetWingman1Binding TargetWingman1 { get; set; }

        [XmlElement(ElementName = "TargetWingman2")]
        public TargetWingman2Binding TargetWingman2 { get; set; }

        [XmlElement(ElementName = "SelectTargetsTarget")]
        public SelectTargetsTargetBinding SelectTargetsTarget { get; set; }

        [XmlElement(ElementName = "WingNavLock")]
        public WingNavLockBinding WingNavLock { get; set; }

        [XmlElement(ElementName = "CycleNextSubsystem")]
        public CycleNextSubsystemBinding CycleNextSubsystem { get; set; }

        [XmlElement(ElementName = "CyclePreviousSubsystem")]
        public CyclePreviousSubsystemBinding CyclePreviousSubsystem { get; set; }

        [XmlElement(ElementName = "TargetNextRouteSystem")]
        public TargetNextRouteSystemBinding TargetNextRouteSystem { get; set; }

        [XmlElement(ElementName = "PrimaryFire")]
        public PrimaryFireBinding PrimaryFire { get; set; }

        [XmlElement(ElementName = "SecondaryFire")]
        public SecondaryFireBinding SecondaryFire { get; set; }

        [XmlElement(ElementName = "CycleFireGroupNext")]
        public CycleFireGroupNextBinding CycleFireGroupNext { get; set; }

        [XmlElement(ElementName = "CycleFireGroupPrevious")]
        public CycleFireGroupPreviousBinding CycleFireGroupPrevious { get; set; }

        [XmlElement(ElementName = "DeployHardpointToggle")]
        public DeployHardpointToggleBinding DeployHardpointToggle { get; set; }

        [XmlElement(ElementName = "DeployHardpointsOnFire")]
        public DeployHardpointsOnFireBinding DeployHardpointsOnFire { get; set; }

        [XmlElement(ElementName = "ToggleButtonUpInput")]
        public ToggleButtonUpInputBinding ToggleButtonUpInput { get; set; }

        [XmlElement(ElementName = "DeployHeatSink")]
        public DeployHeatSinkBinding DeployHeatSink { get; set; }

        [XmlElement(ElementName = "ShipSpotLightToggle")]
        public ShipSpotLightToggleBinding ShipSpotLightToggle { get; set; }

        [XmlElement(ElementName = "RadarRangeAxis")]
        public RadarRangeAxisBinding RadarRangeAxis { get; set; }

        [XmlElement(ElementName = "RadarIncreaseRange")]
        public RadarIncreaseRangeBinding RadarIncreaseRange { get; set; }

        [XmlElement(ElementName = "RadarDecreaseRange")]
        public RadarDecreaseRangeBinding RadarDecreaseRange { get; set; }

        [XmlElement(ElementName = "IncreaseEnginesPower")]
        public IncreaseEnginesPowerBinding IncreaseEnginesPower { get; set; }

        [XmlElement(ElementName = "IncreaseWeaponsPower")]
        public IncreaseWeaponsPowerBinding IncreaseWeaponsPower { get; set; }

        [XmlElement(ElementName = "IncreaseSystemsPower")]
        public IncreaseSystemsPowerBinding IncreaseSystemsPower { get; set; }

        [XmlElement(ElementName = "ResetPowerDistribution")]
        public ResetPowerDistributionBinding ResetPowerDistribution { get; set; }

        [XmlElement(ElementName = "HMDReset")]
        public HMDResetBinding HMDReset { get; set; }

        [XmlElement(ElementName = "ToggleCargoScoop")]
        public ToggleCargoScoopBinding ToggleCargoScoop { get; set; }

        [XmlElement(ElementName = "EjectAllCargo")]
        public EjectAllCargoBinding EjectAllCargo { get; set; }

        [XmlElement(ElementName = "LandingGearToggle")]
        public LandingGearToggleBinding LandingGearToggle { get; set; }

        [XmlElement(ElementName = "MicrophoneMute")]
        public MicrophoneMuteBinding MicrophoneMute { get; set; }

        [XmlElement(ElementName = "MuteButtonMode")]
        public MuteButtonModeBinding MuteButtonMode { get; set; }

        [XmlElement(ElementName = "CqcMuteButtonMode")]
        public CqcMuteButtonModeBinding CqcMuteButtonMode { get; set; }

        [XmlElement(ElementName = "UseShieldCell")]
        public UseShieldCellBinding UseShieldCell { get; set; }

        [XmlElement(ElementName = "FireChaffLauncher")]
        public FireChaffLauncherBinding FireChaffLauncher { get; set; }

        [XmlElement(ElementName = "ChargeECM")]
        public ChargeECMBinding ChargeECM { get; set; }

        [XmlElement(ElementName = "EnableRumbleTrigger")]
        public EnableRumbleTriggerBinding EnableRumbleTrigger { get; set; }

        [XmlElement(ElementName = "EnableMenuGroups")]
        public EnableMenuGroupsBinding EnableMenuGroups { get; set; }

        [XmlElement(ElementName = "WeaponColourToggle")]
        public WeaponColourToggleBinding WeaponColourToggle { get; set; }

        [XmlElement(ElementName = "EngineColourToggle")]
        public EngineColourToggleBinding EngineColourToggle { get; set; }

        [XmlElement(ElementName = "NightVisionToggle")]
        public NightVisionToggleBinding NightVisionToggle { get; set; }

        [XmlElement(ElementName = "UIFocus")]
        public UIFocusBinding UIFocus { get; set; }

        [XmlElement(ElementName = "UIFocusMode")]
        public UIFocusModeBinding UIFocusMode { get; set; }

        [XmlElement(ElementName = "FocusLeftPanel")]
        public FocusLeftPanelBinding FocusLeftPanel { get; set; }

        [XmlElement(ElementName = "FocusCommsPanel")]
        public FocusCommsPanelBinding FocusCommsPanel { get; set; }

        [XmlElement(ElementName = "FocusOnTextEntryField")]
        public FocusOnTextEntryFieldBinding FocusOnTextEntryField { get; set; }

        [XmlElement(ElementName = "QuickCommsPanel")]
        public QuickCommsPanelBinding QuickCommsPanel { get; set; }

        [XmlElement(ElementName = "FocusRadarPanel")]
        public FocusRadarPanelBinding FocusRadarPanel { get; set; }

        [XmlElement(ElementName = "FocusRightPanel")]
        public FocusRightPanelBinding FocusRightPanel { get; set; }

        [XmlElement(ElementName = "LeftPanelFocusOptions")]
        public LeftPanelFocusOptionsBinding LeftPanelFocusOptions { get; set; }

        [XmlElement(ElementName = "CommsPanelFocusOptions")]
        public CommsPanelFocusOptionsBinding CommsPanelFocusOptions { get; set; }

        [XmlElement(ElementName = "RolePanelFocusOptions")]
        public RolePanelFocusOptionsBinding RolePanelFocusOptions { get; set; }

        [XmlElement(ElementName = "RightPanelFocusOptions")]
        public RightPanelFocusOptionsBinding RightPanelFocusOptions { get; set; }

        [XmlElement(ElementName = "EnableCameraLockOn")]
        public EnableCameraLockOnBinding EnableCameraLockOn { get; set; }

        [XmlElement(ElementName = "GalaxyMapOpen")]
        public GalaxyMapOpenBinding GalaxyMapOpen { get; set; }

        [XmlElement(ElementName = "SystemMapOpen")]
        public SystemMapOpenBinding SystemMapOpen { get; set; }

        [XmlElement(ElementName = "ShowPGScoreSummaryInput")]
        public ShowPGScoreSummaryInputBinding ShowPGScoreSummaryInput { get; set; }

        [XmlElement(ElementName = "HeadLookToggle")]
        public HeadLookToggleBinding HeadLookToggle { get; set; }

        [XmlElement(ElementName = "Pause")]
        public PauseBinding Pause { get; set; }

        [XmlElement(ElementName = "FriendsMenu")]
        public FriendsMenuBinding FriendsMenu { get; set; }

        [XmlElement(ElementName = "OpenCodexGoToDiscovery")]
        public OpenCodexGoToDiscoveryBinding OpenCodexGoToDiscovery { get; set; }

        [XmlElement(ElementName = "PlayerHUDModeToggle")]
        public PlayerHUDModeToggleBinding PlayerHUDModeToggle { get; set; }

        [XmlElement(ElementName = "ExplorationFSSEnter")]
        public ExplorationFSSEnterBinding ExplorationFSSEnter { get; set; }

        [XmlElement(ElementName = "UI_Up")]
        public UIUpBinding UIUp { get; set; }

        [XmlElement(ElementName = "UI_Down")]
        public UIDownBinding UIDown { get; set; }

        [XmlElement(ElementName = "UI_Left")]
        public UILeftBinding UILeft { get; set; }

        [XmlElement(ElementName = "UI_Right")]
        public UIRightBinding UIRight { get; set; }

        [XmlElement(ElementName = "UI_Select")]
        public UISelectBinding UISelect { get; set; }

        [XmlElement(ElementName = "UI_Back")]
        public UIBackBinding UIBack { get; set; }

        [XmlElement(ElementName = "UI_Toggle")]
        public UIToggleBinding UIToggle { get; set; }

        [XmlElement(ElementName = "CycleNextPanel")]
        public CycleNextPanelBinding CycleNextPanel { get; set; }

        [XmlElement(ElementName = "CyclePreviousPanel")]
        public CyclePreviousPanelBinding CyclePreviousPanel { get; set; }

        [XmlElement(ElementName = "CycleNextPage")]
        public CycleNextPageBinding CycleNextPage { get; set; }

        [XmlElement(ElementName = "CyclePreviousPage")]
        public CyclePreviousPageBinding CyclePreviousPage { get; set; }

        [XmlElement(ElementName = "MouseHeadlook")]
        public MouseHeadlookBinding MouseHeadlook { get; set; }

        [XmlElement(ElementName = "MouseHeadlookInvert")]
        public MouseHeadlookInvertBinding MouseHeadlookInvert { get; set; }

        [XmlElement(ElementName = "MouseHeadlookSensitivity")]
        public MouseHeadlookSensitivityBinding MouseHeadlookSensitivity { get; set; }

        [XmlElement(ElementName = "HeadlookDefault")]
        public HeadlookDefaultBinding HeadlookDefault { get; set; }

        [XmlElement(ElementName = "HeadlookIncrement")]
        public HeadlookIncrementBinding HeadlookIncrement { get; set; }

        [XmlElement(ElementName = "HeadlookMode")]
        public HeadlookModeBinding HeadlookMode { get; set; }

        [XmlElement(ElementName = "HeadlookResetOnToggle")]
        public HeadlookResetOnToggleBinding HeadlookResetOnToggle { get; set; }

        [XmlElement(ElementName = "HeadlookSensitivity")]
        public HeadlookSensitivityBinding HeadlookSensitivity { get; set; }

        [XmlElement(ElementName = "HeadlookSmoothing")]
        public HeadlookSmoothingBinding HeadlookSmoothing { get; set; }

        [XmlElement(ElementName = "HeadLookReset")]
        public HeadLookResetBinding HeadLookReset { get; set; }

        [XmlElement(ElementName = "HeadLookPitchUp")]
        public HeadLookPitchUpBinding HeadLookPitchUp { get; set; }

        [XmlElement(ElementName = "HeadLookPitchDown")]
        public HeadLookPitchDownBinding HeadLookPitchDown { get; set; }

        [XmlElement(ElementName = "HeadLookPitchAxisRaw")]
        public HeadLookPitchAxisRawBinding HeadLookPitchAxisRaw { get; set; }

        [XmlElement(ElementName = "HeadLookYawLeft")]
        public HeadLookYawLeftBinding HeadLookYawLeft { get; set; }

        [XmlElement(ElementName = "HeadLookYawRight")]
        public HeadLookYawRightBinding HeadLookYawRight { get; set; }

        [XmlElement(ElementName = "HeadLookYawAxis")]
        public HeadLookYawAxisBinding HeadLookYawAxis { get; set; }

        [XmlElement(ElementName = "MotionHeadlook")]
        public MotionHeadlookBinding MotionHeadlook { get; set; }

        [XmlElement(ElementName = "HeadlookMotionSensitivity")]
        public HeadlookMotionSensitivityBinding HeadlookMotionSensitivity { get; set; }

        [XmlElement(ElementName = "yawRotateHeadlook")]
        public YawRotateHeadlookBinding YawRotateHeadlook { get; set; }

        [XmlElement(ElementName = "CamPitchAxis")]
        public CamPitchAxisBinding CamPitchAxis { get; set; }

        [XmlElement(ElementName = "CamPitchUp")]
        public CamPitchUpBinding CamPitchUp { get; set; }

        [XmlElement(ElementName = "CamPitchDown")]
        public CamPitchDownBinding CamPitchDown { get; set; }

        [XmlElement(ElementName = "CamYawAxis")]
        public CamYawAxisBinding CamYawAxis { get; set; }

        [XmlElement(ElementName = "CamYawLeft")]
        public CamYawLeftBinding CamYawLeft { get; set; }

        [XmlElement(ElementName = "CamYawRight")]
        public CamYawRightBinding CamYawRight { get; set; }

        [XmlElement(ElementName = "CamTranslateYAxis")]
        public CamTranslateYAxisBinding CamTranslateYAxis { get; set; }

        [XmlElement(ElementName = "CamTranslateForward")]
        public CamTranslateForwardBinding CamTranslateForward { get; set; }

        [XmlElement(ElementName = "CamTranslateBackward")]
        public CamTranslateBackwardBinding CamTranslateBackward { get; set; }

        [XmlElement(ElementName = "CamTranslateXAxis")]
        public CamTranslateXAxisBinding CamTranslateXAxis { get; set; }

        [XmlElement(ElementName = "CamTranslateLeft")]
        public CamTranslateLeftBinding CamTranslateLeft { get; set; }

        [XmlElement(ElementName = "CamTranslateRight")]
        public CamTranslateRightBinding CamTranslateRight { get; set; }

        [XmlElement(ElementName = "CamTranslateZAxis")]
        public CamTranslateZAxisBinding CamTranslateZAxis { get; set; }

        [XmlElement(ElementName = "CamTranslateUp")]
        public CamTranslateUpBinding CamTranslateUp { get; set; }

        [XmlElement(ElementName = "CamTranslateDown")]
        public CamTranslateDownBinding CamTranslateDown { get; set; }

        [XmlElement(ElementName = "CamZoomAxis")]
        public CamZoomAxisBinding CamZoomAxis { get; set; }

        [XmlElement(ElementName = "CamZoomIn")]
        public CamZoomInBinding CamZoomIn { get; set; }

        [XmlElement(ElementName = "CamZoomOut")]
        public CamZoomOutBinding CamZoomOut { get; set; }

        [XmlElement(ElementName = "CamTranslateZHold")]
        public CamTranslateZHoldBinding CamTranslateZHold { get; set; }

        [XmlElement(ElementName = "GalaxyMapHome")]
        public GalaxyMapHomeBinding GalaxyMapHome { get; set; }

        [XmlElement(ElementName = "ToggleDriveAssist")]
        public ToggleDriveAssistBinding ToggleDriveAssist { get; set; }

        [XmlElement(ElementName = "DriveAssistDefault")]
        public DriveAssistDefaultBinding DriveAssistDefault { get; set; }

        [XmlElement(ElementName = "MouseBuggySteeringXMode")]
        public MouseBuggySteeringXModeBinding MouseBuggySteeringXMode { get; set; }

        [XmlElement(ElementName = "MouseBuggySteeringXDecay")]
        public MouseBuggySteeringXDecayBinding MouseBuggySteeringXDecay { get; set; }

        [XmlElement(ElementName = "MouseBuggyRollingXMode")]
        public MouseBuggyRollingXModeBinding MouseBuggyRollingXMode { get; set; }

        [XmlElement(ElementName = "MouseBuggyRollingXDecay")]
        public MouseBuggyRollingXDecayBinding MouseBuggyRollingXDecay { get; set; }

        [XmlElement(ElementName = "MouseBuggyYMode")]
        public MouseBuggyYModeBinding MouseBuggyYMode { get; set; }

        [XmlElement(ElementName = "MouseBuggyYDecay")]
        public MouseBuggyYDecayBinding MouseBuggyYDecay { get; set; }

        [XmlElement(ElementName = "SteeringAxis")]
        public SteeringAxisBinding SteeringAxis { get; set; }

        [XmlElement(ElementName = "SteerLeftButton")]
        public SteerLeftButtonBinding SteerLeftButton { get; set; }

        [XmlElement(ElementName = "SteerRightButton")]
        public SteerRightButtonBinding SteerRightButton { get; set; }

        [XmlElement(ElementName = "BuggyRollAxisRaw")]
        public BuggyRollAxisRawBinding BuggyRollAxisRaw { get; set; }

        [XmlElement(ElementName = "BuggyRollLeftButton")]
        public BuggyRollLeftButtonBinding BuggyRollLeftButton { get; set; }

        [XmlElement(ElementName = "BuggyRollRightButton")]
        public BuggyRollRightButtonBinding BuggyRollRightButton { get; set; }

        [XmlElement(ElementName = "BuggyPitchAxis")]
        public BuggyPitchAxisBinding BuggyPitchAxis { get; set; }

        [XmlElement(ElementName = "BuggyPitchUpButton")]
        public BuggyPitchUpButtonBinding BuggyPitchUpButton { get; set; }

        [XmlElement(ElementName = "BuggyPitchDownButton")]
        public BuggyPitchDownButtonBinding BuggyPitchDownButton { get; set; }

        [XmlElement(ElementName = "VerticalThrustersButton")]
        public VerticalThrustersButtonBinding VerticalThrustersButton { get; set; }

        [XmlElement(ElementName = "BuggyPrimaryFireButton")]
        public BuggyPrimaryFireButtonBinding BuggyPrimaryFireButton { get; set; }

        [XmlElement(ElementName = "BuggySecondaryFireButton")]
        public BuggySecondaryFireButtonBinding BuggySecondaryFireButton { get; set; }

        [XmlElement(ElementName = "AutoBreakBuggyButton")]
        public AutoBreakBuggyButtonBinding AutoBreakBuggyButton { get; set; }

        [XmlElement(ElementName = "HeadlightsBuggyButton")]
        public HeadlightsBuggyButtonBinding HeadlightsBuggyButton { get; set; }

        [XmlElement(ElementName = "ToggleBuggyTurretButton")]
        public ToggleBuggyTurretButtonBinding ToggleBuggyTurretButton { get; set; }

        [XmlElement(ElementName = "BuggyCycleFireGroupNext")]
        public BuggyCycleFireGroupNextBinding BuggyCycleFireGroupNext { get; set; }

        [XmlElement(ElementName = "BuggyCycleFireGroupPrevious")]
        public BuggyCycleFireGroupPreviousBinding BuggyCycleFireGroupPrevious { get; set; }

        [XmlElement(ElementName = "SelectTarget_Buggy")]
        public SelectTargetBuggyBinding SelectTargetBuggy { get; set; }

        [XmlElement(ElementName = "MouseTurretXMode")]
        public MouseTurretXModeBinding MouseTurretXMode { get; set; }

        [XmlElement(ElementName = "MouseTurretXDecay")]
        public MouseTurretXDecayBinding MouseTurretXDecay { get; set; }

        [XmlElement(ElementName = "MouseTurretYMode")]
        public MouseTurretYModeBinding MouseTurretYMode { get; set; }

        [XmlElement(ElementName = "MouseTurretYDecay")]
        public MouseTurretYDecayBinding MouseTurretYDecay { get; set; }

        [XmlElement(ElementName = "BuggyTurretYawAxisRaw")]
        public BuggyTurretYawAxisRawBinding BuggyTurretYawAxisRaw { get; set; }

        [XmlElement(ElementName = "BuggyTurretYawLeftButton")]
        public BuggyTurretYawLeftButtonBinding BuggyTurretYawLeftButton { get; set; }

        [XmlElement(ElementName = "BuggyTurretYawRightButton")]
        public BuggyTurretYawRightButtonBinding BuggyTurretYawRightButton { get; set; }

        [XmlElement(ElementName = "BuggyTurretPitchAxisRaw")]
        public BuggyTurretPitchAxisRawBinding BuggyTurretPitchAxisRaw { get; set; }

        [XmlElement(ElementName = "BuggyTurretPitchUpButton")]
        public BuggyTurretPitchUpButtonBinding BuggyTurretPitchUpButton { get; set; }

        [XmlElement(ElementName = "BuggyTurretPitchDownButton")]
        public BuggyTurretPitchDownButtonBinding BuggyTurretPitchDownButton { get; set; }

        [XmlElement(ElementName = "BuggyTurretMouseSensitivity")]
        public BuggyTurretMouseSensitivityBinding BuggyTurretMouseSensitivity { get; set; }

        [XmlElement(ElementName = "BuggyTurretMouseDeadzone")]
        public BuggyTurretMouseDeadzoneBinding BuggyTurretMouseDeadzone { get; set; }

        [XmlElement(ElementName = "BuggyTurretMouseLinearity")]
        public BuggyTurretMouseLinearityBinding BuggyTurretMouseLinearity { get; set; }

        [XmlElement(ElementName = "DriveSpeedAxis")]
        public DriveSpeedAxisBinding DriveSpeedAxis { get; set; }

        [XmlElement(ElementName = "BuggyThrottleRange")]
        public BuggyThrottleRangeBinding BuggyThrottleRange { get; set; }

        [XmlElement(ElementName = "BuggyToggleReverseThrottleInput")]
        public BuggyToggleReverseThrottleInputBinding BuggyToggleReverseThrottleInput { get; set; }

        [XmlElement(ElementName = "BuggyThrottleIncrement")]
        public BuggyThrottleIncrementBinding BuggyThrottleIncrement { get; set; }

        [XmlElement(ElementName = "IncreaseSpeedButtonMax")]
        public IncreaseSpeedButtonMaxBinding IncreaseSpeedButtonMax { get; set; }

        [XmlElement(ElementName = "DecreaseSpeedButtonMax")]
        public DecreaseSpeedButtonMaxBinding DecreaseSpeedButtonMax { get; set; }

        [XmlElement(ElementName = "IncreaseSpeedButtonPartial")]
        public IncreaseSpeedButtonPartialBinding IncreaseSpeedButtonPartial { get; set; }

        [XmlElement(ElementName = "DecreaseSpeedButtonPartial")]
        public DecreaseSpeedButtonPartialBinding DecreaseSpeedButtonPartial { get; set; }

        [XmlElement(ElementName = "IncreaseEnginesPower_Buggy")]
        public IncreaseEnginesPowerBuggyBinding IncreaseEnginesPowerBuggy { get; set; }

        [XmlElement(ElementName = "IncreaseWeaponsPower_Buggy")]
        public IncreaseWeaponsPowerBuggyBinding IncreaseWeaponsPowerBuggy { get; set; }

        [XmlElement(ElementName = "IncreaseSystemsPower_Buggy")]
        public IncreaseSystemsPowerBuggyBinding IncreaseSystemsPowerBuggy { get; set; }

        [XmlElement(ElementName = "ResetPowerDistribution_Buggy")]
        public ResetPowerDistributionBuggyBinding ResetPowerDistributionBuggy { get; set; }

        [XmlElement(ElementName = "ToggleCargoScoop_Buggy")]
        public ToggleCargoScoopBuggyBinding ToggleCargoScoopBuggy { get; set; }

        [XmlElement(ElementName = "EjectAllCargo_Buggy")]
        public EjectAllCargoBuggyBinding EjectAllCargoBuggy { get; set; }

        [XmlElement(ElementName = "RecallDismissShip")]
        public RecallDismissShipBinding RecallDismissShip { get; set; }

        [XmlElement(ElementName = "UIFocus_Buggy")]
        public UIFocusBuggyBinding UIFocusBuggy { get; set; }

        [XmlElement(ElementName = "FocusLeftPanel_Buggy")]
        public FocusLeftPanelBuggyBinding FocusLeftPanelBuggy { get; set; }

        [XmlElement(ElementName = "FocusCommsPanel_Buggy")]
        public FocusCommsPanelBuggyBinding FocusCommsPanelBuggy { get; set; }

        [XmlElement(ElementName = "QuickCommsPanel_Buggy")]
        public QuickCommsPanelBuggyBinding QuickCommsPanelBuggy { get; set; }

        [XmlElement(ElementName = "FocusRadarPanel_Buggy")]
        public FocusRadarPanelBuggyBinding FocusRadarPanelBuggy { get; set; }

        [XmlElement(ElementName = "FocusRightPanel_Buggy")]
        public FocusRightPanelBuggyBinding FocusRightPanelBuggy { get; set; }

        [XmlElement(ElementName = "GalaxyMapOpen_Buggy")]
        public GalaxyMapOpenBuggyBinding GalaxyMapOpenBuggy { get; set; }

        [XmlElement(ElementName = "SystemMapOpen_Buggy")]
        public SystemMapOpenBuggyBinding SystemMapOpenBuggy { get; set; }

        [XmlElement(ElementName = "OpenCodexGoToDiscovery_Buggy")]
        public OpenCodexGoToDiscoveryBuggyBinding OpenCodexGoToDiscoveryBuggy { get; set; }

        [XmlElement(ElementName = "PlayerHUDModeToggle_Buggy")]
        public PlayerHUDModeToggleBuggyBinding PlayerHUDModeToggleBuggy { get; set; }

        [XmlElement(ElementName = "HeadLookToggle_Buggy")]
        public HeadLookToggleBuggyBinding HeadLookToggleBuggy { get; set; }

        [XmlElement(ElementName = "MultiCrewToggleMode")]
        public MultiCrewToggleModeBinding MultiCrewToggleMode { get; set; }

        [XmlElement(ElementName = "MultiCrewPrimaryFire")]
        public MultiCrewPrimaryFireBinding MultiCrewPrimaryFire { get; set; }

        [XmlElement(ElementName = "MultiCrewSecondaryFire")]
        public MultiCrewSecondaryFireBinding MultiCrewSecondaryFire { get; set; }

        [XmlElement(ElementName = "MultiCrewPrimaryUtilityFire")]
        public MultiCrewPrimaryUtilityFireBinding MultiCrewPrimaryUtilityFire { get; set; }

        [XmlElement(ElementName = "MultiCrewSecondaryUtilityFire")]
        public MultiCrewSecondaryUtilityFireBinding MultiCrewSecondaryUtilityFire { get; set; }

        [XmlElement(ElementName = "MultiCrewThirdPersonMouseXMode")]
        public MultiCrewThirdPersonMouseXModeBinding MultiCrewThirdPersonMouseXMode { get; set; }

        [XmlElement(ElementName = "MultiCrewThirdPersonMouseXDecay")]
        public MultiCrewThirdPersonMouseXDecayBinding MultiCrewThirdPersonMouseXDecay { get; set; }

        [XmlElement(ElementName = "MultiCrewThirdPersonMouseYMode")]
        public MultiCrewThirdPersonMouseYModeBinding MultiCrewThirdPersonMouseYMode { get; set; }

        [XmlElement(ElementName = "MultiCrewThirdPersonMouseYDecay")]
        public MultiCrewThirdPersonMouseYDecayBinding MultiCrewThirdPersonMouseYDecay { get; set; }

        [XmlElement(ElementName = "MultiCrewThirdPersonYawAxisRaw")]
        public MultiCrewThirdPersonYawAxisRawBinding MultiCrewThirdPersonYawAxisRaw { get; set; }

        [XmlElement(ElementName = "MultiCrewThirdPersonYawLeftButton")]
        public MultiCrewThirdPersonYawLeftButtonBinding MultiCrewThirdPersonYawLeftButton { get; set; }

        [XmlElement(ElementName = "MultiCrewThirdPersonYawRightButton")]
        public MultiCrewThirdPersonYawRightButtonBinding MultiCrewThirdPersonYawRightButton { get; set; }

        [XmlElement(ElementName = "MultiCrewThirdPersonPitchAxisRaw")]
        public MultiCrewThirdPersonPitchAxisRawBinding MultiCrewThirdPersonPitchAxisRaw { get; set; }

        [XmlElement(ElementName = "MultiCrewThirdPersonPitchUpButton")]
        public MultiCrewThirdPersonPitchUpButtonBinding MultiCrewThirdPersonPitchUpButton { get; set; }

        [XmlElement(ElementName = "MultiCrewThirdPersonPitchDownButton")]
        public MultiCrewThirdPersonPitchDownButtonBinding MultiCrewThirdPersonPitchDownButton { get; set; }

        [XmlElement(ElementName = "MultiCrewThirdPersonMouseSensitivity")]
        public MultiCrewThirdPersonMouseSensitivityBinding MultiCrewThirdPersonMouseSensitivity { get; set; }

        [XmlElement(ElementName = "MultiCrewThirdPersonFovAxisRaw")]
        public MultiCrewThirdPersonFovAxisRawBinding MultiCrewThirdPersonFovAxisRaw { get; set; }

        [XmlElement(ElementName = "MultiCrewThirdPersonFovOutButton")]
        public MultiCrewThirdPersonFovOutButtonBinding MultiCrewThirdPersonFovOutButton { get; set; }

        [XmlElement(ElementName = "MultiCrewThirdPersonFovInButton")]
        public MultiCrewThirdPersonFovInButtonBinding MultiCrewThirdPersonFovInButton { get; set; }

        [XmlElement(ElementName = "MultiCrewCockpitUICycleForward")]
        public MultiCrewCockpitUICycleForwardBinding MultiCrewCockpitUICycleForward { get; set; }

        [XmlElement(ElementName = "MultiCrewCockpitUICycleBackward")]
        public MultiCrewCockpitUICycleBackwardBinding MultiCrewCockpitUICycleBackward { get; set; }

        [XmlElement(ElementName = "OrderRequestDock")]
        public OrderRequestDockBinding OrderRequestDock { get; set; }

        [XmlElement(ElementName = "OrderDefensiveBehaviour")]
        public OrderDefensiveBehaviourBinding OrderDefensiveBehaviour { get; set; }

        [XmlElement(ElementName = "OrderAggressiveBehaviour")]
        public OrderAggressiveBehaviourBinding OrderAggressiveBehaviour { get; set; }

        [XmlElement(ElementName = "OrderFocusTarget")]
        public OrderFocusTargetBinding OrderFocusTarget { get; set; }

        [XmlElement(ElementName = "OrderHoldFire")]
        public OrderHoldFireBinding OrderHoldFire { get; set; }

        [XmlElement(ElementName = "OrderHoldPosition")]
        public OrderHoldPositionBinding OrderHoldPosition { get; set; }

        [XmlElement(ElementName = "OrderFollow")]
        public OrderFollowBinding OrderFollow { get; set; }

        [XmlElement(ElementName = "OpenOrders")]
        public OpenOrdersBinding OpenOrders { get; set; }

        [XmlElement(ElementName = "PhotoCameraToggle")]
        public PhotoCameraToggleBinding PhotoCameraToggle { get; set; }

        [XmlElement(ElementName = "PhotoCameraToggle_Buggy")]
        public PhotoCameraToggleBuggyBinding PhotoCameraToggleBuggy { get; set; }

        [XmlElement(ElementName = "VanityCameraScrollLeft")]
        public VanityCameraScrollLeftBinding VanityCameraScrollLeft { get; set; }

        [XmlElement(ElementName = "VanityCameraScrollRight")]
        public VanityCameraScrollRightBinding VanityCameraScrollRight { get; set; }

        [XmlElement(ElementName = "ToggleFreeCam")]
        public ToggleFreeCamBinding ToggleFreeCam { get; set; }

        [XmlElement(ElementName = "VanityCameraOne")]
        public VanityCameraOneBinding VanityCameraOne { get; set; }

        [XmlElement(ElementName = "VanityCameraTwo")]
        public VanityCameraTwoBinding VanityCameraTwo { get; set; }

        [XmlElement(ElementName = "VanityCameraThree")]
        public VanityCameraThreeBinding VanityCameraThree { get; set; }

        [XmlElement(ElementName = "VanityCameraFour")]
        public VanityCameraFourBinding VanityCameraFour { get; set; }

        [XmlElement(ElementName = "VanityCameraFive")]
        public VanityCameraFiveBinding VanityCameraFive { get; set; }

        [XmlElement(ElementName = "VanityCameraSix")]
        public VanityCameraSixBinding VanityCameraSix { get; set; }

        [XmlElement(ElementName = "VanityCameraSeven")]
        public VanityCameraSevenBinding VanityCameraSeven { get; set; }

        [XmlElement(ElementName = "VanityCameraEight")]
        public VanityCameraEightBinding VanityCameraEight { get; set; }

        [XmlElement(ElementName = "VanityCameraNine")]
        public VanityCameraNineBinding VanityCameraNine { get; set; }

        [XmlElement(ElementName = "FreeCamToggleHUD")]
        public FreeCamToggleHUDBinding FreeCamToggleHUD { get; set; }

        [XmlElement(ElementName = "FreeCamSpeedInc")]
        public FreeCamSpeedIncBinding FreeCamSpeedInc { get; set; }

        [XmlElement(ElementName = "FreeCamSpeedDec")]
        public FreeCamSpeedDecBinding FreeCamSpeedDec { get; set; }

        [XmlElement(ElementName = "MoveFreeCamY")]
        public MoveFreeCamYBinding MoveFreeCamY { get; set; }

        [XmlElement(ElementName = "ThrottleRangeFreeCam")]
        public ThrottleRangeFreeCamBinding ThrottleRangeFreeCam { get; set; }

        [XmlElement(ElementName = "ToggleReverseThrottleInputFreeCam")]
        public ToggleReverseThrottleInputFreeCamBinding ToggleReverseThrottleInputFreeCam { get; set; }

        [XmlElement(ElementName = "MoveFreeCamForward")]
        public MoveFreeCamForwardBinding MoveFreeCamForward { get; set; }

        [XmlElement(ElementName = "MoveFreeCamBackwards")]
        public MoveFreeCamBackwardsBinding MoveFreeCamBackwards { get; set; }

        [XmlElement(ElementName = "MoveFreeCamX")]
        public MoveFreeCamXBinding MoveFreeCamX { get; set; }

        [XmlElement(ElementName = "MoveFreeCamRight")]
        public MoveFreeCamRightBinding MoveFreeCamRight { get; set; }

        [XmlElement(ElementName = "MoveFreeCamLeft")]
        public MoveFreeCamLeftBinding MoveFreeCamLeft { get; set; }

        [XmlElement(ElementName = "MoveFreeCamZ")]
        public MoveFreeCamZBinding MoveFreeCamZ { get; set; }

        [XmlElement(ElementName = "MoveFreeCamUpAxis")]
        public MoveFreeCamUpAxisBinding MoveFreeCamUpAxis { get; set; }

        [XmlElement(ElementName = "MoveFreeCamDownAxis")]
        public MoveFreeCamDownAxisBinding MoveFreeCamDownAxis { get; set; }

        [XmlElement(ElementName = "MoveFreeCamUp")]
        public MoveFreeCamUpBinding MoveFreeCamUp { get; set; }

        [XmlElement(ElementName = "MoveFreeCamDown")]
        public MoveFreeCamDownBinding MoveFreeCamDown { get; set; }

        [XmlElement(ElementName = "PitchCameraMouse")]
        public PitchCameraMouseBinding PitchCameraMouse { get; set; }

        [XmlElement(ElementName = "YawCameraMouse")]
        public YawCameraMouseBinding YawCameraMouse { get; set; }

        [XmlElement(ElementName = "PitchCamera")]
        public PitchCameraBinding PitchCamera { get; set; }

        [XmlElement(ElementName = "FreeCamMouseSensitivity")]
        public FreeCamMouseSensitivityBinding FreeCamMouseSensitivity { get; set; }

        [XmlElement(ElementName = "FreeCamMouseYDecay")]
        public FreeCamMouseYDecayBinding FreeCamMouseYDecay { get; set; }

        [XmlElement(ElementName = "PitchCameraUp")]
        public PitchCameraUpBinding PitchCameraUp { get; set; }

        [XmlElement(ElementName = "PitchCameraDown")]
        public PitchCameraDownBinding PitchCameraDown { get; set; }

        [XmlElement(ElementName = "YawCamera")]
        public YawCameraBinding YawCamera { get; set; }

        [XmlElement(ElementName = "FreeCamMouseXDecay")]
        public FreeCamMouseXDecayBinding FreeCamMouseXDecay { get; set; }

        [XmlElement(ElementName = "YawCameraLeft")]
        public YawCameraLeftBinding YawCameraLeft { get; set; }

        [XmlElement(ElementName = "YawCameraRight")]
        public YawCameraRightBinding YawCameraRight { get; set; }

        [XmlElement(ElementName = "RollCamera")]
        public RollCameraBinding RollCamera { get; set; }

        [XmlElement(ElementName = "RollCameraLeft")]
        public RollCameraLeftBinding RollCameraLeft { get; set; }

        [XmlElement(ElementName = "RollCameraRight")]
        public RollCameraRightBinding RollCameraRight { get; set; }

        [XmlElement(ElementName = "ToggleRotationLock")]
        public ToggleRotationLockBinding ToggleRotationLock { get; set; }

        [XmlElement(ElementName = "FixCameraRelativeToggle")]
        public FixCameraRelativeToggleBinding FixCameraRelativeToggle { get; set; }

        [XmlElement(ElementName = "FixCameraWorldToggle")]
        public FixCameraWorldToggleBinding FixCameraWorldToggle { get; set; }

        [XmlElement(ElementName = "QuitCamera")]
        public QuitCameraBinding QuitCamera { get; set; }

        [XmlElement(ElementName = "ToggleAdvanceMode")]
        public ToggleAdvanceModeBinding ToggleAdvanceMode { get; set; }

        [XmlElement(ElementName = "FreeCamZoomIn")]
        public FreeCamZoomInBinding FreeCamZoomIn { get; set; }

        [XmlElement(ElementName = "FreeCamZoomOut")]
        public FreeCamZoomOutBinding FreeCamZoomOut { get; set; }

        [XmlElement(ElementName = "FStopDec")]
        public FStopDecBinding FStopDec { get; set; }

        [XmlElement(ElementName = "FStopInc")]
        public FStopIncBinding FStopInc { get; set; }

        [XmlElement(ElementName = "StoreEnableRotation")]
        public StoreEnableRotationBinding StoreEnableRotation { get; set; }

        [XmlElement(ElementName = "StorePitchCamera")]
        public StorePitchCameraBinding StorePitchCamera { get; set; }

        [XmlElement(ElementName = "StoreYawCamera")]
        public StoreYawCameraBinding StoreYawCamera { get; set; }

        [XmlElement(ElementName = "StoreCamZoomIn")]
        public StoreCamZoomInBinding StoreCamZoomIn { get; set; }

        [XmlElement(ElementName = "StoreCamZoomOut")]
        public StoreCamZoomOutBinding StoreCamZoomOut { get; set; }

        [XmlElement(ElementName = "StoreToggle")]
        public StoreToggleBinding StoreToggle { get; set; }

        [XmlElement(ElementName = "CommanderCreator_Undo")]
        public CommanderCreatorUndoBinding CommanderCreatorUndo { get; set; }

        [XmlElement(ElementName = "CommanderCreator_Redo")]
        public CommanderCreatorRedoBinding CommanderCreatorRedo { get; set; }

        [XmlElement(ElementName = "CommanderCreator_Rotation_MouseToggle")]
        public CommanderCreatorRotationMouseToggleBinding CommanderCreatorRotationMouseToggle { get; set; }

        [XmlElement(ElementName = "CommanderCreator_Rotation")]
        public CommanderCreatorRotationBinding CommanderCreatorRotation { get; set; }

        [XmlElement(ElementName = "GalnetAudio_Play_Pause")]
        public GalnetAudioPlayPauseBinding GalnetAudioPlayPause { get; set; }

        [XmlElement(ElementName = "GalnetAudio_SkipForward")]
        public GalnetAudioSkipForwardBinding GalnetAudioSkipForward { get; set; }

        [XmlElement(ElementName = "GalnetAudio_SkipBackward")]
        public GalnetAudioSkipBackwardBinding GalnetAudioSkipBackward { get; set; }

        [XmlElement(ElementName = "GalnetAudio_ClearQueue")]
        public GalnetAudioClearQueueBinding GalnetAudioClearQueue { get; set; }

        [XmlElement(ElementName = "ExplorationFSSCameraPitch")]
        public ExplorationFSSCameraPitchBinding ExplorationFSSCameraPitch { get; set; }

        [XmlElement(ElementName = "ExplorationFSSCameraPitchIncreaseButton")]
        public ExplorationFSSCameraPitchIncreaseButtonBinding ExplorationFSSCameraPitchIncreaseButton { get; set; }

        [XmlElement(ElementName = "ExplorationFSSCameraPitchDecreaseButton")]
        public ExplorationFSSCameraPitchDecreaseButtonBinding ExplorationFSSCameraPitchDecreaseButton { get; set; }

        [XmlElement(ElementName = "ExplorationFSSCameraYaw")]
        public ExplorationFSSCameraYawBinding ExplorationFSSCameraYaw { get; set; }

        [XmlElement(ElementName = "ExplorationFSSCameraYawIncreaseButton")]
        public ExplorationFSSCameraYawIncreaseButtonBinding ExplorationFSSCameraYawIncreaseButton { get; set; }

        [XmlElement(ElementName = "ExplorationFSSCameraYawDecreaseButton")]
        public ExplorationFSSCameraYawDecreaseButtonBinding ExplorationFSSCameraYawDecreaseButton { get; set; }

        [XmlElement(ElementName = "ExplorationFSSZoomIn")]
        public ExplorationFSSZoomInBinding ExplorationFSSZoomIn { get; set; }

        [XmlElement(ElementName = "ExplorationFSSZoomOut")]
        public ExplorationFSSZoomOutBinding ExplorationFSSZoomOut { get; set; }

        [XmlElement(ElementName = "ExplorationFSSMiniZoomIn")]
        public ExplorationFSSMiniZoomInBinding ExplorationFSSMiniZoomIn { get; set; }

        [XmlElement(ElementName = "ExplorationFSSMiniZoomOut")]
        public ExplorationFSSMiniZoomOutBinding ExplorationFSSMiniZoomOut { get; set; }

        [XmlElement(ElementName = "ExplorationFSSRadioTuningX_Raw")]
        public ExplorationFSSRadioTuningXRawBinding ExplorationFSSRadioTuningXRaw { get; set; }

        [XmlElement(ElementName = "ExplorationFSSRadioTuningX_Increase")]
        public ExplorationFSSRadioTuningXIncreaseBinding ExplorationFSSRadioTuningXIncrease { get; set; }

        [XmlElement(ElementName = "ExplorationFSSRadioTuningX_Decrease")]
        public ExplorationFSSRadioTuningXDecreaseBinding ExplorationFSSRadioTuningXDecrease { get; set; }

        [XmlElement(ElementName = "ExplorationFSSRadioTuningAbsoluteX")]
        public ExplorationFSSRadioTuningAbsoluteXBinding ExplorationFSSRadioTuningAbsoluteX { get; set; }

        [XmlElement(ElementName = "FSSTuningSensitivity")]
        public FSSTuningSensitivityBinding FSSTuningSensitivity { get; set; }

        [XmlElement(ElementName = "ExplorationFSSDiscoveryScan")]
        public ExplorationFSSDiscoveryScanBinding ExplorationFSSDiscoveryScan { get; set; }

        [XmlElement(ElementName = "ExplorationFSSQuit")]
        public ExplorationFSSQuitBinding ExplorationFSSQuit { get; set; }

        [XmlElement(ElementName = "FSSMouseXMode")]
        public FSSMouseXModeBinding FSSMouseXMode { get; set; }

        [XmlElement(ElementName = "FSSMouseXDecay")]
        public FSSMouseXDecayBinding FSSMouseXDecay { get; set; }

        [XmlElement(ElementName = "FSSMouseYMode")]
        public FSSMouseYModeBinding FSSMouseYMode { get; set; }

        [XmlElement(ElementName = "FSSMouseYDecay")]
        public FSSMouseYDecayBinding FSSMouseYDecay { get; set; }

        [XmlElement(ElementName = "FSSMouseSensitivity")]
        public FSSMouseSensitivityBinding FSSMouseSensitivity { get; set; }

        [XmlElement(ElementName = "FSSMouseDeadzone")]
        public FSSMouseDeadzoneBinding FSSMouseDeadzone { get; set; }

        [XmlElement(ElementName = "FSSMouseLinearity")]
        public FSSMouseLinearityBinding FSSMouseLinearity { get; set; }

        [XmlElement(ElementName = "ExplorationFSSTarget")]
        public ExplorationFSSTargetBinding ExplorationFSSTarget { get; set; }

        [XmlElement(ElementName = "ExplorationFSSShowHelp")]
        public ExplorationFSSShowHelpBinding ExplorationFSSShowHelp { get; set; }

        [XmlElement(ElementName = "ExplorationSAAChangeScannedAreaViewToggle")]
        public ExplorationSAAChangeScannedAreaViewToggleBinding ExplorationSAAChangeScannedAreaViewToggle { get; set; }

        [XmlElement(ElementName = "ExplorationSAAExitThirdPerson")]
        public ExplorationSAAExitThirdPersonBinding ExplorationSAAExitThirdPerson { get; set; }

        [XmlElement(ElementName = "SAAThirdPersonMouseXMode")]
        public SAAThirdPersonMouseXModeBinding SAAThirdPersonMouseXMode { get; set; }

        [XmlElement(ElementName = "SAAThirdPersonMouseXDecay")]
        public SAAThirdPersonMouseXDecayBinding SAAThirdPersonMouseXDecay { get; set; }

        [XmlElement(ElementName = "SAAThirdPersonMouseYMode")]
        public SAAThirdPersonMouseYModeBinding SAAThirdPersonMouseYMode { get; set; }

        [XmlElement(ElementName = "SAAThirdPersonMouseYDecay")]
        public SAAThirdPersonMouseYDecayBinding SAAThirdPersonMouseYDecay { get; set; }

        [XmlElement(ElementName = "SAAThirdPersonMouseSensitivity")]
        public SAAThirdPersonMouseSensitivityBinding SAAThirdPersonMouseSensitivity { get; set; }

        [XmlElement(ElementName = "SAAThirdPersonYawAxisRaw")]
        public SAAThirdPersonYawAxisRawBinding SAAThirdPersonYawAxisRaw { get; set; }

        [XmlElement(ElementName = "SAAThirdPersonYawLeftButton")]
        public SAAThirdPersonYawLeftButtonBinding SAAThirdPersonYawLeftButton { get; set; }

        [XmlElement(ElementName = "SAAThirdPersonYawRightButton")]
        public SAAThirdPersonYawRightButtonBinding SAAThirdPersonYawRightButton { get; set; }

        [XmlElement(ElementName = "SAAThirdPersonPitchAxisRaw")]
        public SAAThirdPersonPitchAxisRawBinding SAAThirdPersonPitchAxisRaw { get; set; }

        [XmlElement(ElementName = "SAAThirdPersonPitchUpButton")]
        public SAAThirdPersonPitchUpButtonBinding SAAThirdPersonPitchUpButton { get; set; }

        [XmlElement(ElementName = "SAAThirdPersonPitchDownButton")]
        public SAAThirdPersonPitchDownButtonBinding SAAThirdPersonPitchDownButton { get; set; }

        [XmlElement(ElementName = "SAAThirdPersonFovAxisRaw")]
        public SAAThirdPersonFovAxisRawBinding SAAThirdPersonFovAxisRaw { get; set; }

        [XmlElement(ElementName = "SAAThirdPersonFovOutButton")]
        public SAAThirdPersonFovOutButtonBinding SAAThirdPersonFovOutButton { get; set; }

        [XmlElement(ElementName = "SAAThirdPersonFovInButton")]
        public SAAThirdPersonFovInButtonBinding SAAThirdPersonFovInButton { get; set; }

        [XmlRoot(ElementName = "Primary")]
        public class PrimaryBinding
        {
            internal PrimaryBinding() { }

            [XmlAttribute(AttributeName = "Device")]
            public string Device { get; set; }

            [XmlAttribute(AttributeName = "Key")]
            public string Key { get; set; }

            [XmlElement(ElementName = "Modifier")]
            public ModifierBinding Modifier { get; set; }
        }

        [XmlRoot(ElementName = "Secondary")]
        public class SecondaryBinding
        {
            internal SecondaryBinding() { }

            [XmlAttribute(AttributeName = "Device")]
            public string Device { get; set; }

            [XmlAttribute(AttributeName = "Key")]
            public string Key { get; set; }
            
            [XmlElement(ElementName = "Modifier")]
            public ModifierBinding Modifier { get; set; }
        }
        
        [XmlRoot(ElementName = "MouseXMode")]
        public class MouseXModeBinding
        {
            internal MouseXModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseXDecay")]
        public class MouseXDecayBinding
        {
            internal MouseXDecayBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseYMode")]
        public class MouseYModeBinding
        {
            internal MouseYModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseYDecay")]
        public class MouseYDecayBinding
        {
            internal MouseYDecayBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseReset")]
        public class MouseResetBinding
        {
            internal MouseResetBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MouseSensitivity")]
        public class MouseSensitivityBinding
        {
            internal MouseSensitivityBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseDecayRate")]
        public class MouseDecayRateBinding
        {
            internal MouseDecayRateBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseDeadzone")]
        public class MouseDeadzoneBinding
        {
            internal MouseDeadzoneBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseLinearity")]
        public class MouseLinearityBinding
        {
            internal MouseLinearityBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseGUI")]
        public class MouseGUIBinding
        {
            internal MouseGUIBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "Binding")]
        public class BindingBinding
        {
            internal BindingBinding() { }

            [XmlAttribute(AttributeName = "Device")]
            public string Device { get; set; }

            [XmlAttribute(AttributeName = "Key")]
            public string Key { get; set; }
        }

        [XmlRoot(ElementName = "Inverted")]
        public class InvertedBinding
        {
            internal InvertedBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "Deadzone")]
        public class DeadzoneBinding
        {
            internal DeadzoneBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; set; }
        }

        [XmlRoot(ElementName = "YawAxisRaw")]
        public class YawAxisRawBinding
        {
            internal YawAxisRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "YawLeftButton")]
        public class YawLeftButtonBinding
        {
            internal YawLeftButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "YawRightButton")]
        public class YawRightButtonBinding
        {
            internal YawRightButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "YawToRollMode")]
        public class YawToRollModeBinding
        {
            internal YawToRollModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "YawToRollSensitivity")]
        public class YawToRollSensitivityBinding
        {
            internal YawToRollSensitivityBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; set; }
        }

        [XmlRoot(ElementName = "YawToRollMode_FAOff")]
        public class YawToRollModeFAOffBinding
        {
            internal YawToRollModeFAOffBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "ToggleOn")]
        public class ToggleOnBinding
        {
            internal ToggleOnBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "YawToRollButton")]
        public class YawToRollButtonBinding
        {
            internal YawToRollButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "RollAxisRaw")]
        public class RollAxisRawBinding
        {
            internal RollAxisRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "RollLeftButton")]
        public class RollLeftButtonBinding
        {
            internal RollLeftButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "RollRightButton")]
        public class RollRightButtonBinding
        {
            internal RollRightButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "PitchAxisRaw")]
        public class PitchAxisRawBinding
        {
            internal PitchAxisRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "PitchUpButton")]
        public class PitchUpButtonBinding
        {
            internal PitchUpButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "PitchDownButton")]
        public class PitchDownButtonBinding
        {
            internal PitchDownButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "LateralThrustRaw")]
        public class LateralThrustRawBinding
        {
            internal LateralThrustRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "LeftThrustButton")]
        public class LeftThrustButtonBinding
        {
            internal LeftThrustButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "RightThrustButton")]
        public class RightThrustButtonBinding
        {
            internal RightThrustButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "VerticalThrustRaw")]
        public class VerticalThrustRawBinding
        {
            internal VerticalThrustRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "UpThrustButton")]
        public class UpThrustButtonBinding
        {
            internal UpThrustButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "DownThrustButton")]
        public class DownThrustButtonBinding
        {
            internal DownThrustButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "AheadThrust")]
        public class AheadThrustBinding
        {
            internal AheadThrustBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "ForwardThrustButton")]
        public class ForwardThrustButtonBinding
        {
            internal ForwardThrustButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "BackwardThrustButton")]
        public class BackwardThrustButtonBinding
        {
            internal BackwardThrustButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "UseAlternateFlightValuesToggle")]
        public class UseAlternateFlightValuesToggleBinding
        {
            internal UseAlternateFlightValuesToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "YawAxisAlternate")]
        public class YawAxisAlternateBinding
        {
            internal YawAxisAlternateBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "RollAxisAlternate")]
        public class RollAxisAlternateBinding
        {
            internal RollAxisAlternateBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "PitchAxisAlternate")]
        public class PitchAxisAlternateBinding
        {
            internal PitchAxisAlternateBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "LateralThrustAlternate")]
        public class LateralThrustAlternateBinding
        {
            internal LateralThrustAlternateBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "VerticalThrustAlternate")]
        public class VerticalThrustAlternateBinding
        {
            internal VerticalThrustAlternateBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "ThrottleAxis")]
        public class ThrottleAxisBinding
        {
            internal ThrottleAxisBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "ThrottleRange")]
        public class ThrottleRangeBinding
        {
            internal ThrottleRangeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "ToggleReverseThrottleInput")]
        public class ToggleReverseThrottleInputBinding
        {
            internal ToggleReverseThrottleInputBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "ForwardKey")]
        public class ForwardKeyBinding
        {
            internal ForwardKeyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "BackwardKey")]
        public class BackwardKeyBinding
        {
            internal BackwardKeyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ThrottleIncrement")]
        public class ThrottleIncrementBinding
        {
            internal ThrottleIncrementBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; set; }
        }

        [XmlRoot(ElementName = "Modifier")]
        public class ModifierBinding
        {
            internal ModifierBinding() { }

            [XmlAttribute(AttributeName = "Device")]
            public string Device { get; set; }

            [XmlAttribute(AttributeName = "Key")]
            public string Key { get; set; }
        }

        [XmlRoot(ElementName = "SetSpeedMinus100")]
        public class SetSpeedMinus100Binding
        {
            internal SetSpeedMinus100Binding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SetSpeedMinus75")]
        public class SetSpeedMinus75Binding
        {
            internal SetSpeedMinus75Binding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SetSpeedMinus50")]
        public class SetSpeedMinus50Binding
        {
            internal SetSpeedMinus50Binding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SetSpeedMinus25")]
        public class SetSpeedMinus25Binding
        {
            internal SetSpeedMinus25Binding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SetSpeedZero")]
        public class SetSpeedZeroBinding
        {
            internal SetSpeedZeroBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SetSpeed25")]
        public class SetSpeed25Binding
        {
            internal SetSpeed25Binding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SetSpeed50")]
        public class SetSpeed50Binding
        {
            internal SetSpeed50Binding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SetSpeed75")]
        public class SetSpeed75Binding
        {
            internal SetSpeed75Binding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SetSpeed100")]
        public class SetSpeed100Binding
        {
            internal SetSpeed100Binding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "YawAxis_Landing")]
        public class YawAxisLandingBinding
        {
            internal YawAxisLandingBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "YawLeftButton_Landing")]
        public class YawLeftButtonLandingBinding
        {
            internal YawLeftButtonLandingBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "YawRightButton_Landing")]
        public class YawRightButtonLandingBinding
        {
            internal YawRightButtonLandingBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "YawToRollMode_Landing")]
        public class YawToRollModeLandingBinding
        {
            internal YawToRollModeLandingBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "PitchAxis_Landing")]
        public class PitchAxisLandingBinding
        {
            internal PitchAxisLandingBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "PitchUpButton_Landing")]
        public class PitchUpButtonLandingBinding
        {
            internal PitchUpButtonLandingBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "PitchDownButton_Landing")]
        public class PitchDownButtonLandingBinding
        {
            internal PitchDownButtonLandingBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "RollAxis_Landing")]
        public class RollAxisLandingBinding
        {
            internal RollAxisLandingBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "RollLeftButton_Landing")]
        public class RollLeftButtonLandingBinding
        {
            internal RollLeftButtonLandingBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "RollRightButton_Landing")]
        public class RollRightButtonLandingBinding
        {
            internal RollRightButtonLandingBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "LateralThrust_Landing")]
        public class LateralThrustLandingBinding
        {
            internal LateralThrustLandingBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "LeftThrustButton_Landing")]
        public class LeftThrustButtonLandingBinding
        {
            internal LeftThrustButtonLandingBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "RightThrustButton_Landing")]
        public class RightThrustButtonLandingBinding
        {
            internal RightThrustButtonLandingBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "VerticalThrust_Landing")]
        public class VerticalThrustLandingBinding
        {
            internal VerticalThrustLandingBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "UpThrustButton_Landing")]
        public class UpThrustButtonLandingBinding
        {
            internal UpThrustButtonLandingBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "DownThrustButton_Landing")]
        public class DownThrustButtonLandingBinding
        {
            internal DownThrustButtonLandingBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "AheadThrust_Landing")]
        public class AheadThrustLandingBinding
        {
            internal AheadThrustLandingBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "ForwardThrustButton_Landing")]
        public class ForwardThrustButtonLandingBinding
        {
            internal ForwardThrustButtonLandingBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "BackwardThrustButton_Landing")]
        public class BackwardThrustButtonLandingBinding
        {
            internal BackwardThrustButtonLandingBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ToggleFlightAssist")]
        public class ToggleFlightAssistBinding
        {
            internal ToggleFlightAssistBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "UseBoostJuice")]
        public class UseBoostJuiceBinding
        {
            internal UseBoostJuiceBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "HyperSuperCombination")]
        public class HyperSuperCombinationBinding
        {
            internal HyperSuperCombinationBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "Supercruise")]
        public class SupercruiseBinding
        {
            internal SupercruiseBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "Hyperspace")]
        public class HyperspaceBinding
        {
            internal HyperspaceBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "DisableRotationCorrectToggle")]
        public class DisableRotationCorrectToggleBinding
        {
            internal DisableRotationCorrectToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "OrbitLinesToggle")]
        public class OrbitLinesToggleBinding
        {
            internal OrbitLinesToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SelectTarget")]
        public class SelectTargetBinding
        {
            internal SelectTargetBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CycleNextTarget")]
        public class CycleNextTargetBinding
        {
            internal CycleNextTargetBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CyclePreviousTarget")]
        public class CyclePreviousTargetBinding
        {
            internal CyclePreviousTargetBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SelectHighestThreat")]
        public class SelectHighestThreatBinding
        {
            internal SelectHighestThreatBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CycleNextHostileTarget")]
        public class CycleNextHostileTargetBinding
        {
            internal CycleNextHostileTargetBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CyclePreviousHostileTarget")]
        public class CyclePreviousHostileTargetBinding
        {
            internal CyclePreviousHostileTargetBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "TargetWingman0")]
        public class TargetWingman0Binding
        {
            internal TargetWingman0Binding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "TargetWingman1")]
        public class TargetWingman1Binding
        {
            internal TargetWingman1Binding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "TargetWingman2")]
        public class TargetWingman2Binding
        {
            internal TargetWingman2Binding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SelectTargetsTarget")]
        public class SelectTargetsTargetBinding
        {
            internal SelectTargetsTargetBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "WingNavLock")]
        public class WingNavLockBinding
        {
            internal WingNavLockBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CycleNextSubsystem")]
        public class CycleNextSubsystemBinding
        {
            internal CycleNextSubsystemBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CyclePreviousSubsystem")]
        public class CyclePreviousSubsystemBinding
        {
            internal CyclePreviousSubsystemBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "TargetNextRouteSystem")]
        public class TargetNextRouteSystemBinding
        {
            internal TargetNextRouteSystemBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "PrimaryFire")]
        public class PrimaryFireBinding
        {
            internal PrimaryFireBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SecondaryFire")]
        public class SecondaryFireBinding
        {
            internal SecondaryFireBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CycleFireGroupNext")]
        public class CycleFireGroupNextBinding
        {
            internal CycleFireGroupNextBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CycleFireGroupPrevious")]
        public class CycleFireGroupPreviousBinding
        {
            internal CycleFireGroupPreviousBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "DeployHardpointToggle")]
        public class DeployHardpointToggleBinding
        {
            internal DeployHardpointToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "DeployHardpointsOnFire")]
        public class DeployHardpointsOnFireBinding
        {
            internal DeployHardpointsOnFireBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "ToggleButtonUpInput")]
        public class ToggleButtonUpInputBinding
        {
            internal ToggleButtonUpInputBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "DeployHeatSink")]
        public class DeployHeatSinkBinding
        {
            internal DeployHeatSinkBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ShipSpotLightToggle")]
        public class ShipSpotLightToggleBinding
        {
            internal ShipSpotLightToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "RadarRangeAxis")]
        public class RadarRangeAxisBinding
        {
            internal RadarRangeAxisBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "RadarIncreaseRange")]
        public class RadarIncreaseRangeBinding
        {
            internal RadarIncreaseRangeBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "RadarDecreaseRange")]
        public class RadarDecreaseRangeBinding
        {
            internal RadarDecreaseRangeBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "IncreaseEnginesPower")]
        public class IncreaseEnginesPowerBinding
        {
            internal IncreaseEnginesPowerBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "IncreaseWeaponsPower")]
        public class IncreaseWeaponsPowerBinding
        {
            internal IncreaseWeaponsPowerBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "IncreaseSystemsPower")]
        public class IncreaseSystemsPowerBinding
        {
            internal IncreaseSystemsPowerBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ResetPowerDistribution")]
        public class ResetPowerDistributionBinding
        {
            internal ResetPowerDistributionBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "HMDReset")]
        public class HMDResetBinding
        {
            internal HMDResetBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ToggleCargoScoop")]
        public class ToggleCargoScoopBinding
        {
            internal ToggleCargoScoopBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "EjectAllCargo")]
        public class EjectAllCargoBinding
        {
            internal EjectAllCargoBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "LandingGearToggle")]
        public class LandingGearToggleBinding
        {
            internal LandingGearToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MicrophoneMute")]
        public class MicrophoneMuteBinding
        {
            internal MicrophoneMuteBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "MuteButtonMode")]
        public class MuteButtonModeBinding
        {
            internal MuteButtonModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "CqcMuteButtonMode")]
        public class CqcMuteButtonModeBinding
        {
            internal CqcMuteButtonModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "UseShieldCell")]
        public class UseShieldCellBinding
        {
            internal UseShieldCellBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FireChaffLauncher")]
        public class FireChaffLauncherBinding
        {
            internal FireChaffLauncherBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ChargeECM")]
        public class ChargeECMBinding
        {
            internal ChargeECMBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "EnableRumbleTrigger")]
        public class EnableRumbleTriggerBinding
        {
            internal EnableRumbleTriggerBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "EnableMenuGroups")]
        public class EnableMenuGroupsBinding
        {
            internal EnableMenuGroupsBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "WeaponColourToggle")]
        public class WeaponColourToggleBinding
        {
            internal WeaponColourToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "EngineColourToggle")]
        public class EngineColourToggleBinding
        {
            internal EngineColourToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "NightVisionToggle")]
        public class NightVisionToggleBinding
        {
            internal NightVisionToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "UIFocus")]
        public class UIFocusBinding
        {
            internal UIFocusBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "UIFocusMode")]
        public class UIFocusModeBinding
        {
            internal UIFocusModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "FocusLeftPanel")]
        public class FocusLeftPanelBinding
        {
            internal FocusLeftPanelBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FocusCommsPanel")]
        public class FocusCommsPanelBinding
        {
            internal FocusCommsPanelBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FocusOnTextEntryField")]
        public class FocusOnTextEntryFieldBinding
        {
            internal FocusOnTextEntryFieldBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "QuickCommsPanel")]
        public class QuickCommsPanelBinding
        {
            internal QuickCommsPanelBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FocusRadarPanel")]
        public class FocusRadarPanelBinding
        {
            internal FocusRadarPanelBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FocusRightPanel")]
        public class FocusRightPanelBinding
        {
            internal FocusRightPanelBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "LeftPanelFocusOptions")]
        public class LeftPanelFocusOptionsBinding
        {
            internal LeftPanelFocusOptionsBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "CommsPanelFocusOptions")]
        public class CommsPanelFocusOptionsBinding
        {
            internal CommsPanelFocusOptionsBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "RolePanelFocusOptions")]
        public class RolePanelFocusOptionsBinding
        {
            internal RolePanelFocusOptionsBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "RightPanelFocusOptions")]
        public class RightPanelFocusOptionsBinding
        {
            internal RightPanelFocusOptionsBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "EnableCameraLockOn")]
        public class EnableCameraLockOnBinding
        {
            internal EnableCameraLockOnBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "GalaxyMapOpen")]
        public class GalaxyMapOpenBinding
        {
            internal GalaxyMapOpenBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SystemMapOpen")]
        public class SystemMapOpenBinding
        {
            internal SystemMapOpenBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ShowPGScoreSummaryInput")]
        public class ShowPGScoreSummaryInputBinding
        {
            internal ShowPGScoreSummaryInputBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "HeadLookToggle")]
        public class HeadLookToggleBinding
        {
            internal HeadLookToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "Pause")]
        public class PauseBinding
        {
            internal PauseBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FriendsMenu")]
        public class FriendsMenuBinding
        {
            internal FriendsMenuBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "OpenCodexGoToDiscovery")]
        public class OpenCodexGoToDiscoveryBinding
        {
            internal OpenCodexGoToDiscoveryBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "PlayerHUDModeToggle")]
        public class PlayerHUDModeToggleBinding
        {
            internal PlayerHUDModeToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSEnter")]
        public class ExplorationFSSEnterBinding
        {
            internal ExplorationFSSEnterBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "UI_Up")]
        public class UIUpBinding
        {
            internal UIUpBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "UI_Down")]
        public class UIDownBinding
        {
            internal UIDownBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "UI_Left")]
        public class UILeftBinding
        {
            internal UILeftBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "UI_Right")]
        public class UIRightBinding
        {
            internal UIRightBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "UI_Select")]
        public class UISelectBinding
        {
            internal UISelectBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "UI_Back")]
        public class UIBackBinding
        {
            internal UIBackBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "UI_Toggle")]
        public class UIToggleBinding
        {
            internal UIToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CycleNextPanel")]
        public class CycleNextPanelBinding
        {
            internal CycleNextPanelBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CyclePreviousPanel")]
        public class CyclePreviousPanelBinding
        {
            internal CyclePreviousPanelBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CycleNextPage")]
        public class CycleNextPageBinding
        {
            internal CycleNextPageBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CyclePreviousPage")]
        public class CyclePreviousPageBinding
        {
            internal CyclePreviousPageBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MouseHeadlook")]
        public class MouseHeadlookBinding
        {
            internal MouseHeadlookBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseHeadlookInvert")]
        public class MouseHeadlookInvertBinding
        {
            internal MouseHeadlookInvertBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseHeadlookSensitivity")]
        public class MouseHeadlookSensitivityBinding
        {
            internal MouseHeadlookSensitivityBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; set; }
        }

        [XmlRoot(ElementName = "HeadlookDefault")]
        public class HeadlookDefaultBinding
        {
            internal HeadlookDefaultBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "HeadlookIncrement")]
        public class HeadlookIncrementBinding
        {
            internal HeadlookIncrementBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; set; }
        }

        [XmlRoot(ElementName = "HeadlookMode")]
        public class HeadlookModeBinding
        {
            internal HeadlookModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "HeadlookResetOnToggle")]
        public class HeadlookResetOnToggleBinding
        {
            internal HeadlookResetOnToggleBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "HeadlookSensitivity")]
        public class HeadlookSensitivityBinding
        {
            internal HeadlookSensitivityBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; set; }
        }

        [XmlRoot(ElementName = "HeadlookSmoothing")]
        public class HeadlookSmoothingBinding
        {
            internal HeadlookSmoothingBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "HeadLookReset")]
        public class HeadLookResetBinding
        {
            internal HeadLookResetBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "HeadLookPitchUp")]
        public class HeadLookPitchUpBinding
        {
            internal HeadLookPitchUpBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "HeadLookPitchDown")]
        public class HeadLookPitchDownBinding
        {
            internal HeadLookPitchDownBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "HeadLookPitchAxisRaw")]
        public class HeadLookPitchAxisRawBinding
        {
            internal HeadLookPitchAxisRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "HeadLookYawLeft")]
        public class HeadLookYawLeftBinding
        {
            internal HeadLookYawLeftBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "HeadLookYawRight")]
        public class HeadLookYawRightBinding
        {
            internal HeadLookYawRightBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "HeadLookYawAxis")]
        public class HeadLookYawAxisBinding
        {
            internal HeadLookYawAxisBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "MotionHeadlook")]
        public class MotionHeadlookBinding
        {
            internal MotionHeadlookBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "HeadlookMotionSensitivity")]
        public class HeadlookMotionSensitivityBinding
        {
            internal HeadlookMotionSensitivityBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; set; }
        }

        [XmlRoot(ElementName = "yawRotateHeadlook")]
        public class YawRotateHeadlookBinding
        {
            internal YawRotateHeadlookBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "CamPitchAxis")]
        public class CamPitchAxisBinding
        {
            internal CamPitchAxisBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "CamPitchUp")]
        public class CamPitchUpBinding
        {
            internal CamPitchUpBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CamPitchDown")]
        public class CamPitchDownBinding
        {
            internal CamPitchDownBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CamYawAxis")]
        public class CamYawAxisBinding
        {
            internal CamYawAxisBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "CamYawLeft")]
        public class CamYawLeftBinding
        {
            internal CamYawLeftBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CamYawRight")]
        public class CamYawRightBinding
        {
            internal CamYawRightBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CamTranslateYAxis")]
        public class CamTranslateYAxisBinding
        {
            internal CamTranslateYAxisBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "CamTranslateForward")]
        public class CamTranslateForwardBinding
        {
            internal CamTranslateForwardBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CamTranslateBackward")]
        public class CamTranslateBackwardBinding
        {
            internal CamTranslateBackwardBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CamTranslateXAxis")]
        public class CamTranslateXAxisBinding
        {
            internal CamTranslateXAxisBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "CamTranslateLeft")]
        public class CamTranslateLeftBinding
        {
            internal CamTranslateLeftBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CamTranslateRight")]
        public class CamTranslateRightBinding
        {
            internal CamTranslateRightBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CamTranslateZAxis")]
        public class CamTranslateZAxisBinding
        {
            internal CamTranslateZAxisBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "CamTranslateUp")]
        public class CamTranslateUpBinding
        {
            internal CamTranslateUpBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CamTranslateDown")]
        public class CamTranslateDownBinding
        {
            internal CamTranslateDownBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CamZoomAxis")]
        public class CamZoomAxisBinding
        {
            internal CamZoomAxisBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "CamZoomIn")]
        public class CamZoomInBinding
        {
            internal CamZoomInBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CamZoomOut")]
        public class CamZoomOutBinding
        {
            internal CamZoomOutBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CamTranslateZHold")]
        public class CamTranslateZHoldBinding
        {
            internal CamTranslateZHoldBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "GalaxyMapHome")]
        public class GalaxyMapHomeBinding
        {
            internal GalaxyMapHomeBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ToggleDriveAssist")]
        public class ToggleDriveAssistBinding
        {
            internal ToggleDriveAssistBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "DriveAssistDefault")]
        public class DriveAssistDefaultBinding
        {
            internal DriveAssistDefaultBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseBuggySteeringXMode")]
        public class MouseBuggySteeringXModeBinding
        {
            internal MouseBuggySteeringXModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseBuggySteeringXDecay")]
        public class MouseBuggySteeringXDecayBinding
        {
            internal MouseBuggySteeringXDecayBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseBuggyRollingXMode")]
        public class MouseBuggyRollingXModeBinding
        {
            internal MouseBuggyRollingXModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseBuggyRollingXDecay")]
        public class MouseBuggyRollingXDecayBinding
        {
            internal MouseBuggyRollingXDecayBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseBuggyYMode")]
        public class MouseBuggyYModeBinding
        {
            internal MouseBuggyYModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseBuggyYDecay")]
        public class MouseBuggyYDecayBinding
        {
            internal MouseBuggyYDecayBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "SteeringAxis")]
        public class SteeringAxisBinding
        {
            internal SteeringAxisBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "SteerLeftButton")]
        public class SteerLeftButtonBinding
        {
            internal SteerLeftButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SteerRightButton")]
        public class SteerRightButtonBinding
        {
            internal SteerRightButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "BuggyRollAxisRaw")]
        public class BuggyRollAxisRawBinding
        {
            internal BuggyRollAxisRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "BuggyRollLeftButton")]
        public class BuggyRollLeftButtonBinding
        {
            internal BuggyRollLeftButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "BuggyRollRightButton")]
        public class BuggyRollRightButtonBinding
        {
            internal BuggyRollRightButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "BuggyPitchAxis")]
        public class BuggyPitchAxisBinding
        {
            internal BuggyPitchAxisBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "BuggyPitchUpButton")]
        public class BuggyPitchUpButtonBinding
        {
            internal BuggyPitchUpButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "BuggyPitchDownButton")]
        public class BuggyPitchDownButtonBinding
        {
            internal BuggyPitchDownButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "VerticalThrustersButton")]
        public class VerticalThrustersButtonBinding
        {
            internal VerticalThrustersButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "BuggyPrimaryFireButton")]
        public class BuggyPrimaryFireButtonBinding
        {
            internal BuggyPrimaryFireButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "BuggySecondaryFireButton")]
        public class BuggySecondaryFireButtonBinding
        {
            internal BuggySecondaryFireButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "AutoBreakBuggyButton")]
        public class AutoBreakBuggyButtonBinding
        {
            internal AutoBreakBuggyButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "HeadlightsBuggyButton")]
        public class HeadlightsBuggyButtonBinding
        {
            internal HeadlightsBuggyButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ToggleBuggyTurretButton")]
        public class ToggleBuggyTurretButtonBinding
        {
            internal ToggleBuggyTurretButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "BuggyCycleFireGroupNext")]
        public class BuggyCycleFireGroupNextBinding
        {
            internal BuggyCycleFireGroupNextBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "BuggyCycleFireGroupPrevious")]
        public class BuggyCycleFireGroupPreviousBinding
        {
            internal BuggyCycleFireGroupPreviousBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SelectTarget_Buggy")]
        public class SelectTargetBuggyBinding
        {
            internal SelectTargetBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MouseTurretXMode")]
        public class MouseTurretXModeBinding
        {
            internal MouseTurretXModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseTurretXDecay")]
        public class MouseTurretXDecayBinding
        {
            internal MouseTurretXDecayBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseTurretYMode")]
        public class MouseTurretYModeBinding
        {
            internal MouseTurretYModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MouseTurretYDecay")]
        public class MouseTurretYDecayBinding
        {
            internal MouseTurretYDecayBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "BuggyTurretYawAxisRaw")]
        public class BuggyTurretYawAxisRawBinding
        {
            internal BuggyTurretYawAxisRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "BuggyTurretYawLeftButton")]
        public class BuggyTurretYawLeftButtonBinding
        {
            internal BuggyTurretYawLeftButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "BuggyTurretYawRightButton")]
        public class BuggyTurretYawRightButtonBinding
        {
            internal BuggyTurretYawRightButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "BuggyTurretPitchAxisRaw")]
        public class BuggyTurretPitchAxisRawBinding
        {
            internal BuggyTurretPitchAxisRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "BuggyTurretPitchUpButton")]
        public class BuggyTurretPitchUpButtonBinding
        {
            internal BuggyTurretPitchUpButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "BuggyTurretPitchDownButton")]
        public class BuggyTurretPitchDownButtonBinding
        {
            internal BuggyTurretPitchDownButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "BuggyTurretMouseSensitivity")]
        public class BuggyTurretMouseSensitivityBinding
        {
            internal BuggyTurretMouseSensitivityBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; set; }
        }

        [XmlRoot(ElementName = "BuggyTurretMouseDeadzone")]
        public class BuggyTurretMouseDeadzoneBinding
        {
            internal BuggyTurretMouseDeadzoneBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; set; }
        }

        [XmlRoot(ElementName = "BuggyTurretMouseLinearity")]
        public class BuggyTurretMouseLinearityBinding
        {
            internal BuggyTurretMouseLinearityBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; set; }
        }

        [XmlRoot(ElementName = "DriveSpeedAxis")]
        public class DriveSpeedAxisBinding
        {
            internal DriveSpeedAxisBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "BuggyThrottleRange")]
        public class BuggyThrottleRangeBinding
        {
            internal BuggyThrottleRangeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "BuggyToggleReverseThrottleInput")]
        public class BuggyToggleReverseThrottleInputBinding
        {
            internal BuggyToggleReverseThrottleInputBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "BuggyThrottleIncrement")]
        public class BuggyThrottleIncrementBinding
        {
            internal BuggyThrottleIncrementBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; set; }
        }

        [XmlRoot(ElementName = "IncreaseSpeedButtonMax")]
        public class IncreaseSpeedButtonMaxBinding
        {
            internal IncreaseSpeedButtonMaxBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "DecreaseSpeedButtonMax")]
        public class DecreaseSpeedButtonMaxBinding
        {
            internal DecreaseSpeedButtonMaxBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "IncreaseSpeedButtonPartial")]
        public class IncreaseSpeedButtonPartialBinding
        {
            internal IncreaseSpeedButtonPartialBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "DecreaseSpeedButtonPartial")]
        public class DecreaseSpeedButtonPartialBinding
        {
            internal DecreaseSpeedButtonPartialBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "IncreaseEnginesPower_Buggy")]
        public class IncreaseEnginesPowerBuggyBinding
        {
            internal IncreaseEnginesPowerBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "IncreaseWeaponsPower_Buggy")]
        public class IncreaseWeaponsPowerBuggyBinding
        {
            internal IncreaseWeaponsPowerBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "IncreaseSystemsPower_Buggy")]
        public class IncreaseSystemsPowerBuggyBinding
        {
            internal IncreaseSystemsPowerBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ResetPowerDistribution_Buggy")]
        public class ResetPowerDistributionBuggyBinding
        {
            internal ResetPowerDistributionBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ToggleCargoScoop_Buggy")]
        public class ToggleCargoScoopBuggyBinding
        {
            internal ToggleCargoScoopBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "EjectAllCargo_Buggy")]
        public class EjectAllCargoBuggyBinding
        {
            internal EjectAllCargoBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "RecallDismissShip")]
        public class RecallDismissShipBinding
        {
            internal RecallDismissShipBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "UIFocus_Buggy")]
        public class UIFocusBuggyBinding
        {
            internal UIFocusBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FocusLeftPanel_Buggy")]
        public class FocusLeftPanelBuggyBinding
        {
            internal FocusLeftPanelBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FocusCommsPanel_Buggy")]
        public class FocusCommsPanelBuggyBinding
        {
            internal FocusCommsPanelBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "QuickCommsPanel_Buggy")]
        public class QuickCommsPanelBuggyBinding
        {
            internal QuickCommsPanelBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FocusRadarPanel_Buggy")]
        public class FocusRadarPanelBuggyBinding
        {
            internal FocusRadarPanelBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FocusRightPanel_Buggy")]
        public class FocusRightPanelBuggyBinding
        {
            internal FocusRightPanelBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "GalaxyMapOpen_Buggy")]
        public class GalaxyMapOpenBuggyBinding
        {
            internal GalaxyMapOpenBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SystemMapOpen_Buggy")]
        public class SystemMapOpenBuggyBinding
        {
            internal SystemMapOpenBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "OpenCodexGoToDiscovery_Buggy")]
        public class OpenCodexGoToDiscoveryBuggyBinding
        {
            internal OpenCodexGoToDiscoveryBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "PlayerHUDModeToggle_Buggy")]
        public class PlayerHUDModeToggleBuggyBinding
        {
            internal PlayerHUDModeToggleBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "HeadLookToggle_Buggy")]
        public class HeadLookToggleBuggyBinding
        {
            internal HeadLookToggleBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewToggleMode")]
        public class MultiCrewToggleModeBinding
        {
            internal MultiCrewToggleModeBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewPrimaryFire")]
        public class MultiCrewPrimaryFireBinding
        {
            internal MultiCrewPrimaryFireBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewSecondaryFire")]
        public class MultiCrewSecondaryFireBinding
        {
            internal MultiCrewSecondaryFireBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewPrimaryUtilityFire")]
        public class MultiCrewPrimaryUtilityFireBinding
        {
            internal MultiCrewPrimaryUtilityFireBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewSecondaryUtilityFire")]
        public class MultiCrewSecondaryUtilityFireBinding
        {
            internal MultiCrewSecondaryUtilityFireBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonMouseXMode")]
        public class MultiCrewThirdPersonMouseXModeBinding
        {
            internal MultiCrewThirdPersonMouseXModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonMouseXDecay")]
        public class MultiCrewThirdPersonMouseXDecayBinding
        {
            internal MultiCrewThirdPersonMouseXDecayBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonMouseYMode")]
        public class MultiCrewThirdPersonMouseYModeBinding
        {
            internal MultiCrewThirdPersonMouseYModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonMouseYDecay")]
        public class MultiCrewThirdPersonMouseYDecayBinding
        {
            internal MultiCrewThirdPersonMouseYDecayBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonYawAxisRaw")]
        public class MultiCrewThirdPersonYawAxisRawBinding
        {
            internal MultiCrewThirdPersonYawAxisRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonYawLeftButton")]
        public class MultiCrewThirdPersonYawLeftButtonBinding
        {
            internal MultiCrewThirdPersonYawLeftButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonYawRightButton")]
        public class MultiCrewThirdPersonYawRightButtonBinding
        {
            internal MultiCrewThirdPersonYawRightButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonPitchAxisRaw")]
        public class MultiCrewThirdPersonPitchAxisRawBinding
        {
            internal MultiCrewThirdPersonPitchAxisRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonPitchUpButton")]
        public class MultiCrewThirdPersonPitchUpButtonBinding
        {
            internal MultiCrewThirdPersonPitchUpButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonPitchDownButton")]
        public class MultiCrewThirdPersonPitchDownButtonBinding
        {
            internal MultiCrewThirdPersonPitchDownButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonMouseSensitivity")]
        public class MultiCrewThirdPersonMouseSensitivityBinding
        {
            internal MultiCrewThirdPersonMouseSensitivityBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonFovAxisRaw")]
        public class MultiCrewThirdPersonFovAxisRawBinding
        {
            internal MultiCrewThirdPersonFovAxisRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonFovOutButton")]
        public class MultiCrewThirdPersonFovOutButtonBinding
        {
            internal MultiCrewThirdPersonFovOutButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewThirdPersonFovInButton")]
        public class MultiCrewThirdPersonFovInButtonBinding
        {
            internal MultiCrewThirdPersonFovInButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewCockpitUICycleForward")]
        public class MultiCrewCockpitUICycleForwardBinding
        {
            internal MultiCrewCockpitUICycleForwardBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MultiCrewCockpitUICycleBackward")]
        public class MultiCrewCockpitUICycleBackwardBinding
        {
            internal MultiCrewCockpitUICycleBackwardBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "OrderRequestDock")]
        public class OrderRequestDockBinding
        {
            internal OrderRequestDockBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "OrderDefensiveBehaviour")]
        public class OrderDefensiveBehaviourBinding
        {
            internal OrderDefensiveBehaviourBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "OrderAggressiveBehaviour")]
        public class OrderAggressiveBehaviourBinding
        {
            internal OrderAggressiveBehaviourBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "OrderFocusTarget")]
        public class OrderFocusTargetBinding
        {
            internal OrderFocusTargetBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "OrderHoldFire")]
        public class OrderHoldFireBinding
        {
            internal OrderHoldFireBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "OrderHoldPosition")]
        public class OrderHoldPositionBinding
        {
            internal OrderHoldPositionBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "OrderFollow")]
        public class OrderFollowBinding
        {
            internal OrderFollowBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "OpenOrders")]
        public class OpenOrdersBinding
        {
            internal OpenOrdersBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "PhotoCameraToggle")]
        public class PhotoCameraToggleBinding
        {
            internal PhotoCameraToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "PhotoCameraToggle_Buggy")]
        public class PhotoCameraToggleBuggyBinding
        {
            internal PhotoCameraToggleBuggyBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "VanityCameraScrollLeft")]
        public class VanityCameraScrollLeftBinding
        {
            internal VanityCameraScrollLeftBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "VanityCameraScrollRight")]
        public class VanityCameraScrollRightBinding
        {
            internal VanityCameraScrollRightBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ToggleFreeCam")]
        public class ToggleFreeCamBinding
        {
            internal ToggleFreeCamBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "VanityCameraOne")]
        public class VanityCameraOneBinding
        {
            internal VanityCameraOneBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "VanityCameraTwo")]
        public class VanityCameraTwoBinding
        {
            internal VanityCameraTwoBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "VanityCameraThree")]
        public class VanityCameraThreeBinding
        {
            internal VanityCameraThreeBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "VanityCameraFour")]
        public class VanityCameraFourBinding
        {
            internal VanityCameraFourBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "VanityCameraFive")]
        public class VanityCameraFiveBinding
        {
            internal VanityCameraFiveBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "VanityCameraSix")]
        public class VanityCameraSixBinding
        {
            internal VanityCameraSixBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "VanityCameraSeven")]
        public class VanityCameraSevenBinding
        {
            internal VanityCameraSevenBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "VanityCameraEight")]
        public class VanityCameraEightBinding
        {
            internal VanityCameraEightBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "VanityCameraNine")]
        public class VanityCameraNineBinding
        {
            internal VanityCameraNineBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FreeCamToggleHUD")]
        public class FreeCamToggleHUDBinding
        {
            internal FreeCamToggleHUDBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FreeCamSpeedInc")]
        public class FreeCamSpeedIncBinding
        {
            internal FreeCamSpeedIncBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FreeCamSpeedDec")]
        public class FreeCamSpeedDecBinding
        {
            internal FreeCamSpeedDecBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamY")]
        public class MoveFreeCamYBinding
        {
            internal MoveFreeCamYBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "ThrottleRangeFreeCam")]
        public class ThrottleRangeFreeCamBinding
        {
            internal ThrottleRangeFreeCamBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "ToggleReverseThrottleInputFreeCam")]
        public class ToggleReverseThrottleInputFreeCamBinding
        {
            internal ToggleReverseThrottleInputFreeCamBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamForward")]
        public class MoveFreeCamForwardBinding
        {
            internal MoveFreeCamForwardBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamBackwards")]
        public class MoveFreeCamBackwardsBinding
        {
            internal MoveFreeCamBackwardsBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamX")]
        public class MoveFreeCamXBinding
        {
            internal MoveFreeCamXBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamRight")]
        public class MoveFreeCamRightBinding
        {
            internal MoveFreeCamRightBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamLeft")]
        public class MoveFreeCamLeftBinding
        {
            internal MoveFreeCamLeftBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamZ")]
        public class MoveFreeCamZBinding
        {
            internal MoveFreeCamZBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamUpAxis")]
        public class MoveFreeCamUpAxisBinding
        {
            internal MoveFreeCamUpAxisBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamDownAxis")]
        public class MoveFreeCamDownAxisBinding
        {
            internal MoveFreeCamDownAxisBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamUp")]
        public class MoveFreeCamUpBinding
        {
            internal MoveFreeCamUpBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "MoveFreeCamDown")]
        public class MoveFreeCamDownBinding
        {
            internal MoveFreeCamDownBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "PitchCameraMouse")]
        public class PitchCameraMouseBinding
        {
            internal PitchCameraMouseBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "YawCameraMouse")]
        public class YawCameraMouseBinding
        {
            internal YawCameraMouseBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "PitchCamera")]
        public class PitchCameraBinding
        {
            internal PitchCameraBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "FreeCamMouseSensitivity")]
        public class FreeCamMouseSensitivityBinding
        {
            internal FreeCamMouseSensitivityBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; set; }
        }

        [XmlRoot(ElementName = "FreeCamMouseYDecay")]
        public class FreeCamMouseYDecayBinding
        {
            internal FreeCamMouseYDecayBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "PitchCameraUp")]
        public class PitchCameraUpBinding
        {
            internal PitchCameraUpBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "PitchCameraDown")]
        public class PitchCameraDownBinding
        {
            internal PitchCameraDownBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "YawCamera")]
        public class YawCameraBinding
        {
            internal YawCameraBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "FreeCamMouseXDecay")]
        public class FreeCamMouseXDecayBinding
        {
            internal FreeCamMouseXDecayBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "YawCameraLeft")]
        public class YawCameraLeftBinding
        {
            internal YawCameraLeftBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "YawCameraRight")]
        public class YawCameraRightBinding
        {
            internal YawCameraRightBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "RollCamera")]
        public class RollCameraBinding
        {
            internal RollCameraBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "RollCameraLeft")]
        public class RollCameraLeftBinding
        {
            internal RollCameraLeftBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "RollCameraRight")]
        public class RollCameraRightBinding
        {
            internal RollCameraRightBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ToggleRotationLock")]
        public class ToggleRotationLockBinding
        {
            internal ToggleRotationLockBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FixCameraRelativeToggle")]
        public class FixCameraRelativeToggleBinding
        {
            internal FixCameraRelativeToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FixCameraWorldToggle")]
        public class FixCameraWorldToggleBinding
        {
            internal FixCameraWorldToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "QuitCamera")]
        public class QuitCameraBinding
        {
            internal QuitCameraBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ToggleAdvanceMode")]
        public class ToggleAdvanceModeBinding
        {
            internal ToggleAdvanceModeBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FreeCamZoomIn")]
        public class FreeCamZoomInBinding
        {
            internal FreeCamZoomInBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FreeCamZoomOut")]
        public class FreeCamZoomOutBinding
        {
            internal FreeCamZoomOutBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FStopDec")]
        public class FStopDecBinding
        {
            internal FStopDecBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FStopInc")]
        public class FStopIncBinding
        {
            internal FStopIncBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "StoreEnableRotation")]
        public class StoreEnableRotationBinding
        {
            internal StoreEnableRotationBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "StorePitchCamera")]
        public class StorePitchCameraBinding
        {
            internal StorePitchCameraBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "StoreYawCamera")]
        public class StoreYawCameraBinding
        {
            internal StoreYawCameraBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "StoreCamZoomIn")]
        public class StoreCamZoomInBinding
        {
            internal StoreCamZoomInBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "StoreCamZoomOut")]
        public class StoreCamZoomOutBinding
        {
            internal StoreCamZoomOutBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "StoreToggle")]
        public class StoreToggleBinding
        {
            internal StoreToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CommanderCreator_Undo")]
        public class CommanderCreatorUndoBinding
        {
            internal CommanderCreatorUndoBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CommanderCreator_Redo")]
        public class CommanderCreatorRedoBinding
        {
            internal CommanderCreatorRedoBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CommanderCreator_Rotation_MouseToggle")]
        public class CommanderCreatorRotationMouseToggleBinding
        {
            internal CommanderCreatorRotationMouseToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "CommanderCreator_Rotation")]
        public class CommanderCreatorRotationBinding
        {
            internal CommanderCreatorRotationBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "GalnetAudio_Play_Pause")]
        public class GalnetAudioPlayPauseBinding
        {
            internal GalnetAudioPlayPauseBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "GalnetAudio_SkipForward")]
        public class GalnetAudioSkipForwardBinding
        {
            internal GalnetAudioSkipForwardBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "GalnetAudio_SkipBackward")]
        public class GalnetAudioSkipBackwardBinding
        {
            internal GalnetAudioSkipBackwardBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "GalnetAudio_ClearQueue")]
        public class GalnetAudioClearQueueBinding
        {
            internal GalnetAudioClearQueueBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSCameraPitch")]
        public class ExplorationFSSCameraPitchBinding
        {
            internal ExplorationFSSCameraPitchBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSCameraPitchIncreaseButton")]
        public class ExplorationFSSCameraPitchIncreaseButtonBinding
        {
            internal ExplorationFSSCameraPitchIncreaseButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSCameraPitchDecreaseButton")]
        public class ExplorationFSSCameraPitchDecreaseButtonBinding
        {
            internal ExplorationFSSCameraPitchDecreaseButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSCameraYaw")]
        public class ExplorationFSSCameraYawBinding
        {
            internal ExplorationFSSCameraYawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSCameraYawIncreaseButton")]
        public class ExplorationFSSCameraYawIncreaseButtonBinding
        {
            internal ExplorationFSSCameraYawIncreaseButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSCameraYawDecreaseButton")]
        public class ExplorationFSSCameraYawDecreaseButtonBinding
        {
            internal ExplorationFSSCameraYawDecreaseButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSZoomIn")]
        public class ExplorationFSSZoomInBinding
        {
            internal ExplorationFSSZoomInBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSZoomOut")]
        public class ExplorationFSSZoomOutBinding
        {
            internal ExplorationFSSZoomOutBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSMiniZoomIn")]
        public class ExplorationFSSMiniZoomInBinding
        {
            internal ExplorationFSSMiniZoomInBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSMiniZoomOut")]
        public class ExplorationFSSMiniZoomOutBinding
        {
            internal ExplorationFSSMiniZoomOutBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSRadioTuningX_Raw")]
        public class ExplorationFSSRadioTuningXRawBinding
        {
            internal ExplorationFSSRadioTuningXRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSRadioTuningX_Increase")]
        public class ExplorationFSSRadioTuningXIncreaseBinding
        {
            internal ExplorationFSSRadioTuningXIncreaseBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSRadioTuningX_Decrease")]
        public class ExplorationFSSRadioTuningXDecreaseBinding
        {
            internal ExplorationFSSRadioTuningXDecreaseBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSRadioTuningAbsoluteX")]
        public class ExplorationFSSRadioTuningAbsoluteXBinding
        {
            internal ExplorationFSSRadioTuningAbsoluteXBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "FSSTuningSensitivity")]
        public class FSSTuningSensitivityBinding
        {
            internal FSSTuningSensitivityBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSDiscoveryScan")]
        public class ExplorationFSSDiscoveryScanBinding
        {
            internal ExplorationFSSDiscoveryScanBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSQuit")]
        public class ExplorationFSSQuitBinding
        {
            internal ExplorationFSSQuitBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "FSSMouseXMode")]
        public class FSSMouseXModeBinding
        {
            internal FSSMouseXModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "FSSMouseXDecay")]
        public class FSSMouseXDecayBinding
        {
            internal FSSMouseXDecayBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "FSSMouseYMode")]
        public class FSSMouseYModeBinding
        {
            internal FSSMouseYModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "FSSMouseYDecay")]
        public class FSSMouseYDecayBinding
        {
            internal FSSMouseYDecayBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "FSSMouseSensitivity")]
        public class FSSMouseSensitivityBinding
        {
            internal FSSMouseSensitivityBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; set; }
        }

        [XmlRoot(ElementName = "FSSMouseDeadzone")]
        public class FSSMouseDeadzoneBinding
        {
            internal FSSMouseDeadzoneBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; set; }
        }

        [XmlRoot(ElementName = "FSSMouseLinearity")]
        public class FSSMouseLinearityBinding
        {
            internal FSSMouseLinearityBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSTarget")]
        public class ExplorationFSSTargetBinding
        {
            internal ExplorationFSSTargetBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ExplorationFSSShowHelp")]
        public class ExplorationFSSShowHelpBinding
        {
            internal ExplorationFSSShowHelpBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "ExplorationSAAChangeScannedAreaViewToggle")]
        public class ExplorationSAAChangeScannedAreaViewToggleBinding
        {
            internal ExplorationSAAChangeScannedAreaViewToggleBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }

            [XmlElement(ElementName = "ToggleOn")]
            public ToggleOnBinding ToggleOn { get; set; }
        }

        [XmlRoot(ElementName = "ExplorationSAAExitThirdPerson")]
        public class ExplorationSAAExitThirdPersonBinding
        {
            internal ExplorationSAAExitThirdPersonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SAAThirdPersonMouseXMode")]
        public class SAAThirdPersonMouseXModeBinding
        {
            internal SAAThirdPersonMouseXModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "SAAThirdPersonMouseXDecay")]
        public class SAAThirdPersonMouseXDecayBinding
        {
            internal SAAThirdPersonMouseXDecayBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "SAAThirdPersonMouseYMode")]
        public class SAAThirdPersonMouseYModeBinding
        {
            internal SAAThirdPersonMouseYModeBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "SAAThirdPersonMouseYDecay")]
        public class SAAThirdPersonMouseYDecayBinding
        {
            internal SAAThirdPersonMouseYDecayBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public int Value { get; set; }
        }

        [XmlRoot(ElementName = "SAAThirdPersonMouseSensitivity")]
        public class SAAThirdPersonMouseSensitivityBinding
        {
            internal SAAThirdPersonMouseSensitivityBinding() { }

            [XmlAttribute(AttributeName = "Value")]
            public double Value { get; set; }
        }

        [XmlRoot(ElementName = "SAAThirdPersonYawAxisRaw")]
        public class SAAThirdPersonYawAxisRawBinding
        {
            internal SAAThirdPersonYawAxisRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "SAAThirdPersonYawLeftButton")]
        public class SAAThirdPersonYawLeftButtonBinding
        {
            internal SAAThirdPersonYawLeftButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SAAThirdPersonYawRightButton")]
        public class SAAThirdPersonYawRightButtonBinding
        {
            internal SAAThirdPersonYawRightButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SAAThirdPersonPitchAxisRaw")]
        public class SAAThirdPersonPitchAxisRawBinding
        {
            internal SAAThirdPersonPitchAxisRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "SAAThirdPersonPitchUpButton")]
        public class SAAThirdPersonPitchUpButtonBinding
        {
            internal SAAThirdPersonPitchUpButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SAAThirdPersonPitchDownButton")]
        public class SAAThirdPersonPitchDownButtonBinding
        {
            internal SAAThirdPersonPitchDownButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SAAThirdPersonFovAxisRaw")]
        public class SAAThirdPersonFovAxisRawBinding
        {
            internal SAAThirdPersonFovAxisRawBinding() { }

            [XmlElement(ElementName = "Binding")]
            public BindingBinding Binding { get; set; }

            [XmlElement(ElementName = "Inverted")]
            public InvertedBinding Inverted { get; set; }

            [XmlElement(ElementName = "Deadzone")]
            public DeadzoneBinding Deadzone { get; set; }
        }

        [XmlRoot(ElementName = "SAAThirdPersonFovOutButton")]
        public class SAAThirdPersonFovOutButtonBinding
        {
            internal SAAThirdPersonFovOutButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }

        [XmlRoot(ElementName = "SAAThirdPersonFovInButton")]
        public class SAAThirdPersonFovInButtonBinding
        {
            internal SAAThirdPersonFovInButtonBinding() { }

            [XmlElement(ElementName = "Primary")]
            public PrimaryBinding Primary { get; set; }

            [XmlElement(ElementName = "Secondary")]
            public SecondaryBinding Secondary { get; set; }
        }
    }
}