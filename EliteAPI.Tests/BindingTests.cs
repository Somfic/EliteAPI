using EliteAPI.Bindings;
using FluentAssertions;

namespace EliteAPI.Tests.Bindings;

public class BindingParserTests
{

    [Test]
    public void Parse_Sample_File()
    {
        string xml = File.ReadAllText("test.binds");

        var content = BindingParser.Parse(xml);

        content.Should().NotBeNull();
    }

    [Test]
    public void Parse_Should_Read_Simple_Primary_Keyboard_Bindings()
    {
        const string xml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
		<Root PresetName=""Custom"">
			<YawLeftButton>
				<Primary Device=""Keyboard"" Key=""Key_A"" />
				<Secondary Device=""{NoDevice}"" Key="""" />
			</YawLeftButton>
			<YawRightButton>
				<Primary Device=""Keyboard"" Key=""Key_D"" />
				<Secondary Device=""{NoDevice}"" Key="""" />
			</YawRightButton>
		</Root>";

        var controls = BindingParser
            .Parse(xml)
            .ToDictionary(c => c.Name);

        controls.Should().ContainKeys("YawLeftButton", "YawRightButton");

        var yawLeft = controls["YawLeftButton"];
        yawLeft.Primary.HasValue.Should().BeTrue();
        yawLeft.Primary!.Value.Device.Should().Be("Keyboard");
        yawLeft.Primary!.Value.Key.Should().Be("Key_A");
        yawLeft.Secondary.HasValue.Should().BeFalse();
        yawLeft.IsToggle.Should().BeNull();
        yawLeft.IsInverted.Should().BeNull();
        yawLeft.Deadzone.Should().BeNull();

        var yawRight = controls["YawRightButton"];
        yawRight.Primary.HasValue.Should().BeTrue();
        yawRight.Primary!.Value.Device.Should().Be("Keyboard");
        yawRight.Primary!.Value.Key.Should().Be("Key_D");
        yawRight.Secondary.HasValue.Should().BeFalse();
    }

    [Test]
    public void Parse_Should_Treat_NoDevice_EmptyKey_As_Unbound()
    {
        const string xml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
		<Root>
			<MouseReset>
				<Primary Device=""{NoDevice}"" Key="""" />
				<Secondary Device=""{NoDevice}"" Key="""" />
			</MouseReset>

			<RollLeftButton>
				<Primary Device=""{NoDevice}"" Key="""" />
				<Secondary Device=""{NoDevice}"" Key="""" />
			</RollLeftButton>
		</Root>";

        var controls = BindingParser
            .Parse(xml)
            .ToDictionary(c => c.Name);

        controls.Should().ContainKeys("MouseReset", "RollLeftButton");

        foreach (var control in controls.Values)
        {
            control.Primary.HasValue.Should().BeFalse();
            control.Secondary.HasValue.Should().BeFalse();
            control.IsToggle.Should().BeNull();
            control.IsInverted.Should().BeNull();
            control.Deadzone.Should().BeNull();
        }
    }

    [Test]
    public void Parse_Should_Map_Binding_Element_To_Primary_And_Read_Inverted_And_Deadzone()
    {
        const string xml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
		<Root>
			<YawAxisRaw>
				<Binding Device=""Joystick"" Key=""Joy_X"" />
				<Inverted Value=""1"" />
				<Deadzone Value=""0.25000000"" />
			</YawAxisRaw>
		</Root>";

        var control = BindingParser
            .Parse(xml)
            .Single(c => c.Name == "YawAxisRaw");

        control.Primary.HasValue.Should().BeTrue();
        var binding = control.Primary!.Value;

        binding.Device.Should().Be("Joystick");
        binding.Key.Should().Be("Joy_X");
        binding.Modifiers.Should().BeNull();

        control.Secondary.HasValue.Should().BeFalse();
        control.IsInverted.Should().BeTrue();
        control.IsToggle.Should().BeNull();
        control.Deadzone.Should().Be(0.25f);
    }

