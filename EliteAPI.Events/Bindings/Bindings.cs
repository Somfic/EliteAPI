using System.Xml.Serialization;

namespace EliteAPI.Events.Bindings;

[XmlRoot(ElementName = "MouseXMode")]
public class MouseXMode
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "MouseXDecay")]
public class MouseXDecay
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "MouseYMode")]
public class MouseYMode
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "MouseYDecay")]
public class MouseYDecay
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "Primary")]
public class Primary
{
    [XmlAttribute(AttributeName = "Device")]
    public string Device { get; set; }

    [XmlAttribute(AttributeName = "Key")]
    public string Key { get; set; }

    [XmlElement(ElementName = "Modifier")]
    public List<Modifier> Modifier { get; set; }
}

[XmlRoot(ElementName = "Secondary")]
public class Secondary
{
    [XmlAttribute(AttributeName = "Device")]
    public string Device { get; set; }

    [XmlAttribute(AttributeName = "Key")]
    public string Key { get; set; }

    [XmlElement(ElementName = "Modifier")]
    public List<Modifier> Modifier { get; set; }
}

[XmlRoot(ElementName = "MouseReset")]
public class MouseReset
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "MouseSensitivity")]
public class MouseSensitivity
{
    [XmlAttribute(AttributeName = "Value")]
    public double Value { get; set; }
}

[XmlRoot(ElementName = "MouseDecayRate")]
public class MouseDecayRate
{
    [XmlAttribute(AttributeName = "Value")]
    public double Value { get; set; }
}

[XmlRoot(ElementName = "MouseDeadzone")]
public class MouseDeadzone
{
    [XmlAttribute(AttributeName = "Value")]
    public double Value { get; set; }
}

[XmlRoot(ElementName = "MouseLinearity")]
public class MouseLinearity
{
    [XmlAttribute(AttributeName = "Value")]
    public double Value { get; set; }
}

[XmlRoot(ElementName = "MouseGUI")]
public class MouseGUI
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "Binding")]
public class Binding
{
    [XmlAttribute(AttributeName = "Device")]
    public string Device { get; set; }

    [XmlAttribute(AttributeName = "Key")]
    public string Key { get; set; }
}

[XmlRoot(ElementName = "Inverted")]
public class Inverted
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "Deadzone")]
public class Deadzone
{
    [XmlAttribute(AttributeName = "Value")]
    public double Value { get; set; }
}

[XmlRoot(ElementName = "YawAxisRaw")]
public class YawAxisRaw
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "YawLeftButton")]
public class YawLeftButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "YawRightButton")]
public class YawRightButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "YawToRollMode")]
public class YawToRollMode
{
    [XmlAttribute(AttributeName = "Value")]
    public string Value { get; set; }
}

[XmlRoot(ElementName = "YawToRollSensitivity")]
public class YawToRollSensitivity
{
    [XmlAttribute(AttributeName = "Value")]
    public double Value { get; set; }
}

[XmlRoot(ElementName = "YawToRollMode_FAOff")]
public class YawToRollModeFAOff
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "ToggleOn")]
public class ToggleOn
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "YawToRollButton")]
public class YawToRollButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }

    [XmlElement(ElementName = "ToggleOn")]
    public ToggleOn ToggleOn { get; set; }
}

[XmlRoot(ElementName = "RollAxisRaw")]
public class RollAxisRaw
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "RollLeftButton")]
public class RollLeftButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "RollRightButton")]
public class RollRightButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "PitchAxisRaw")]
public class PitchAxisRaw
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "PitchUpButton")]
public class PitchUpButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "PitchDownButton")]
public class PitchDownButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "LateralThrustRaw")]
public class LateralThrustRaw
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "Modifier")]
public class Modifier
{
    [XmlAttribute(AttributeName = "Device")]
    public string Device { get; set; }

    [XmlAttribute(AttributeName = "Key")]
    public string Key { get; set; }
}

[XmlRoot(ElementName = "LeftThrustButton")]
public class LeftThrustButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "RightThrustButton")]
public class RightThrustButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "VerticalThrustRaw")]
public class VerticalThrustRaw
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "UpThrustButton")]
public class UpThrustButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "DownThrustButton")]
public class DownThrustButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "AheadThrust")]
public class AheadThrust
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "ForwardThrustButton")]
public class ForwardThrustButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "BackwardThrustButton")]
public class BackwardThrustButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "UseAlternateFlightValuesToggle")]
public class UseAlternateFlightValuesToggle
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }

    [XmlElement(ElementName = "ToggleOn")]
    public ToggleOn ToggleOn { get; set; }
}

[XmlRoot(ElementName = "YawAxisAlternate")]
public class YawAxisAlternate
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "RollAxisAlternate")]
public class RollAxisAlternate
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "PitchAxisAlternate")]
public class PitchAxisAlternate
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "LateralThrustAlternate")]
public class LateralThrustAlternate
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "VerticalThrustAlternate")]
public class VerticalThrustAlternate
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "ThrottleAxis")]
public class ThrottleAxis
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "ThrottleRange")]
public class ThrottleRange
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "ToggleReverseThrottleInput")]
public class ToggleReverseThrottleInput
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }

    [XmlElement(ElementName = "ToggleOn")]
    public ToggleOn ToggleOn { get; set; }
}

[XmlRoot(ElementName = "ForwardKey")]
public class ForwardKey
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "BackwardKey")]
public class BackwardKey
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ThrottleIncrement")]
public class ThrottleIncrement
{
    [XmlAttribute(AttributeName = "Value")]
    public double Value { get; set; }
}

[XmlRoot(ElementName = "SetSpeedMinus100")]
public class SetSpeedMinus100
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "SetSpeedMinus75")]
public class SetSpeedMinus75
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "SetSpeedMinus50")]
public class SetSpeedMinus50
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "SetSpeedMinus25")]
public class SetSpeedMinus25
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "SetSpeedZero")]
public class SetSpeedZero
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "SetSpeed25")]
public class SetSpeed25
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "SetSpeed50")]
public class SetSpeed50
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "SetSpeed75")]
public class SetSpeed75
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "SetSpeed100")]
public class SetSpeed100
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "YawAxis_Landing")]
public class YawAxisLanding
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "YawLeftButton_Landing")]
public class YawLeftButtonLanding
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "YawRightButton_Landing")]
public class YawRightButtonLanding
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "YawToRollMode_Landing")]
public class YawToRollModeLanding
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "PitchAxis_Landing")]
public class PitchAxisLanding
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "PitchUpButton_Landing")]
public class PitchUpButtonLanding
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "PitchDownButton_Landing")]
public class PitchDownButtonLanding
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "RollAxis_Landing")]
public class RollAxisLanding
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "RollLeftButton_Landing")]
public class RollLeftButtonLanding
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "RollRightButton_Landing")]
public class RollRightButtonLanding
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "LateralThrust_Landing")]
public class LateralThrustLanding
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "LeftThrustButton_Landing")]
public class LeftThrustButtonLanding
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "RightThrustButton_Landing")]
public class RightThrustButtonLanding
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "VerticalThrust_Landing")]
public class VerticalThrustLanding
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "UpThrustButton_Landing")]
public class UpThrustButtonLanding
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "DownThrustButton_Landing")]
public class DownThrustButtonLanding
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "AheadThrust_Landing")]
public class AheadThrustLanding
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "ForwardThrustButton_Landing")]
public class ForwardThrustButtonLanding
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "BackwardThrustButton_Landing")]
public class BackwardThrustButtonLanding
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ToggleFlightAssist")]
public class ToggleFlightAssist
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }

    [XmlElement(ElementName = "ToggleOn")]
    public ToggleOn ToggleOn { get; set; }
}

[XmlRoot(ElementName = "UseBoostJuice")]
public class UseBoostJuice
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HyperSuperCombination")]
public class HyperSuperCombination
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "Supercruise")]
public class Supercruise
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "Hyperspace")]
public class Hyperspace
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "DisableRotationCorrectToggle")]
public class DisableRotationCorrectToggle
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }

    [XmlElement(ElementName = "ToggleOn")]
    public ToggleOn ToggleOn { get; set; }
}

[XmlRoot(ElementName = "OrbitLinesToggle")]
public class OrbitLinesToggle
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "SelectTarget")]
public class SelectTarget
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "CycleNextTarget")]
public class CycleNextTarget
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "CyclePreviousTarget")]
public class CyclePreviousTarget
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "SelectHighestThreat")]
public class SelectHighestThreat
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "CycleNextHostileTarget")]
public class CycleNextHostileTarget
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "CyclePreviousHostileTarget")]
public class CyclePreviousHostileTarget
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "TargetWingman0")]
public class TargetWingman0
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "TargetWingman1")]
public class TargetWingman1
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "TargetWingman2")]
public class TargetWingman2
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "SelectTargetsTarget")]
public class SelectTargetsTarget
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "WingNavLock")]
public class WingNavLock
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "CycleNextSubsystem")]
public class CycleNextSubsystem
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "CyclePreviousSubsystem")]
public class CyclePreviousSubsystem
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "TargetNextRouteSystem")]
public class TargetNextRouteSystem
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "PrimaryFire")]
public class PrimaryFire
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "SecondaryFire")]
public class SecondaryFire
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "CycleFireGroupNext")]
public class CycleFireGroupNext
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "CycleFireGroupPrevious")]
public class CycleFireGroupPrevious
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "DeployHardpointToggle")]
public class DeployHardpointToggle
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "DeployHardpointsOnFire")]
public class DeployHardpointsOnFire
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "ToggleButtonUpInput")]
public class ToggleButtonUpInput
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }

    [XmlElement(ElementName = "ToggleOn")]
    public ToggleOn ToggleOn { get; set; }
}

[XmlRoot(ElementName = "DeployHeatSink")]
public class DeployHeatSink
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ShipSpotLightToggle")]
public class ShipSpotLightToggle
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "RadarRangeAxis")]
public class RadarRangeAxis
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "RadarIncreaseRange")]
public class RadarIncreaseRange
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "RadarDecreaseRange")]
public class RadarDecreaseRange
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "IncreaseEnginesPower")]
public class IncreaseEnginesPower
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "IncreaseWeaponsPower")]
public class IncreaseWeaponsPower
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "IncreaseSystemsPower")]
public class IncreaseSystemsPower
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ResetPowerDistribution")]
public class ResetPowerDistribution
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HMDReset")]
public class HMDReset
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ToggleCargoScoop")]
public class ToggleCargoScoop
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }

    [XmlElement(ElementName = "ToggleOn")]
    public ToggleOn ToggleOn { get; set; }
}

[XmlRoot(ElementName = "EjectAllCargo")]
public class EjectAllCargo
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "LandingGearToggle")]
public class LandingGearToggle
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "MicrophoneMute")]
public class MicrophoneMute
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }

    [XmlElement(ElementName = "ToggleOn")]
    public ToggleOn ToggleOn { get; set; }
}

[XmlRoot(ElementName = "MuteButtonMode")]
public class MuteButtonMode
{
    [XmlAttribute(AttributeName = "Value")]
    public string Value { get; set; }
}

[XmlRoot(ElementName = "CqcMuteButtonMode")]
public class CqcMuteButtonMode
{
    [XmlAttribute(AttributeName = "Value")]
    public string Value { get; set; }
}

[XmlRoot(ElementName = "UseShieldCell")]
public class UseShieldCell
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "FireChaffLauncher")]
public class FireChaffLauncher
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ChargeECM")]
public class ChargeECM
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "EnableRumbleTrigger")]
public class EnableRumbleTrigger
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "EnableMenuGroups")]
public class EnableMenuGroups
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "WeaponColourToggle")]
public class WeaponColourToggle
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "EngineColourToggle")]
public class EngineColourToggle
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "NightVisionToggle")]
public class NightVisionToggle
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "UIFocus")]
public class UIFocus
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "UIFocusMode")]
public class UIFocusMode
{
    [XmlAttribute(AttributeName = "Value")]
    public string Value { get; set; }
}

[XmlRoot(ElementName = "FocusLeftPanel")]
public class FocusLeftPanel
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "FocusCommsPanel")]
public class FocusCommsPanel
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "FocusOnTextEntryField")]
public class FocusOnTextEntryField
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "QuickCommsPanel")]
public class QuickCommsPanel
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "FocusRadarPanel")]
public class FocusRadarPanel
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "FocusRightPanel")]
public class FocusRightPanel
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "LeftPanelFocusOptions")]
public class LeftPanelFocusOptions
{
    [XmlAttribute(AttributeName = "Value")]
    public string Value { get; set; }
}

[XmlRoot(ElementName = "CommsPanelFocusOptions")]
public class CommsPanelFocusOptions
{
    [XmlAttribute(AttributeName = "Value")]
    public string Value { get; set; }
}

[XmlRoot(ElementName = "RolePanelFocusOptions")]
public class RolePanelFocusOptions
{
    [XmlAttribute(AttributeName = "Value")]
    public string Value { get; set; }
}

[XmlRoot(ElementName = "RightPanelFocusOptions")]
public class RightPanelFocusOptions
{
    [XmlAttribute(AttributeName = "Value")]
    public string Value { get; set; }
}

[XmlRoot(ElementName = "EnableCameraLockOn")]
public class EnableCameraLockOn
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "GalaxyMapOpen")]
public class GalaxyMapOpen
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "SystemMapOpen")]
public class SystemMapOpen
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ShowPGScoreSummaryInput")]
public class ShowPGScoreSummaryInput
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }

    [XmlElement(ElementName = "ToggleOn")]
    public ToggleOn ToggleOn { get; set; }
}

[XmlRoot(ElementName = "HeadLookToggle")]
public class HeadLookToggle
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }

    [XmlElement(ElementName = "ToggleOn")]
    public ToggleOn ToggleOn { get; set; }
}

[XmlRoot(ElementName = "Pause")]
public class Pause
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "FriendsMenu")]
public class FriendsMenu
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "OpenCodexGoToDiscovery")]
public class OpenCodexGoToDiscovery
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "PlayerHUDModeToggle")]
public class PlayerHUDModeToggle
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ExplorationFSSEnter")]
public class ExplorationFSSEnter
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "UI_Up")]
public class UIUp
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "UI_Down")]
public class UIDown
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "UI_Left")]
public class UILeft
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "UI_Right")]
public class UIRight
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "UI_Select")]
public class UISelect
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "UI_Back")]
public class UIBack
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "UI_Toggle")]
public class UIToggle
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "CycleNextPanel")]
public class CycleNextPanel
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "CyclePreviousPanel")]
public class CyclePreviousPanel
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "CycleNextPage")]
public class CycleNextPage
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "CyclePreviousPage")]
public class CyclePreviousPage
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "MouseHeadlook")]
public class MouseHeadlook
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "MouseHeadlookInvert")]
public class MouseHeadlookInvert
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "MouseHeadlookSensitivity")]
public class MouseHeadlookSensitivity
{
    [XmlAttribute(AttributeName = "Value")]
    public double Value { get; set; }
}

