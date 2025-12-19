using System.Runtime.InteropServices;

namespace EliteAI.Input;

/// <summary>
/// Global hotkey that works even when the application doesn't have focus.
/// Uses keyboard polling to detect key presses.
/// </summary>
public class GlobalHotkey
{
    [DllImport("user32.dll")]
    private static extern short GetAsyncKeyState(int vKey);

    private readonly int _vkCode;
    private bool _wasPressed = false;

    public GlobalHotkey(int vkCode)
    {
        _vkCode = vkCode;
    }

    /// <summary>
    /// Checks if the key was pressed since the last check.
    /// Returns true only once per key press (not continuous).
    /// </summary>
    public bool WasPressed()
    {
        // GetAsyncKeyState returns non-zero if key is currently pressed
        // Bit 0x8000 is set if key is currently down
        var state = GetAsyncKeyState(_vkCode);
        var isPressed = (state & 0x8000) != 0;

        // Edge detection: only return true on press (not while held)
        if (isPressed && !_wasPressed)
        {
            _wasPressed = true;
            return true;
        }
        else if (!isPressed)
        {
            _wasPressed = false;
        }

        return false;
    }
}