    [Test]
    public void Parse_Should_Handle_All_ToggleOn_Variants()
    {
        const string xml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
		<Root>
			<!-- Explicit false -->
			<BlockMouseDecay>
				<Primary Device=""{NoDevice}"" Key="""" />
				<Secondary Device=""{NoDevice}"" Key="""" />
				<ToggleOn Value=""0"" />
			</BlockMouseDecay>

			<!-- Explicit true -->
			<ToggleFlightAssist>
				<Primary Device=""Keyboard"" Key=""Key_Z"" />
				<Secondary Device=""{NoDevice}"" Key="""" />
				<ToggleOn Value=""1"" />
			</ToggleFlightAssist>

			<!-- No Value attribute, taken from HCS pattern -->
			<YawToRollButton>
				<Primary Device=""{NoDevice}"" Key="""" />
				<Secondary Device=""{NoDevice}"" Key="""" />
				<ToggleOn />
			</YawToRollButton>

			<!-- No ToggleOn at all -->
			<MouseReset>
				<Primary Device=""{NoDevice}"" Key="""" />
				<Secondary Device=""{NoDevice}"" Key="""" />
			</MouseReset>
		</Root>";

        var controls = BindingParser
            .Parse(xml)
            .ToDictionary(c => c.Name);

        controls["BlockMouseDecay"].IsToggle.Should().BeFalse();
        controls["ToggleFlightAssist"].IsToggle.Should().BeTrue();

        // Presence of <ToggleOn /> with no Value attribute – treat as true
        controls["YawToRollButton"].IsToggle.Should().BeTrue();

        // No <ToggleOn> element at all
        controls["MouseReset"].IsToggle.Should().BeNull();
    }

    [Test]
    public void Parse_Should_Read_Modifiers_On_Primary_And_Secondary()
    {
        const string xml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
		<Root>
			<!-- From the stock binds -->
			<PhotoCameraToggle>
				<Primary Device=""Keyboard"" Key=""Key_Space"">
					<Modifier Device=""Keyboard"" Key=""Key_LeftControl"" />
					<Modifier Device=""Keyboard"" Key=""Key_LeftAlt"" />
				</Primary>
				<Secondary Device=""{NoDevice}"" Key="""" />
			</PhotoCameraToggle>

			<!-- From the HCS binds: modifiers on Secondary -->
			<ToggleReverseThrottleInput>
				<Primary Device=""{NoDevice}"" Key="""" />
				<Secondary Device=""Keyboard"" Key=""Key_A"">
					<Modifier Device=""Keyboard"" Key=""Key_LeftAlt"" />
					<Modifier Device=""Keyboard"" Key=""Key_RightShift"" />
				</Secondary>
				<ToggleOn Value=""1"" />
			</ToggleReverseThrottleInput>
		</Root>";

        var controls = BindingParser
            .Parse(xml)
            .ToDictionary(c => c.Name);

        // Primary modifiers
        var photo = controls["PhotoCameraToggle"];
        photo.Primary.HasValue.Should().BeTrue();
        var photoPrimary = photo.Primary!.Value;

        photoPrimary.Device.Should().Be("Keyboard");
        photoPrimary.Key.Should().Be("Key_Space");
        photoPrimary.Modifiers.Should().NotBeNull();
        photoPrimary.Modifiers!.Should().HaveCount(2);

        var firstPhotoMod = (Binding)photoPrimary.Modifiers![0];
        var secondPhotoMod = (Binding)photoPrimary.Modifiers![1];

        firstPhotoMod.Device.Should().Be("Keyboard");
        firstPhotoMod.Key.Should().Be("Key_LeftControl");
        secondPhotoMod.Device.Should().Be("Keyboard");
        secondPhotoMod.Key.Should().Be("Key_LeftAlt");

        // Secondary modifiers
        var reverse = controls["ToggleReverseThrottleInput"];
        reverse.Secondary.HasValue.Should().BeTrue();
        var reverseSecondary = reverse.Secondary!.Value;

        reverseSecondary.Device.Should().Be("Keyboard");
        reverseSecondary.Key.Should().Be("Key_A");
        reverseSecondary.Modifiers.Should().NotBeNull();
        reverseSecondary.Modifiers!.Should().HaveCount(2);

        var firstReverseMod = (Binding)reverseSecondary.Modifiers![0];
        var secondReverseMod = (Binding)reverseSecondary.Modifiers![1];

        firstReverseMod.Device.Should().Be("Keyboard");
        firstReverseMod.Key.Should().Be("Key_LeftAlt");
        secondReverseMod.Device.Should().Be("Keyboard");
        secondReverseMod.Key.Should().Be("Key_RightShift");
    }

    [Test]
    public void Parse_Should_Ignore_Hold_Child_And_Still_Parse_Binding_And_Toggle()
    {
        const string xml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
		<Root>
			<HumanoidItemWheelButton>
				<Primary Device=""Keyboard"" Key=""Key_LeftAlt"">
					<Hold Value=""1"" />
				</Primary>
				<Secondary Device=""{NoDevice}"" Key="""" />
				<ToggleOn Value=""0"" />
			</HumanoidItemWheelButton>
		</Root>";

        var control = BindingParser
            .Parse(xml)
            .Single(c => c.Name == "HumanoidItemWheelButton");

        control.Primary.HasValue.Should().BeTrue();
        var primary = control.Primary!.Value;

        primary.Device.Should().Be("Keyboard");
        primary.Key.Should().Be("Key_LeftAlt");

        // Hold isn't currently modelled on Binding – at minimum it must not break parsing
        primary.Modifiers.Should().BeNull();

        control.IsToggle.Should().BeFalse(); // Value=""0""
    }