[XmlRoot(ElementName = "HeadlookDefault")]
public class HeadlookDefault
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "HeadlookIncrement")]
public class HeadlookIncrement
{
    [XmlAttribute(AttributeName = "Value")]
    public double Value { get; set; }
}

[XmlRoot(ElementName = "HeadlookMode")]
public class HeadlookMode
{
    [XmlAttribute(AttributeName = "Value")]
    public string Value { get; set; }
}

[XmlRoot(ElementName = "HeadlookResetOnToggle")]
public class HeadlookResetOnToggle
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "HeadlookSensitivity")]
public class HeadlookSensitivity
{
    [XmlAttribute(AttributeName = "Value")]
    public double Value { get; set; }
}

[XmlRoot(ElementName = "HeadlookSmoothing")]
public class HeadlookSmoothing
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "HeadLookReset")]
public class HeadLookReset
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HeadLookPitchUp")]
public class HeadLookPitchUp
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HeadLookPitchDown")]
public class HeadLookPitchDown
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HeadLookPitchAxisRaw")]
public class HeadLookPitchAxisRaw
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "HeadLookYawLeft")]
public class HeadLookYawLeft
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HeadLookYawRight")]
public class HeadLookYawRight
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HeadLookYawAxis")]
public class HeadLookYawAxis
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "MotionHeadlook")]
public class MotionHeadlook
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "HeadlookMotionSensitivity")]
public class HeadlookMotionSensitivity
{
    [XmlAttribute(AttributeName = "Value")]
    public double Value { get; set; }
}

[XmlRoot(ElementName = "yawRotateHeadlook")]
public class YawRotateHeadlook
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "CamPitchAxis")]
public class CamPitchAxis
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "CamPitchUp")]
public class CamPitchUp
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "CamPitchDown")]
public class CamPitchDown
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "CamYawAxis")]
public class CamYawAxis
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "CamYawLeft")]
public class CamYawLeft
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "CamYawRight")]
public class CamYawRight
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "CamTranslateYAxis")]
public class CamTranslateYAxis
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "CamTranslateForward")]
public class CamTranslateForward
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "CamTranslateBackward")]
public class CamTranslateBackward
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "CamTranslateXAxis")]
public class CamTranslateXAxis
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "CamTranslateLeft")]
public class CamTranslateLeft
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "CamTranslateRight")]
public class CamTranslateRight
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "CamTranslateZAxis")]
public class CamTranslateZAxis
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "CamTranslateUp")]
public class CamTranslateUp
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "CamTranslateDown")]
public class CamTranslateDown
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "CamZoomAxis")]
public class CamZoomAxis
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "CamZoomIn")]
public class CamZoomIn
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "CamZoomOut")]
public class CamZoomOut
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "CamTranslateZHold")]
public class CamTranslateZHold
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }

    [XmlElement(ElementName = "ToggleOn")]
    public ToggleOn ToggleOn { get; set; }
}

[XmlRoot(ElementName = "GalaxyMapHome")]
public class GalaxyMapHome
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ToggleDriveAssist")]
public class ToggleDriveAssist
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }

    [XmlElement(ElementName = "ToggleOn")]
    public ToggleOn ToggleOn { get; set; }
}

[XmlRoot(ElementName = "DriveAssistDefault")]
public class DriveAssistDefault
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "MouseBuggySteeringXMode")]
public class MouseBuggySteeringXMode
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "MouseBuggySteeringXDecay")]
public class MouseBuggySteeringXDecay
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "MouseBuggyRollingXMode")]
public class MouseBuggyRollingXMode
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "MouseBuggyRollingXDecay")]
public class MouseBuggyRollingXDecay
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "MouseBuggyYMode")]
public class MouseBuggyYMode
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "MouseBuggyYDecay")]
public class MouseBuggyYDecay
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "SteeringAxis")]
public class SteeringAxis
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "SteerLeftButton")]
public class SteerLeftButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "SteerRightButton")]
public class SteerRightButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "BuggyRollAxisRaw")]
public class BuggyRollAxisRaw
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "BuggyRollLeftButton")]
public class BuggyRollLeftButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "BuggyRollRightButton")]
public class BuggyRollRightButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "BuggyPitchAxis")]
public class BuggyPitchAxis
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "BuggyPitchUpButton")]
public class BuggyPitchUpButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "BuggyPitchDownButton")]
public class BuggyPitchDownButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "VerticalThrustersButton")]
public class VerticalThrustersButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }

    [XmlElement(ElementName = "ToggleOn")]
    public ToggleOn ToggleOn { get; set; }
}

[XmlRoot(ElementName = "BuggyPrimaryFireButton")]
public class BuggyPrimaryFireButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "BuggySecondaryFireButton")]
public class BuggySecondaryFireButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "AutoBreakBuggyButton")]
public class AutoBreakBuggyButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }

    [XmlElement(ElementName = "ToggleOn")]
    public ToggleOn ToggleOn { get; set; }
}

[XmlRoot(ElementName = "HeadlightsBuggyButton")]
public class HeadlightsBuggyButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ToggleBuggyTurretButton")]
public class ToggleBuggyTurretButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "BuggyCycleFireGroupNext")]
public class BuggyCycleFireGroupNext
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "BuggyCycleFireGroupPrevious")]
public class BuggyCycleFireGroupPrevious
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "SelectTarget_Buggy")]
public class SelectTargetBuggy
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "MouseTurretXMode")]
public class MouseTurretXMode
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "MouseTurretXDecay")]
public class MouseTurretXDecay
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "MouseTurretYMode")]
public class MouseTurretYMode
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "MouseTurretYDecay")]
public class MouseTurretYDecay
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "BuggyTurretYawAxisRaw")]
public class BuggyTurretYawAxisRaw
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "BuggyTurretYawLeftButton")]
public class BuggyTurretYawLeftButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "BuggyTurretYawRightButton")]
public class BuggyTurretYawRightButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "BuggyTurretPitchAxisRaw")]
public class BuggyTurretPitchAxisRaw
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "BuggyTurretPitchUpButton")]
public class BuggyTurretPitchUpButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "BuggyTurretPitchDownButton")]
public class BuggyTurretPitchDownButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "BuggyTurretMouseSensitivity")]
public class BuggyTurretMouseSensitivity
{
    [XmlAttribute(AttributeName = "Value")]
    public double Value { get; set; }
}

[XmlRoot(ElementName = "BuggyTurretMouseDeadzone")]
public class BuggyTurretMouseDeadzone
{
    [XmlAttribute(AttributeName = "Value")]
    public double Value { get; set; }
}

[XmlRoot(ElementName = "BuggyTurretMouseLinearity")]
public class BuggyTurretMouseLinearity
{
    [XmlAttribute(AttributeName = "Value")]
    public double Value { get; set; }
}

[XmlRoot(ElementName = "DriveSpeedAxis")]
public class DriveSpeedAxis
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "BuggyThrottleRange")]
public class BuggyThrottleRange
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "BuggyToggleReverseThrottleInput")]
public class BuggyToggleReverseThrottleInput
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }

    [XmlElement(ElementName = "ToggleOn")]
    public ToggleOn ToggleOn { get; set; }
}

[XmlRoot(ElementName = "BuggyThrottleIncrement")]
public class BuggyThrottleIncrement
{
    [XmlAttribute(AttributeName = "Value")]
    public double Value { get; set; }
}

[XmlRoot(ElementName = "IncreaseSpeedButtonMax")]
public class IncreaseSpeedButtonMax
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "DecreaseSpeedButtonMax")]
public class DecreaseSpeedButtonMax
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "IncreaseSpeedButtonPartial")]
public class IncreaseSpeedButtonPartial
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "DecreaseSpeedButtonPartial")]
public class DecreaseSpeedButtonPartial
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "IncreaseEnginesPower_Buggy")]
public class IncreaseEnginesPowerBuggy
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "IncreaseWeaponsPower_Buggy")]
public class IncreaseWeaponsPowerBuggy
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "IncreaseSystemsPower_Buggy")]
public class IncreaseSystemsPowerBuggy
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ResetPowerDistribution_Buggy")]
public class ResetPowerDistributionBuggy
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ToggleCargoScoop_Buggy")]
public class ToggleCargoScoopBuggy
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }

    [XmlElement(ElementName = "ToggleOn")]
    public ToggleOn ToggleOn { get; set; }
}

[XmlRoot(ElementName = "EjectAllCargo_Buggy")]
public class EjectAllCargoBuggy
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "RecallDismissShip")]
public class RecallDismissShip
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "EnableMenuGroupsSRV")]
public class EnableMenuGroupsSRV
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "UIFocus_Buggy")]
public class UIFocusBuggy
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "FocusLeftPanel_Buggy")]
public class FocusLeftPanelBuggy
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "FocusCommsPanel_Buggy")]
public class FocusCommsPanelBuggy
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "QuickCommsPanel_Buggy")]
public class QuickCommsPanelBuggy
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "FocusRadarPanel_Buggy")]
public class FocusRadarPanelBuggy
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "FocusRightPanel_Buggy")]
public class FocusRightPanelBuggy
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "GalaxyMapOpen_Buggy")]
public class GalaxyMapOpenBuggy
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "SystemMapOpen_Buggy")]
public class SystemMapOpenBuggy
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "OpenCodexGoToDiscovery_Buggy")]
public class OpenCodexGoToDiscoveryBuggy
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "PlayerHUDModeToggle_Buggy")]
public class PlayerHUDModeToggleBuggy
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HeadLookToggle_Buggy")]
public class HeadLookToggleBuggy
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }

    [XmlElement(ElementName = "ToggleOn")]
    public ToggleOn ToggleOn { get; set; }
}

[XmlRoot(ElementName = "MultiCrewToggleMode")]
public class MultiCrewToggleMode
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "MultiCrewPrimaryFire")]
public class MultiCrewPrimaryFire
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "MultiCrewSecondaryFire")]
public class MultiCrewSecondaryFire
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "MultiCrewPrimaryUtilityFire")]
public class MultiCrewPrimaryUtilityFire
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "MultiCrewSecondaryUtilityFire")]
public class MultiCrewSecondaryUtilityFire
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "MultiCrewThirdPersonMouseXMode")]
public class MultiCrewThirdPersonMouseXMode
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "MultiCrewThirdPersonMouseXDecay")]
public class MultiCrewThirdPersonMouseXDecay
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "MultiCrewThirdPersonMouseYMode")]
public class MultiCrewThirdPersonMouseYMode
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "MultiCrewThirdPersonMouseYDecay")]
public class MultiCrewThirdPersonMouseYDecay
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "MultiCrewThirdPersonYawAxisRaw")]
public class MultiCrewThirdPersonYawAxisRaw
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "MultiCrewThirdPersonYawLeftButton")]
public class MultiCrewThirdPersonYawLeftButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "MultiCrewThirdPersonYawRightButton")]
public class MultiCrewThirdPersonYawRightButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "MultiCrewThirdPersonPitchAxisRaw")]
public class MultiCrewThirdPersonPitchAxisRaw
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "MultiCrewThirdPersonPitchUpButton")]
public class MultiCrewThirdPersonPitchUpButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "MultiCrewThirdPersonPitchDownButton")]
public class MultiCrewThirdPersonPitchDownButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "MultiCrewThirdPersonMouseSensitivity")]
public class MultiCrewThirdPersonMouseSensitivity
{
    [XmlAttribute(AttributeName = "Value")]
    public double Value { get; set; }
}

[XmlRoot(ElementName = "MultiCrewThirdPersonFovAxisRaw")]
public class MultiCrewThirdPersonFovAxisRaw
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "MultiCrewThirdPersonFovOutButton")]
public class MultiCrewThirdPersonFovOutButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "MultiCrewThirdPersonFovInButton")]
public class MultiCrewThirdPersonFovInButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "MultiCrewCockpitUICycleForward")]
public class MultiCrewCockpitUICycleForward
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "MultiCrewCockpitUICycleBackward")]
public class MultiCrewCockpitUICycleBackward
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "OrderRequestDock")]
public class OrderRequestDock
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "OrderDefensiveBehaviour")]
public class OrderDefensiveBehaviour
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "OrderAggressiveBehaviour")]
public class OrderAggressiveBehaviour
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "OrderFocusTarget")]
public class OrderFocusTarget
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "OrderHoldFire")]
public class OrderHoldFire
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "OrderHoldPosition")]
public class OrderHoldPosition
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "OrderFollow")]
public class OrderFollow
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "OpenOrders")]
public class OpenOrders
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "PhotoCameraToggle")]
public class PhotoCameraToggle
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "PhotoCameraToggle_Buggy")]
public class PhotoCameraToggleBuggy
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "PhotoCameraToggle_Humanoid")]
public class PhotoCameraToggleHumanoid
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "VanityCameraScrollLeft")]
public class VanityCameraScrollLeft
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "VanityCameraScrollRight")]
public class VanityCameraScrollRight
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ToggleFreeCam")]
public class ToggleFreeCam
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "VanityCameraOne")]
public class VanityCameraOne
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "VanityCameraTwo")]
public class VanityCameraTwo
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "VanityCameraThree")]
public class VanityCameraThree
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "VanityCameraFour")]
public class VanityCameraFour
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "VanityCameraFive")]
public class VanityCameraFive
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "VanityCameraSix")]
public class VanityCameraSix
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "VanityCameraSeven")]
public class VanityCameraSeven
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "VanityCameraEight")]
public class VanityCameraEight
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "VanityCameraNine")]
public class VanityCameraNine
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "VanityCameraTen")]
public class VanityCameraTen
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "FreeCamToggleHUD")]
public class FreeCamToggleHUD
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "FreeCamSpeedInc")]
public class FreeCamSpeedInc
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "FreeCamSpeedDec")]
public class FreeCamSpeedDec
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "MoveFreeCamY")]
public class MoveFreeCamY
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "ThrottleRangeFreeCam")]
public class ThrottleRangeFreeCam
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "ToggleReverseThrottleInputFreeCam")]
public class ToggleReverseThrottleInputFreeCam
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }

    [XmlElement(ElementName = "ToggleOn")]
    public ToggleOn ToggleOn { get; set; }
}

