using System.Runtime.InteropServices;

namespace EliteAI.Input;

/// <summary>
/// Simple keyboard input controller using Windows API
/// </summary>
public static class Keyboard
{
    [StructLayout(LayoutKind.Sequential)]
    private struct MOUSEINPUT
    {
        public int dx;
        public int dy;
        public uint mouseData;
        public uint dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct KEYBDINPUT
    {
        public ushort wVk;
        public ushort wScan;
        public uint dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct HARDWAREINPUT
    {
        public uint uMsg;
        public ushort wParamL;
        public ushort wParamH;
    }

    [StructLayout(LayoutKind.Explicit)]
    private struct InputUnion
    {
        [FieldOffset(0)]
        public MOUSEINPUT mi;
        [FieldOffset(0)]
        public KEYBDINPUT ki;
        [FieldOffset(0)]
        public HARDWAREINPUT hi;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct INPUT
    {
        public int type;
        public InputUnion u;
    }

    [DllImport("user32.dll", SetLastError = true)]
    private static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

    private const int INPUT_KEYBOARD = 1;
    private const uint KEYEVENTF_KEYDOWN = 0x0000;
    private const uint KEYEVENTF_KEYUP = 0x0002;
    private const uint KEYEVENTF_SCANCODE = 0x0008;

    // Scan codes (more reliable for games than virtual keys)
    private static readonly Dictionary<char, ushort> ScanCodes = new()
    {
        { 'A', 0x1E },
        { 'D', 0x20 },
        { 'W', 0x11 },
        { 'S', 0x1F },
        { '7', 0x08 },
        { '8', 0x09 },
        { '9', 0x0A },
        { '0', 0x0B },
        { 'E', 0x12 },  // UI_Select (default E)
        { 'Q', 0x10 },  // UI_Back (default Q)
        { 'R', 0x13 },  // CycleNextPanel (default R)
        { 'F', 0x21 },  // UIFocus (default F)
        { 'H', 0x23 },  // HeadLookReset (default H key)
    };

    /// <summary>
    /// Presses a key (down and up)
    /// </summary>
    public static void Press(char key)
    {
        KeyDown(key);
        Thread.Sleep(50);
        KeyUp(key);
    }

    /// <summary>
    /// Holds a key down
    /// </summary>
    public static void KeyDown(char key)
    {
        key = char.ToUpper(key);
        if (!ScanCodes.TryGetValue(key, out var scanCode))
            return;

        var input = new INPUT
        {
            type = INPUT_KEYBOARD,
            u = new InputUnion
            {
                ki = new KEYBDINPUT
                {
                    wVk = 0,
                    wScan = scanCode,
                    dwFlags = KEYEVENTF_SCANCODE,
                    time = 0,
                    dwExtraInfo = IntPtr.Zero
                }
            }
        };

        var result = SendInput(1, new[] { input }, Marshal.SizeOf(typeof(INPUT)));
        if (result == 0)
        {
            var error = Marshal.GetLastWin32Error();
            Console.WriteLine($"SendInput failed for KeyDown({key}): Error {error}");
        }
    }

    /// <summary>
    /// Releases a key
    /// </summary>
    public static void KeyUp(char key)
    {
        key = char.ToUpper(key);
        if (!ScanCodes.TryGetValue(key, out var scanCode))
            return;

        var input = new INPUT
        {
            type = INPUT_KEYBOARD,
            u = new InputUnion
            {
                ki = new KEYBDINPUT
                {
                    wVk = 0,
                    wScan = scanCode,
                    dwFlags = KEYEVENTF_SCANCODE | KEYEVENTF_KEYUP,
                    time = 0,
                    dwExtraInfo = IntPtr.Zero
                }
            }
        };

        var result = SendInput(1, new[] { input }, Marshal.SizeOf(typeof(INPUT)));
        if (result == 0)
        {
            var error = Marshal.GetLastWin32Error();
            Console.WriteLine($"SendInput failed for KeyUp({key}): Error {error}");
        }
    }
}

/// <summary>
/// Simple autopilot that aims at the navball target
/// </summary>
public class SimpleAutopilot
{
    private readonly float _deadzone;
    private readonly float _rollThreshold; // Threshold to switch from yaw to roll+pitch
    private readonly float _precisionThreshold; // Threshold for pulse mode
    private readonly int _pulseDurationMs; // Duration of key pulses in precision mode
    private readonly int _pulseIntervalMs; // Minimum interval between pulses

    private readonly HashSet<char> _pressedKeys = new();
    private DateTime _lastHorizontalPulseTime = DateTime.MinValue;
    private DateTime _lastVerticalPulseTime = DateTime.MinValue;

    public SimpleAutopilot(float deadzone = 0.02f, float rollThreshold = 0.3f, float precisionThreshold = 0.2f, int pulseDurationMs = 5, int pulseIntervalMs = 100)
    {
        _deadzone = deadzone;
        _rollThreshold = rollThreshold; // Use roll for corrections > 30%
        _precisionThreshold = precisionThreshold; // Use pulse mode for corrections < 20%
        _pulseDurationMs = pulseDurationMs;
        _pulseIntervalMs = pulseIntervalMs;
    }

    /// <summary>
    /// Pulses a key (press and release after duration)
    /// </summary>
    private async void PulseKey(char key)
    {
        Keyboard.KeyDown(key);
        await Task.Delay(_pulseDurationMs);
        Keyboard.KeyUp(key);
    }

    /// <summary>
    /// Helper to press a key (adds to tracking set)
    /// </summary>
    private void PressKey(char key)
    {
        if (_pressedKeys.Add(key))
        {
            Keyboard.KeyDown(key);
        }
    }

    /// <summary>
    /// Helper to release all currently pressed keys
    /// </summary>
    private void ReleaseAllKeys()
    {
        foreach (var key in _pressedKeys)
        {
            Keyboard.KeyUp(key);
        }
        _pressedKeys.Clear();
    }

    /// <summary>
    /// Calculates pulse interval based on error magnitude (linear interpolation).
    /// Larger errors = faster pulses, smaller errors = slower pulses.
    /// </summary>
    private int GetPulseInterval(float error)
    {
        // Map error range to pulse interval range
        // At deadzone: max interval (slowest)
        // At precision threshold: min interval (fastest)
        var normalizedError = (error - _deadzone) / (_precisionThreshold - _deadzone);
        normalizedError = Math.Clamp(normalizedError, 0f, 1f);

        // Linear interpolation: 300ms (slow) at deadzone -> 50ms (fast) at threshold
        const int maxInterval = 300;
        const int minInterval = 50;
        return (int)(maxInterval - (normalizedError * (maxInterval - minInterval)));
    }

    /// <summary>
    /// Updates the autopilot based on target position
    /// </summary>
    /// <param name="targetX">Horizontal position from -1 (left) to 1 (right)</param>
    /// <param name="targetY">Vertical position from -1 (up) to 1 (down)</param>
    public void Update(float targetX, float targetY)
    {
        // Release all keys first
        ReleaseAllKeys();

        // Calculate error magnitudes
        var absX = Math.Abs(targetX);
        var absY = Math.Abs(targetY);

        // Horizontal control (yaw) - dynamic pulse timing
        if (absX > _precisionThreshold)
        {
            // Large horizontal error: Hold keys continuously
            if (targetX < -_deadzone)
                PressKey('A');
            else if (targetX > _deadzone)
                PressKey('D');
        }
        else if (absX > _deadzone)
        {
            // Fine horizontal corrections: Dynamic pulse mode
            var horizontalInterval = GetPulseInterval(absX);
            var timeSinceLastHorizontalPulse = (DateTime.Now - _lastHorizontalPulseTime).TotalMilliseconds;

            if (timeSinceLastHorizontalPulse >= horizontalInterval)
            {
                if (targetX < -_deadzone)
                    PulseKey('A');
                else if (targetX > _deadzone)
                    PulseKey('D');

                _lastHorizontalPulseTime = DateTime.Now;
            }
        }

        // Vertical control (pitch) - dynamic pulse timing
        if (absY > _precisionThreshold)
        {
            // Large vertical error: Hold keys continuously
            if (targetY < -_deadzone)
                PressKey('7'); // Target above, pitch up
            else if (targetY > _deadzone)
                PressKey('8'); // Target below, pitch down
        }
        else if (absY > _deadzone)
        {
            // Fine vertical corrections: Dynamic pulse mode
            var verticalInterval = GetPulseInterval(absY);
            var timeSinceLastVerticalPulse = (DateTime.Now - _lastVerticalPulseTime).TotalMilliseconds;

            if (timeSinceLastVerticalPulse >= verticalInterval)
            {
                if (targetY < -_deadzone)
                    PulseKey('7'); // Target above, pitch up
                else if (targetY > _deadzone)
                    PulseKey('8'); // Target below, pitch down

                _lastVerticalPulseTime = DateTime.Now;
            }
        }
    }

    /// <summary>
    /// Stops all inputs
    /// </summary>
    public void Stop()
    {
        ReleaseAllKeys();
    }
}