    [Test]
    public void Parse_Should_Treat_Key_Attribute_Case_Insensitive()
    {
        // Based on ToggleVanityCamera in HCS, but with a meaningful secondary key
        const string xml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
		<Root>
			<ToggleVanityCamera>
				<Primary Device=""Keyboard"" Key=""Key_RightShift"" />
				<!-- key attribute is lowercase here on purpose -->
				<Secondary Device=""Keyboard"" key=""Key_F12"" />
			</ToggleVanityCamera>
		</Root>";

        var control = BindingParser
            .Parse(xml)
            .Single(c => c.Name == "ToggleVanityCamera");

        control.Primary.HasValue.Should().BeTrue();
        control.Primary!.Value.Key.Should().Be("Key_RightShift");

        control.Secondary.HasValue.Should().BeTrue();
        control.Secondary!.Value.Device.Should().Be("Keyboard");
        control.Secondary!.Value.Key.Should().Be("Key_F12");
    }

    [Test]
    public void Parse_Should_Handle_Float_Deadzone_Formats()
    {
        const string xml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
		<Root>
			<RollAxisRaw>
				<Binding Device=""Joystick"" Key=""Joy_Roll"" />
				<Deadzone Value=""0.00000000"" />
			</RollAxisRaw>

			<LateralThrustRaw>
				<Binding Device=""Joystick"" Key=""Joy_Lateral"" />
				<Deadzone Value=""0.05"" />
			</LateralThrustRaw>

			<VerticalThrustRaw>
				<Binding Device=""Joystick"" Key=""Joy_Vertical"" />
				<Deadzone Value=""7"" />
			</VerticalThrustRaw>
		</Root>";

        var controls = BindingParser
            .Parse(xml)
            .ToDictionary(c => c.Name);

        controls["RollAxisRaw"].Deadzone.Should().Be(0.0f);
        controls["LateralThrustRaw"].Deadzone.Should().Be(0.05f);
        controls["VerticalThrustRaw"].Deadzone.Should().Be(7.0f);
    }

    [Test]
    public void Parse_Should_Ignore_Value_Only_Elements_And_Only_Return_Controls_With_Bindings()
    {
        const string xml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
		<Root PresetName=""Custom"">
			<KeyboardLayout>nl-NL</KeyboardLayout>
			<MouseXMode Value=""Bindings_MouseRoll"" />
			<MouseSensitivity Value=""1.00000000"" />
			<MouseGUI Value=""1"" />

			<YawLeftButton>
				<Primary Device=""Keyboard"" Key=""Key_A"" />
				<Secondary Device=""{NoDevice}"" Key="""" />
			</YawLeftButton>
		</Root>";

        var controls = BindingParser.Parse(xml).ToArray();

        controls.Should().ContainSingle(c => c.Name == "YawLeftButton");
        controls.Select(c => c.Name).Should().NotContain("MouseXMode");
        controls.Select(c => c.Name).Should().NotContain("MouseSensitivity");
        controls.Select(c => c.Name).Should().NotContain("MouseGUI");
    }
}