[XmlRoot(ElementName = "MoveFreeCamForward")]
public class MoveFreeCamForward
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "MoveFreeCamBackwards")]
public class MoveFreeCamBackwards
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "MoveFreeCamX")]
public class MoveFreeCamX
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "MoveFreeCamRight")]
public class MoveFreeCamRight
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "MoveFreeCamLeft")]
public class MoveFreeCamLeft
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "MoveFreeCamZ")]
public class MoveFreeCamZ
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "MoveFreeCamUpAxis")]
public class MoveFreeCamUpAxis
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "MoveFreeCamDownAxis")]
public class MoveFreeCamDownAxis
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "MoveFreeCamUp")]
public class MoveFreeCamUp
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "MoveFreeCamDown")]
public class MoveFreeCamDown
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "PitchCameraMouse")]
public class PitchCameraMouse
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "YawCameraMouse")]
public class YawCameraMouse
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "PitchCamera")]
public class PitchCamera
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "FreeCamMouseSensitivity")]
public class FreeCamMouseSensitivity
{
    [XmlAttribute(AttributeName = "Value")]
    public double Value { get; set; }
}

[XmlRoot(ElementName = "FreeCamMouseYDecay")]
public class FreeCamMouseYDecay
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "PitchCameraUp")]
public class PitchCameraUp
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "PitchCameraDown")]
public class PitchCameraDown
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "YawCamera")]
public class YawCamera
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "FreeCamMouseXDecay")]
public class FreeCamMouseXDecay
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "YawCameraLeft")]
public class YawCameraLeft
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "YawCameraRight")]
public class YawCameraRight
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "RollCamera")]
public class RollCamera
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "RollCameraLeft")]
public class RollCameraLeft
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "RollCameraRight")]
public class RollCameraRight
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ToggleRotationLock")]
public class ToggleRotationLock
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "FixCameraRelativeToggle")]
public class FixCameraRelativeToggle
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "FixCameraWorldToggle")]
public class FixCameraWorldToggle
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "QuitCamera")]
public class QuitCamera
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ToggleAdvanceMode")]
public class ToggleAdvanceMode
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "FreeCamZoomIn")]
public class FreeCamZoomIn
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "FreeCamZoomOut")]
public class FreeCamZoomOut
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "FStopDec")]
public class FStopDec
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "FStopInc")]
public class FStopInc
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "CommanderCreator_Undo")]
public class CommanderCreatorUndo
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "CommanderCreator_Redo")]
public class CommanderCreatorRedo
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "CommanderCreator_Rotation_MouseToggle")]
public class CommanderCreatorRotationMouseToggle
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "CommanderCreator_Rotation")]
public class CommanderCreatorRotation
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "GalnetAudio_Play_Pause")]
public class GalnetAudioPlayPause
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "GalnetAudio_SkipForward")]
public class GalnetAudioSkipForward
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "GalnetAudio_SkipBackward")]
public class GalnetAudioSkipBackward
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "GalnetAudio_ClearQueue")]
public class GalnetAudioClearQueue
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ExplorationFSSCameraPitch")]
public class ExplorationFSSCameraPitch
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "ExplorationFSSCameraPitchIncreaseButton")]
public class ExplorationFSSCameraPitchIncreaseButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ExplorationFSSCameraPitchDecreaseButton")]
public class ExplorationFSSCameraPitchDecreaseButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ExplorationFSSCameraYaw")]
public class ExplorationFSSCameraYaw
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "ExplorationFSSCameraYawIncreaseButton")]
public class ExplorationFSSCameraYawIncreaseButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ExplorationFSSCameraYawDecreaseButton")]
public class ExplorationFSSCameraYawDecreaseButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ExplorationFSSZoomIn")]
public class ExplorationFSSZoomIn
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ExplorationFSSZoomOut")]
public class ExplorationFSSZoomOut
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ExplorationFSSMiniZoomIn")]
public class ExplorationFSSMiniZoomIn
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ExplorationFSSMiniZoomOut")]
public class ExplorationFSSMiniZoomOut
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ExplorationFSSRadioTuningX_Raw")]
public class ExplorationFSSRadioTuningXRaw
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "ExplorationFSSRadioTuningX_Increase")]
public class ExplorationFSSRadioTuningXIncrease
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ExplorationFSSRadioTuningX_Decrease")]
public class ExplorationFSSRadioTuningXDecrease
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ExplorationFSSRadioTuningAbsoluteX")]
public class ExplorationFSSRadioTuningAbsoluteX
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "FSSTuningSensitivity")]
public class FSSTuningSensitivity
{
    [XmlAttribute(AttributeName = "Value")]
    public double Value { get; set; }
}

[XmlRoot(ElementName = "ExplorationFSSDiscoveryScan")]
public class ExplorationFSSDiscoveryScan
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ExplorationFSSQuit")]
public class ExplorationFSSQuit
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "FSSMouseXMode")]
public class FSSMouseXMode
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "FSSMouseXDecay")]
public class FSSMouseXDecay
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "FSSMouseYMode")]
public class FSSMouseYMode
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "FSSMouseYDecay")]
public class FSSMouseYDecay
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "FSSMouseSensitivity")]
public class FSSMouseSensitivity
{
    [XmlAttribute(AttributeName = "Value")]
    public double Value { get; set; }
}

[XmlRoot(ElementName = "FSSMouseDeadzone")]
public class FSSMouseDeadzone
{
    [XmlAttribute(AttributeName = "Value")]
    public double Value { get; set; }
}

[XmlRoot(ElementName = "FSSMouseLinearity")]
public class FSSMouseLinearity
{
    [XmlAttribute(AttributeName = "Value")]
    public double Value { get; set; }
}

[XmlRoot(ElementName = "ExplorationFSSTarget")]
public class ExplorationFSSTarget
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ExplorationFSSShowHelp")]
public class ExplorationFSSShowHelp
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ExplorationSAAChangeScannedAreaViewToggle")]
public class ExplorationSAAChangeScannedAreaViewToggle
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }

    [XmlElement(ElementName = "ToggleOn")]
    public ToggleOn ToggleOn { get; set; }
}

[XmlRoot(ElementName = "ExplorationSAAExitThirdPerson")]
public class ExplorationSAAExitThirdPerson
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ExplorationSAANextGenus")]
public class ExplorationSAANextGenus
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "ExplorationSAAPreviousGenus")]
public class ExplorationSAAPreviousGenus
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "SAAThirdPersonMouseXMode")]
public class SAAThirdPersonMouseXMode
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "SAAThirdPersonMouseXDecay")]
public class SAAThirdPersonMouseXDecay
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "SAAThirdPersonMouseYMode")]
public class SAAThirdPersonMouseYMode
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "SAAThirdPersonMouseYDecay")]
public class SAAThirdPersonMouseYDecay
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "SAAThirdPersonMouseSensitivity")]
public class SAAThirdPersonMouseSensitivity
{
    [XmlAttribute(AttributeName = "Value")]
    public double Value { get; set; }
}

[XmlRoot(ElementName = "SAAThirdPersonYawAxisRaw")]
public class SAAThirdPersonYawAxisRaw
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "SAAThirdPersonYawLeftButton")]
public class SAAThirdPersonYawLeftButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "SAAThirdPersonYawRightButton")]
public class SAAThirdPersonYawRightButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "SAAThirdPersonPitchAxisRaw")]
public class SAAThirdPersonPitchAxisRaw
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "SAAThirdPersonPitchUpButton")]
public class SAAThirdPersonPitchUpButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "SAAThirdPersonPitchDownButton")]
public class SAAThirdPersonPitchDownButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "SAAThirdPersonFovAxisRaw")]
public class SAAThirdPersonFovAxisRaw
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "SAAThirdPersonFovOutButton")]
public class SAAThirdPersonFovOutButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "SAAThirdPersonFovInButton")]
public class SAAThirdPersonFovInButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "MouseHumanoidXMode")]
public class MouseHumanoidXMode
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "MouseHumanoidYMode")]
public class MouseHumanoidYMode
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "MouseHumanoidSensitivity")]
public class MouseHumanoidSensitivity
{
    [XmlAttribute(AttributeName = "Value")]
    public double Value { get; set; }
}

[XmlRoot(ElementName = "HumanoidForwardAxis")]
public class HumanoidForwardAxis
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "HumanoidForwardButton")]
public class HumanoidForwardButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidBackwardButton")]
public class HumanoidBackwardButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidStrafeAxis")]
public class HumanoidStrafeAxis
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "HumanoidStrafeLeftButton")]
public class HumanoidStrafeLeftButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidStrafeRightButton")]
public class HumanoidStrafeRightButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidRotateAxis")]
public class HumanoidRotateAxis
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "HumanoidRotateSensitivity")]
public class HumanoidRotateSensitivity
{
    [XmlAttribute(AttributeName = "Value")]
    public double Value { get; set; }
}

[XmlRoot(ElementName = "HumanoidRotateLeftButton")]
public class HumanoidRotateLeftButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidRotateRightButton")]
public class HumanoidRotateRightButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidPitchAxis")]
public class HumanoidPitchAxis
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "HumanoidPitchSensitivity")]
public class HumanoidPitchSensitivity
{
    [XmlAttribute(AttributeName = "Value")]
    public double Value { get; set; }
}

[XmlRoot(ElementName = "HumanoidPitchUpButton")]
public class HumanoidPitchUpButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidPitchDownButton")]
public class HumanoidPitchDownButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidSprintButton")]
public class HumanoidSprintButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }

    [XmlElement(ElementName = "ToggleOn")]
    public ToggleOn ToggleOn { get; set; }
}

[XmlRoot(ElementName = "HumanoidWalkButton")]
public class HumanoidWalkButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }

    [XmlElement(ElementName = "ToggleOn")]
    public ToggleOn ToggleOn { get; set; }
}

[XmlRoot(ElementName = "HumanoidCrouchButton")]
public class HumanoidCrouchButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }

    [XmlElement(ElementName = "ToggleOn")]
    public ToggleOn ToggleOn { get; set; }
}

[XmlRoot(ElementName = "HumanoidJumpButton")]
public class HumanoidJumpButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidPrimaryInteractButton")]
public class HumanoidPrimaryInteractButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidSecondaryInteractButton")]
public class HumanoidSecondaryInteractButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidItemWheelButton")]
public class HumanoidItemWheelButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }

    [XmlElement(ElementName = "ToggleOn")]
    public ToggleOn ToggleOn { get; set; }
}

[XmlRoot(ElementName = "HumanoidEmoteWheelButton")]
public class HumanoidEmoteWheelButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }

    [XmlElement(ElementName = "ToggleOn")]
    public ToggleOn ToggleOn { get; set; }
}

[XmlRoot(ElementName = "HumanoidUtilityWheelCycleMode")]
public class HumanoidUtilityWheelCycleMode
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidItemWheelButton_XAxis")]
public class HumanoidItemWheelButtonXAxis
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "HumanoidItemWheelButton_XLeft")]
public class HumanoidItemWheelButtonXLeft
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidItemWheelButton_XRight")]
public class HumanoidItemWheelButtonXRight
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidItemWheelButton_YAxis")]
public class HumanoidItemWheelButtonYAxis
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "HumanoidItemWheelButton_YUp")]
public class HumanoidItemWheelButtonYUp
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidItemWheelButton_YDown")]
public class HumanoidItemWheelButtonYDown
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidItemWheel_AcceptMouseInput")]
public class HumanoidItemWheelAcceptMouseInput
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "HumanoidPrimaryFireButton")]
public class HumanoidPrimaryFireButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidZoomButton")]
public class HumanoidZoomButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }

    [XmlElement(ElementName = "ToggleOn")]
    public ToggleOn ToggleOn { get; set; }
}

[XmlRoot(ElementName = "HumanoidThrowGrenadeButton")]
public class HumanoidThrowGrenadeButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidMeleeButton")]
public class HumanoidMeleeButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidReloadButton")]
public class HumanoidReloadButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidSwitchWeapon")]
public class HumanoidSwitchWeapon
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidSelectPrimaryWeaponButton")]
public class HumanoidSelectPrimaryWeaponButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidSelectSecondaryWeaponButton")]
public class HumanoidSelectSecondaryWeaponButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidSelectUtilityWeaponButton")]
public class HumanoidSelectUtilityWeaponButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidSelectNextWeaponButton")]
public class HumanoidSelectNextWeaponButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidSelectPreviousWeaponButton")]
public class HumanoidSelectPreviousWeaponButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidHideWeaponButton")]
public class HumanoidHideWeaponButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidSelectNextGrenadeTypeButton")]
public class HumanoidSelectNextGrenadeTypeButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidSelectPreviousGrenadeTypeButton")]
public class HumanoidSelectPreviousGrenadeTypeButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidToggleFlashlightButton")]
public class HumanoidToggleFlashlightButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidToggleNightVisionButton")]
public class HumanoidToggleNightVisionButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidToggleShieldsButton")]
public class HumanoidToggleShieldsButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidClearAuthorityLevel")]
public class HumanoidClearAuthorityLevel
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidHealthPack")]
public class HumanoidHealthPack
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidBattery")]
public class HumanoidBattery
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidSelectFragGrenade")]
public class HumanoidSelectFragGrenade
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidSelectEMPGrenade")]
public class HumanoidSelectEMPGrenade
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidSelectShieldGrenade")]
public class HumanoidSelectShieldGrenade
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidSwitchToRechargeTool")]
public class HumanoidSwitchToRechargeTool
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidSwitchToCompAnalyser")]
public class HumanoidSwitchToCompAnalyser
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidSwitchToSuitTool")]
public class HumanoidSwitchToSuitTool
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidToggleToolModeButton")]
public class HumanoidToggleToolModeButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidToggleMissionHelpPanelButton")]
public class HumanoidToggleMissionHelpPanelButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidPing")]
public class HumanoidPing
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "GalaxyMapOpen_Humanoid")]
public class GalaxyMapOpenHumanoid
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "SystemMapOpen_Humanoid")]
public class SystemMapOpenHumanoid
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "FocusCommsPanel_Humanoid")]
public class FocusCommsPanelHumanoid
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "QuickCommsPanel_Humanoid")]
public class QuickCommsPanelHumanoid
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidOpenAccessPanelButton")]
public class HumanoidOpenAccessPanelButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidConflictContextualUIButton")]
public class HumanoidConflictContextualUIButton
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "EnableMenuGroupsOnFoot")]
public class EnableMenuGroupsOnFoot
{
    [XmlAttribute(AttributeName = "Value")]
    public int Value { get; set; }
}

