namespace EliteVA.Process;

public class VoiceAttackActiveWindow
{
    private readonly dynamic _proxy;

    internal VoiceAttackActiveWindow(dynamic proxy)
    {
        _proxy = proxy;
    }

    /// <summary>
    /// The title of the window
    /// </summary>
    public string Title => _proxy.Utility.ActiveWindowTitle( );

    /// <summary>
    /// The name of the process of the window
    /// </summary>
    public string ProcessName => _proxy.Utility.ActiveWindowProcessName();

    /// <summary>
    /// The id of the process of the window
    /// </summary>
    public int ProcessId => _proxy.Utility.ActiveWindowProcessID();

    /// <summary>
    /// The path of the process of the window
    /// </summary>
    public FileInfo Path => new FileInfo(_proxy.Utility.ActiveWindowPath());

    /// <summary>
    /// The size of the window
    /// </summary>
    public (int width, int height) WindowSize => (_proxy.Utility.ActiveWindowWidth(), _proxy.Utility.ActiveWindowHeight());

    /// <summary>
    /// The top left coordinates of the window, relative to the screen
    /// </summary>
    /// <remarks>Top left is 0,0</remarks>
    public (int x, int y) TopLeft => (_proxy.Utility.ActiveWindowLeft(), _proxy.Utility.ActiveWindowTop());

    /// <summary>
    /// Gets the mouse position relative to the window
    /// </summary>
    /// <remarks>Top left is 0,0</remarks>
    public (int x, int y) MouseRelative => (_proxy.Utility.MousePositionWindowX(), _proxy.Utility.MousePositionWindowY());

    /// <summary>
    /// Gets the mouse position on the screen
    /// </summary>
    /// <remarks>Top left is 0,0</remarks>
    public (int x, int y) MouseAbsolute => (_proxy.Utility.MousePositionScreenX(), _proxy.Utility.MousePositionScreenY());
}