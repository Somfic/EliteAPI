using System.Xml.Serialization;

namespace EliteAPI.KeyBindings;

[XmlRoot(ElementName = "Root")]
public readonly struct Bindings
{
    [XmlElement(ElementName = "KeyboardLayout")]
    public string KeyboardLayout { get; }

    [XmlElement(ElementName = "MouseXMode")]
    public MouseXModeBinding MouseXMode { get; }

    [XmlElement(ElementName = "MouseXDecay")]
    public MouseXDecayBinding MouseXDecay { get; }

    [XmlElement(ElementName = "MouseYMode")]
    public MouseYModeBinding MouseYMode { get; }

    [XmlElement(ElementName = "MouseYDecay")]
    public MouseYDecayBinding MouseYDecay { get; }

    [XmlElement(ElementName = "MouseReset")]
    public MouseResetBinding MouseReset { get; }

    [XmlElement(ElementName = "MouseSensitivity")]
    public MouseSensitivityBinding MouseSensitivity { get; }

    [XmlElement(ElementName = "MouseDecayRate")]
    public MouseDecayRateBinding MouseDecayRate { get; }

    [XmlElement(ElementName = "MouseDeadzone")]
    public MouseDeadzoneBinding MouseDeadzone { get; }

    [XmlElement(ElementName = "MouseLinearity")]
    public MouseLinearityBinding MouseLinearity { get; }

    [XmlElement(ElementName = "MouseGUI")]
    public List<MouseGUIBinding> MouseGUI { get; }

    [XmlElement(ElementName = "YawAxisRaw")]
    public YawAxisRawBinding YawAxisRaw { get; }

    [XmlElement(ElementName = "YawLeftButton")]
    public YawLeftButtonBinding YawLeftButton { get; }

    [XmlElement(ElementName = "YawRightButton")]
    public YawRightButtonBinding YawRightButton { get; }

    [XmlElement(ElementName = "YawToRollMode")]
    public YawToRollModeBinding YawToRollMode { get; }

    [XmlElement(ElementName = "YawToRollSensitivity")]
    public YawToRollSensitivityBinding YawToRollSensitivity { get; }

    [XmlElement(ElementName = "YawToRollMode_FAOff")]
    public YawToRollModeFAOffBinding YawToRollModeFAOff { get; }

    [XmlElement(ElementName = "YawToRollButton")]
    public YawToRollButtonBinding YawToRollButton { get; }

    [XmlElement(ElementName = "RollAxisRaw")]
    public RollAxisRawBinding RollAxisRaw { get; }

    [XmlElement(ElementName = "RollLeftButton")]
    public RollLeftButtonBinding RollLeftButton { get; }

    [XmlElement(ElementName = "RollRightButton")]
    public RollRightButtonBinding RollRightButton { get; }

    [XmlElement(ElementName = "PitchAxisRaw")]
    public PitchAxisRawBinding PitchAxisRaw { get; }

    [XmlElement(ElementName = "PitchUpButton")]
    public PitchUpButtonBinding PitchUpButton { get; }

    [XmlElement(ElementName = "PitchDownButton")]
    public PitchDownButtonBinding PitchDownButton { get; }

    [XmlElement(ElementName = "LateralThrustRaw")]
    public LateralThrustRawBinding LateralThrustRaw { get; }

    [XmlElement(ElementName = "LeftThrustButton")]
    public LeftThrustButtonBinding LeftThrustButton { get; }

    [XmlElement(ElementName = "RightThrustButton")]
    public RightThrustButtonBinding RightThrustButton { get; }

    [XmlElement(ElementName = "VerticalThrustRaw")]
    public VerticalThrustRawBinding VerticalThrustRaw { get; }

    [XmlElement(ElementName = "UpThrustButton")]
    public UpThrustButtonBinding UpThrustButton { get; }

    [XmlElement(ElementName = "DownThrustButton")]
    public DownThrustButtonBinding DownThrustButton { get; }

    [XmlElement(ElementName = "AheadThrust")]
    public AheadThrustBinding AheadThrust { get; }

    [XmlElement(ElementName = "ForwardThrustButton")]
    public ForwardThrustButtonBinding ForwardThrustButton { get; }

    [XmlElement(ElementName = "BackwardThrustButton")]
    public BackwardThrustButtonBinding BackwardThrustButton { get; }

    [XmlElement(ElementName = "UseAlternateFlightValuesToggle")]
    public UseAlternateFlightValuesToggleBinding UseAlternateFlightValuesToggle { get; }

    [XmlElement(ElementName = "YawAxisAlternate")]
    public YawAxisAlternateBinding YawAxisAlternate { get; }

    [XmlElement(ElementName = "RollAxisAlternate")]
    public RollAxisAlternateBinding RollAxisAlternate { get; }

    [XmlElement(ElementName = "PitchAxisAlternate")]
    public PitchAxisAlternateBinding PitchAxisAlternate { get; }

    [XmlElement(ElementName = "LateralThrustAlternate")]
    public LateralThrustAlternateBinding LateralThrustAlternate { get; }

    [XmlElement(ElementName = "VerticalThrustAlternate")]
    public VerticalThrustAlternateBinding VerticalThrustAlternate { get; }

    [XmlElement(ElementName = "ThrottleAxis")]
    public ThrottleAxisBinding ThrottleAxis { get; }

    [XmlElement(ElementName = "ThrottleRange")]
    public ThrottleRangeBinding ThrottleRange { get; }

    [XmlElement(ElementName = "ToggleReverseThrottleInput")]
    public ToggleReverseThrottleInputBinding ToggleReverseThrottleInput { get; }

    [XmlElement(ElementName = "ForwardKey")]
    public ForwardKeyBinding ForwardKey { get; }

    [XmlElement(ElementName = "BackwardKey")]
    public BackwardKeyBinding BackwardKey { get; }

    [XmlElement(ElementName = "ThrottleIncrement")]
    public ThrottleIncrementBinding ThrottleIncrement { get; }

    [XmlElement(ElementName = "SetSpeedMinus100")]
    public SetSpeedMinus100Binding SetSpeedMinus100 { get; }

    [XmlElement(ElementName = "SetSpeedMinus75")]
    public SetSpeedMinus75Binding SetSpeedMinus75 { get; }

    [XmlElement(ElementName = "SetSpeedMinus50")]
    public SetSpeedMinus50Binding SetSpeedMinus50 { get; }

    [XmlElement(ElementName = "SetSpeedMinus25")]
    public SetSpeedMinus25Binding SetSpeedMinus25 { get; }

    [XmlElement(ElementName = "SetSpeedZero")]
    public SetSpeedZeroBinding SetSpeedZero { get; }

    [XmlElement(ElementName = "SetSpeed25")]
    public SetSpeed25Binding SetSpeed25 { get; }

    [XmlElement(ElementName = "SetSpeed50")]
    public SetSpeed50Binding SetSpeed50 { get; }

    [XmlElement(ElementName = "SetSpeed75")]
    public SetSpeed75Binding SetSpeed75 { get; }

    [XmlElement(ElementName = "SetSpeed100")]
    public SetSpeed100Binding SetSpeed100 { get; }

    [XmlElement(ElementName = "YawAxis_Landing")]
    public YawAxisLandingBinding YawAxisLanding { get; }

    [XmlElement(ElementName = "YawLeftButton_Landing")]
    public YawLeftButtonLandingBinding YawLeftButtonLanding { get; }

    [XmlElement(ElementName = "YawRightButton_Landing")]
    public YawRightButtonLandingBinding YawRightButtonLanding { get; }

    [XmlElement(ElementName = "YawToRollMode_Landing")]
    public YawToRollModeLandingBinding YawToRollModeLanding { get; }

    [XmlElement(ElementName = "PitchAxis_Landing")]
    public PitchAxisLandingBinding PitchAxisLanding { get; }

    [XmlElement(ElementName = "PitchUpButton_Landing")]
    public PitchUpButtonLandingBinding PitchUpButtonLanding { get; }

    [XmlElement(ElementName = "PitchDownButton_Landing")]
    public PitchDownButtonLandingBinding PitchDownButtonLanding { get; }

    [XmlElement(ElementName = "RollAxis_Landing")]
    public RollAxisLandingBinding RollAxisLanding { get; }

    [XmlElement(ElementName = "RollLeftButton_Landing")]
    public RollLeftButtonLandingBinding RollLeftButtonLanding { get; }

    [XmlElement(ElementName = "RollRightButton_Landing")]
    public RollRightButtonLandingBinding RollRightButtonLanding { get; }

    [XmlElement(ElementName = "LateralThrust_Landing")]
    public LateralThrustLandingBinding LateralThrustLanding { get; }

    [XmlElement(ElementName = "LeftThrustButton_Landing")]
    public LeftThrustButtonLandingBinding LeftThrustButtonLanding { get; }

    [XmlElement(ElementName = "RightThrustButton_Landing")]
    public RightThrustButtonLandingBinding RightThrustButtonLanding { get; }

    [XmlElement(ElementName = "VerticalThrust_Landing")]
    public VerticalThrustLandingBinding VerticalThrustLanding { get; }

    [XmlElement(ElementName = "UpThrustButton_Landing")]
    public UpThrustButtonLandingBinding UpThrustButtonLanding { get; }

    [XmlElement(ElementName = "DownThrustButton_Landing")]
    public DownThrustButtonLandingBinding DownThrustButtonLanding { get; }

    [XmlElement(ElementName = "AheadThrust_Landing")]
    public AheadThrustLandingBinding AheadThrustLanding { get; }

    [XmlElement(ElementName = "ForwardThrustButton_Landing")]
    public ForwardThrustButtonLandingBinding ForwardThrustButtonLanding { get; }

    [XmlElement(ElementName = "BackwardThrustButton_Landing")]
    public BackwardThrustButtonLandingBinding BackwardThrustButtonLanding { get; }

    [XmlElement(ElementName = "ToggleFlightAssist")]
    public ToggleFlightAssistBinding ToggleFlightAssist { get; }

    [XmlElement(ElementName = "UseBoostJuice")]
    public UseBoostJuiceBinding UseBoostJuice { get; }

    [XmlElement(ElementName = "HyperSuperCombination")]
    public HyperSuperCombinationBinding HyperSuperCombination { get; }

    [XmlElement(ElementName = "Supercruise")]
    public SupercruiseBinding Supercruise { get; }

    [XmlElement(ElementName = "Hyperspace")]
    public HyperspaceBinding Hyperspace { get; }

    [XmlElement(ElementName = "DisableRotationCorrectToggle")]
    public DisableRotationCorrectToggleBinding DisableRotationCorrectToggle { get; }

    [XmlElement(ElementName = "OrbitLinesToggle")]
    public OrbitLinesToggleBinding OrbitLinesToggle { get; }

    [XmlElement(ElementName = "SelectTarget")]
    public SelectTargetBinding SelectTarget { get; }

    [XmlElement(ElementName = "CycleNextTarget")]
    public CycleNextTargetBinding CycleNextTarget { get; }

    [XmlElement(ElementName = "CyclePreviousTarget")]
    public CyclePreviousTargetBinding CyclePreviousTarget { get; }

    [XmlElement(ElementName = "SelectHighestThreat")]
    public SelectHighestThreatBinding SelectHighestThreat { get; }

    [XmlElement(ElementName = "CycleNextHostileTarget")]
    public CycleNextHostileTargetBinding CycleNextHostileTarget { get; }

    [XmlElement(ElementName = "CyclePreviousHostileTarget")]
    public CyclePreviousHostileTargetBinding CyclePreviousHostileTarget { get; }

    [XmlElement(ElementName = "TargetWingman0")]
    public TargetWingman0Binding TargetWingman0 { get; }

    [XmlElement(ElementName = "TargetWingman1")]
    public TargetWingman1Binding TargetWingman1 { get; }

    [XmlElement(ElementName = "TargetWingman2")]
    public TargetWingman2Binding TargetWingman2 { get; }

    [XmlElement(ElementName = "SelectTargetsTarget")]
    public SelectTargetsTargetBinding SelectTargetsTarget { get; }

    [XmlElement(ElementName = "WingNavLock")]
    public WingNavLockBinding WingNavLock { get; }

    [XmlElement(ElementName = "CycleNextSubsystem")]
    public CycleNextSubsystemBinding CycleNextSubsystem { get; }

    [XmlElement(ElementName = "CyclePreviousSubsystem")]
    public CyclePreviousSubsystemBinding CyclePreviousSubsystem { get; }

    [XmlElement(ElementName = "TargetNextRouteSystem")]
    public TargetNextRouteSystemBinding TargetNextRouteSystem { get; }

    [XmlElement(ElementName = "PrimaryFire")]
    public PrimaryFireBinding PrimaryFire { get; }

    [XmlElement(ElementName = "SecondaryFire")]
    public SecondaryFireBinding SecondaryFire { get; }

    [XmlElement(ElementName = "CycleFireGroupNext")]
    public CycleFireGroupNextBinding CycleFireGroupNext { get; }

    [XmlElement(ElementName = "CycleFireGroupPrevious")]
    public CycleFireGroupPreviousBinding CycleFireGroupPrevious { get; }

    [XmlElement(ElementName = "DeployHardpointToggle")]
    public DeployHardpointToggleBinding DeployHardpointToggle { get; }

    [XmlElement(ElementName = "DeployHardpointsOnFire")]
    public DeployHardpointsOnFireBinding DeployHardpointsOnFire { get; }

    [XmlElement(ElementName = "ToggleButtonUpInput")]
    public ToggleButtonUpInputBinding ToggleButtonUpInput { get; }

    [XmlElement(ElementName = "DeployHeatSink")]
    public DeployHeatSinkBinding DeployHeatSink { get; }

    [XmlElement(ElementName = "ShipSpotLightToggle")]
    public ShipSpotLightToggleBinding ShipSpotLightToggle { get; }

    [XmlElement(ElementName = "RadarRangeAxis")]
    public RadarRangeAxisBinding RadarRangeAxis { get; }

    [XmlElement(ElementName = "RadarIncreaseRange")]
    public RadarIncreaseRangeBinding RadarIncreaseRange { get; }

    [XmlElement(ElementName = "RadarDecreaseRange")]
    public RadarDecreaseRangeBinding RadarDecreaseRange { get; }

    [XmlElement(ElementName = "IncreaseEnginesPower")]
    public IncreaseEnginesPowerBinding IncreaseEnginesPower { get; }

    [XmlElement(ElementName = "IncreaseWeaponsPower")]
    public IncreaseWeaponsPowerBinding IncreaseWeaponsPower { get; }

    [XmlElement(ElementName = "IncreaseSystemsPower")]
    public IncreaseSystemsPowerBinding IncreaseSystemsPower { get; }

    [XmlElement(ElementName = "ResetPowerDistribution")]
    public ResetPowerDistributionBinding ResetPowerDistribution { get; }

    [XmlElement(ElementName = "HMDReset")]
    public HMDResetBinding HMDReset { get; }

    [XmlElement(ElementName = "ToggleCargoScoop")]
    public ToggleCargoScoopBinding ToggleCargoScoop { get; }

    [XmlElement(ElementName = "EjectAllCargo")]
    public EjectAllCargoBinding EjectAllCargo { get; }

    [XmlElement(ElementName = "LandingGearToggle")]
    public LandingGearToggleBinding LandingGearToggle { get; }

    [XmlElement(ElementName = "MicrophoneMute")]
    public MicrophoneMuteBinding MicrophoneMute { get; }

    [XmlElement(ElementName = "MuteButtonMode")]
    public MuteButtonModeBinding MuteButtonMode { get; }

    [XmlElement(ElementName = "CqcMuteButtonMode")]
    public CqcMuteButtonModeBinding CqcMuteButtonMode { get; }

    [XmlElement(ElementName = "UseShieldCell")]
    public UseShieldCellBinding UseShieldCell { get; }

    [XmlElement(ElementName = "FireChaffLauncher")]
    public FireChaffLauncherBinding FireChaffLauncher { get; }

    [XmlElement(ElementName = "ChargeECM")]
    public ChargeECMBinding ChargeECM { get; }

    [XmlElement(ElementName = "EnableRumbleTrigger")]
    public EnableRumbleTriggerBinding EnableRumbleTrigger { get; }

    [XmlElement(ElementName = "EnableMenuGroups")]
    public EnableMenuGroupsBinding EnableMenuGroups { get; }

    [XmlElement(ElementName = "WeaponColourToggle")]
    public WeaponColourToggleBinding WeaponColourToggle { get; }

    [XmlElement(ElementName = "EngineColourToggle")]
    public EngineColourToggleBinding EngineColourToggle { get; }

    [XmlElement(ElementName = "NightVisionToggle")]
    public NightVisionToggleBinding NightVisionToggle { get; }

    [XmlElement(ElementName = "UIFocus")]
    public UIFocusBinding UIFocus { get; }

    [XmlElement(ElementName = "UIFocusMode")]
    public UIFocusModeBinding UIFocusMode { get; }

    [XmlElement(ElementName = "FocusLeftPanel")]
    public FocusLeftPanelBinding FocusLeftPanel { get; }

    [XmlElement(ElementName = "FocusCommsPanel")]
    public FocusCommsPanelBinding FocusCommsPanel { get; }

    [XmlElement(ElementName = "FocusOnTextEntryField")]
    public FocusOnTextEntryFieldBinding FocusOnTextEntryField { get; }

    [XmlElement(ElementName = "QuickCommsPanel")]
    public QuickCommsPanelBinding QuickCommsPanel { get; }

    [XmlElement(ElementName = "FocusRadarPanel")]
    public FocusRadarPanelBinding FocusRadarPanel { get; }

    [XmlElement(ElementName = "FocusRightPanel")]
    public FocusRightPanelBinding FocusRightPanel { get; }

    [XmlElement(ElementName = "LeftPanelFocusOptions")]
    public LeftPanelFocusOptionsBinding LeftPanelFocusOptions { get; }

    [XmlElement(ElementName = "CommsPanelFocusOptions")]
    public CommsPanelFocusOptionsBinding CommsPanelFocusOptions { get; }

    [XmlElement(ElementName = "RolePanelFocusOptions")]
    public RolePanelFocusOptionsBinding RolePanelFocusOptions { get; }

    [XmlElement(ElementName = "RightPanelFocusOptions")]
    public RightPanelFocusOptionsBinding RightPanelFocusOptions { get; }

    [XmlElement(ElementName = "EnableCameraLockOn")]
    public EnableCameraLockOnBinding EnableCameraLockOn { get; }

    [XmlElement(ElementName = "GalaxyMapOpen")]
    public GalaxyMapOpenBinding GalaxyMapOpen { get; }

    [XmlElement(ElementName = "SystemMapOpen")]
    public SystemMapOpenBinding SystemMapOpen { get; }

    [XmlElement(ElementName = "ShowPGScoreSummaryInput")]
    public ShowPGScoreSummaryInputBinding ShowPGScoreSummaryInput { get; }

    [XmlElement(ElementName = "HeadLookToggle")]
    public HeadLookToggleBinding HeadLookToggle { get; }

    [XmlElement(ElementName = "Pause")]
    public PauseBinding Pause { get; }

    [XmlElement(ElementName = "FriendsMenu")]
    public FriendsMenuBinding FriendsMenu { get; }

    [XmlElement(ElementName = "OpenCodexGoToDiscovery")]
    public OpenCodexGoToDiscoveryBinding OpenCodexGoToDiscovery { get; }

    [XmlElement(ElementName = "PlayerHUDModeToggle")]
    public PlayerHUDModeToggleBinding PlayerHUDModeToggle { get; }

    [XmlElement(ElementName = "ExplorationFSSEnter")]
    public ExplorationFSSEnterBinding ExplorationFSSEnter { get; }

    [XmlElement(ElementName = "UI_Up")]
    public UIUpBinding UIUp { get; }

    [XmlElement(ElementName = "UI_Down")]
    public UIDownBinding UIDown { get; }

    [XmlElement(ElementName = "UI_Left")]
    public UILeftBinding UILeft { get; }

    [XmlElement(ElementName = "UI_Right")]
    public UIRightBinding UIRight { get; }

    [XmlElement(ElementName = "UI_Select")]
    public UISelectBinding UISelect { get; }

    [XmlElement(ElementName = "UI_Back")]
    public UIBackBinding UIBack { get; }

    [XmlElement(ElementName = "UI_Toggle")]
    public UIToggleBinding UIToggle { get; }

    [XmlElement(ElementName = "CycleNextPanel")]
    public CycleNextPanelBinding CycleNextPanel { get; }

    [XmlElement(ElementName = "CyclePreviousPanel")]
    public CyclePreviousPanelBinding CyclePreviousPanel { get; }

    [XmlElement(ElementName = "CycleNextPage")]
    public CycleNextPageBinding CycleNextPage { get; }

    [XmlElement(ElementName = "CyclePreviousPage")]
    public CyclePreviousPageBinding CyclePreviousPage { get; }

    [XmlElement(ElementName = "MouseHeadlook")]
    public MouseHeadlookBinding MouseHeadlook { get; }

    [XmlElement(ElementName = "MouseHeadlookInvert")]
    public MouseHeadlookInvertBinding MouseHeadlookInvert { get; }

    [XmlElement(ElementName = "MouseHeadlookSensitivity")]
    public MouseHeadlookSensitivityBinding MouseHeadlookSensitivity { get; }

    [XmlElement(ElementName = "HeadlookDefault")]
    public HeadlookDefaultBinding HeadlookDefault { get; }

    [XmlElement(ElementName = "HeadlookIncrement")]
    public HeadlookIncrementBinding HeadlookIncrement { get; }

    [XmlElement(ElementName = "HeadlookMode")]
    public HeadlookModeBinding HeadlookMode { get; }

    [XmlElement(ElementName = "HeadlookResetOnToggle")]
    public HeadlookResetOnToggleBinding HeadlookResetOnToggle { get; }

    [XmlElement(ElementName = "HeadlookSensitivity")]
    public HeadlookSensitivityBinding HeadlookSensitivity { get; }

    [XmlElement(ElementName = "HeadlookSmoothing")]
    public HeadlookSmoothingBinding HeadlookSmoothing { get; }

    [XmlElement(ElementName = "HeadLookReset")]
    public HeadLookResetBinding HeadLookReset { get; }

    [XmlElement(ElementName = "HeadLookPitchUp")]
    public HeadLookPitchUpBinding HeadLookPitchUp { get; }

    [XmlElement(ElementName = "HeadLookPitchDown")]
    public HeadLookPitchDownBinding HeadLookPitchDown { get; }

    [XmlElement(ElementName = "HeadLookPitchAxisRaw")]
    public HeadLookPitchAxisRawBinding HeadLookPitchAxisRaw { get; }

    [XmlElement(ElementName = "HeadLookYawLeft")]
    public HeadLookYawLeftBinding HeadLookYawLeft { get; }

    [XmlElement(ElementName = "HeadLookYawRight")]
    public HeadLookYawRightBinding HeadLookYawRight { get; }

    [XmlElement(ElementName = "HeadLookYawAxis")]
    public HeadLookYawAxisBinding HeadLookYawAxis { get; }

    [XmlElement(ElementName = "MotionHeadlook")]
    public MotionHeadlookBinding MotionHeadlook { get; }

    [XmlElement(ElementName = "HeadlookMotionSensitivity")]
    public HeadlookMotionSensitivityBinding HeadlookMotionSensitivity { get; }

    [XmlElement(ElementName = "yawRotateHeadlook")]
    public YawRotateHeadlookBinding YawRotateHeadlook { get; }

    [XmlElement(ElementName = "CamPitchAxis")]
    public CamPitchAxisBinding CamPitchAxis { get; }

    [XmlElement(ElementName = "CamPitchUp")]
    public CamPitchUpBinding CamPitchUp { get; }

    [XmlElement(ElementName = "CamPitchDown")]
    public CamPitchDownBinding CamPitchDown { get; }

    [XmlElement(ElementName = "CamYawAxis")]
    public CamYawAxisBinding CamYawAxis { get; }

    [XmlElement(ElementName = "CamYawLeft")]
    public CamYawLeftBinding CamYawLeft { get; }

    [XmlElement(ElementName = "CamYawRight")]
    public CamYawRightBinding CamYawRight { get; }

    [XmlElement(ElementName = "CamTranslateYAxis")]
    public CamTranslateYAxisBinding CamTranslateYAxis { get; }

    [XmlElement(ElementName = "CamTranslateForward")]
    public CamTranslateForwardBinding CamTranslateForward { get; }

    [XmlElement(ElementName = "CamTranslateBackward")]
    public CamTranslateBackwardBinding CamTranslateBackward { get; }

    [XmlElement(ElementName = "CamTranslateXAxis")]
    public CamTranslateXAxisBinding CamTranslateXAxis { get; }

    [XmlElement(ElementName = "CamTranslateLeft")]
    public CamTranslateLeftBinding CamTranslateLeft { get; }

    [XmlElement(ElementName = "CamTranslateRight")]
    public CamTranslateRightBinding CamTranslateRight { get; }

    [XmlElement(ElementName = "CamTranslateZAxis")]
    public CamTranslateZAxisBinding CamTranslateZAxis { get; }

    [XmlElement(ElementName = "CamTranslateUp")]
    public CamTranslateUpBinding CamTranslateUp { get; }

    [XmlElement(ElementName = "CamTranslateDown")]
    public CamTranslateDownBinding CamTranslateDown { get; }

    [XmlElement(ElementName = "CamZoomAxis")]
    public CamZoomAxisBinding CamZoomAxis { get; }

    [XmlElement(ElementName = "CamZoomIn")]
    public CamZoomInBinding CamZoomIn { get; }

    [XmlElement(ElementName = "CamZoomOut")]
    public CamZoomOutBinding CamZoomOut { get; }

    [XmlElement(ElementName = "CamTranslateZHold")]
    public CamTranslateZHoldBinding CamTranslateZHold { get; }

    [XmlElement(ElementName = "GalaxyMapHome")]
    public GalaxyMapHomeBinding GalaxyMapHome { get; }

    [XmlElement(ElementName = "ToggleDriveAssist")]
    public ToggleDriveAssistBinding ToggleDriveAssist { get; }

    [XmlElement(ElementName = "DriveAssistDefault")]
    public DriveAssistDefaultBinding DriveAssistDefault { get; }

    [XmlElement(ElementName = "MouseBuggySteeringXMode")]
    public MouseBuggySteeringXModeBinding MouseBuggySteeringXMode { get; }

    [XmlElement(ElementName = "MouseBuggySteeringXDecay")]
    public MouseBuggySteeringXDecayBinding MouseBuggySteeringXDecay { get; }

    [XmlElement(ElementName = "MouseBuggyRollingXMode")]
    public MouseBuggyRollingXModeBinding MouseBuggyRollingXMode { get; }

    [XmlElement(ElementName = "MouseBuggyRollingXDecay")]
    public MouseBuggyRollingXDecayBinding MouseBuggyRollingXDecay { get; }

    [XmlElement(ElementName = "MouseBuggyYMode")]
    public MouseBuggyYModeBinding MouseBuggyYMode { get; }

    [XmlElement(ElementName = "MouseBuggyYDecay")]
    public MouseBuggyYDecayBinding MouseBuggyYDecay { get; }

    [XmlElement(ElementName = "SteeringAxis")]
    public SteeringAxisBinding SteeringAxis { get; }

    [XmlElement(ElementName = "SteerLeftButton")]
    public SteerLeftButtonBinding SteerLeftButton { get; }

    [XmlElement(ElementName = "SteerRightButton")]
    public SteerRightButtonBinding SteerRightButton { get; }

    [XmlElement(ElementName = "BuggyRollAxisRaw")]
    public BuggyRollAxisRawBinding BuggyRollAxisRaw { get; }

    [XmlElement(ElementName = "BuggyRollLeftButton")]
    public BuggyRollLeftButtonBinding BuggyRollLeftButton { get; }

    [XmlElement(ElementName = "BuggyRollRightButton")]
    public BuggyRollRightButtonBinding BuggyRollRightButton { get; }

    [XmlElement(ElementName = "BuggyPitchAxis")]
    public BuggyPitchAxisBinding BuggyPitchAxis { get; }

    [XmlElement(ElementName = "BuggyPitchUpButton")]
    public BuggyPitchUpButtonBinding BuggyPitchUpButton { get; }

    [XmlElement(ElementName = "BuggyPitchDownButton")]
    public BuggyPitchDownButtonBinding BuggyPitchDownButton { get; }

    [XmlElement(ElementName = "VerticalThrustersButton")]
    public VerticalThrustersButtonBinding VerticalThrustersButton { get; }

    [XmlElement(ElementName = "BuggyPrimaryFireButton")]
    public BuggyPrimaryFireButtonBinding BuggyPrimaryFireButton { get; }

    [XmlElement(ElementName = "BuggySecondaryFireButton")]
    public BuggySecondaryFireButtonBinding BuggySecondaryFireButton { get; }

    [XmlElement(ElementName = "AutoBreakBuggyButton")]
    public AutoBreakBuggyButtonBinding AutoBreakBuggyButton { get; }

    [XmlElement(ElementName = "HeadlightsBuggyButton")]
    public HeadlightsBuggyButtonBinding HeadlightsBuggyButton { get; }

    [XmlElement(ElementName = "ToggleBuggyTurretButton")]
    public ToggleBuggyTurretButtonBinding ToggleBuggyTurretButton { get; }

    [XmlElement(ElementName = "BuggyCycleFireGroupNext")]
    public BuggyCycleFireGroupNextBinding BuggyCycleFireGroupNext { get; }

    [XmlElement(ElementName = "BuggyCycleFireGroupPrevious")]
    public BuggyCycleFireGroupPreviousBinding BuggyCycleFireGroupPrevious { get; }

    [XmlElement(ElementName = "SelectTarget_Buggy")]
    public SelectTargetBuggyBinding SelectTargetBuggy { get; }

    [XmlElement(ElementName = "MouseTurretXMode")]
    public MouseTurretXModeBinding MouseTurretXMode { get; }

    [XmlElement(ElementName = "MouseTurretXDecay")]
    public MouseTurretXDecayBinding MouseTurretXDecay { get; }

    [XmlElement(ElementName = "MouseTurretYMode")]
    public MouseTurretYModeBinding MouseTurretYMode { get; }

    [XmlElement(ElementName = "MouseTurretYDecay")]
    public MouseTurretYDecayBinding MouseTurretYDecay { get; }

    [XmlElement(ElementName = "BuggyTurretYawAxisRaw")]
    public BuggyTurretYawAxisRawBinding BuggyTurretYawAxisRaw { get; }

    [XmlElement(ElementName = "BuggyTurretYawLeftButton")]
    public BuggyTurretYawLeftButtonBinding BuggyTurretYawLeftButton { get; }

    [XmlElement(ElementName = "BuggyTurretYawRightButton")]
    public BuggyTurretYawRightButtonBinding BuggyTurretYawRightButton { get; }

    [XmlElement(ElementName = "BuggyTurretPitchAxisRaw")]
    public BuggyTurretPitchAxisRawBinding BuggyTurretPitchAxisRaw { get; }

    [XmlElement(ElementName = "BuggyTurretPitchUpButton")]
    public BuggyTurretPitchUpButtonBinding BuggyTurretPitchUpButton { get; }

    [XmlElement(ElementName = "BuggyTurretPitchDownButton")]
    public BuggyTurretPitchDownButtonBinding BuggyTurretPitchDownButton { get; }

    [XmlElement(ElementName = "BuggyTurretMouseSensitivity")]
    public BuggyTurretMouseSensitivityBinding BuggyTurretMouseSensitivity { get; }

    [XmlElement(ElementName = "BuggyTurretMouseDeadzone")]
    public BuggyTurretMouseDeadzoneBinding BuggyTurretMouseDeadzone { get; }

    [XmlElement(ElementName = "BuggyTurretMouseLinearity")]
    public BuggyTurretMouseLinearityBinding BuggyTurretMouseLinearity { get; }

    [XmlElement(ElementName = "DriveSpeedAxis")]
    public DriveSpeedAxisBinding DriveSpeedAxis { get; }

    [XmlElement(ElementName = "BuggyThrottleRange")]
    public BuggyThrottleRangeBinding BuggyThrottleRange { get; }

    [XmlElement(ElementName = "BuggyToggleReverseThrottleInput")]
    public BuggyToggleReverseThrottleInputBinding BuggyToggleReverseThrottleInput { get; }

    [XmlElement(ElementName = "BuggyThrottleIncrement")]
    public BuggyThrottleIncrementBinding BuggyThrottleIncrement { get; }

    [XmlElement(ElementName = "IncreaseSpeedButtonMax")]
    public IncreaseSpeedButtonMaxBinding IncreaseSpeedButtonMax { get; }

    [XmlElement(ElementName = "DecreaseSpeedButtonMax")]
    public DecreaseSpeedButtonMaxBinding DecreaseSpeedButtonMax { get; }

    [XmlElement(ElementName = "IncreaseSpeedButtonPartial")]
    public IncreaseSpeedButtonPartialBinding IncreaseSpeedButtonPartial { get; }

    [XmlElement(ElementName = "DecreaseSpeedButtonPartial")]
    public DecreaseSpeedButtonPartialBinding DecreaseSpeedButtonPartial { get; }

    [XmlElement(ElementName = "IncreaseEnginesPower_Buggy")]
    public IncreaseEnginesPowerBuggyBinding IncreaseEnginesPowerBuggy { get; }

    [XmlElement(ElementName = "IncreaseWeaponsPower_Buggy")]
    public IncreaseWeaponsPowerBuggyBinding IncreaseWeaponsPowerBuggy { get; }

    [XmlElement(ElementName = "IncreaseSystemsPower_Buggy")]
    public IncreaseSystemsPowerBuggyBinding IncreaseSystemsPowerBuggy { get; }

    [XmlElement(ElementName = "ResetPowerDistribution_Buggy")]
    public ResetPowerDistributionBuggyBinding ResetPowerDistributionBuggy { get; }

    [XmlElement(ElementName = "ToggleCargoScoop_Buggy")]
    public ToggleCargoScoopBuggyBinding ToggleCargoScoopBuggy { get; }

    [XmlElement(ElementName = "EjectAllCargo_Buggy")]
    public EjectAllCargoBuggyBinding EjectAllCargoBuggy { get; }

    [XmlElement(ElementName = "RecallDismissShip")]
    public RecallDismissShipBinding RecallDismissShip { get; }

    [XmlElement(ElementName = "EnableMenuGroupsSRV")]
    public EnableMenuGroupsSRVBinding EnableMenuGroupsSRV { get; }

    [XmlElement(ElementName = "UIFocus_Buggy")]
    public UIFocusBuggyBinding UIFocusBuggy { get; }

    [XmlElement(ElementName = "FocusLeftPanel_Buggy")]
    public FocusLeftPanelBuggyBinding FocusLeftPanelBuggy { get; }

    [XmlElement(ElementName = "FocusCommsPanel_Buggy")]
    public FocusCommsPanelBuggyBinding FocusCommsPanelBuggy { get; }

    [XmlElement(ElementName = "QuickCommsPanel_Buggy")]
    public QuickCommsPanelBuggyBinding QuickCommsPanelBuggy { get; }

    [XmlElement(ElementName = "FocusRadarPanel_Buggy")]
    public FocusRadarPanelBuggyBinding FocusRadarPanelBuggy { get; }

    [XmlElement(ElementName = "FocusRightPanel_Buggy")]
    public FocusRightPanelBuggyBinding FocusRightPanelBuggy { get; }

    [XmlElement(ElementName = "GalaxyMapOpen_Buggy")]
    public GalaxyMapOpenBuggyBinding GalaxyMapOpenBuggy { get; }

    [XmlElement(ElementName = "SystemMapOpen_Buggy")]
    public SystemMapOpenBuggyBinding SystemMapOpenBuggy { get; }

    [XmlElement(ElementName = "OpenCodexGoToDiscovery_Buggy")]
    public OpenCodexGoToDiscoveryBuggyBinding OpenCodexGoToDiscoveryBuggy { get; }

    [XmlElement(ElementName = "PlayerHUDModeToggle_Buggy")]
    public PlayerHUDModeToggleBuggyBinding PlayerHUDModeToggleBuggy { get; }

    [XmlElement(ElementName = "HeadLookToggle_Buggy")]
    public HeadLookToggleBuggyBinding HeadLookToggleBuggy { get; }

    [XmlElement(ElementName = "MultiCrewToggleMode")]
    public MultiCrewToggleModeBinding MultiCrewToggleMode { get; }

    [XmlElement(ElementName = "MultiCrewPrimaryFire")]
    public MultiCrewPrimaryFireBinding MultiCrewPrimaryFire { get; }

    [XmlElement(ElementName = "MultiCrewSecondaryFire")]
    public MultiCrewSecondaryFireBinding MultiCrewSecondaryFire { get; }

    [XmlElement(ElementName = "MultiCrewPrimaryUtilityFire")]
    public MultiCrewPrimaryUtilityFireBinding MultiCrewPrimaryUtilityFire { get; }

    [XmlElement(ElementName = "MultiCrewSecondaryUtilityFire")]
    public MultiCrewSecondaryUtilityFireBinding MultiCrewSecondaryUtilityFire { get; }

    [XmlElement(ElementName = "MultiCrewThirdPersonMouseXMode")]
    public MultiCrewThirdPersonMouseXModeBinding MultiCrewThirdPersonMouseXMode { get; }

    [XmlElement(ElementName = "MultiCrewThirdPersonMouseXDecay")]
    public MultiCrewThirdPersonMouseXDecayBinding MultiCrewThirdPersonMouseXDecay { get; }

    [XmlElement(ElementName = "MultiCrewThirdPersonMouseYMode")]
    public MultiCrewThirdPersonMouseYModeBinding MultiCrewThirdPersonMouseYMode { get; }

    [XmlElement(ElementName = "MultiCrewThirdPersonMouseYDecay")]
    public MultiCrewThirdPersonMouseYDecayBinding MultiCrewThirdPersonMouseYDecay { get; }

    [XmlElement(ElementName = "MultiCrewThirdPersonYawAxisRaw")]
    public MultiCrewThirdPersonYawAxisRawBinding MultiCrewThirdPersonYawAxisRaw { get; }

    [XmlElement(ElementName = "MultiCrewThirdPersonYawLeftButton")]
    public MultiCrewThirdPersonYawLeftButtonBinding MultiCrewThirdPersonYawLeftButton { get; }

    [XmlElement(ElementName = "MultiCrewThirdPersonYawRightButton")]
    public MultiCrewThirdPersonYawRightButtonBinding MultiCrewThirdPersonYawRightButton { get; }

    [XmlElement(ElementName = "MultiCrewThirdPersonPitchAxisRaw")]
    public MultiCrewThirdPersonPitchAxisRawBinding MultiCrewThirdPersonPitchAxisRaw { get; }

    [XmlElement(ElementName = "MultiCrewThirdPersonPitchUpButton")]
    public MultiCrewThirdPersonPitchUpButtonBinding MultiCrewThirdPersonPitchUpButton { get; }

    [XmlElement(ElementName = "MultiCrewThirdPersonPitchDownButton")]
    public MultiCrewThirdPersonPitchDownButtonBinding MultiCrewThirdPersonPitchDownButton { get; }

    [XmlElement(ElementName = "MultiCrewThirdPersonMouseSensitivity")]
    public MultiCrewThirdPersonMouseSensitivityBinding MultiCrewThirdPersonMouseSensitivity { get; }

    [XmlElement(ElementName = "MultiCrewThirdPersonFovAxisRaw")]
    public MultiCrewThirdPersonFovAxisRawBinding MultiCrewThirdPersonFovAxisRaw { get; }

    [XmlElement(ElementName = "MultiCrewThirdPersonFovOutButton")]
    public MultiCrewThirdPersonFovOutButtonBinding MultiCrewThirdPersonFovOutButton { get; }

    [XmlElement(ElementName = "MultiCrewThirdPersonFovInButton")]
    public MultiCrewThirdPersonFovInButtonBinding MultiCrewThirdPersonFovInButton { get; }

    [XmlElement(ElementName = "MultiCrewCockpitUICycleForward")]
    public MultiCrewCockpitUICycleForwardBinding MultiCrewCockpitUICycleForward { get; }

    [XmlElement(ElementName = "MultiCrewCockpitUICycleBackward")]
    public MultiCrewCockpitUICycleBackwardBinding MultiCrewCockpitUICycleBackward { get; }

    [XmlElement(ElementName = "OrderRequestDock")]
    public OrderRequestDockBinding OrderRequestDock { get; }

    [XmlElement(ElementName = "OrderDefensiveBehaviour")]
    public OrderDefensiveBehaviourBinding OrderDefensiveBehaviour { get; }

    [XmlElement(ElementName = "OrderAggressiveBehaviour")]
    public OrderAggressiveBehaviourBinding OrderAggressiveBehaviour { get; }

    [XmlElement(ElementName = "OrderFocusTarget")]
    public OrderFocusTargetBinding OrderFocusTarget { get; }

    [XmlElement(ElementName = "OrderHoldFire")]
    public OrderHoldFireBinding OrderHoldFire { get; }

    [XmlElement(ElementName = "OrderHoldPosition")]
    public OrderHoldPositionBinding OrderHoldPosition { get; }

    [XmlElement(ElementName = "OrderFollow")]
    public OrderFollowBinding OrderFollow { get; }

    [XmlElement(ElementName = "OpenOrders")]
    public OpenOrdersBinding OpenOrders { get; }

    [XmlElement(ElementName = "PhotoCameraToggle")]
    public PhotoCameraToggleBinding PhotoCameraToggle { get; }

    [XmlElement(ElementName = "PhotoCameraToggle_Buggy")]
    public PhotoCameraToggleBuggyBinding PhotoCameraToggleBuggy { get; }

    [XmlElement(ElementName = "PhotoCameraToggle_Humanoid")]
    public PhotoCameraToggleHumanoidBinding PhotoCameraToggleHumanoid { get; }

    [XmlElement(ElementName = "VanityCameraScrollLeft")]
    public VanityCameraScrollLeftBinding VanityCameraScrollLeft { get; }

    [XmlElement(ElementName = "VanityCameraScrollRight")]
    public VanityCameraScrollRightBinding VanityCameraScrollRight { get; }

    [XmlElement(ElementName = "ToggleFreeCam")]
    public ToggleFreeCamBinding ToggleFreeCam { get; }

    [XmlElement(ElementName = "VanityCameraOne")]
    public VanityCameraOneBinding VanityCameraOne { get; }

    [XmlElement(ElementName = "VanityCameraTwo")]
    public VanityCameraTwoBinding VanityCameraTwo { get; }

    [XmlElement(ElementName = "VanityCameraThree")]
    public VanityCameraThreeBinding VanityCameraThree { get; }

    [XmlElement(ElementName = "VanityCameraFour")]
    public VanityCameraFourBinding VanityCameraFour { get; }

    [XmlElement(ElementName = "VanityCameraFive")]
    public VanityCameraFiveBinding VanityCameraFive { get; }

    [XmlElement(ElementName = "VanityCameraSix")]
    public VanityCameraSixBinding VanityCameraSix { get; }

    [XmlElement(ElementName = "VanityCameraSeven")]
    public VanityCameraSevenBinding VanityCameraSeven { get; }

    [XmlElement(ElementName = "VanityCameraEight")]
    public VanityCameraEightBinding VanityCameraEight { get; }

    [XmlElement(ElementName = "VanityCameraNine")]
    public VanityCameraNineBinding VanityCameraNine { get; }

    [XmlElement(ElementName = "VanityCameraTen")]
    public VanityCameraTenBinding VanityCameraTen { get; }

    [XmlElement(ElementName = "FreeCamToggleHUD")]
    public FreeCamToggleHUDBinding FreeCamToggleHUD { get; }

    [XmlElement(ElementName = "FreeCamSpeedInc")]
    public FreeCamSpeedIncBinding FreeCamSpeedInc { get; }

    [XmlElement(ElementName = "FreeCamSpeedDec")]
    public FreeCamSpeedDecBinding FreeCamSpeedDec { get; }

    [XmlElement(ElementName = "MoveFreeCamY")]
    public MoveFreeCamYBinding MoveFreeCamY { get; }

    [XmlElement(ElementName = "ThrottleRangeFreeCam")]
    public ThrottleRangeFreeCamBinding ThrottleRangeFreeCam { get; }

    [XmlElement(ElementName = "ToggleReverseThrottleInputFreeCam")]
    public ToggleReverseThrottleInputFreeCamBinding ToggleReverseThrottleInputFreeCam { get; }

    [XmlElement(ElementName = "MoveFreeCamForward")]
    public MoveFreeCamForwardBinding MoveFreeCamForward { get; }

    [XmlElement(ElementName = "MoveFreeCamBackwards")]
    public MoveFreeCamBackwardsBinding MoveFreeCamBackwards { get; }

    [XmlElement(ElementName = "MoveFreeCamX")]
    public MoveFreeCamXBinding MoveFreeCamX { get; }

    [XmlElement(ElementName = "MoveFreeCamRight")]
    public MoveFreeCamRightBinding MoveFreeCamRight { get; }

    [XmlElement(ElementName = "MoveFreeCamLeft")]
    public MoveFreeCamLeftBinding MoveFreeCamLeft { get; }

    [XmlElement(ElementName = "MoveFreeCamZ")]
    public MoveFreeCamZBinding MoveFreeCamZ { get; }

    [XmlElement(ElementName = "MoveFreeCamUpAxis")]
    public MoveFreeCamUpAxisBinding MoveFreeCamUpAxis { get; }

    [XmlElement(ElementName = "MoveFreeCamDownAxis")]
    public MoveFreeCamDownAxisBinding MoveFreeCamDownAxis { get; }

    [XmlElement(ElementName = "MoveFreeCamUp")]
    public MoveFreeCamUpBinding MoveFreeCamUp { get; }

    [XmlElement(ElementName = "MoveFreeCamDown")]
    public MoveFreeCamDownBinding MoveFreeCamDown { get; }

    [XmlElement(ElementName = "PitchCameraMouse")]
    public PitchCameraMouseBinding PitchCameraMouse { get; }

    [XmlElement(ElementName = "YawCameraMouse")]
    public YawCameraMouseBinding YawCameraMouse { get; }

    [XmlElement(ElementName = "PitchCamera")]
    public PitchCameraBinding PitchCamera { get; }

    [XmlElement(ElementName = "FreeCamMouseSensitivity")]
    public FreeCamMouseSensitivityBinding FreeCamMouseSensitivity { get; }

    [XmlElement(ElementName = "FreeCamMouseYDecay")]
    public FreeCamMouseYDecayBinding FreeCamMouseYDecay { get; }

    [XmlElement(ElementName = "PitchCameraUp")]
    public PitchCameraUpBinding PitchCameraUp { get; }

    [XmlElement(ElementName = "PitchCameraDown")]
    public PitchCameraDownBinding PitchCameraDown { get; }

    [XmlElement(ElementName = "YawCamera")]
    public YawCameraBinding YawCamera { get; }

    [XmlElement(ElementName = "FreeCamMouseXDecay")]
    public FreeCamMouseXDecayBinding FreeCamMouseXDecay { get; }

    [XmlElement(ElementName = "YawCameraLeft")]
    public YawCameraLeftBinding YawCameraLeft { get; }

    [XmlElement(ElementName = "YawCameraRight")]
    public YawCameraRightBinding YawCameraRight { get; }

    [XmlElement(ElementName = "RollCamera")]
    public RollCameraBinding RollCamera { get; }

    [XmlElement(ElementName = "RollCameraLeft")]
    public RollCameraLeftBinding RollCameraLeft { get; }

    [XmlElement(ElementName = "RollCameraRight")]
    public RollCameraRightBinding RollCameraRight { get; }

    [XmlElement(ElementName = "ToggleRotationLock")]
    public ToggleRotationLockBinding ToggleRotationLock { get; }

    [XmlElement(ElementName = "FixCameraRelativeToggle")]
    public FixCameraRelativeToggleBinding FixCameraRelativeToggle { get; }

    [XmlElement(ElementName = "FixCameraWorldToggle")]
    public FixCameraWorldToggleBinding FixCameraWorldToggle { get; }

    [XmlElement(ElementName = "QuitCamera")]
    public QuitCameraBinding QuitCamera { get; }

    [XmlElement(ElementName = "ToggleAdvanceMode")]
    public ToggleAdvanceModeBinding ToggleAdvanceMode { get; }

    [XmlElement(ElementName = "FreeCamZoomIn")]
    public FreeCamZoomInBinding FreeCamZoomIn { get; }

    [XmlElement(ElementName = "FreeCamZoomOut")]
    public FreeCamZoomOutBinding FreeCamZoomOut { get; }

    [XmlElement(ElementName = "FStopDec")]
    public FStopDecBinding FStopDec { get; }

    [XmlElement(ElementName = "FStopInc")]
    public FStopIncBinding FStopInc { get; }

    [XmlElement(ElementName = "CommanderCreator_Undo")]
    public CommanderCreatorUndoBinding CommanderCreatorUndo { get; }

    [XmlElement(ElementName = "CommanderCreator_Redo")]
    public CommanderCreatorRedoBinding CommanderCreatorRedo { get; }

    [XmlElement(ElementName = "CommanderCreator_Rotation_MouseToggle")]
    public CommanderCreatorRotationMouseToggleBinding CommanderCreatorRotationMouseToggle { get; }

    [XmlElement(ElementName = "CommanderCreator_Rotation")]
    public CommanderCreatorRotationBinding CommanderCreatorRotation { get; }

    [XmlElement(ElementName = "GalnetAudio_Play_Pause")]
    public GalnetAudioPlayPauseBinding GalnetAudioPlayPause { get; }

    [XmlElement(ElementName = "GalnetAudio_SkipForward")]
    public GalnetAudioSkipForwardBinding GalnetAudioSkipForward { get; }

    [XmlElement(ElementName = "GalnetAudio_SkipBackward")]
    public GalnetAudioSkipBackwardBinding GalnetAudioSkipBackward { get; }

    [XmlElement(ElementName = "GalnetAudio_ClearQueue")]
    public GalnetAudioClearQueueBinding GalnetAudioClearQueue { get; }

    [XmlElement(ElementName = "ExplorationFSSCameraPitch")]
    public ExplorationFSSCameraPitchBinding ExplorationFSSCameraPitch { get; }

    [XmlElement(ElementName = "ExplorationFSSCameraPitchIncreaseButton")]
    public ExplorationFSSCameraPitchIncreaseButtonBinding ExplorationFSSCameraPitchIncreaseButton { get; }

    [XmlElement(ElementName = "ExplorationFSSCameraPitchDecreaseButton")]
    public ExplorationFSSCameraPitchDecreaseButtonBinding ExplorationFSSCameraPitchDecreaseButton { get; }

    [XmlElement(ElementName = "ExplorationFSSCameraYaw")]
    public ExplorationFSSCameraYawBinding ExplorationFSSCameraYaw { get; }

    [XmlElement(ElementName = "ExplorationFSSCameraYawIncreaseButton")]
    public ExplorationFSSCameraYawIncreaseButtonBinding ExplorationFSSCameraYawIncreaseButton { get; }

    [XmlElement(ElementName = "ExplorationFSSCameraYawDecreaseButton")]
    public ExplorationFSSCameraYawDecreaseButtonBinding ExplorationFSSCameraYawDecreaseButton { get; }

    [XmlElement(ElementName = "ExplorationFSSZoomIn")]
    public ExplorationFSSZoomInBinding ExplorationFSSZoomIn { get; }

    [XmlElement(ElementName = "ExplorationFSSZoomOut")]
    public ExplorationFSSZoomOutBinding ExplorationFSSZoomOut { get; }

    [XmlElement(ElementName = "ExplorationFSSMiniZoomIn")]
    public ExplorationFSSMiniZoomInBinding ExplorationFSSMiniZoomIn { get; }

    [XmlElement(ElementName = "ExplorationFSSMiniZoomOut")]
    public ExplorationFSSMiniZoomOutBinding ExplorationFSSMiniZoomOut { get; }

    [XmlElement(ElementName = "ExplorationFSSRadioTuningX_Raw")]
    public ExplorationFSSRadioTuningXRawBinding ExplorationFSSRadioTuningXRaw { get; }

    [XmlElement(ElementName = "ExplorationFSSRadioTuningX_Increase")]
    public ExplorationFSSRadioTuningXIncreaseBinding ExplorationFSSRadioTuningXIncrease { get; }

    [XmlElement(ElementName = "ExplorationFSSRadioTuningX_Decrease")]
    public ExplorationFSSRadioTuningXDecreaseBinding ExplorationFSSRadioTuningXDecrease { get; }

    [XmlElement(ElementName = "ExplorationFSSRadioTuningAbsoluteX")]
    public ExplorationFSSRadioTuningAbsoluteXBinding ExplorationFSSRadioTuningAbsoluteX { get; }

    [XmlElement(ElementName = "FSSTuningSensitivity")]
    public FSSTuningSensitivityBinding FSSTuningSensitivity { get; }

    [XmlElement(ElementName = "ExplorationFSSDiscoveryScan")]
    public ExplorationFSSDiscoveryScanBinding ExplorationFSSDiscoveryScan { get; }

    [XmlElement(ElementName = "ExplorationFSSQuit")]
    public ExplorationFSSQuitBinding ExplorationFSSQuit { get; }

    [XmlElement(ElementName = "FSSMouseXMode")]
    public FSSMouseXModeBinding FSSMouseXMode { get; }

    [XmlElement(ElementName = "FSSMouseXDecay")]
    public FSSMouseXDecayBinding FSSMouseXDecay { get; }

    [XmlElement(ElementName = "FSSMouseYMode")]
    public FSSMouseYModeBinding FSSMouseYMode { get; }

    [XmlElement(ElementName = "FSSMouseYDecay")]
    public FSSMouseYDecayBinding FSSMouseYDecay { get; }

    [XmlElement(ElementName = "FSSMouseSensitivity")]
    public FSSMouseSensitivityBinding FSSMouseSensitivity { get; }

    [XmlElement(ElementName = "FSSMouseDeadzone")]
    public FSSMouseDeadzoneBinding FSSMouseDeadzone { get; }

    [XmlElement(ElementName = "FSSMouseLinearity")]
    public FSSMouseLinearityBinding FSSMouseLinearity { get; }

    [XmlElement(ElementName = "ExplorationFSSTarget")]
    public ExplorationFSSTargetBinding ExplorationFSSTarget { get; }

    [XmlElement(ElementName = "ExplorationFSSShowHelp")]
    public ExplorationFSSShowHelpBinding ExplorationFSSShowHelp { get; }

    [XmlElement(ElementName = "ExplorationSAAChangeScannedAreaViewToggle")]
    public ExplorationSAAChangeScannedAreaViewToggleBinding ExplorationSAAChangeScannedAreaViewToggle { get; }

    [XmlElement(ElementName = "ExplorationSAAExitThirdPerson")]
    public ExplorationSAAExitThirdPersonBinding ExplorationSAAExitThirdPerson { get; }

    [XmlElement(ElementName = "ExplorationSAANextGenus")]
    public ExplorationSAANextGenusBinding ExplorationSAANextGenus { get; }

    [XmlElement(ElementName = "ExplorationSAAPreviousGenus")]
    public ExplorationSAAPreviousGenusBinding ExplorationSAAPreviousGenus { get; }

    [XmlElement(ElementName = "SAAThirdPersonMouseXMode")]
    public SAAThirdPersonMouseXModeBinding SAAThirdPersonMouseXMode { get; }

    [XmlElement(ElementName = "SAAThirdPersonMouseXDecay")]
    public SAAThirdPersonMouseXDecayBinding SAAThirdPersonMouseXDecay { get; }

    [XmlElement(ElementName = "SAAThirdPersonMouseYMode")]
    public SAAThirdPersonMouseYModeBinding SAAThirdPersonMouseYMode { get; }

    [XmlElement(ElementName = "SAAThirdPersonMouseYDecay")]
    public SAAThirdPersonMouseYDecayBinding SAAThirdPersonMouseYDecay { get; }

    [XmlElement(ElementName = "SAAThirdPersonMouseSensitivity")]
    public SAAThirdPersonMouseSensitivityBinding SAAThirdPersonMouseSensitivity { get; }

    [XmlElement(ElementName = "SAAThirdPersonYawAxisRaw")]
    public SAAThirdPersonYawAxisRawBinding SAAThirdPersonYawAxisRaw { get; }

    [XmlElement(ElementName = "SAAThirdPersonYawLeftButton")]
    public SAAThirdPersonYawLeftButtonBinding SAAThirdPersonYawLeftButton { get; }

    [XmlElement(ElementName = "SAAThirdPersonYawRightButton")]
    public SAAThirdPersonYawRightButtonBinding SAAThirdPersonYawRightButton { get; }

    [XmlElement(ElementName = "SAAThirdPersonPitchAxisRaw")]
    public SAAThirdPersonPitchAxisRawBinding SAAThirdPersonPitchAxisRaw { get; }

    [XmlElement(ElementName = "SAAThirdPersonPitchUpButton")]
    public SAAThirdPersonPitchUpButtonBinding SAAThirdPersonPitchUpButton { get; }

    [XmlElement(ElementName = "SAAThirdPersonPitchDownButton")]
    public SAAThirdPersonPitchDownButtonBinding SAAThirdPersonPitchDownButton { get; }

    [XmlElement(ElementName = "SAAThirdPersonFovAxisRaw")]
    public SAAThirdPersonFovAxisRawBinding SAAThirdPersonFovAxisRaw { get; }

    [XmlElement(ElementName = "SAAThirdPersonFovOutButton")]
    public SAAThirdPersonFovOutButtonBinding SAAThirdPersonFovOutButton { get; }

    [XmlElement(ElementName = "SAAThirdPersonFovInButton")]
    public SAAThirdPersonFovInButtonBinding SAAThirdPersonFovInButton { get; }

    [XmlElement(ElementName = "MouseHumanoidXMode")]
    public MouseHumanoidXModeBinding MouseHumanoidXMode { get; }

    [XmlElement(ElementName = "MouseHumanoidYMode")]
    public MouseHumanoidYModeBinding MouseHumanoidYMode { get; }

    [XmlElement(ElementName = "MouseHumanoidSensitivity")]
    public MouseHumanoidSensitivityBinding MouseHumanoidSensitivity { get; }

    [XmlElement(ElementName = "HumanoidForwardAxis")]
    public HumanoidForwardAxisBinding HumanoidForwardAxis { get; }

    [XmlElement(ElementName = "HumanoidForwardButton")]
    public HumanoidForwardButtonBinding HumanoidForwardButton { get; }

    [XmlElement(ElementName = "HumanoidBackwardButton")]
    public HumanoidBackwardButtonBinding HumanoidBackwardButton { get; }

    [XmlElement(ElementName = "HumanoidStrafeAxis")]
    public HumanoidStrafeAxisBinding HumanoidStrafeAxis { get; }

    [XmlElement(ElementName = "HumanoidStrafeLeftButton")]
    public HumanoidStrafeLeftButtonBinding HumanoidStrafeLeftButton { get; }

    [XmlElement(ElementName = "HumanoidStrafeRightButton")]
    public HumanoidStrafeRightButtonBinding HumanoidStrafeRightButton { get; }

    [XmlElement(ElementName = "HumanoidRotateAxis")]
    public HumanoidRotateAxisBinding HumanoidRotateAxis { get; }

    [XmlElement(ElementName = "HumanoidRotateSensitivity")]
    public HumanoidRotateSensitivityBinding HumanoidRotateSensitivity { get; }

    [XmlElement(ElementName = "HumanoidRotateLeftButton")]
    public HumanoidRotateLeftButtonBinding HumanoidRotateLeftButton { get; }

    [XmlElement(ElementName = "HumanoidRotateRightButton")]
    public HumanoidRotateRightButtonBinding HumanoidRotateRightButton { get; }

    [XmlElement(ElementName = "HumanoidPitchAxis")]
    public HumanoidPitchAxisBinding HumanoidPitchAxis { get; }

    [XmlElement(ElementName = "HumanoidPitchSensitivity")]
    public HumanoidPitchSensitivityBinding HumanoidPitchSensitivity { get; }

    [XmlElement(ElementName = "HumanoidPitchUpButton")]
    public HumanoidPitchUpButtonBinding HumanoidPitchUpButton { get; }

    [XmlElement(ElementName = "HumanoidPitchDownButton")]
    public HumanoidPitchDownButtonBinding HumanoidPitchDownButton { get; }

    [XmlElement(ElementName = "HumanoidSprintButton")]
    public HumanoidSprintButtonBinding HumanoidSprintButton { get; }

    [XmlElement(ElementName = "HumanoidWalkButton")]
    public HumanoidWalkButtonBinding HumanoidWalkButton { get; }

    [XmlElement(ElementName = "HumanoidCrouchButton")]
    public HumanoidCrouchButtonBinding HumanoidCrouchButton { get; }

    [XmlElement(ElementName = "HumanoidJumpButton")]
    public HumanoidJumpButtonBinding HumanoidJumpButton { get; }

    [XmlElement(ElementName = "HumanoidPrimaryInteractButton")]
    public HumanoidPrimaryInteractButtonBinding HumanoidPrimaryInteractButton { get; }

    [XmlElement(ElementName = "HumanoidSecondaryInteractButton")]
    public HumanoidSecondaryInteractButtonBinding HumanoidSecondaryInteractButton { get; }

    [XmlElement(ElementName = "HumanoidItemWheelButton")]
    public HumanoidItemWheelButtonBinding HumanoidItemWheelButton { get; }

    [XmlElement(ElementName = "HumanoidEmoteWheelButton")]
    public HumanoidEmoteWheelButtonBinding HumanoidEmoteWheelButton { get; }

    [XmlElement(ElementName = "HumanoidUtilityWheelCycleMode")]
    public HumanoidUtilityWheelCycleModeBinding HumanoidUtilityWheelCycleMode { get; }

    [XmlElement(ElementName = "HumanoidItemWheelButton_XAxis")]
    public HumanoidItemWheelButtonXAxisBinding HumanoidItemWheelButtonXAxis { get; }

    [XmlElement(ElementName = "HumanoidItemWheelButton_XLeft")]
    public HumanoidItemWheelButtonXLeftBinding HumanoidItemWheelButtonXLeft { get; }

    [XmlElement(ElementName = "HumanoidItemWheelButton_XRight")]
    public HumanoidItemWheelButtonXRightBinding HumanoidItemWheelButtonXRight { get; }

    [XmlElement(ElementName = "HumanoidItemWheelButton_YAxis")]
    public HumanoidItemWheelButtonYAxisBinding HumanoidItemWheelButtonYAxis { get; }

    [XmlElement(ElementName = "HumanoidItemWheelButton_YUp")]
    public HumanoidItemWheelButtonYUpBinding HumanoidItemWheelButtonYUp { get; }

    [XmlElement(ElementName = "HumanoidItemWheelButton_YDown")]
    public HumanoidItemWheelButtonYDownBinding HumanoidItemWheelButtonYDown { get; }

    [XmlElement(ElementName = "HumanoidItemWheel_AcceptMouseInput")]
    public HumanoidItemWheelAcceptMouseInputBinding HumanoidItemWheelAcceptMouseInput { get; }

    [XmlElement(ElementName = "HumanoidPrimaryFireButton")]
    public HumanoidPrimaryFireButtonBinding HumanoidPrimaryFireButton { get; }

    [XmlElement(ElementName = "HumanoidZoomButton")]
    public HumanoidZoomButtonBinding HumanoidZoomButton { get; }

    [XmlElement(ElementName = "HumanoidThrowGrenadeButton")]
    public HumanoidThrowGrenadeButtonBinding HumanoidThrowGrenadeButton { get; }

    [XmlElement(ElementName = "HumanoidMeleeButton")]
    public HumanoidMeleeButtonBinding HumanoidMeleeButton { get; }

    [XmlElement(ElementName = "HumanoidReloadButton")]
    public HumanoidReloadButtonBinding HumanoidReloadButton { get; }

    [XmlElement(ElementName = "HumanoidSwitchWeapon")]
    public HumanoidSwitchWeaponBinding HumanoidSwitchWeapon { get; }

    [XmlElement(ElementName = "HumanoidSelectPrimaryWeaponButton")]
    public HumanoidSelectPrimaryWeaponButtonBinding HumanoidSelectPrimaryWeaponButton { get; }

    [XmlElement(ElementName = "HumanoidSelectSecondaryWeaponButton")]
    public HumanoidSelectSecondaryWeaponButtonBinding HumanoidSelectSecondaryWeaponButton { get; }

    [XmlElement(ElementName = "HumanoidSelectUtilityWeaponButton")]
    public HumanoidSelectUtilityWeaponButtonBinding HumanoidSelectUtilityWeaponButton { get; }

    [XmlElement(ElementName = "HumanoidSelectNextWeaponButton")]
    public HumanoidSelectNextWeaponButtonBinding HumanoidSelectNextWeaponButton { get; }

    [XmlElement(ElementName = "HumanoidSelectPreviousWeaponButton")]
    public HumanoidSelectPreviousWeaponButtonBinding HumanoidSelectPreviousWeaponButton { get; }

    [XmlElement(ElementName = "HumanoidHideWeaponButton")]
    public HumanoidHideWeaponButtonBinding HumanoidHideWeaponButton { get; }

    [XmlElement(ElementName = "HumanoidSelectNextGrenadeTypeButton")]
    public HumanoidSelectNextGrenadeTypeButtonBinding HumanoidSelectNextGrenadeTypeButton { get; }

    [XmlElement(ElementName = "HumanoidSelectPreviousGrenadeTypeButton")]
    public HumanoidSelectPreviousGrenadeTypeButtonBinding HumanoidSelectPreviousGrenadeTypeButton { get; }

    [XmlElement(ElementName = "HumanoidToggleFlashlightButton")]
    public HumanoidToggleFlashlightButtonBinding HumanoidToggleFlashlightButton { get; }

    [XmlElement(ElementName = "HumanoidToggleNightVisionButton")]
    public HumanoidToggleNightVisionButtonBinding HumanoidToggleNightVisionButton { get; }

    [XmlElement(ElementName = "HumanoidToggleShieldsButton")]
    public HumanoidToggleShieldsButtonBinding HumanoidToggleShieldsButton { get; }

    [XmlElement(ElementName = "HumanoidClearAuthorityLevel")]
    public HumanoidClearAuthorityLevelBinding HumanoidClearAuthorityLevel { get; }

    [XmlElement(ElementName = "HumanoidHealthPack")]
    public HumanoidHealthPackBinding HumanoidHealthPack { get; }

    [XmlElement(ElementName = "HumanoidBattery")]
    public HumanoidBatteryBinding HumanoidBattery { get; }

    [XmlElement(ElementName = "HumanoidSelectFragGrenade")]
    public HumanoidSelectFragGrenadeBinding HumanoidSelectFragGrenade { get; }

    [XmlElement(ElementName = "HumanoidSelectEMPGrenade")]
    public HumanoidSelectEMPGrenadeBinding HumanoidSelectEMPGrenade { get; }

    [XmlElement(ElementName = "HumanoidSelectShieldGrenade")]
    public HumanoidSelectShieldGrenadeBinding HumanoidSelectShieldGrenade { get; }

    [XmlElement(ElementName = "HumanoidSwitchToRechargeTool")]
    public HumanoidSwitchToRechargeToolBinding HumanoidSwitchToRechargeTool { get; }

    [XmlElement(ElementName = "HumanoidSwitchToCompAnalyser")]
    public HumanoidSwitchToCompAnalyserBinding HumanoidSwitchToCompAnalyser { get; }

    [XmlElement(ElementName = "HumanoidSwitchToSuitTool")]
    public HumanoidSwitchToSuitToolBinding HumanoidSwitchToSuitTool { get; }

    [XmlElement(ElementName = "HumanoidToggleToolModeButton")]
    public HumanoidToggleToolModeButtonBinding HumanoidToggleToolModeButton { get; }

    [XmlElement(ElementName = "HumanoidToggleMissionHelpPanelButton")]
    public HumanoidToggleMissionHelpPanelButtonBinding HumanoidToggleMissionHelpPanelButton { get; }

    [XmlElement(ElementName = "HumanoidPing")]
    public HumanoidPingBinding HumanoidPing { get; }

    [XmlElement(ElementName = "GalaxyMapOpen_Humanoid")]
    public GalaxyMapOpenHumanoidBinding GalaxyMapOpenHumanoid { get; }

    [XmlElement(ElementName = "SystemMapOpen_Humanoid")]
    public SystemMapOpenHumanoidBinding SystemMapOpenHumanoid { get; }

    [XmlElement(ElementName = "FocusCommsPanel_Humanoid")]
    public FocusCommsPanelHumanoidBinding FocusCommsPanelHumanoid { get; }

    [XmlElement(ElementName = "QuickCommsPanel_Humanoid")]
    public QuickCommsPanelHumanoidBinding QuickCommsPanelHumanoid { get; }

    [XmlElement(ElementName = "HumanoidOpenAccessPanelButton")]
    public HumanoidOpenAccessPanelButtonBinding HumanoidOpenAccessPanelButton { get; }

    [XmlElement(ElementName = "HumanoidConflictContextualUIButton")]
    public HumanoidConflictContextualUIButtonBinding HumanoidConflictContextualUIButton { get; }

    [XmlElement(ElementName = "EnableMenuGroupsOnFoot")]
    public EnableMenuGroupsOnFootBinding EnableMenuGroupsOnFoot { get; }

    [XmlElement(ElementName = "StoreEnableRotation")]
    public StoreEnableRotationBinding StoreEnableRotation { get; }

    [XmlElement(ElementName = "StorePitchCamera")]
    public StorePitchCameraBinding StorePitchCamera { get; }

    [XmlElement(ElementName = "StoreYawCamera")]
    public StoreYawCameraBinding StoreYawCamera { get; }

    [XmlElement(ElementName = "StoreCamZoomIn")]
    public StoreCamZoomInBinding StoreCamZoomIn { get; }

    [XmlElement(ElementName = "StoreCamZoomOut")]
    public StoreCamZoomOutBinding StoreCamZoomOut { get; }

    [XmlElement(ElementName = "StoreToggle")]
    public StoreToggleBinding StoreToggle { get; }

    [XmlElement(ElementName = "HumanoidEmoteSlot1")]
    public HumanoidEmoteSlot1Binding HumanoidEmoteSlot1 { get; }

    [XmlElement(ElementName = "HumanoidEmoteSlot2")]
    public HumanoidEmoteSlot2Binding HumanoidEmoteSlot2 { get; }

    [XmlElement(ElementName = "HumanoidEmoteSlot3")]
    public HumanoidEmoteSlot3Binding HumanoidEmoteSlot3 { get; }

    [XmlElement(ElementName = "HumanoidEmoteSlot4")]
    public HumanoidEmoteSlot4Binding HumanoidEmoteSlot4 { get; }

    [XmlElement(ElementName = "HumanoidEmoteSlot5")]
    public HumanoidEmoteSlot5Binding HumanoidEmoteSlot5 { get; }

    [XmlElement(ElementName = "HumanoidEmoteSlot6")]
    public HumanoidEmoteSlot6Binding HumanoidEmoteSlot6 { get; }

    [XmlElement(ElementName = "HumanoidEmoteSlot7")]
    public HumanoidEmoteSlot7Binding HumanoidEmoteSlot7 { get; }

    [XmlElement(ElementName = "HumanoidEmoteSlot8")]
    public HumanoidEmoteSlot8Binding HumanoidEmoteSlot8 { get; }

    [XmlAttribute(AttributeName = "PresetName")]
    public string PresetName { get; }

    [XmlAttribute(AttributeName = "MajorVersion")]
    public int MajorVersion { get; }

    [XmlAttribute(AttributeName = "MinorVersion")]
    public int MinorVersion { get; }

    [XmlText]
    public string Text { get; }

    [XmlRoot(ElementName = "MouseXMode")]
    public readonly struct MouseXModeBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "MouseXDecay")]
    public readonly struct MouseXDecayBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "MouseYMode")]
    public readonly struct MouseYModeBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "MouseYDecay")]
    public readonly struct MouseYDecayBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "Primary")]
    public readonly struct Primary
    {
        [XmlAttribute(AttributeName = "Device")]
        public string Device { get; }

        [XmlAttribute(AttributeName = "Key")]
        public string Key { get; }

        [XmlElement(ElementName = "Modifier")]
        public List<Modifier> Modifier { get; }
    }

    [XmlRoot(ElementName = "Secondary")]
    public readonly struct Secondary
    {
        [XmlAttribute(AttributeName = "Device")]
        public string Device { get; }

        [XmlAttribute(AttributeName = "Key")]
        public string Key { get; }

        [XmlElement(ElementName = "Modifier")]
        public List<Modifier> Modifier { get; }
    }

    [XmlRoot(ElementName = "MouseReset")]
    public readonly struct MouseResetBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "MouseSensitivity")]
    public readonly struct MouseSensitivityBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public double Value { get; }
    }

    [XmlRoot(ElementName = "MouseDecayRate")]
    public readonly struct MouseDecayRateBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public double Value { get; }
    }

    [XmlRoot(ElementName = "MouseDeadzone")]
    public readonly struct MouseDeadzoneBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public double Value { get; }
    }

    [XmlRoot(ElementName = "MouseLinearity")]
    public readonly struct MouseLinearityBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public double Value { get; }
    }

    [XmlRoot(ElementName = "MouseGUI")]
    public readonly struct MouseGUIBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "Binding")]
    public readonly struct Binding
    {
        [XmlAttribute(AttributeName = "Device")]
        public string Device { get; }

        [XmlAttribute(AttributeName = "Key")]
        public string Key { get; }
    }

    [XmlRoot(ElementName = "Inverted")]
    public readonly struct Inverted
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "Deadzone")]
    public readonly struct Deadzone
    {
        [XmlAttribute(AttributeName = "Value")]
        public double Value { get; }
    }

    [XmlRoot(ElementName = "YawAxisRaw")]
    public readonly struct YawAxisRawBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "YawLeftButton")]
    public readonly struct YawLeftButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "YawRightButton")]
    public readonly struct YawRightButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "YawToRollMode")]
    public readonly struct YawToRollModeBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; }
    }

    [XmlRoot(ElementName = "YawToRollSensitivity")]
    public readonly struct YawToRollSensitivityBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public double Value { get; }
    }

    [XmlRoot(ElementName = "YawToRollMode_FAOff")]
    public readonly struct YawToRollModeFAOffBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "ToggleOn")]
    public readonly struct ToggleOn
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "YawToRollButton")]
    public readonly struct YawToRollButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }

        [XmlElement(ElementName = "ToggleOn")]
        public ToggleOn ToggleOn { get; }
    }

    [XmlRoot(ElementName = "RollAxisRaw")]
    public readonly struct RollAxisRawBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "RollLeftButton")]
    public readonly struct RollLeftButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "RollRightButton")]
    public readonly struct RollRightButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "PitchAxisRaw")]
    public readonly struct PitchAxisRawBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "PitchUpButton")]
    public readonly struct PitchUpButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "PitchDownButton")]
    public readonly struct PitchDownButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "LateralThrustRaw")]
    public readonly struct LateralThrustRawBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "Modifier")]
    public readonly struct Modifier
    {
        [XmlAttribute(AttributeName = "Device")]
        public string Device { get; }

        [XmlAttribute(AttributeName = "Key")]
        public string Key { get; }
    }

    [XmlRoot(ElementName = "LeftThrustButton")]
    public readonly struct LeftThrustButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "RightThrustButton")]
    public readonly struct RightThrustButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "VerticalThrustRaw")]
    public readonly struct VerticalThrustRawBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "UpThrustButton")]
    public readonly struct UpThrustButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "DownThrustButton")]
    public readonly struct DownThrustButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "AheadThrust")]
    public readonly struct AheadThrustBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "ForwardThrustButton")]
    public readonly struct ForwardThrustButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "BackwardThrustButton")]
    public readonly struct BackwardThrustButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "UseAlternateFlightValuesToggle")]
    public readonly struct UseAlternateFlightValuesToggleBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }

        [XmlElement(ElementName = "ToggleOn")]
        public ToggleOn ToggleOn { get; }
    }

    [XmlRoot(ElementName = "YawAxisAlternate")]
    public readonly struct YawAxisAlternateBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "RollAxisAlternate")]
    public readonly struct RollAxisAlternateBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "PitchAxisAlternate")]
    public readonly struct PitchAxisAlternateBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "LateralThrustAlternate")]
    public readonly struct LateralThrustAlternateBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "VerticalThrustAlternate")]
    public readonly struct VerticalThrustAlternateBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "ThrottleAxis")]
    public readonly struct ThrottleAxisBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "ThrottleRange")]
    public readonly struct ThrottleRangeBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "ToggleReverseThrottleInput")]
    public readonly struct ToggleReverseThrottleInputBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }

        [XmlElement(ElementName = "ToggleOn")]
        public ToggleOn ToggleOn { get; }
    }

    [XmlRoot(ElementName = "ForwardKey")]
    public readonly struct ForwardKeyBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "BackwardKey")]
    public readonly struct BackwardKeyBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ThrottleIncrement")]
    public readonly struct ThrottleIncrementBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public double Value { get; }
    }

    [XmlRoot(ElementName = "SetSpeedMinus100")]
    public readonly struct SetSpeedMinus100Binding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "SetSpeedMinus75")]
    public readonly struct SetSpeedMinus75Binding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "SetSpeedMinus50")]
    public readonly struct SetSpeedMinus50Binding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "SetSpeedMinus25")]
    public readonly struct SetSpeedMinus25Binding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "SetSpeedZero")]
    public readonly struct SetSpeedZeroBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "SetSpeed25")]
    public readonly struct SetSpeed25Binding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "SetSpeed50")]
    public readonly struct SetSpeed50Binding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "SetSpeed75")]
    public readonly struct SetSpeed75Binding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "SetSpeed100")]
    public readonly struct SetSpeed100Binding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "YawAxis_Landing")]
    public readonly struct YawAxisLandingBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "YawLeftButton_Landing")]
    public readonly struct YawLeftButtonLandingBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "YawRightButton_Landing")]
    public readonly struct YawRightButtonLandingBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "YawToRollMode_Landing")]
    public readonly struct YawToRollModeLandingBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "PitchAxis_Landing")]
    public readonly struct PitchAxisLandingBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "PitchUpButton_Landing")]
    public readonly struct PitchUpButtonLandingBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "PitchDownButton_Landing")]
    public readonly struct PitchDownButtonLandingBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "RollAxis_Landing")]
    public readonly struct RollAxisLandingBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "RollLeftButton_Landing")]
    public readonly struct RollLeftButtonLandingBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "RollRightButton_Landing")]
    public readonly struct RollRightButtonLandingBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "LateralThrust_Landing")]
    public readonly struct LateralThrustLandingBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "LeftThrustButton_Landing")]
    public readonly struct LeftThrustButtonLandingBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "RightThrustButton_Landing")]
    public readonly struct RightThrustButtonLandingBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "VerticalThrust_Landing")]
    public readonly struct VerticalThrustLandingBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "UpThrustButton_Landing")]
    public readonly struct UpThrustButtonLandingBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "DownThrustButton_Landing")]
    public readonly struct DownThrustButtonLandingBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "AheadThrust_Landing")]
    public readonly struct AheadThrustLandingBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "ForwardThrustButton_Landing")]
    public readonly struct ForwardThrustButtonLandingBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "BackwardThrustButton_Landing")]
    public readonly struct BackwardThrustButtonLandingBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ToggleFlightAssist")]
    public readonly struct ToggleFlightAssistBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }

        [XmlElement(ElementName = "ToggleOn")]
        public ToggleOn ToggleOn { get; }
    }

    [XmlRoot(ElementName = "UseBoostJuice")]
    public readonly struct UseBoostJuiceBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HyperSuperCombination")]
    public readonly struct HyperSuperCombinationBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "Supercruise")]
    public readonly struct SupercruiseBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "Hyperspace")]
    public readonly struct HyperspaceBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "DisableRotationCorrectToggle")]
    public readonly struct DisableRotationCorrectToggleBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }

        [XmlElement(ElementName = "ToggleOn")]
        public ToggleOn ToggleOn { get; }
    }

    [XmlRoot(ElementName = "OrbitLinesToggle")]
    public readonly struct OrbitLinesToggleBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "SelectTarget")]
    public readonly struct SelectTargetBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "CycleNextTarget")]
    public readonly struct CycleNextTargetBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "CyclePreviousTarget")]
    public readonly struct CyclePreviousTargetBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "SelectHighestThreat")]
    public readonly struct SelectHighestThreatBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "CycleNextHostileTarget")]
    public readonly struct CycleNextHostileTargetBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "CyclePreviousHostileTarget")]
    public readonly struct CyclePreviousHostileTargetBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "TargetWingman0")]
    public readonly struct TargetWingman0Binding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "TargetWingman1")]
    public readonly struct TargetWingman1Binding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "TargetWingman2")]
    public readonly struct TargetWingman2Binding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "SelectTargetsTarget")]
    public readonly struct SelectTargetsTargetBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "WingNavLock")]
    public readonly struct WingNavLockBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "CycleNextSubsystem")]
    public readonly struct CycleNextSubsystemBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "CyclePreviousSubsystem")]
    public readonly struct CyclePreviousSubsystemBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "TargetNextRouteSystem")]
    public readonly struct TargetNextRouteSystemBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "PrimaryFire")]
    public readonly struct PrimaryFireBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "SecondaryFire")]
    public readonly struct SecondaryFireBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "CycleFireGroupNext")]
    public readonly struct CycleFireGroupNextBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "CycleFireGroupPrevious")]
    public readonly struct CycleFireGroupPreviousBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "DeployHardpointToggle")]
    public readonly struct DeployHardpointToggleBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "DeployHardpointsOnFire")]
    public readonly struct DeployHardpointsOnFireBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "ToggleButtonUpInput")]
    public readonly struct ToggleButtonUpInputBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }

        [XmlElement(ElementName = "ToggleOn")]
        public ToggleOn ToggleOn { get; }
    }

    [XmlRoot(ElementName = "DeployHeatSink")]
    public readonly struct DeployHeatSinkBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ShipSpotLightToggle")]
    public readonly struct ShipSpotLightToggleBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "RadarRangeAxis")]
    public readonly struct RadarRangeAxisBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "RadarIncreaseRange")]
    public readonly struct RadarIncreaseRangeBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "RadarDecreaseRange")]
    public readonly struct RadarDecreaseRangeBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "IncreaseEnginesPower")]
    public readonly struct IncreaseEnginesPowerBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "IncreaseWeaponsPower")]
    public readonly struct IncreaseWeaponsPowerBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "IncreaseSystemsPower")]
    public readonly struct IncreaseSystemsPowerBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ResetPowerDistribution")]
    public readonly struct ResetPowerDistributionBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HMDReset")]
    public readonly struct HMDResetBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ToggleCargoScoop")]
    public readonly struct ToggleCargoScoopBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }

        [XmlElement(ElementName = "ToggleOn")]
        public ToggleOn ToggleOn { get; }
    }

    [XmlRoot(ElementName = "EjectAllCargo")]
    public readonly struct EjectAllCargoBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "LandingGearToggle")]
    public readonly struct LandingGearToggleBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "MicrophoneMute")]
    public readonly struct MicrophoneMuteBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }

        [XmlElement(ElementName = "ToggleOn")]
        public ToggleOn ToggleOn { get; }
    }

    [XmlRoot(ElementName = "MuteButtonMode")]
    public readonly struct MuteButtonModeBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; }
    }

    [XmlRoot(ElementName = "CqcMuteButtonMode")]
    public readonly struct CqcMuteButtonModeBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; }
    }

    [XmlRoot(ElementName = "UseShieldCell")]
    public readonly struct UseShieldCellBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "FireChaffLauncher")]
    public readonly struct FireChaffLauncherBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ChargeECM")]
    public readonly struct ChargeECMBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "EnableRumbleTrigger")]
    public readonly struct EnableRumbleTriggerBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "EnableMenuGroups")]
    public readonly struct EnableMenuGroupsBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "WeaponColourToggle")]
    public readonly struct WeaponColourToggleBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "EngineColourToggle")]
    public readonly struct EngineColourToggleBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "NightVisionToggle")]
    public readonly struct NightVisionToggleBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "UIFocus")]
    public readonly struct UIFocusBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "UIFocusMode")]
    public readonly struct UIFocusModeBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; }
    }

    [XmlRoot(ElementName = "FocusLeftPanel")]
    public readonly struct FocusLeftPanelBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "FocusCommsPanel")]
    public readonly struct FocusCommsPanelBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "FocusOnTextEntryField")]
    public readonly struct FocusOnTextEntryFieldBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "QuickCommsPanel")]
    public readonly struct QuickCommsPanelBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "FocusRadarPanel")]
    public readonly struct FocusRadarPanelBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "FocusRightPanel")]
    public readonly struct FocusRightPanelBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "LeftPanelFocusOptions")]
    public readonly struct LeftPanelFocusOptionsBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; }
    }

    [XmlRoot(ElementName = "CommsPanelFocusOptions")]
    public readonly struct CommsPanelFocusOptionsBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; }
    }

    [XmlRoot(ElementName = "RolePanelFocusOptions")]
    public readonly struct RolePanelFocusOptionsBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; }
    }

    [XmlRoot(ElementName = "RightPanelFocusOptions")]
    public readonly struct RightPanelFocusOptionsBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; }
    }

    [XmlRoot(ElementName = "EnableCameraLockOn")]
    public readonly struct EnableCameraLockOnBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "GalaxyMapOpen")]
    public readonly struct GalaxyMapOpenBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "SystemMapOpen")]
    public readonly struct SystemMapOpenBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ShowPGScoreSummaryInput")]
    public readonly struct ShowPGScoreSummaryInputBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }

        [XmlElement(ElementName = "ToggleOn")]
        public ToggleOn ToggleOn { get; }
    }

    [XmlRoot(ElementName = "HeadLookToggle")]
    public readonly struct HeadLookToggleBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }

        [XmlElement(ElementName = "ToggleOn")]
        public ToggleOn ToggleOn { get; }
    }

    [XmlRoot(ElementName = "Pause")]
    public readonly struct PauseBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "FriendsMenu")]
    public readonly struct FriendsMenuBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "OpenCodexGoToDiscovery")]
    public readonly struct OpenCodexGoToDiscoveryBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "PlayerHUDModeToggle")]
    public readonly struct PlayerHUDModeToggleBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ExplorationFSSEnter")]
    public readonly struct ExplorationFSSEnterBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "UI_Up")]
    public readonly struct UIUpBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "UI_Down")]
    public readonly struct UIDownBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "UI_Left")]
    public readonly struct UILeftBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "UI_Right")]
    public readonly struct UIRightBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "UI_Select")]
    public readonly struct UISelectBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "UI_Back")]
    public readonly struct UIBackBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "UI_Toggle")]
    public readonly struct UIToggleBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "CycleNextPanel")]
    public readonly struct CycleNextPanelBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "CyclePreviousPanel")]
    public readonly struct CyclePreviousPanelBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "CycleNextPage")]
    public readonly struct CycleNextPageBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "CyclePreviousPage")]
    public readonly struct CyclePreviousPageBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "MouseHeadlook")]
    public readonly struct MouseHeadlookBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "MouseHeadlookInvert")]
    public readonly struct MouseHeadlookInvertBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "MouseHeadlookSensitivity")]
    public readonly struct MouseHeadlookSensitivityBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public double Value { get; }
    }

    [XmlRoot(ElementName = "HeadlookDefault")]
    public readonly struct HeadlookDefaultBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "HeadlookIncrement")]
    public readonly struct HeadlookIncrementBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public double Value { get; }
    }

    [XmlRoot(ElementName = "HeadlookMode")]
    public readonly struct HeadlookModeBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; }
    }

    [XmlRoot(ElementName = "HeadlookResetOnToggle")]
    public readonly struct HeadlookResetOnToggleBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "HeadlookSensitivity")]
    public readonly struct HeadlookSensitivityBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public double Value { get; }
    }

    [XmlRoot(ElementName = "HeadlookSmoothing")]
    public readonly struct HeadlookSmoothingBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "HeadLookReset")]
    public readonly struct HeadLookResetBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HeadLookPitchUp")]
    public readonly struct HeadLookPitchUpBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HeadLookPitchDown")]
    public readonly struct HeadLookPitchDownBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HeadLookPitchAxisRaw")]
    public readonly struct HeadLookPitchAxisRawBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "HeadLookYawLeft")]
    public readonly struct HeadLookYawLeftBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HeadLookYawRight")]
    public readonly struct HeadLookYawRightBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HeadLookYawAxis")]
    public readonly struct HeadLookYawAxisBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "MotionHeadlook")]
    public readonly struct MotionHeadlookBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "HeadlookMotionSensitivity")]
    public readonly struct HeadlookMotionSensitivityBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public double Value { get; }
    }

    [XmlRoot(ElementName = "yawRotateHeadlook")]
    public readonly struct YawRotateHeadlookBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "CamPitchAxis")]
    public readonly struct CamPitchAxisBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "CamPitchUp")]
    public readonly struct CamPitchUpBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "CamPitchDown")]
    public readonly struct CamPitchDownBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "CamYawAxis")]
    public readonly struct CamYawAxisBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "CamYawLeft")]
    public readonly struct CamYawLeftBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "CamYawRight")]
    public readonly struct CamYawRightBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "CamTranslateYAxis")]
    public readonly struct CamTranslateYAxisBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "CamTranslateForward")]
    public readonly struct CamTranslateForwardBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "CamTranslateBackward")]
    public readonly struct CamTranslateBackwardBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "CamTranslateXAxis")]
    public readonly struct CamTranslateXAxisBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "CamTranslateLeft")]
    public readonly struct CamTranslateLeftBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "CamTranslateRight")]
    public readonly struct CamTranslateRightBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "CamTranslateZAxis")]
    public readonly struct CamTranslateZAxisBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "CamTranslateUp")]
    public readonly struct CamTranslateUpBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "CamTranslateDown")]
    public readonly struct CamTranslateDownBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "CamZoomAxis")]
    public readonly struct CamZoomAxisBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "CamZoomIn")]
    public readonly struct CamZoomInBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "CamZoomOut")]
    public readonly struct CamZoomOutBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "CamTranslateZHold")]
    public readonly struct CamTranslateZHoldBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }

        [XmlElement(ElementName = "ToggleOn")]
        public ToggleOn ToggleOn { get; }
    }

    [XmlRoot(ElementName = "GalaxyMapHome")]
    public readonly struct GalaxyMapHomeBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ToggleDriveAssist")]
    public readonly struct ToggleDriveAssistBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }

        [XmlElement(ElementName = "ToggleOn")]
        public ToggleOn ToggleOn { get; }
    }

    [XmlRoot(ElementName = "DriveAssistDefault")]
    public readonly struct DriveAssistDefaultBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "MouseBuggySteeringXMode")]
    public readonly struct MouseBuggySteeringXModeBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "MouseBuggySteeringXDecay")]
    public readonly struct MouseBuggySteeringXDecayBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "MouseBuggyRollingXMode")]
    public readonly struct MouseBuggyRollingXModeBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "MouseBuggyRollingXDecay")]
    public readonly struct MouseBuggyRollingXDecayBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "MouseBuggyYMode")]
    public readonly struct MouseBuggyYModeBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "MouseBuggyYDecay")]
    public readonly struct MouseBuggyYDecayBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "SteeringAxis")]
    public readonly struct SteeringAxisBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "SteerLeftButton")]
    public readonly struct SteerLeftButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "SteerRightButton")]
    public readonly struct SteerRightButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "BuggyRollAxisRaw")]
    public readonly struct BuggyRollAxisRawBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "BuggyRollLeftButton")]
    public readonly struct BuggyRollLeftButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "BuggyRollRightButton")]
    public readonly struct BuggyRollRightButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "BuggyPitchAxis")]
    public readonly struct BuggyPitchAxisBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "BuggyPitchUpButton")]
    public readonly struct BuggyPitchUpButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "BuggyPitchDownButton")]
    public readonly struct BuggyPitchDownButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "VerticalThrustersButton")]
    public readonly struct VerticalThrustersButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }

        [XmlElement(ElementName = "ToggleOn")]
        public ToggleOn ToggleOn { get; }
    }

    [XmlRoot(ElementName = "BuggyPrimaryFireButton")]
    public readonly struct BuggyPrimaryFireButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "BuggySecondaryFireButton")]
    public readonly struct BuggySecondaryFireButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "AutoBreakBuggyButton")]
    public readonly struct AutoBreakBuggyButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }

        [XmlElement(ElementName = "ToggleOn")]
        public ToggleOn ToggleOn { get; }
    }

    [XmlRoot(ElementName = "HeadlightsBuggyButton")]
    public readonly struct HeadlightsBuggyButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ToggleBuggyTurretButton")]
    public readonly struct ToggleBuggyTurretButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "BuggyCycleFireGroupNext")]
    public readonly struct BuggyCycleFireGroupNextBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "BuggyCycleFireGroupPrevious")]
    public readonly struct BuggyCycleFireGroupPreviousBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "SelectTarget_Buggy")]
    public readonly struct SelectTargetBuggyBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "MouseTurretXMode")]
    public readonly struct MouseTurretXModeBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "MouseTurretXDecay")]
    public readonly struct MouseTurretXDecayBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "MouseTurretYMode")]
    public readonly struct MouseTurretYModeBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "MouseTurretYDecay")]
    public readonly struct MouseTurretYDecayBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "BuggyTurretYawAxisRaw")]
    public readonly struct BuggyTurretYawAxisRawBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "BuggyTurretYawLeftButton")]
    public readonly struct BuggyTurretYawLeftButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "BuggyTurretYawRightButton")]
    public readonly struct BuggyTurretYawRightButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "BuggyTurretPitchAxisRaw")]
    public readonly struct BuggyTurretPitchAxisRawBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "BuggyTurretPitchUpButton")]
    public readonly struct BuggyTurretPitchUpButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "BuggyTurretPitchDownButton")]
    public readonly struct BuggyTurretPitchDownButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "BuggyTurretMouseSensitivity")]
    public readonly struct BuggyTurretMouseSensitivityBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public double Value { get; }
    }

    [XmlRoot(ElementName = "BuggyTurretMouseDeadzone")]
    public readonly struct BuggyTurretMouseDeadzoneBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public double Value { get; }
    }

    [XmlRoot(ElementName = "BuggyTurretMouseLinearity")]
    public readonly struct BuggyTurretMouseLinearityBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public double Value { get; }
    }

    [XmlRoot(ElementName = "DriveSpeedAxis")]
    public readonly struct DriveSpeedAxisBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "BuggyThrottleRange")]
    public readonly struct BuggyThrottleRangeBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "BuggyToggleReverseThrottleInput")]
    public readonly struct BuggyToggleReverseThrottleInputBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }

        [XmlElement(ElementName = "ToggleOn")]
        public ToggleOn ToggleOn { get; }
    }

    [XmlRoot(ElementName = "BuggyThrottleIncrement")]
    public readonly struct BuggyThrottleIncrementBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public double Value { get; }
    }

    [XmlRoot(ElementName = "IncreaseSpeedButtonMax")]
    public readonly struct IncreaseSpeedButtonMaxBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "DecreaseSpeedButtonMax")]
    public readonly struct DecreaseSpeedButtonMaxBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "IncreaseSpeedButtonPartial")]
    public readonly struct IncreaseSpeedButtonPartialBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "DecreaseSpeedButtonPartial")]
    public readonly struct DecreaseSpeedButtonPartialBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "IncreaseEnginesPower_Buggy")]
    public readonly struct IncreaseEnginesPowerBuggyBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "IncreaseWeaponsPower_Buggy")]
    public readonly struct IncreaseWeaponsPowerBuggyBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "IncreaseSystemsPower_Buggy")]
    public readonly struct IncreaseSystemsPowerBuggyBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ResetPowerDistribution_Buggy")]
    public readonly struct ResetPowerDistributionBuggyBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ToggleCargoScoop_Buggy")]
    public readonly struct ToggleCargoScoopBuggyBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }

        [XmlElement(ElementName = "ToggleOn")]
        public ToggleOn ToggleOn { get; }
    }

    [XmlRoot(ElementName = "EjectAllCargo_Buggy")]
    public readonly struct EjectAllCargoBuggyBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "RecallDismissShip")]
    public readonly struct RecallDismissShipBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "EnableMenuGroupsSRV")]
    public readonly struct EnableMenuGroupsSRVBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "UIFocus_Buggy")]
    public readonly struct UIFocusBuggyBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "FocusLeftPanel_Buggy")]
    public readonly struct FocusLeftPanelBuggyBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "FocusCommsPanel_Buggy")]
    public readonly struct FocusCommsPanelBuggyBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "QuickCommsPanel_Buggy")]
    public readonly struct QuickCommsPanelBuggyBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "FocusRadarPanel_Buggy")]
    public readonly struct FocusRadarPanelBuggyBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "FocusRightPanel_Buggy")]
    public readonly struct FocusRightPanelBuggyBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "GalaxyMapOpen_Buggy")]
    public readonly struct GalaxyMapOpenBuggyBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "SystemMapOpen_Buggy")]
    public readonly struct SystemMapOpenBuggyBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "OpenCodexGoToDiscovery_Buggy")]
    public readonly struct OpenCodexGoToDiscoveryBuggyBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "PlayerHUDModeToggle_Buggy")]
    public readonly struct PlayerHUDModeToggleBuggyBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HeadLookToggle_Buggy")]
    public readonly struct HeadLookToggleBuggyBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }

        [XmlElement(ElementName = "ToggleOn")]
        public ToggleOn ToggleOn { get; }
    }

    [XmlRoot(ElementName = "MultiCrewToggleMode")]
    public readonly struct MultiCrewToggleModeBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "MultiCrewPrimaryFire")]
    public readonly struct MultiCrewPrimaryFireBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "MultiCrewSecondaryFire")]
    public readonly struct MultiCrewSecondaryFireBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "MultiCrewPrimaryUtilityFire")]
    public readonly struct MultiCrewPrimaryUtilityFireBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "MultiCrewSecondaryUtilityFire")]
    public readonly struct MultiCrewSecondaryUtilityFireBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "MultiCrewThirdPersonMouseXMode")]
    public readonly struct MultiCrewThirdPersonMouseXModeBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "MultiCrewThirdPersonMouseXDecay")]
    public readonly struct MultiCrewThirdPersonMouseXDecayBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "MultiCrewThirdPersonMouseYMode")]
    public readonly struct MultiCrewThirdPersonMouseYModeBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "MultiCrewThirdPersonMouseYDecay")]
    public readonly struct MultiCrewThirdPersonMouseYDecayBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "MultiCrewThirdPersonYawAxisRaw")]
    public readonly struct MultiCrewThirdPersonYawAxisRawBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "MultiCrewThirdPersonYawLeftButton")]
    public readonly struct MultiCrewThirdPersonYawLeftButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "MultiCrewThirdPersonYawRightButton")]
    public readonly struct MultiCrewThirdPersonYawRightButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "MultiCrewThirdPersonPitchAxisRaw")]
    public readonly struct MultiCrewThirdPersonPitchAxisRawBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "MultiCrewThirdPersonPitchUpButton")]
    public readonly struct MultiCrewThirdPersonPitchUpButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "MultiCrewThirdPersonPitchDownButton")]
    public readonly struct MultiCrewThirdPersonPitchDownButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "MultiCrewThirdPersonMouseSensitivity")]
    public readonly struct MultiCrewThirdPersonMouseSensitivityBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public double Value { get; }
    }

    [XmlRoot(ElementName = "MultiCrewThirdPersonFovAxisRaw")]
    public readonly struct MultiCrewThirdPersonFovAxisRawBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "MultiCrewThirdPersonFovOutButton")]
    public readonly struct MultiCrewThirdPersonFovOutButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "MultiCrewThirdPersonFovInButton")]
    public readonly struct MultiCrewThirdPersonFovInButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "MultiCrewCockpitUICycleForward")]
    public readonly struct MultiCrewCockpitUICycleForwardBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "MultiCrewCockpitUICycleBackward")]
    public readonly struct MultiCrewCockpitUICycleBackwardBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "OrderRequestDock")]
    public readonly struct OrderRequestDockBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "OrderDefensiveBehaviour")]
    public readonly struct OrderDefensiveBehaviourBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "OrderAggressiveBehaviour")]
    public readonly struct OrderAggressiveBehaviourBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "OrderFocusTarget")]
    public readonly struct OrderFocusTargetBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "OrderHoldFire")]
    public readonly struct OrderHoldFireBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "OrderHoldPosition")]
    public readonly struct OrderHoldPositionBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "OrderFollow")]
    public readonly struct OrderFollowBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "OpenOrders")]
    public readonly struct OpenOrdersBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "PhotoCameraToggle")]
    public readonly struct PhotoCameraToggleBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "PhotoCameraToggle_Buggy")]
    public readonly struct PhotoCameraToggleBuggyBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "PhotoCameraToggle_Humanoid")]
    public readonly struct PhotoCameraToggleHumanoidBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "VanityCameraScrollLeft")]
    public readonly struct VanityCameraScrollLeftBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "VanityCameraScrollRight")]
    public readonly struct VanityCameraScrollRightBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ToggleFreeCam")]
    public readonly struct ToggleFreeCamBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "VanityCameraOne")]
    public readonly struct VanityCameraOneBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "VanityCameraTwo")]
    public readonly struct VanityCameraTwoBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "VanityCameraThree")]
    public readonly struct VanityCameraThreeBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "VanityCameraFour")]
    public readonly struct VanityCameraFourBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "VanityCameraFive")]
    public readonly struct VanityCameraFiveBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "VanityCameraSix")]
    public readonly struct VanityCameraSixBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "VanityCameraSeven")]
    public readonly struct VanityCameraSevenBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "VanityCameraEight")]
    public readonly struct VanityCameraEightBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "VanityCameraNine")]
    public readonly struct VanityCameraNineBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "VanityCameraTen")]
    public readonly struct VanityCameraTenBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "FreeCamToggleHUD")]
    public readonly struct FreeCamToggleHUDBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "FreeCamSpeedInc")]
    public readonly struct FreeCamSpeedIncBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "FreeCamSpeedDec")]
    public readonly struct FreeCamSpeedDecBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "MoveFreeCamY")]
    public readonly struct MoveFreeCamYBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "ThrottleRangeFreeCam")]
    public readonly struct ThrottleRangeFreeCamBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "ToggleReverseThrottleInputFreeCam")]
    public readonly struct ToggleReverseThrottleInputFreeCamBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }

        [XmlElement(ElementName = "ToggleOn")]
        public ToggleOn ToggleOn { get; }
    }

    [XmlRoot(ElementName = "MoveFreeCamForward")]
    public readonly struct MoveFreeCamForwardBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "MoveFreeCamBackwards")]
    public readonly struct MoveFreeCamBackwardsBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "MoveFreeCamX")]
    public readonly struct MoveFreeCamXBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "MoveFreeCamRight")]
    public readonly struct MoveFreeCamRightBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "MoveFreeCamLeft")]
    public readonly struct MoveFreeCamLeftBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "MoveFreeCamZ")]
    public readonly struct MoveFreeCamZBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "MoveFreeCamUpAxis")]
    public readonly struct MoveFreeCamUpAxisBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "MoveFreeCamDownAxis")]
    public readonly struct MoveFreeCamDownAxisBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "MoveFreeCamUp")]
    public readonly struct MoveFreeCamUpBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "MoveFreeCamDown")]
    public readonly struct MoveFreeCamDownBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "PitchCameraMouse")]
    public readonly struct PitchCameraMouseBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "YawCameraMouse")]
    public readonly struct YawCameraMouseBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "PitchCamera")]
    public readonly struct PitchCameraBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "FreeCamMouseSensitivity")]
    public readonly struct FreeCamMouseSensitivityBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public double Value { get; }
    }

    [XmlRoot(ElementName = "FreeCamMouseYDecay")]
    public readonly struct FreeCamMouseYDecayBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "PitchCameraUp")]
    public readonly struct PitchCameraUpBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "PitchCameraDown")]
    public readonly struct PitchCameraDownBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "YawCamera")]
    public readonly struct YawCameraBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "FreeCamMouseXDecay")]
    public readonly struct FreeCamMouseXDecayBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "YawCameraLeft")]
    public readonly struct YawCameraLeftBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "YawCameraRight")]
    public readonly struct YawCameraRightBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "RollCamera")]
    public readonly struct RollCameraBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "RollCameraLeft")]
    public readonly struct RollCameraLeftBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "RollCameraRight")]
    public readonly struct RollCameraRightBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ToggleRotationLock")]
    public readonly struct ToggleRotationLockBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "FixCameraRelativeToggle")]
    public readonly struct FixCameraRelativeToggleBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "FixCameraWorldToggle")]
    public readonly struct FixCameraWorldToggleBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "QuitCamera")]
    public readonly struct QuitCameraBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ToggleAdvanceMode")]
    public readonly struct ToggleAdvanceModeBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "FreeCamZoomIn")]
    public readonly struct FreeCamZoomInBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "FreeCamZoomOut")]
    public readonly struct FreeCamZoomOutBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "FStopDec")]
    public readonly struct FStopDecBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "FStopInc")]
    public readonly struct FStopIncBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "CommanderCreator_Undo")]
    public readonly struct CommanderCreatorUndoBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "CommanderCreator_Redo")]
    public readonly struct CommanderCreatorRedoBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "CommanderCreator_Rotation_MouseToggle")]
    public readonly struct CommanderCreatorRotationMouseToggleBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "CommanderCreator_Rotation")]
    public readonly struct CommanderCreatorRotationBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "GalnetAudio_Play_Pause")]
    public readonly struct GalnetAudioPlayPauseBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "GalnetAudio_SkipForward")]
    public readonly struct GalnetAudioSkipForwardBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "GalnetAudio_SkipBackward")]
    public readonly struct GalnetAudioSkipBackwardBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "GalnetAudio_ClearQueue")]
    public readonly struct GalnetAudioClearQueueBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ExplorationFSSCameraPitch")]
    public readonly struct ExplorationFSSCameraPitchBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "ExplorationFSSCameraPitchIncreaseButton")]
    public readonly struct ExplorationFSSCameraPitchIncreaseButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ExplorationFSSCameraPitchDecreaseButton")]
    public readonly struct ExplorationFSSCameraPitchDecreaseButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ExplorationFSSCameraYaw")]
    public readonly struct ExplorationFSSCameraYawBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "ExplorationFSSCameraYawIncreaseButton")]
    public readonly struct ExplorationFSSCameraYawIncreaseButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ExplorationFSSCameraYawDecreaseButton")]
    public readonly struct ExplorationFSSCameraYawDecreaseButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ExplorationFSSZoomIn")]
    public readonly struct ExplorationFSSZoomInBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ExplorationFSSZoomOut")]
    public readonly struct ExplorationFSSZoomOutBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ExplorationFSSMiniZoomIn")]
    public readonly struct ExplorationFSSMiniZoomInBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ExplorationFSSMiniZoomOut")]
    public readonly struct ExplorationFSSMiniZoomOutBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ExplorationFSSRadioTuningX_Raw")]
    public readonly struct ExplorationFSSRadioTuningXRawBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "ExplorationFSSRadioTuningX_Increase")]
    public readonly struct ExplorationFSSRadioTuningXIncreaseBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ExplorationFSSRadioTuningX_Decrease")]
    public readonly struct ExplorationFSSRadioTuningXDecreaseBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ExplorationFSSRadioTuningAbsoluteX")]
    public readonly struct ExplorationFSSRadioTuningAbsoluteXBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "FSSTuningSensitivity")]
    public readonly struct FSSTuningSensitivityBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public double Value { get; }
    }

    [XmlRoot(ElementName = "ExplorationFSSDiscoveryScan")]
    public readonly struct ExplorationFSSDiscoveryScanBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ExplorationFSSQuit")]
    public readonly struct ExplorationFSSQuitBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "FSSMouseXMode")]
    public readonly struct FSSMouseXModeBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "FSSMouseXDecay")]
    public readonly struct FSSMouseXDecayBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "FSSMouseYMode")]
    public readonly struct FSSMouseYModeBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "FSSMouseYDecay")]
    public readonly struct FSSMouseYDecayBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "FSSMouseSensitivity")]
    public readonly struct FSSMouseSensitivityBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public double Value { get; }
    }

    [XmlRoot(ElementName = "FSSMouseDeadzone")]
    public readonly struct FSSMouseDeadzoneBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public double Value { get; }
    }

    [XmlRoot(ElementName = "FSSMouseLinearity")]
    public readonly struct FSSMouseLinearityBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public double Value { get; }
    }

    [XmlRoot(ElementName = "ExplorationFSSTarget")]
    public readonly struct ExplorationFSSTargetBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ExplorationFSSShowHelp")]
    public readonly struct ExplorationFSSShowHelpBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ExplorationSAAChangeScannedAreaViewToggle")]
    public readonly struct ExplorationSAAChangeScannedAreaViewToggleBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }

        [XmlElement(ElementName = "ToggleOn")]
        public ToggleOn ToggleOn { get; }
    }

    [XmlRoot(ElementName = "ExplorationSAAExitThirdPerson")]
    public readonly struct ExplorationSAAExitThirdPersonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ExplorationSAANextGenus")]
    public readonly struct ExplorationSAANextGenusBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "ExplorationSAAPreviousGenus")]
    public readonly struct ExplorationSAAPreviousGenusBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "SAAThirdPersonMouseXMode")]
    public readonly struct SAAThirdPersonMouseXModeBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "SAAThirdPersonMouseXDecay")]
    public readonly struct SAAThirdPersonMouseXDecayBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "SAAThirdPersonMouseYMode")]
    public readonly struct SAAThirdPersonMouseYModeBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "SAAThirdPersonMouseYDecay")]
    public readonly struct SAAThirdPersonMouseYDecayBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "SAAThirdPersonMouseSensitivity")]
    public readonly struct SAAThirdPersonMouseSensitivityBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public double Value { get; }
    }

    [XmlRoot(ElementName = "SAAThirdPersonYawAxisRaw")]
    public readonly struct SAAThirdPersonYawAxisRawBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "SAAThirdPersonYawLeftButton")]
    public readonly struct SAAThirdPersonYawLeftButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "SAAThirdPersonYawRightButton")]
    public readonly struct SAAThirdPersonYawRightButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "SAAThirdPersonPitchAxisRaw")]
    public readonly struct SAAThirdPersonPitchAxisRawBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "SAAThirdPersonPitchUpButton")]
    public readonly struct SAAThirdPersonPitchUpButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "SAAThirdPersonPitchDownButton")]
    public readonly struct SAAThirdPersonPitchDownButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "SAAThirdPersonFovAxisRaw")]
    public readonly struct SAAThirdPersonFovAxisRawBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "SAAThirdPersonFovOutButton")]
    public readonly struct SAAThirdPersonFovOutButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "SAAThirdPersonFovInButton")]
    public readonly struct SAAThirdPersonFovInButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "MouseHumanoidXMode")]
    public readonly struct MouseHumanoidXModeBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "MouseHumanoidYMode")]
    public readonly struct MouseHumanoidYModeBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "MouseHumanoidSensitivity")]
    public readonly struct MouseHumanoidSensitivityBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public double Value { get; }
    }

    [XmlRoot(ElementName = "HumanoidForwardAxis")]
    public readonly struct HumanoidForwardAxisBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "HumanoidForwardButton")]
    public readonly struct HumanoidForwardButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidBackwardButton")]
    public readonly struct HumanoidBackwardButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidStrafeAxis")]
    public readonly struct HumanoidStrafeAxisBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "HumanoidStrafeLeftButton")]
    public readonly struct HumanoidStrafeLeftButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidStrafeRightButton")]
    public readonly struct HumanoidStrafeRightButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidRotateAxis")]
    public readonly struct HumanoidRotateAxisBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "HumanoidRotateSensitivity")]
    public readonly struct HumanoidRotateSensitivityBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public double Value { get; }
    }

    [XmlRoot(ElementName = "HumanoidRotateLeftButton")]
    public readonly struct HumanoidRotateLeftButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidRotateRightButton")]
    public readonly struct HumanoidRotateRightButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidPitchAxis")]
    public readonly struct HumanoidPitchAxisBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "HumanoidPitchSensitivity")]
    public readonly struct HumanoidPitchSensitivityBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public double Value { get; }
    }

    [XmlRoot(ElementName = "HumanoidPitchUpButton")]
    public readonly struct HumanoidPitchUpButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidPitchDownButton")]
    public readonly struct HumanoidPitchDownButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidSprintButton")]
    public readonly struct HumanoidSprintButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }

        [XmlElement(ElementName = "ToggleOn")]
        public ToggleOn ToggleOn { get; }
    }

    [XmlRoot(ElementName = "HumanoidWalkButton")]
    public readonly struct HumanoidWalkButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }

        [XmlElement(ElementName = "ToggleOn")]
        public ToggleOn ToggleOn { get; }
    }

    [XmlRoot(ElementName = "HumanoidCrouchButton")]
    public readonly struct HumanoidCrouchButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }

        [XmlElement(ElementName = "ToggleOn")]
        public ToggleOn ToggleOn { get; }
    }

    [XmlRoot(ElementName = "HumanoidJumpButton")]
    public readonly struct HumanoidJumpButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidPrimaryInteractButton")]
    public readonly struct HumanoidPrimaryInteractButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidSecondaryInteractButton")]
    public readonly struct HumanoidSecondaryInteractButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidItemWheelButton")]
    public readonly struct HumanoidItemWheelButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }

        [XmlElement(ElementName = "ToggleOn")]
        public ToggleOn ToggleOn { get; }
    }

    [XmlRoot(ElementName = "HumanoidEmoteWheelButton")]
    public readonly struct HumanoidEmoteWheelButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }

        [XmlElement(ElementName = "ToggleOn")]
        public ToggleOn ToggleOn { get; }
    }

    [XmlRoot(ElementName = "HumanoidUtilityWheelCycleMode")]
    public readonly struct HumanoidUtilityWheelCycleModeBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidItemWheelButton_XAxis")]
    public readonly struct HumanoidItemWheelButtonXAxisBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "HumanoidItemWheelButton_XLeft")]
    public readonly struct HumanoidItemWheelButtonXLeftBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidItemWheelButton_XRight")]
    public readonly struct HumanoidItemWheelButtonXRightBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidItemWheelButton_YAxis")]
    public readonly struct HumanoidItemWheelButtonYAxisBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "HumanoidItemWheelButton_YUp")]
    public readonly struct HumanoidItemWheelButtonYUpBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidItemWheelButton_YDown")]
    public readonly struct HumanoidItemWheelButtonYDownBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidItemWheel_AcceptMouseInput")]
    public readonly struct HumanoidItemWheelAcceptMouseInputBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "HumanoidPrimaryFireButton")]
    public readonly struct HumanoidPrimaryFireButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidZoomButton")]
    public readonly struct HumanoidZoomButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }

        [XmlElement(ElementName = "ToggleOn")]
        public ToggleOn ToggleOn { get; }
    }

    [XmlRoot(ElementName = "HumanoidThrowGrenadeButton")]
    public readonly struct HumanoidThrowGrenadeButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidMeleeButton")]
    public readonly struct HumanoidMeleeButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidReloadButton")]
    public readonly struct HumanoidReloadButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidSwitchWeapon")]
    public readonly struct HumanoidSwitchWeaponBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidSelectPrimaryWeaponButton")]
    public readonly struct HumanoidSelectPrimaryWeaponButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidSelectSecondaryWeaponButton")]
    public readonly struct HumanoidSelectSecondaryWeaponButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidSelectUtilityWeaponButton")]
    public readonly struct HumanoidSelectUtilityWeaponButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidSelectNextWeaponButton")]
    public readonly struct HumanoidSelectNextWeaponButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidSelectPreviousWeaponButton")]
    public readonly struct HumanoidSelectPreviousWeaponButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidHideWeaponButton")]
    public readonly struct HumanoidHideWeaponButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidSelectNextGrenadeTypeButton")]
    public readonly struct HumanoidSelectNextGrenadeTypeButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidSelectPreviousGrenadeTypeButton")]
    public readonly struct HumanoidSelectPreviousGrenadeTypeButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidToggleFlashlightButton")]
    public readonly struct HumanoidToggleFlashlightButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidToggleNightVisionButton")]
    public readonly struct HumanoidToggleNightVisionButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidToggleShieldsButton")]
    public readonly struct HumanoidToggleShieldsButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidClearAuthorityLevel")]
    public readonly struct HumanoidClearAuthorityLevelBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidHealthPack")]
    public readonly struct HumanoidHealthPackBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidBattery")]
    public readonly struct HumanoidBatteryBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidSelectFragGrenade")]
    public readonly struct HumanoidSelectFragGrenadeBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidSelectEMPGrenade")]
    public readonly struct HumanoidSelectEMPGrenadeBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidSelectShieldGrenade")]
    public readonly struct HumanoidSelectShieldGrenadeBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidSwitchToRechargeTool")]
    public readonly struct HumanoidSwitchToRechargeToolBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidSwitchToCompAnalyser")]
    public readonly struct HumanoidSwitchToCompAnalyserBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidSwitchToSuitTool")]
    public readonly struct HumanoidSwitchToSuitToolBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidToggleToolModeButton")]
    public readonly struct HumanoidToggleToolModeButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidToggleMissionHelpPanelButton")]
    public readonly struct HumanoidToggleMissionHelpPanelButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidPing")]
    public readonly struct HumanoidPingBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "GalaxyMapOpen_Humanoid")]
    public readonly struct GalaxyMapOpenHumanoidBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "SystemMapOpen_Humanoid")]
    public readonly struct SystemMapOpenHumanoidBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "FocusCommsPanel_Humanoid")]
    public readonly struct FocusCommsPanelHumanoidBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "QuickCommsPanel_Humanoid")]
    public readonly struct QuickCommsPanelHumanoidBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidOpenAccessPanelButton")]
    public readonly struct HumanoidOpenAccessPanelButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidConflictContextualUIButton")]
    public readonly struct HumanoidConflictContextualUIButtonBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "EnableMenuGroupsOnFoot")]
    public readonly struct EnableMenuGroupsOnFootBinding
    {
        [XmlAttribute(AttributeName = "Value")]
        public int Value { get; }
    }

    [XmlRoot(ElementName = "StoreEnableRotation")]
    public readonly struct StoreEnableRotationBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "StorePitchCamera")]
    public readonly struct StorePitchCameraBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "StoreYawCamera")]
    public readonly struct StoreYawCameraBinding
    {
        [XmlElement(ElementName = "Binding")]
        public Binding Binding { get; }

        [XmlElement(ElementName = "Inverted")]
        public Inverted Inverted { get; }

        [XmlElement(ElementName = "Deadzone")]
        public Deadzone Deadzone { get; }
    }

    [XmlRoot(ElementName = "StoreCamZoomIn")]
    public readonly struct StoreCamZoomInBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "StoreCamZoomOut")]
    public readonly struct StoreCamZoomOutBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "StoreToggle")]
    public readonly struct StoreToggleBinding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidEmoteSlot1")]
    public readonly struct HumanoidEmoteSlot1Binding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidEmoteSlot2")]
    public readonly struct HumanoidEmoteSlot2Binding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidEmoteSlot3")]
    public readonly struct HumanoidEmoteSlot3Binding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidEmoteSlot4")]
    public readonly struct HumanoidEmoteSlot4Binding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidEmoteSlot5")]
    public readonly struct HumanoidEmoteSlot5Binding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidEmoteSlot6")]
    public readonly struct HumanoidEmoteSlot6Binding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidEmoteSlot7")]
    public readonly struct HumanoidEmoteSlot7Binding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }

    [XmlRoot(ElementName = "HumanoidEmoteSlot8")]
    public readonly struct HumanoidEmoteSlot8Binding
    {
        [XmlElement(ElementName = "Primary")]
        public Primary Primary { get; }

        [XmlElement(ElementName = "Secondary")]
        public Secondary Secondary { get; }
    }
}