[XmlRoot(ElementName = "StoreEnableRotation")]
public class StoreEnableRotation
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "StorePitchCamera")]
public class StorePitchCamera
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "StoreYawCamera")]
public class StoreYawCamera
{
    [XmlElement(ElementName = "Binding")]
    public Binding Binding { get; set; }

    [XmlElement(ElementName = "Inverted")]
    public Inverted Inverted { get; set; }

    [XmlElement(ElementName = "Deadzone")]
    public Deadzone Deadzone { get; set; }
}

[XmlRoot(ElementName = "StoreCamZoomIn")]
public class StoreCamZoomIn
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "StoreCamZoomOut")]
public class StoreCamZoomOut
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "StoreToggle")]
public class StoreToggle
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidEmoteSlot1")]
public class HumanoidEmoteSlot1
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidEmoteSlot2")]
public class HumanoidEmoteSlot2
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidEmoteSlot3")]
public class HumanoidEmoteSlot3
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidEmoteSlot4")]
public class HumanoidEmoteSlot4
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidEmoteSlot5")]
public class HumanoidEmoteSlot5
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidEmoteSlot6")]
public class HumanoidEmoteSlot6
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidEmoteSlot7")]
public class HumanoidEmoteSlot7
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "HumanoidEmoteSlot8")]
public class HumanoidEmoteSlot8
{
    [XmlElement(ElementName = "Primary")]
    public Primary Primary { get; set; }

    [XmlElement(ElementName = "Secondary")]
    public Secondary Secondary { get; set; }
}

[XmlRoot(ElementName = "Root")]
public class Root
{
    [XmlElement(ElementName = "KeyboardLayout")]
    public string KeyboardLayout { get; set; }

    [XmlElement(ElementName = "MouseXMode")]
    public MouseXMode MouseXMode { get; set; }

    [XmlElement(ElementName = "MouseXDecay")]
    public MouseXDecay MouseXDecay { get; set; }

    [XmlElement(ElementName = "MouseYMode")]
    public MouseYMode MouseYMode { get; set; }

    [XmlElement(ElementName = "MouseYDecay")]
    public MouseYDecay MouseYDecay { get; set; }

    [XmlElement(ElementName = "MouseReset")]
    public MouseReset MouseReset { get; set; }

    [XmlElement(ElementName = "MouseSensitivity")]
    public MouseSensitivity MouseSensitivity { get; set; }

    [XmlElement(ElementName = "MouseDecayRate")]
    public MouseDecayRate MouseDecayRate { get; set; }

    [XmlElement(ElementName = "MouseDeadzone")]
    public MouseDeadzone MouseDeadzone { get; set; }

    [XmlElement(ElementName = "MouseLinearity")]
    public MouseLinearity MouseLinearity { get; set; }

    [XmlElement(ElementName = "MouseGUI")]
    public List<MouseGUI> MouseGUI { get; set; }

    [XmlElement(ElementName = "YawAxisRaw")]
    public YawAxisRaw YawAxisRaw { get; set; }

    [XmlElement(ElementName = "YawLeftButton")]
    public YawLeftButton YawLeftButton { get; set; }

    [XmlElement(ElementName = "YawRightButton")]
    public YawRightButton YawRightButton { get; set; }

    [XmlElement(ElementName = "YawToRollMode")]
    public YawToRollMode YawToRollMode { get; set; }

    [XmlElement(ElementName = "YawToRollSensitivity")]
    public YawToRollSensitivity YawToRollSensitivity { get; set; }

    [XmlElement(ElementName = "YawToRollMode_FAOff")]
    public YawToRollModeFAOff YawToRollModeFAOff { get; set; }

    [XmlElement(ElementName = "YawToRollButton")]
    public YawToRollButton YawToRollButton { get; set; }

    [XmlElement(ElementName = "RollAxisRaw")]
    public RollAxisRaw RollAxisRaw { get; set; }

    [XmlElement(ElementName = "RollLeftButton")]
    public RollLeftButton RollLeftButton { get; set; }

    [XmlElement(ElementName = "RollRightButton")]
    public RollRightButton RollRightButton { get; set; }

    [XmlElement(ElementName = "PitchAxisRaw")]
    public PitchAxisRaw PitchAxisRaw { get; set; }

    [XmlElement(ElementName = "PitchUpButton")]
    public PitchUpButton PitchUpButton { get; set; }

    [XmlElement(ElementName = "PitchDownButton")]
    public PitchDownButton PitchDownButton { get; set; }

    [XmlElement(ElementName = "LateralThrustRaw")]
    public LateralThrustRaw LateralThrustRaw { get; set; }

    [XmlElement(ElementName = "LeftThrustButton")]
    public LeftThrustButton LeftThrustButton { get; set; }

    [XmlElement(ElementName = "RightThrustButton")]
    public RightThrustButton RightThrustButton { get; set; }

    [XmlElement(ElementName = "VerticalThrustRaw")]
    public VerticalThrustRaw VerticalThrustRaw { get; set; }

    [XmlElement(ElementName = "UpThrustButton")]
    public UpThrustButton UpThrustButton { get; set; }

    [XmlElement(ElementName = "DownThrustButton")]
    public DownThrustButton DownThrustButton { get; set; }

    [XmlElement(ElementName = "AheadThrust")]
    public AheadThrust AheadThrust { get; set; }

    [XmlElement(ElementName = "ForwardThrustButton")]
    public ForwardThrustButton ForwardThrustButton { get; set; }

    [XmlElement(ElementName = "BackwardThrustButton")]
    public BackwardThrustButton BackwardThrustButton { get; set; }

    [XmlElement(ElementName = "UseAlternateFlightValuesToggle")]
    public UseAlternateFlightValuesToggle UseAlternateFlightValuesToggle { get; set; }

    [XmlElement(ElementName = "YawAxisAlternate")]
    public YawAxisAlternate YawAxisAlternate { get; set; }

    [XmlElement(ElementName = "RollAxisAlternate")]
    public RollAxisAlternate RollAxisAlternate { get; set; }

    [XmlElement(ElementName = "PitchAxisAlternate")]
    public PitchAxisAlternate PitchAxisAlternate { get; set; }

    [XmlElement(ElementName = "LateralThrustAlternate")]
    public LateralThrustAlternate LateralThrustAlternate { get; set; }

    [XmlElement(ElementName = "VerticalThrustAlternate")]
    public VerticalThrustAlternate VerticalThrustAlternate { get; set; }

    [XmlElement(ElementName = "ThrottleAxis")]
    public ThrottleAxis ThrottleAxis { get; set; }

    [XmlElement(ElementName = "ThrottleRange")]
    public ThrottleRange ThrottleRange { get; set; }

    [XmlElement(ElementName = "ToggleReverseThrottleInput")]
    public ToggleReverseThrottleInput ToggleReverseThrottleInput { get; set; }

    [XmlElement(ElementName = "ForwardKey")]
    public ForwardKey ForwardKey { get; set; }

    [XmlElement(ElementName = "BackwardKey")]
    public BackwardKey BackwardKey { get; set; }

    [XmlElement(ElementName = "ThrottleIncrement")]
    public ThrottleIncrement ThrottleIncrement { get; set; }

    [XmlElement(ElementName = "SetSpeedMinus100")]
    public SetSpeedMinus100 SetSpeedMinus100 { get; set; }

    [XmlElement(ElementName = "SetSpeedMinus75")]
    public SetSpeedMinus75 SetSpeedMinus75 { get; set; }

    [XmlElement(ElementName = "SetSpeedMinus50")]
    public SetSpeedMinus50 SetSpeedMinus50 { get; set; }

    [XmlElement(ElementName = "SetSpeedMinus25")]
    public SetSpeedMinus25 SetSpeedMinus25 { get; set; }

    [XmlElement(ElementName = "SetSpeedZero")]
    public SetSpeedZero SetSpeedZero { get; set; }

    [XmlElement(ElementName = "SetSpeed25")]
    public SetSpeed25 SetSpeed25 { get; set; }

    [XmlElement(ElementName = "SetSpeed50")]
    public SetSpeed50 SetSpeed50 { get; set; }

    [XmlElement(ElementName = "SetSpeed75")]
    public SetSpeed75 SetSpeed75 { get; set; }

    [XmlElement(ElementName = "SetSpeed100")]
    public SetSpeed100 SetSpeed100 { get; set; }

    [XmlElement(ElementName = "YawAxis_Landing")]
    public YawAxisLanding YawAxisLanding { get; set; }

    [XmlElement(ElementName = "YawLeftButton_Landing")]
    public YawLeftButtonLanding YawLeftButtonLanding { get; set; }

    [XmlElement(ElementName = "YawRightButton_Landing")]
    public YawRightButtonLanding YawRightButtonLanding { get; set; }

    [XmlElement(ElementName = "YawToRollMode_Landing")]
    public YawToRollModeLanding YawToRollModeLanding { get; set; }

    [XmlElement(ElementName = "PitchAxis_Landing")]
    public PitchAxisLanding PitchAxisLanding { get; set; }

    [XmlElement(ElementName = "PitchUpButton_Landing")]
    public PitchUpButtonLanding PitchUpButtonLanding { get; set; }

    [XmlElement(ElementName = "PitchDownButton_Landing")]
    public PitchDownButtonLanding PitchDownButtonLanding { get; set; }

    [XmlElement(ElementName = "RollAxis_Landing")]
    public RollAxisLanding RollAxisLanding { get; set; }

    [XmlElement(ElementName = "RollLeftButton_Landing")]
    public RollLeftButtonLanding RollLeftButtonLanding { get; set; }

    [XmlElement(ElementName = "RollRightButton_Landing")]
    public RollRightButtonLanding RollRightButtonLanding { get; set; }

    [XmlElement(ElementName = "LateralThrust_Landing")]
    public LateralThrustLanding LateralThrustLanding { get; set; }

    [XmlElement(ElementName = "LeftThrustButton_Landing")]
    public LeftThrustButtonLanding LeftThrustButtonLanding { get; set; }

    [XmlElement(ElementName = "RightThrustButton_Landing")]
    public RightThrustButtonLanding RightThrustButtonLanding { get; set; }

    [XmlElement(ElementName = "VerticalThrust_Landing")]
    public VerticalThrustLanding VerticalThrustLanding { get; set; }

    [XmlElement(ElementName = "UpThrustButton_Landing")]
    public UpThrustButtonLanding UpThrustButtonLanding { get; set; }

    [XmlElement(ElementName = "DownThrustButton_Landing")]
    public DownThrustButtonLanding DownThrustButtonLanding { get; set; }

    [XmlElement(ElementName = "AheadThrust_Landing")]
    public AheadThrustLanding AheadThrustLanding { get; set; }

    [XmlElement(ElementName = "ForwardThrustButton_Landing")]
    public ForwardThrustButtonLanding ForwardThrustButtonLanding { get; set; }

    [XmlElement(ElementName = "BackwardThrustButton_Landing")]
    public BackwardThrustButtonLanding BackwardThrustButtonLanding { get; set; }

    [XmlElement(ElementName = "ToggleFlightAssist")]
    public ToggleFlightAssist ToggleFlightAssist { get; set; }

    [XmlElement(ElementName = "UseBoostJuice")]
    public UseBoostJuice UseBoostJuice { get; set; }

    [XmlElement(ElementName = "HyperSuperCombination")]
    public HyperSuperCombination HyperSuperCombination { get; set; }

    [XmlElement(ElementName = "Supercruise")]
    public Supercruise Supercruise { get; set; }

    [XmlElement(ElementName = "Hyperspace")]
    public Hyperspace Hyperspace { get; set; }

    [XmlElement(ElementName = "DisableRotationCorrectToggle")]
    public DisableRotationCorrectToggle DisableRotationCorrectToggle { get; set; }

    [XmlElement(ElementName = "OrbitLinesToggle")]
    public OrbitLinesToggle OrbitLinesToggle { get; set; }

    [XmlElement(ElementName = "SelectTarget")]
    public SelectTarget SelectTarget { get; set; }

    [XmlElement(ElementName = "CycleNextTarget")]
    public CycleNextTarget CycleNextTarget { get; set; }

    [XmlElement(ElementName = "CyclePreviousTarget")]
    public CyclePreviousTarget CyclePreviousTarget { get; set; }

    [XmlElement(ElementName = "SelectHighestThreat")]
    public SelectHighestThreat SelectHighestThreat { get; set; }

    [XmlElement(ElementName = "CycleNextHostileTarget")]
    public CycleNextHostileTarget CycleNextHostileTarget { get; set; }

    [XmlElement(ElementName = "CyclePreviousHostileTarget")]
    public CyclePreviousHostileTarget CyclePreviousHostileTarget { get; set; }

    [XmlElement(ElementName = "TargetWingman0")]
    public TargetWingman0 TargetWingman0 { get; set; }

    [XmlElement(ElementName = "TargetWingman1")]
    public TargetWingman1 TargetWingman1 { get; set; }

    [XmlElement(ElementName = "TargetWingman2")]
    public TargetWingman2 TargetWingman2 { get; set; }

    [XmlElement(ElementName = "SelectTargetsTarget")]
    public SelectTargetsTarget SelectTargetsTarget { get; set; }

    [XmlElement(ElementName = "WingNavLock")]
    public WingNavLock WingNavLock { get; set; }

    [XmlElement(ElementName = "CycleNextSubsystem")]
    public CycleNextSubsystem CycleNextSubsystem { get; set; }

    [XmlElement(ElementName = "CyclePreviousSubsystem")]
    public CyclePreviousSubsystem CyclePreviousSubsystem { get; set; }

    [XmlElement(ElementName = "TargetNextRouteSystem")]
    public TargetNextRouteSystem TargetNextRouteSystem { get; set; }

    [XmlElement(ElementName = "PrimaryFire")]
    public PrimaryFire PrimaryFire { get; set; }

    [XmlElement(ElementName = "SecondaryFire")]
    public SecondaryFire SecondaryFire { get; set; }

    [XmlElement(ElementName = "CycleFireGroupNext")]
    public CycleFireGroupNext CycleFireGroupNext { get; set; }

    [XmlElement(ElementName = "CycleFireGroupPrevious")]
    public CycleFireGroupPrevious CycleFireGroupPrevious { get; set; }

    [XmlElement(ElementName = "DeployHardpointToggle")]
    public DeployHardpointToggle DeployHardpointToggle { get; set; }

    [XmlElement(ElementName = "DeployHardpointsOnFire")]
    public DeployHardpointsOnFire DeployHardpointsOnFire { get; set; }

    [XmlElement(ElementName = "ToggleButtonUpInput")]
    public ToggleButtonUpInput ToggleButtonUpInput { get; set; }

    [XmlElement(ElementName = "DeployHeatSink")]
    public DeployHeatSink DeployHeatSink { get; set; }

    [XmlElement(ElementName = "ShipSpotLightToggle")]
    public ShipSpotLightToggle ShipSpotLightToggle { get; set; }

    [XmlElement(ElementName = "RadarRangeAxis")]
    public RadarRangeAxis RadarRangeAxis { get; set; }

    [XmlElement(ElementName = "RadarIncreaseRange")]
    public RadarIncreaseRange RadarIncreaseRange { get; set; }

    [XmlElement(ElementName = "RadarDecreaseRange")]
    public RadarDecreaseRange RadarDecreaseRange { get; set; }

    [XmlElement(ElementName = "IncreaseEnginesPower")]
    public IncreaseEnginesPower IncreaseEnginesPower { get; set; }

    [XmlElement(ElementName = "IncreaseWeaponsPower")]
    public IncreaseWeaponsPower IncreaseWeaponsPower { get; set; }

    [XmlElement(ElementName = "IncreaseSystemsPower")]
    public IncreaseSystemsPower IncreaseSystemsPower { get; set; }

    [XmlElement(ElementName = "ResetPowerDistribution")]
    public ResetPowerDistribution ResetPowerDistribution { get; set; }

    [XmlElement(ElementName = "HMDReset")]
    public HMDReset HMDReset { get; set; }

    [XmlElement(ElementName = "ToggleCargoScoop")]
    public ToggleCargoScoop ToggleCargoScoop { get; set; }

    [XmlElement(ElementName = "EjectAllCargo")]
    public EjectAllCargo EjectAllCargo { get; set; }

    [XmlElement(ElementName = "LandingGearToggle")]
    public LandingGearToggle LandingGearToggle { get; set; }

    [XmlElement(ElementName = "MicrophoneMute")]
    public MicrophoneMute MicrophoneMute { get; set; }

    [XmlElement(ElementName = "MuteButtonMode")]
    public MuteButtonMode MuteButtonMode { get; set; }

    [XmlElement(ElementName = "CqcMuteButtonMode")]
    public CqcMuteButtonMode CqcMuteButtonMode { get; set; }

    [XmlElement(ElementName = "UseShieldCell")]
    public UseShieldCell UseShieldCell { get; set; }

    [XmlElement(ElementName = "FireChaffLauncher")]
    public FireChaffLauncher FireChaffLauncher { get; set; }

    [XmlElement(ElementName = "ChargeECM")]
    public ChargeECM ChargeECM { get; set; }

    [XmlElement(ElementName = "EnableRumbleTrigger")]
    public EnableRumbleTrigger EnableRumbleTrigger { get; set; }

    [XmlElement(ElementName = "EnableMenuGroups")]
    public EnableMenuGroups EnableMenuGroups { get; set; }

    [XmlElement(ElementName = "WeaponColourToggle")]
    public WeaponColourToggle WeaponColourToggle { get; set; }

    [XmlElement(ElementName = "EngineColourToggle")]
    public EngineColourToggle EngineColourToggle { get; set; }

    [XmlElement(ElementName = "NightVisionToggle")]
    public NightVisionToggle NightVisionToggle { get; set; }

    [XmlElement(ElementName = "UIFocus")]
    public UIFocus UIFocus { get; set; }

    [XmlElement(ElementName = "UIFocusMode")]
    public UIFocusMode UIFocusMode { get; set; }

    [XmlElement(ElementName = "FocusLeftPanel")]
    public FocusLeftPanel FocusLeftPanel { get; set; }

    [XmlElement(ElementName = "FocusCommsPanel")]
    public FocusCommsPanel FocusCommsPanel { get; set; }

    [XmlElement(ElementName = "FocusOnTextEntryField")]
    public FocusOnTextEntryField FocusOnTextEntryField { get; set; }

    [XmlElement(ElementName = "QuickCommsPanel")]
    public QuickCommsPanel QuickCommsPanel { get; set; }

    [XmlElement(ElementName = "FocusRadarPanel")]
    public FocusRadarPanel FocusRadarPanel { get; set; }

    [XmlElement(ElementName = "FocusRightPanel")]
    public FocusRightPanel FocusRightPanel { get; set; }

    [XmlElement(ElementName = "LeftPanelFocusOptions")]
    public LeftPanelFocusOptions LeftPanelFocusOptions { get; set; }

    [XmlElement(ElementName = "CommsPanelFocusOptions")]
    public CommsPanelFocusOptions CommsPanelFocusOptions { get; set; }

    [XmlElement(ElementName = "RolePanelFocusOptions")]
    public RolePanelFocusOptions RolePanelFocusOptions { get; set; }

    [XmlElement(ElementName = "RightPanelFocusOptions")]
    public RightPanelFocusOptions RightPanelFocusOptions { get; set; }

    [XmlElement(ElementName = "EnableCameraLockOn")]
    public EnableCameraLockOn EnableCameraLockOn { get; set; }

    [XmlElement(ElementName = "GalaxyMapOpen")]
    public GalaxyMapOpen GalaxyMapOpen { get; set; }

    [XmlElement(ElementName = "SystemMapOpen")]
    public SystemMapOpen SystemMapOpen { get; set; }

    [XmlElement(ElementName = "ShowPGScoreSummaryInput")]
    public ShowPGScoreSummaryInput ShowPGScoreSummaryInput { get; set; }

    [XmlElement(ElementName = "HeadLookToggle")]
    public HeadLookToggle HeadLookToggle { get; set; }

    [XmlElement(ElementName = "Pause")]
    public Pause Pause { get; set; }

    [XmlElement(ElementName = "FriendsMenu")]
    public FriendsMenu FriendsMenu { get; set; }

    [XmlElement(ElementName = "OpenCodexGoToDiscovery")]
    public OpenCodexGoToDiscovery OpenCodexGoToDiscovery { get; set; }

    [XmlElement(ElementName = "PlayerHUDModeToggle")]
    public PlayerHUDModeToggle PlayerHUDModeToggle { get; set; }

    [XmlElement(ElementName = "ExplorationFSSEnter")]
    public ExplorationFSSEnter ExplorationFSSEnter { get; set; }

    [XmlElement(ElementName = "UI_Up")]
    public UIUp UIUp { get; set; }

    [XmlElement(ElementName = "UI_Down")]
    public UIDown UIDown { get; set; }

    [XmlElement(ElementName = "UI_Left")]
    public UILeft UILeft { get; set; }

    [XmlElement(ElementName = "UI_Right")]
    public UIRight UIRight { get; set; }

    [XmlElement(ElementName = "UI_Select")]
    public UISelect UISelect { get; set; }

    [XmlElement(ElementName = "UI_Back")]
    public UIBack UIBack { get; set; }

    [XmlElement(ElementName = "UI_Toggle")]
    public UIToggle UIToggle { get; set; }

    [XmlElement(ElementName = "CycleNextPanel")]
    public CycleNextPanel CycleNextPanel { get; set; }

    [XmlElement(ElementName = "CyclePreviousPanel")]
    public CyclePreviousPanel CyclePreviousPanel { get; set; }

    [XmlElement(ElementName = "CycleNextPage")]
    public CycleNextPage CycleNextPage { get; set; }

    [XmlElement(ElementName = "CyclePreviousPage")]
    public CyclePreviousPage CyclePreviousPage { get; set; }

    [XmlElement(ElementName = "MouseHeadlook")]
    public MouseHeadlook MouseHeadlook { get; set; }

    [XmlElement(ElementName = "MouseHeadlookInvert")]
    public MouseHeadlookInvert MouseHeadlookInvert { get; set; }

    [XmlElement(ElementName = "MouseHeadlookSensitivity")]
    public MouseHeadlookSensitivity MouseHeadlookSensitivity { get; set; }

    [XmlElement(ElementName = "HeadlookDefault")]
    public HeadlookDefault HeadlookDefault { get; set; }

    [XmlElement(ElementName = "HeadlookIncrement")]
    public HeadlookIncrement HeadlookIncrement { get; set; }

    [XmlElement(ElementName = "HeadlookMode")]
    public HeadlookMode HeadlookMode { get; set; }

    [XmlElement(ElementName = "HeadlookResetOnToggle")]
    public HeadlookResetOnToggle HeadlookResetOnToggle { get; set; }

    [XmlElement(ElementName = "HeadlookSensitivity")]
    public HeadlookSensitivity HeadlookSensitivity { get; set; }

    [XmlElement(ElementName = "HeadlookSmoothing")]
    public HeadlookSmoothing HeadlookSmoothing { get; set; }

    [XmlElement(ElementName = "HeadLookReset")]
    public HeadLookReset HeadLookReset { get; set; }

    [XmlElement(ElementName = "HeadLookPitchUp")]
    public HeadLookPitchUp HeadLookPitchUp { get; set; }

    [XmlElement(ElementName = "HeadLookPitchDown")]
    public HeadLookPitchDown HeadLookPitchDown { get; set; }

    [XmlElement(ElementName = "HeadLookPitchAxisRaw")]
    public HeadLookPitchAxisRaw HeadLookPitchAxisRaw { get; set; }

    [XmlElement(ElementName = "HeadLookYawLeft")]
    public HeadLookYawLeft HeadLookYawLeft { get; set; }

    [XmlElement(ElementName = "HeadLookYawRight")]
    public HeadLookYawRight HeadLookYawRight { get; set; }

    [XmlElement(ElementName = "HeadLookYawAxis")]
    public HeadLookYawAxis HeadLookYawAxis { get; set; }

    [XmlElement(ElementName = "MotionHeadlook")]
    public MotionHeadlook MotionHeadlook { get; set; }

    [XmlElement(ElementName = "HeadlookMotionSensitivity")]
    public HeadlookMotionSensitivity HeadlookMotionSensitivity { get; set; }

    [XmlElement(ElementName = "yawRotateHeadlook")]
    public YawRotateHeadlook YawRotateHeadlook { get; set; }

    [XmlElement(ElementName = "CamPitchAxis")]
    public CamPitchAxis CamPitchAxis { get; set; }

    [XmlElement(ElementName = "CamPitchUp")]
    public CamPitchUp CamPitchUp { get; set; }

    [XmlElement(ElementName = "CamPitchDown")]
    public CamPitchDown CamPitchDown { get; set; }

    [XmlElement(ElementName = "CamYawAxis")]
    public CamYawAxis CamYawAxis { get; set; }

    [XmlElement(ElementName = "CamYawLeft")]
    public CamYawLeft CamYawLeft { get; set; }

    [XmlElement(ElementName = "CamYawRight")]
    public CamYawRight CamYawRight { get; set; }

    [XmlElement(ElementName = "CamTranslateYAxis")]
    public CamTranslateYAxis CamTranslateYAxis { get; set; }

    [XmlElement(ElementName = "CamTranslateForward")]
    public CamTranslateForward CamTranslateForward { get; set; }

    [XmlElement(ElementName = "CamTranslateBackward")]
    public CamTranslateBackward CamTranslateBackward { get; set; }

    [XmlElement(ElementName = "CamTranslateXAxis")]
    public CamTranslateXAxis CamTranslateXAxis { get; set; }

    [XmlElement(ElementName = "CamTranslateLeft")]
    public CamTranslateLeft CamTranslateLeft { get; set; }

    [XmlElement(ElementName = "CamTranslateRight")]
    public CamTranslateRight CamTranslateRight { get; set; }

    [XmlElement(ElementName = "CamTranslateZAxis")]
    public CamTranslateZAxis CamTranslateZAxis { get; set; }

    [XmlElement(ElementName = "CamTranslateUp")]
    public CamTranslateUp CamTranslateUp { get; set; }

    [XmlElement(ElementName = "CamTranslateDown")]
    public CamTranslateDown CamTranslateDown { get; set; }

    [XmlElement(ElementName = "CamZoomAxis")]
    public CamZoomAxis CamZoomAxis { get; set; }

    [XmlElement(ElementName = "CamZoomIn")]
    public CamZoomIn CamZoomIn { get; set; }

    [XmlElement(ElementName = "CamZoomOut")]
    public CamZoomOut CamZoomOut { get; set; }

    [XmlElement(ElementName = "CamTranslateZHold")]
    public CamTranslateZHold CamTranslateZHold { get; set; }

    [XmlElement(ElementName = "GalaxyMapHome")]
    public GalaxyMapHome GalaxyMapHome { get; set; }

    [XmlElement(ElementName = "ToggleDriveAssist")]
    public ToggleDriveAssist ToggleDriveAssist { get; set; }

    [XmlElement(ElementName = "DriveAssistDefault")]
    public DriveAssistDefault DriveAssistDefault { get; set; }

    [XmlElement(ElementName = "MouseBuggySteeringXMode")]
    public MouseBuggySteeringXMode MouseBuggySteeringXMode { get; set; }

    [XmlElement(ElementName = "MouseBuggySteeringXDecay")]
    public MouseBuggySteeringXDecay MouseBuggySteeringXDecay { get; set; }

    [XmlElement(ElementName = "MouseBuggyRollingXMode")]
    public MouseBuggyRollingXMode MouseBuggyRollingXMode { get; set; }

    [XmlElement(ElementName = "MouseBuggyRollingXDecay")]
    public MouseBuggyRollingXDecay MouseBuggyRollingXDecay { get; set; }

    [XmlElement(ElementName = "MouseBuggyYMode")]
    public MouseBuggyYMode MouseBuggyYMode { get; set; }

    [XmlElement(ElementName = "MouseBuggyYDecay")]
    public MouseBuggyYDecay MouseBuggyYDecay { get; set; }

    [XmlElement(ElementName = "SteeringAxis")]
    public SteeringAxis SteeringAxis { get; set; }

    [XmlElement(ElementName = "SteerLeftButton")]
    public SteerLeftButton SteerLeftButton { get; set; }

    [XmlElement(ElementName = "SteerRightButton")]
    public SteerRightButton SteerRightButton { get; set; }

    [XmlElement(ElementName = "BuggyRollAxisRaw")]
    public BuggyRollAxisRaw BuggyRollAxisRaw { get; set; }

    [XmlElement(ElementName = "BuggyRollLeftButton")]
    public BuggyRollLeftButton BuggyRollLeftButton { get; set; }

    [XmlElement(ElementName = "BuggyRollRightButton")]
    public BuggyRollRightButton BuggyRollRightButton { get; set; }

    [XmlElement(ElementName = "BuggyPitchAxis")]
    public BuggyPitchAxis BuggyPitchAxis { get; set; }

    [XmlElement(ElementName = "BuggyPitchUpButton")]
    public BuggyPitchUpButton BuggyPitchUpButton { get; set; }

    [XmlElement(ElementName = "BuggyPitchDownButton")]
    public BuggyPitchDownButton BuggyPitchDownButton { get; set; }

    [XmlElement(ElementName = "VerticalThrustersButton")]
    public VerticalThrustersButton VerticalThrustersButton { get; set; }

    [XmlElement(ElementName = "BuggyPrimaryFireButton")]
    public BuggyPrimaryFireButton BuggyPrimaryFireButton { get; set; }

    [XmlElement(ElementName = "BuggySecondaryFireButton")]
    public BuggySecondaryFireButton BuggySecondaryFireButton { get; set; }

    [XmlElement(ElementName = "AutoBreakBuggyButton")]
    public AutoBreakBuggyButton AutoBreakBuggyButton { get; set; }

    [XmlElement(ElementName = "HeadlightsBuggyButton")]
    public HeadlightsBuggyButton HeadlightsBuggyButton { get; set; }

    [XmlElement(ElementName = "ToggleBuggyTurretButton")]
    public ToggleBuggyTurretButton ToggleBuggyTurretButton { get; set; }

    [XmlElement(ElementName = "BuggyCycleFireGroupNext")]
    public BuggyCycleFireGroupNext BuggyCycleFireGroupNext { get; set; }

    [XmlElement(ElementName = "BuggyCycleFireGroupPrevious")]
    public BuggyCycleFireGroupPrevious BuggyCycleFireGroupPrevious { get; set; }

    [XmlElement(ElementName = "SelectTarget_Buggy")]
    public SelectTargetBuggy SelectTargetBuggy { get; set; }

    [XmlElement(ElementName = "MouseTurretXMode")]
    public MouseTurretXMode MouseTurretXMode { get; set; }

    [XmlElement(ElementName = "MouseTurretXDecay")]
    public MouseTurretXDecay MouseTurretXDecay { get; set; }

    [XmlElement(ElementName = "MouseTurretYMode")]
    public MouseTurretYMode MouseTurretYMode { get; set; }

    [XmlElement(ElementName = "MouseTurretYDecay")]
    public MouseTurretYDecay MouseTurretYDecay { get; set; }

    [XmlElement(ElementName = "BuggyTurretYawAxisRaw")]
    public BuggyTurretYawAxisRaw BuggyTurretYawAxisRaw { get; set; }

    [XmlElement(ElementName = "BuggyTurretYawLeftButton")]
    public BuggyTurretYawLeftButton BuggyTurretYawLeftButton { get; set; }

    [XmlElement(ElementName = "BuggyTurretYawRightButton")]
    public BuggyTurretYawRightButton BuggyTurretYawRightButton { get; set; }

    [XmlElement(ElementName = "BuggyTurretPitchAxisRaw")]
    public BuggyTurretPitchAxisRaw BuggyTurretPitchAxisRaw { get; set; }

    [XmlElement(ElementName = "BuggyTurretPitchUpButton")]
    public BuggyTurretPitchUpButton BuggyTurretPitchUpButton { get; set; }

    [XmlElement(ElementName = "BuggyTurretPitchDownButton")]
    public BuggyTurretPitchDownButton BuggyTurretPitchDownButton { get; set; }

    [XmlElement(ElementName = "BuggyTurretMouseSensitivity")]
    public BuggyTurretMouseSensitivity BuggyTurretMouseSensitivity { get; set; }

    [XmlElement(ElementName = "BuggyTurretMouseDeadzone")]
    public BuggyTurretMouseDeadzone BuggyTurretMouseDeadzone { get; set; }

    [XmlElement(ElementName = "BuggyTurretMouseLinearity")]
    public BuggyTurretMouseLinearity BuggyTurretMouseLinearity { get; set; }

    [XmlElement(ElementName = "DriveSpeedAxis")]
    public DriveSpeedAxis DriveSpeedAxis { get; set; }

    [XmlElement(ElementName = "BuggyThrottleRange")]
    public BuggyThrottleRange BuggyThrottleRange { get; set; }

    [XmlElement(ElementName = "BuggyToggleReverseThrottleInput")]
    public BuggyToggleReverseThrottleInput BuggyToggleReverseThrottleInput { get; set; }

    [XmlElement(ElementName = "BuggyThrottleIncrement")]
    public BuggyThrottleIncrement BuggyThrottleIncrement { get; set; }

    [XmlElement(ElementName = "IncreaseSpeedButtonMax")]
    public IncreaseSpeedButtonMax IncreaseSpeedButtonMax { get; set; }

    [XmlElement(ElementName = "DecreaseSpeedButtonMax")]
    public DecreaseSpeedButtonMax DecreaseSpeedButtonMax { get; set; }

    [XmlElement(ElementName = "IncreaseSpeedButtonPartial")]
    public IncreaseSpeedButtonPartial IncreaseSpeedButtonPartial { get; set; }

    [XmlElement(ElementName = "DecreaseSpeedButtonPartial")]
    public DecreaseSpeedButtonPartial DecreaseSpeedButtonPartial { get; set; }

    [XmlElement(ElementName = "IncreaseEnginesPower_Buggy")]
    public IncreaseEnginesPowerBuggy IncreaseEnginesPowerBuggy { get; set; }

    [XmlElement(ElementName = "IncreaseWeaponsPower_Buggy")]
    public IncreaseWeaponsPowerBuggy IncreaseWeaponsPowerBuggy { get; set; }

    [XmlElement(ElementName = "IncreaseSystemsPower_Buggy")]
    public IncreaseSystemsPowerBuggy IncreaseSystemsPowerBuggy { get; set; }

    [XmlElement(ElementName = "ResetPowerDistribution_Buggy")]
    public ResetPowerDistributionBuggy ResetPowerDistributionBuggy { get; set; }

    [XmlElement(ElementName = "ToggleCargoScoop_Buggy")]
    public ToggleCargoScoopBuggy ToggleCargoScoopBuggy { get; set; }

    [XmlElement(ElementName = "EjectAllCargo_Buggy")]
    public EjectAllCargoBuggy EjectAllCargoBuggy { get; set; }

    [XmlElement(ElementName = "RecallDismissShip")]
    public RecallDismissShip RecallDismissShip { get; set; }

    [XmlElement(ElementName = "EnableMenuGroupsSRV")]
    public EnableMenuGroupsSRV EnableMenuGroupsSRV { get; set; }

    [XmlElement(ElementName = "UIFocus_Buggy")]
    public UIFocusBuggy UIFocusBuggy { get; set; }

    [XmlElement(ElementName = "FocusLeftPanel_Buggy")]
    public FocusLeftPanelBuggy FocusLeftPanelBuggy { get; set; }

    [XmlElement(ElementName = "FocusCommsPanel_Buggy")]
    public FocusCommsPanelBuggy FocusCommsPanelBuggy { get; set; }

    [XmlElement(ElementName = "QuickCommsPanel_Buggy")]
    public QuickCommsPanelBuggy QuickCommsPanelBuggy { get; set; }

    [XmlElement(ElementName = "FocusRadarPanel_Buggy")]
    public FocusRadarPanelBuggy FocusRadarPanelBuggy { get; set; }

    [XmlElement(ElementName = "FocusRightPanel_Buggy")]
    public FocusRightPanelBuggy FocusRightPanelBuggy { get; set; }

    [XmlElement(ElementName = "GalaxyMapOpen_Buggy")]
    public GalaxyMapOpenBuggy GalaxyMapOpenBuggy { get; set; }

    [XmlElement(ElementName = "SystemMapOpen_Buggy")]
    public SystemMapOpenBuggy SystemMapOpenBuggy { get; set; }

    [XmlElement(ElementName = "OpenCodexGoToDiscovery_Buggy")]
    public OpenCodexGoToDiscoveryBuggy OpenCodexGoToDiscoveryBuggy { get; set; }

    [XmlElement(ElementName = "PlayerHUDModeToggle_Buggy")]
    public PlayerHUDModeToggleBuggy PlayerHUDModeToggleBuggy { get; set; }

    [XmlElement(ElementName = "HeadLookToggle_Buggy")]
    public HeadLookToggleBuggy HeadLookToggleBuggy { get; set; }

    [XmlElement(ElementName = "MultiCrewToggleMode")]
    public MultiCrewToggleMode MultiCrewToggleMode { get; set; }

    [XmlElement(ElementName = "MultiCrewPrimaryFire")]
    public MultiCrewPrimaryFire MultiCrewPrimaryFire { get; set; }

    [XmlElement(ElementName = "MultiCrewSecondaryFire")]
    public MultiCrewSecondaryFire MultiCrewSecondaryFire { get; set; }

    [XmlElement(ElementName = "MultiCrewPrimaryUtilityFire")]
    public MultiCrewPrimaryUtilityFire MultiCrewPrimaryUtilityFire { get; set; }

    [XmlElement(ElementName = "MultiCrewSecondaryUtilityFire")]
    public MultiCrewSecondaryUtilityFire MultiCrewSecondaryUtilityFire { get; set; }

    [XmlElement(ElementName = "MultiCrewThirdPersonMouseXMode")]
    public MultiCrewThirdPersonMouseXMode MultiCrewThirdPersonMouseXMode { get; set; }

    [XmlElement(ElementName = "MultiCrewThirdPersonMouseXDecay")]
    public MultiCrewThirdPersonMouseXDecay MultiCrewThirdPersonMouseXDecay { get; set; }

    [XmlElement(ElementName = "MultiCrewThirdPersonMouseYMode")]
    public MultiCrewThirdPersonMouseYMode MultiCrewThirdPersonMouseYMode { get; set; }

    [XmlElement(ElementName = "MultiCrewThirdPersonMouseYDecay")]
    public MultiCrewThirdPersonMouseYDecay MultiCrewThirdPersonMouseYDecay { get; set; }

    [XmlElement(ElementName = "MultiCrewThirdPersonYawAxisRaw")]
    public MultiCrewThirdPersonYawAxisRaw MultiCrewThirdPersonYawAxisRaw { get; set; }

    [XmlElement(ElementName = "MultiCrewThirdPersonYawLeftButton")]
    public MultiCrewThirdPersonYawLeftButton MultiCrewThirdPersonYawLeftButton { get; set; }

    [XmlElement(ElementName = "MultiCrewThirdPersonYawRightButton")]
    public MultiCrewThirdPersonYawRightButton MultiCrewThirdPersonYawRightButton { get; set; }

    [XmlElement(ElementName = "MultiCrewThirdPersonPitchAxisRaw")]
    public MultiCrewThirdPersonPitchAxisRaw MultiCrewThirdPersonPitchAxisRaw { get; set; }

    [XmlElement(ElementName = "MultiCrewThirdPersonPitchUpButton")]
    public MultiCrewThirdPersonPitchUpButton MultiCrewThirdPersonPitchUpButton { get; set; }

    [XmlElement(ElementName = "MultiCrewThirdPersonPitchDownButton")]
    public MultiCrewThirdPersonPitchDownButton MultiCrewThirdPersonPitchDownButton { get; set; }

    [XmlElement(ElementName = "MultiCrewThirdPersonMouseSensitivity")]
    public MultiCrewThirdPersonMouseSensitivity MultiCrewThirdPersonMouseSensitivity { get; set; }

    [XmlElement(ElementName = "MultiCrewThirdPersonFovAxisRaw")]
    public MultiCrewThirdPersonFovAxisRaw MultiCrewThirdPersonFovAxisRaw { get; set; }

    [XmlElement(ElementName = "MultiCrewThirdPersonFovOutButton")]
    public MultiCrewThirdPersonFovOutButton MultiCrewThirdPersonFovOutButton { get; set; }

    [XmlElement(ElementName = "MultiCrewThirdPersonFovInButton")]
    public MultiCrewThirdPersonFovInButton MultiCrewThirdPersonFovInButton { get; set; }

    [XmlElement(ElementName = "MultiCrewCockpitUICycleForward")]
    public MultiCrewCockpitUICycleForward MultiCrewCockpitUICycleForward { get; set; }

    [XmlElement(ElementName = "MultiCrewCockpitUICycleBackward")]
    public MultiCrewCockpitUICycleBackward MultiCrewCockpitUICycleBackward { get; set; }

    [XmlElement(ElementName = "OrderRequestDock")]
    public OrderRequestDock OrderRequestDock { get; set; }

    [XmlElement(ElementName = "OrderDefensiveBehaviour")]
    public OrderDefensiveBehaviour OrderDefensiveBehaviour { get; set; }

    [XmlElement(ElementName = "OrderAggressiveBehaviour")]
    public OrderAggressiveBehaviour OrderAggressiveBehaviour { get; set; }

    [XmlElement(ElementName = "OrderFocusTarget")]
    public OrderFocusTarget OrderFocusTarget { get; set; }

    [XmlElement(ElementName = "OrderHoldFire")]
    public OrderHoldFire OrderHoldFire { get; set; }

    [XmlElement(ElementName = "OrderHoldPosition")]
    public OrderHoldPosition OrderHoldPosition { get; set; }

    [XmlElement(ElementName = "OrderFollow")]
    public OrderFollow OrderFollow { get; set; }

    [XmlElement(ElementName = "OpenOrders")]
    public OpenOrders OpenOrders { get; set; }

    [XmlElement(ElementName = "PhotoCameraToggle")]
    public PhotoCameraToggle PhotoCameraToggle { get; set; }

    [XmlElement(ElementName = "PhotoCameraToggle_Buggy")]
    public PhotoCameraToggleBuggy PhotoCameraToggleBuggy { get; set; }

    [XmlElement(ElementName = "PhotoCameraToggle_Humanoid")]
    public PhotoCameraToggleHumanoid PhotoCameraToggleHumanoid { get; set; }

    [XmlElement(ElementName = "VanityCameraScrollLeft")]
    public VanityCameraScrollLeft VanityCameraScrollLeft { get; set; }

    [XmlElement(ElementName = "VanityCameraScrollRight")]
    public VanityCameraScrollRight VanityCameraScrollRight { get; set; }

    [XmlElement(ElementName = "ToggleFreeCam")]
    public ToggleFreeCam ToggleFreeCam { get; set; }

    [XmlElement(ElementName = "VanityCameraOne")]
    public VanityCameraOne VanityCameraOne { get; set; }

    [XmlElement(ElementName = "VanityCameraTwo")]
    public VanityCameraTwo VanityCameraTwo { get; set; }

    [XmlElement(ElementName = "VanityCameraThree")]
    public VanityCameraThree VanityCameraThree { get; set; }

    [XmlElement(ElementName = "VanityCameraFour")]
    public VanityCameraFour VanityCameraFour { get; set; }

    [XmlElement(ElementName = "VanityCameraFive")]
    public VanityCameraFive VanityCameraFive { get; set; }

    [XmlElement(ElementName = "VanityCameraSix")]
    public VanityCameraSix VanityCameraSix { get; set; }

    [XmlElement(ElementName = "VanityCameraSeven")]
    public VanityCameraSeven VanityCameraSeven { get; set; }

    [XmlElement(ElementName = "VanityCameraEight")]
    public VanityCameraEight VanityCameraEight { get; set; }

    [XmlElement(ElementName = "VanityCameraNine")]
    public VanityCameraNine VanityCameraNine { get; set; }

    [XmlElement(ElementName = "VanityCameraTen")]
    public VanityCameraTen VanityCameraTen { get; set; }

    [XmlElement(ElementName = "FreeCamToggleHUD")]
    public FreeCamToggleHUD FreeCamToggleHUD { get; set; }

    [XmlElement(ElementName = "FreeCamSpeedInc")]
    public FreeCamSpeedInc FreeCamSpeedInc { get; set; }

    [XmlElement(ElementName = "FreeCamSpeedDec")]
    public FreeCamSpeedDec FreeCamSpeedDec { get; set; }

    [XmlElement(ElementName = "MoveFreeCamY")]
    public MoveFreeCamY MoveFreeCamY { get; set; }

    [XmlElement(ElementName = "ThrottleRangeFreeCam")]
    public ThrottleRangeFreeCam ThrottleRangeFreeCam { get; set; }

    [XmlElement(ElementName = "ToggleReverseThrottleInputFreeCam")]
    public ToggleReverseThrottleInputFreeCam ToggleReverseThrottleInputFreeCam { get; set; }

    [XmlElement(ElementName = "MoveFreeCamForward")]
    public MoveFreeCamForward MoveFreeCamForward { get; set; }

    [XmlElement(ElementName = "MoveFreeCamBackwards")]
    public MoveFreeCamBackwards MoveFreeCamBackwards { get; set; }

    [XmlElement(ElementName = "MoveFreeCamX")]
    public MoveFreeCamX MoveFreeCamX { get; set; }

    [XmlElement(ElementName = "MoveFreeCamRight")]
    public MoveFreeCamRight MoveFreeCamRight { get; set; }

    [XmlElement(ElementName = "MoveFreeCamLeft")]
    public MoveFreeCamLeft MoveFreeCamLeft { get; set; }

    [XmlElement(ElementName = "MoveFreeCamZ")]
    public MoveFreeCamZ MoveFreeCamZ { get; set; }

    [XmlElement(ElementName = "MoveFreeCamUpAxis")]
    public MoveFreeCamUpAxis MoveFreeCamUpAxis { get; set; }

    [XmlElement(ElementName = "MoveFreeCamDownAxis")]
    public MoveFreeCamDownAxis MoveFreeCamDownAxis { get; set; }

    [XmlElement(ElementName = "MoveFreeCamUp")]
    public MoveFreeCamUp MoveFreeCamUp { get; set; }

    [XmlElement(ElementName = "MoveFreeCamDown")]
    public MoveFreeCamDown MoveFreeCamDown { get; set; }

    [XmlElement(ElementName = "PitchCameraMouse")]
    public PitchCameraMouse PitchCameraMouse { get; set; }

    [XmlElement(ElementName = "YawCameraMouse")]
    public YawCameraMouse YawCameraMouse { get; set; }

    [XmlElement(ElementName = "PitchCamera")]
    public PitchCamera PitchCamera { get; set; }

    [XmlElement(ElementName = "FreeCamMouseSensitivity")]
    public FreeCamMouseSensitivity FreeCamMouseSensitivity { get; set; }

    [XmlElement(ElementName = "FreeCamMouseYDecay")]
    public FreeCamMouseYDecay FreeCamMouseYDecay { get; set; }

    [XmlElement(ElementName = "PitchCameraUp")]
    public PitchCameraUp PitchCameraUp { get; set; }

    [XmlElement(ElementName = "PitchCameraDown")]
    public PitchCameraDown PitchCameraDown { get; set; }

    [XmlElement(ElementName = "YawCamera")]
    public YawCamera YawCamera { get; set; }

    [XmlElement(ElementName = "FreeCamMouseXDecay")]
    public FreeCamMouseXDecay FreeCamMouseXDecay { get; set; }

    [XmlElement(ElementName = "YawCameraLeft")]
    public YawCameraLeft YawCameraLeft { get; set; }

    [XmlElement(ElementName = "YawCameraRight")]
    public YawCameraRight YawCameraRight { get; set; }

    [XmlElement(ElementName = "RollCamera")]
    public RollCamera RollCamera { get; set; }

    [XmlElement(ElementName = "RollCameraLeft")]
    public RollCameraLeft RollCameraLeft { get; set; }

    [XmlElement(ElementName = "RollCameraRight")]
    public RollCameraRight RollCameraRight { get; set; }

    [XmlElement(ElementName = "ToggleRotationLock")]
    public ToggleRotationLock ToggleRotationLock { get; set; }

    [XmlElement(ElementName = "FixCameraRelativeToggle")]
    public FixCameraRelativeToggle FixCameraRelativeToggle { get; set; }

    [XmlElement(ElementName = "FixCameraWorldToggle")]
    public FixCameraWorldToggle FixCameraWorldToggle { get; set; }

    [XmlElement(ElementName = "QuitCamera")]
    public QuitCamera QuitCamera { get; set; }

    [XmlElement(ElementName = "ToggleAdvanceMode")]
    public ToggleAdvanceMode ToggleAdvanceMode { get; set; }

    [XmlElement(ElementName = "FreeCamZoomIn")]
    public FreeCamZoomIn FreeCamZoomIn { get; set; }

    [XmlElement(ElementName = "FreeCamZoomOut")]
    public FreeCamZoomOut FreeCamZoomOut { get; set; }

    [XmlElement(ElementName = "FStopDec")]
    public FStopDec FStopDec { get; set; }

    [XmlElement(ElementName = "FStopInc")]
    public FStopInc FStopInc { get; set; }

    [XmlElement(ElementName = "CommanderCreator_Undo")]
    public CommanderCreatorUndo CommanderCreatorUndo { get; set; }

    [XmlElement(ElementName = "CommanderCreator_Redo")]
    public CommanderCreatorRedo CommanderCreatorRedo { get; set; }

    [XmlElement(ElementName = "CommanderCreator_Rotation_MouseToggle")]
    public CommanderCreatorRotationMouseToggle CommanderCreatorRotationMouseToggle { get; set; }

    [XmlElement(ElementName = "CommanderCreator_Rotation")]
    public CommanderCreatorRotation CommanderCreatorRotation { get; set; }

    [XmlElement(ElementName = "GalnetAudio_Play_Pause")]
    public GalnetAudioPlayPause GalnetAudioPlayPause { get; set; }

    [XmlElement(ElementName = "GalnetAudio_SkipForward")]
    public GalnetAudioSkipForward GalnetAudioSkipForward { get; set; }

    [XmlElement(ElementName = "GalnetAudio_SkipBackward")]
    public GalnetAudioSkipBackward GalnetAudioSkipBackward { get; set; }

    [XmlElement(ElementName = "GalnetAudio_ClearQueue")]
    public GalnetAudioClearQueue GalnetAudioClearQueue { get; set; }

    [XmlElement(ElementName = "ExplorationFSSCameraPitch")]
    public ExplorationFSSCameraPitch ExplorationFSSCameraPitch { get; set; }

    [XmlElement(ElementName = "ExplorationFSSCameraPitchIncreaseButton")]
    public ExplorationFSSCameraPitchIncreaseButton ExplorationFSSCameraPitchIncreaseButton { get; set; }

    [XmlElement(ElementName = "ExplorationFSSCameraPitchDecreaseButton")]
    public ExplorationFSSCameraPitchDecreaseButton ExplorationFSSCameraPitchDecreaseButton { get; set; }

    [XmlElement(ElementName = "ExplorationFSSCameraYaw")]
    public ExplorationFSSCameraYaw ExplorationFSSCameraYaw { get; set; }

    [XmlElement(ElementName = "ExplorationFSSCameraYawIncreaseButton")]
    public ExplorationFSSCameraYawIncreaseButton ExplorationFSSCameraYawIncreaseButton { get; set; }

    [XmlElement(ElementName = "ExplorationFSSCameraYawDecreaseButton")]
    public ExplorationFSSCameraYawDecreaseButton ExplorationFSSCameraYawDecreaseButton { get; set; }

    [XmlElement(ElementName = "ExplorationFSSZoomIn")]
    public ExplorationFSSZoomIn ExplorationFSSZoomIn { get; set; }

    [XmlElement(ElementName = "ExplorationFSSZoomOut")]
    public ExplorationFSSZoomOut ExplorationFSSZoomOut { get; set; }

    [XmlElement(ElementName = "ExplorationFSSMiniZoomIn")]
    public ExplorationFSSMiniZoomIn ExplorationFSSMiniZoomIn { get; set; }

    [XmlElement(ElementName = "ExplorationFSSMiniZoomOut")]
    public ExplorationFSSMiniZoomOut ExplorationFSSMiniZoomOut { get; set; }

    [XmlElement(ElementName = "ExplorationFSSRadioTuningX_Raw")]
    public ExplorationFSSRadioTuningXRaw ExplorationFSSRadioTuningXRaw { get; set; }

    [XmlElement(ElementName = "ExplorationFSSRadioTuningX_Increase")]
    public ExplorationFSSRadioTuningXIncrease ExplorationFSSRadioTuningXIncrease { get; set; }

    [XmlElement(ElementName = "ExplorationFSSRadioTuningX_Decrease")]
    public ExplorationFSSRadioTuningXDecrease ExplorationFSSRadioTuningXDecrease { get; set; }

    [XmlElement(ElementName = "ExplorationFSSRadioTuningAbsoluteX")]
    public ExplorationFSSRadioTuningAbsoluteX ExplorationFSSRadioTuningAbsoluteX { get; set; }

    [XmlElement(ElementName = "FSSTuningSensitivity")]
    public FSSTuningSensitivity FSSTuningSensitivity { get; set; }

    [XmlElement(ElementName = "ExplorationFSSDiscoveryScan")]
    public ExplorationFSSDiscoveryScan ExplorationFSSDiscoveryScan { get; set; }

    [XmlElement(ElementName = "ExplorationFSSQuit")]
    public ExplorationFSSQuit ExplorationFSSQuit { get; set; }

    [XmlElement(ElementName = "FSSMouseXMode")]
    public FSSMouseXMode FSSMouseXMode { get; set; }

    [XmlElement(ElementName = "FSSMouseXDecay")]
    public FSSMouseXDecay FSSMouseXDecay { get; set; }

    [XmlElement(ElementName = "FSSMouseYMode")]
    public FSSMouseYMode FSSMouseYMode { get; set; }

    [XmlElement(ElementName = "FSSMouseYDecay")]
    public FSSMouseYDecay FSSMouseYDecay { get; set; }

    [XmlElement(ElementName = "FSSMouseSensitivity")]
    public FSSMouseSensitivity FSSMouseSensitivity { get; set; }

    [XmlElement(ElementName = "FSSMouseDeadzone")]
    public FSSMouseDeadzone FSSMouseDeadzone { get; set; }

    [XmlElement(ElementName = "FSSMouseLinearity")]
    public FSSMouseLinearity FSSMouseLinearity { get; set; }

    [XmlElement(ElementName = "ExplorationFSSTarget")]
    public ExplorationFSSTarget ExplorationFSSTarget { get; set; }

    [XmlElement(ElementName = "ExplorationFSSShowHelp")]
    public ExplorationFSSShowHelp ExplorationFSSShowHelp { get; set; }

    [XmlElement(ElementName = "ExplorationSAAChangeScannedAreaViewToggle")]
    public ExplorationSAAChangeScannedAreaViewToggle ExplorationSAAChangeScannedAreaViewToggle { get; set; }

    [XmlElement(ElementName = "ExplorationSAAExitThirdPerson")]
    public ExplorationSAAExitThirdPerson ExplorationSAAExitThirdPerson { get; set; }

    [XmlElement(ElementName = "ExplorationSAANextGenus")]
    public ExplorationSAANextGenus ExplorationSAANextGenus { get; set; }

    [XmlElement(ElementName = "ExplorationSAAPreviousGenus")]
    public ExplorationSAAPreviousGenus ExplorationSAAPreviousGenus { get; set; }

    [XmlElement(ElementName = "SAAThirdPersonMouseXMode")]
    public SAAThirdPersonMouseXMode SAAThirdPersonMouseXMode { get; set; }

    [XmlElement(ElementName = "SAAThirdPersonMouseXDecay")]
    public SAAThirdPersonMouseXDecay SAAThirdPersonMouseXDecay { get; set; }

    [XmlElement(ElementName = "SAAThirdPersonMouseYMode")]
    public SAAThirdPersonMouseYMode SAAThirdPersonMouseYMode { get; set; }

    [XmlElement(ElementName = "SAAThirdPersonMouseYDecay")]
    public SAAThirdPersonMouseYDecay SAAThirdPersonMouseYDecay { get; set; }

    [XmlElement(ElementName = "SAAThirdPersonMouseSensitivity")]
    public SAAThirdPersonMouseSensitivity SAAThirdPersonMouseSensitivity { get; set; }

    [XmlElement(ElementName = "SAAThirdPersonYawAxisRaw")]
    public SAAThirdPersonYawAxisRaw SAAThirdPersonYawAxisRaw { get; set; }

    [XmlElement(ElementName = "SAAThirdPersonYawLeftButton")]
    public SAAThirdPersonYawLeftButton SAAThirdPersonYawLeftButton { get; set; }

    [XmlElement(ElementName = "SAAThirdPersonYawRightButton")]
    public SAAThirdPersonYawRightButton SAAThirdPersonYawRightButton { get; set; }

    [XmlElement(ElementName = "SAAThirdPersonPitchAxisRaw")]
    public SAAThirdPersonPitchAxisRaw SAAThirdPersonPitchAxisRaw { get; set; }

    [XmlElement(ElementName = "SAAThirdPersonPitchUpButton")]
    public SAAThirdPersonPitchUpButton SAAThirdPersonPitchUpButton { get; set; }

    [XmlElement(ElementName = "SAAThirdPersonPitchDownButton")]
    public SAAThirdPersonPitchDownButton SAAThirdPersonPitchDownButton { get; set; }

    [XmlElement(ElementName = "SAAThirdPersonFovAxisRaw")]
    public SAAThirdPersonFovAxisRaw SAAThirdPersonFovAxisRaw { get; set; }

    [XmlElement(ElementName = "SAAThirdPersonFovOutButton")]
    public SAAThirdPersonFovOutButton SAAThirdPersonFovOutButton { get; set; }

    [XmlElement(ElementName = "SAAThirdPersonFovInButton")]
    public SAAThirdPersonFovInButton SAAThirdPersonFovInButton { get; set; }

    [XmlElement(ElementName = "MouseHumanoidXMode")]
    public MouseHumanoidXMode MouseHumanoidXMode { get; set; }

    [XmlElement(ElementName = "MouseHumanoidYMode")]
    public MouseHumanoidYMode MouseHumanoidYMode { get; set; }

    [XmlElement(ElementName = "MouseHumanoidSensitivity")]
    public MouseHumanoidSensitivity MouseHumanoidSensitivity { get; set; }

    [XmlElement(ElementName = "HumanoidForwardAxis")]
    public HumanoidForwardAxis HumanoidForwardAxis { get; set; }

    [XmlElement(ElementName = "HumanoidForwardButton")]
    public HumanoidForwardButton HumanoidForwardButton { get; set; }

    [XmlElement(ElementName = "HumanoidBackwardButton")]
    public HumanoidBackwardButton HumanoidBackwardButton { get; set; }

    [XmlElement(ElementName = "HumanoidStrafeAxis")]
    public HumanoidStrafeAxis HumanoidStrafeAxis { get; set; }

    [XmlElement(ElementName = "HumanoidStrafeLeftButton")]
    public HumanoidStrafeLeftButton HumanoidStrafeLeftButton { get; set; }

    [XmlElement(ElementName = "HumanoidStrafeRightButton")]
    public HumanoidStrafeRightButton HumanoidStrafeRightButton { get; set; }

    [XmlElement(ElementName = "HumanoidRotateAxis")]
    public HumanoidRotateAxis HumanoidRotateAxis { get; set; }

    [XmlElement(ElementName = "HumanoidRotateSensitivity")]
    public HumanoidRotateSensitivity HumanoidRotateSensitivity { get; set; }

    [XmlElement(ElementName = "HumanoidRotateLeftButton")]
    public HumanoidRotateLeftButton HumanoidRotateLeftButton { get; set; }

    [XmlElement(ElementName = "HumanoidRotateRightButton")]
    public HumanoidRotateRightButton HumanoidRotateRightButton { get; set; }

    [XmlElement(ElementName = "HumanoidPitchAxis")]
    public HumanoidPitchAxis HumanoidPitchAxis { get; set; }

    [XmlElement(ElementName = "HumanoidPitchSensitivity")]
    public HumanoidPitchSensitivity HumanoidPitchSensitivity { get; set; }

    [XmlElement(ElementName = "HumanoidPitchUpButton")]
    public HumanoidPitchUpButton HumanoidPitchUpButton { get; set; }

    [XmlElement(ElementName = "HumanoidPitchDownButton")]
    public HumanoidPitchDownButton HumanoidPitchDownButton { get; set; }

    [XmlElement(ElementName = "HumanoidSprintButton")]
    public HumanoidSprintButton HumanoidSprintButton { get; set; }

    [XmlElement(ElementName = "HumanoidWalkButton")]
    public HumanoidWalkButton HumanoidWalkButton { get; set; }

    [XmlElement(ElementName = "HumanoidCrouchButton")]
    public HumanoidCrouchButton HumanoidCrouchButton { get; set; }

    [XmlElement(ElementName = "HumanoidJumpButton")]
    public HumanoidJumpButton HumanoidJumpButton { get; set; }

    [XmlElement(ElementName = "HumanoidPrimaryInteractButton")]
    public HumanoidPrimaryInteractButton HumanoidPrimaryInteractButton { get; set; }

    [XmlElement(ElementName = "HumanoidSecondaryInteractButton")]
    public HumanoidSecondaryInteractButton HumanoidSecondaryInteractButton { get; set; }

    [XmlElement(ElementName = "HumanoidItemWheelButton")]
    public HumanoidItemWheelButton HumanoidItemWheelButton { get; set; }

    [XmlElement(ElementName = "HumanoidEmoteWheelButton")]
    public HumanoidEmoteWheelButton HumanoidEmoteWheelButton { get; set; }

    [XmlElement(ElementName = "HumanoidUtilityWheelCycleMode")]
    public HumanoidUtilityWheelCycleMode HumanoidUtilityWheelCycleMode { get; set; }

    [XmlElement(ElementName = "HumanoidItemWheelButton_XAxis")]
    public HumanoidItemWheelButtonXAxis HumanoidItemWheelButtonXAxis { get; set; }

    [XmlElement(ElementName = "HumanoidItemWheelButton_XLeft")]
    public HumanoidItemWheelButtonXLeft HumanoidItemWheelButtonXLeft { get; set; }

    [XmlElement(ElementName = "HumanoidItemWheelButton_XRight")]
    public HumanoidItemWheelButtonXRight HumanoidItemWheelButtonXRight { get; set; }

    [XmlElement(ElementName = "HumanoidItemWheelButton_YAxis")]
    public HumanoidItemWheelButtonYAxis HumanoidItemWheelButtonYAxis { get; set; }

    [XmlElement(ElementName = "HumanoidItemWheelButton_YUp")]
    public HumanoidItemWheelButtonYUp HumanoidItemWheelButtonYUp { get; set; }

    [XmlElement(ElementName = "HumanoidItemWheelButton_YDown")]
    public HumanoidItemWheelButtonYDown HumanoidItemWheelButtonYDown { get; set; }

    [XmlElement(ElementName = "HumanoidItemWheel_AcceptMouseInput")]
    public HumanoidItemWheelAcceptMouseInput HumanoidItemWheelAcceptMouseInput { get; set; }

    [XmlElement(ElementName = "HumanoidPrimaryFireButton")]
    public HumanoidPrimaryFireButton HumanoidPrimaryFireButton { get; set; }

    [XmlElement(ElementName = "HumanoidZoomButton")]
    public HumanoidZoomButton HumanoidZoomButton { get; set; }

    [XmlElement(ElementName = "HumanoidThrowGrenadeButton")]
    public HumanoidThrowGrenadeButton HumanoidThrowGrenadeButton { get; set; }

    [XmlElement(ElementName = "HumanoidMeleeButton")]
    public HumanoidMeleeButton HumanoidMeleeButton { get; set; }

    [XmlElement(ElementName = "HumanoidReloadButton")]
    public HumanoidReloadButton HumanoidReloadButton { get; set; }

    [XmlElement(ElementName = "HumanoidSwitchWeapon")]
    public HumanoidSwitchWeapon HumanoidSwitchWeapon { get; set; }

    [XmlElement(ElementName = "HumanoidSelectPrimaryWeaponButton")]
    public HumanoidSelectPrimaryWeaponButton HumanoidSelectPrimaryWeaponButton { get; set; }

    [XmlElement(ElementName = "HumanoidSelectSecondaryWeaponButton")]
    public HumanoidSelectSecondaryWeaponButton HumanoidSelectSecondaryWeaponButton { get; set; }

    [XmlElement(ElementName = "HumanoidSelectUtilityWeaponButton")]
    public HumanoidSelectUtilityWeaponButton HumanoidSelectUtilityWeaponButton { get; set; }

    [XmlElement(ElementName = "HumanoidSelectNextWeaponButton")]
    public HumanoidSelectNextWeaponButton HumanoidSelectNextWeaponButton { get; set; }

    [XmlElement(ElementName = "HumanoidSelectPreviousWeaponButton")]
    public HumanoidSelectPreviousWeaponButton HumanoidSelectPreviousWeaponButton { get; set; }

    [XmlElement(ElementName = "HumanoidHideWeaponButton")]
    public HumanoidHideWeaponButton HumanoidHideWeaponButton { get; set; }

    [XmlElement(ElementName = "HumanoidSelectNextGrenadeTypeButton")]
    public HumanoidSelectNextGrenadeTypeButton HumanoidSelectNextGrenadeTypeButton { get; set; }

    [XmlElement(ElementName = "HumanoidSelectPreviousGrenadeTypeButton")]
    public HumanoidSelectPreviousGrenadeTypeButton HumanoidSelectPreviousGrenadeTypeButton { get; set; }

    [XmlElement(ElementName = "HumanoidToggleFlashlightButton")]
    public HumanoidToggleFlashlightButton HumanoidToggleFlashlightButton { get; set; }

    [XmlElement(ElementName = "HumanoidToggleNightVisionButton")]
    public HumanoidToggleNightVisionButton HumanoidToggleNightVisionButton { get; set; }

    [XmlElement(ElementName = "HumanoidToggleShieldsButton")]
    public HumanoidToggleShieldsButton HumanoidToggleShieldsButton { get; set; }

    [XmlElement(ElementName = "HumanoidClearAuthorityLevel")]
    public HumanoidClearAuthorityLevel HumanoidClearAuthorityLevel { get; set; }

    [XmlElement(ElementName = "HumanoidHealthPack")]
    public HumanoidHealthPack HumanoidHealthPack { get; set; }

    [XmlElement(ElementName = "HumanoidBattery")]
    public HumanoidBattery HumanoidBattery { get; set; }

    [XmlElement(ElementName = "HumanoidSelectFragGrenade")]
    public HumanoidSelectFragGrenade HumanoidSelectFragGrenade { get; set; }

    [XmlElement(ElementName = "HumanoidSelectEMPGrenade")]
    public HumanoidSelectEMPGrenade HumanoidSelectEMPGrenade { get; set; }

    [XmlElement(ElementName = "HumanoidSelectShieldGrenade")]
    public HumanoidSelectShieldGrenade HumanoidSelectShieldGrenade { get; set; }

    [XmlElement(ElementName = "HumanoidSwitchToRechargeTool")]
    public HumanoidSwitchToRechargeTool HumanoidSwitchToRechargeTool { get; set; }

    [XmlElement(ElementName = "HumanoidSwitchToCompAnalyser")]
    public HumanoidSwitchToCompAnalyser HumanoidSwitchToCompAnalyser { get; set; }

    [XmlElement(ElementName = "HumanoidSwitchToSuitTool")]
    public HumanoidSwitchToSuitTool HumanoidSwitchToSuitTool { get; set; }

    [XmlElement(ElementName = "HumanoidToggleToolModeButton")]
    public HumanoidToggleToolModeButton HumanoidToggleToolModeButton { get; set; }

    [XmlElement(ElementName = "HumanoidToggleMissionHelpPanelButton")]
    public HumanoidToggleMissionHelpPanelButton HumanoidToggleMissionHelpPanelButton { get; set; }

    [XmlElement(ElementName = "HumanoidPing")]
    public HumanoidPing HumanoidPing { get; set; }

    [XmlElement(ElementName = "GalaxyMapOpen_Humanoid")]
    public GalaxyMapOpenHumanoid GalaxyMapOpenHumanoid { get; set; }

    [XmlElement(ElementName = "SystemMapOpen_Humanoid")]
    public SystemMapOpenHumanoid SystemMapOpenHumanoid { get; set; }

    [XmlElement(ElementName = "FocusCommsPanel_Humanoid")]
    public FocusCommsPanelHumanoid FocusCommsPanelHumanoid { get; set; }

    [XmlElement(ElementName = "QuickCommsPanel_Humanoid")]
    public QuickCommsPanelHumanoid QuickCommsPanelHumanoid { get; set; }

    [XmlElement(ElementName = "HumanoidOpenAccessPanelButton")]
    public HumanoidOpenAccessPanelButton HumanoidOpenAccessPanelButton { get; set; }

    [XmlElement(ElementName = "HumanoidConflictContextualUIButton")]
    public HumanoidConflictContextualUIButton HumanoidConflictContextualUIButton { get; set; }

    [XmlElement(ElementName = "EnableMenuGroupsOnFoot")]
    public EnableMenuGroupsOnFoot EnableMenuGroupsOnFoot { get; set; }

    [XmlElement(ElementName = "StoreEnableRotation")]
    public StoreEnableRotation StoreEnableRotation { get; set; }

    [XmlElement(ElementName = "StorePitchCamera")]
    public StorePitchCamera StorePitchCamera { get; set; }

    [XmlElement(ElementName = "StoreYawCamera")]
    public StoreYawCamera StoreYawCamera { get; set; }

    [XmlElement(ElementName = "StoreCamZoomIn")]
    public StoreCamZoomIn StoreCamZoomIn { get; set; }

    [XmlElement(ElementName = "StoreCamZoomOut")]
    public StoreCamZoomOut StoreCamZoomOut { get; set; }

    [XmlElement(ElementName = "StoreToggle")]
    public StoreToggle StoreToggle { get; set; }

    [XmlElement(ElementName = "HumanoidEmoteSlot1")]
    public HumanoidEmoteSlot1 HumanoidEmoteSlot1 { get; set; }

    [XmlElement(ElementName = "HumanoidEmoteSlot2")]
    public HumanoidEmoteSlot2 HumanoidEmoteSlot2 { get; set; }

    [XmlElement(ElementName = "HumanoidEmoteSlot3")]
    public HumanoidEmoteSlot3 HumanoidEmoteSlot3 { get; set; }

    [XmlElement(ElementName = "HumanoidEmoteSlot4")]
    public HumanoidEmoteSlot4 HumanoidEmoteSlot4 { get; set; }

    [XmlElement(ElementName = "HumanoidEmoteSlot5")]
    public HumanoidEmoteSlot5 HumanoidEmoteSlot5 { get; set; }

    [XmlElement(ElementName = "HumanoidEmoteSlot6")]
    public HumanoidEmoteSlot6 HumanoidEmoteSlot6 { get; set; }

    [XmlElement(ElementName = "HumanoidEmoteSlot7")]
    public HumanoidEmoteSlot7 HumanoidEmoteSlot7 { get; set; }

    [XmlElement(ElementName = "HumanoidEmoteSlot8")]
    public HumanoidEmoteSlot8 HumanoidEmoteSlot8 { get; set; }

    [XmlAttribute(AttributeName = "PresetName")]
    public string PresetName { get; set; }

    [XmlAttribute(AttributeName = "MajorVersion")]
    public int MajorVersion { get; set; }

    [XmlAttribute(AttributeName = "MinorVersion")]
    public int MinorVersion { get; set; }

    [XmlText]
    public string Text { get; set; }
}