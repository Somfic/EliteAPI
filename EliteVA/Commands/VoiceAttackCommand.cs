namespace EliteVA.Commands;

public class VoiceAttackCommand
{
    private readonly dynamic _proxy;

    internal VoiceAttackCommand(dynamic proxy)
    {
        _proxy = proxy;
    }

    /// <summary>
    /// The name of the executing command
    /// </summary>
    public string Name => _proxy.Command.Name();

    /// <summary>
    /// The identifier of the executing command
    /// </summary>
    public Guid Identifier => _proxy.Command.InternalID();

    /// <summary>
    /// Gets a segment from a dynamic command
    /// </summary>
    /// <param name="index">Zero based segment index</param>
    public string GetSegment(int index) => _proxy.Command.Segment(index);

    /// <summary>
    /// The executing command source
    /// </summary>
    public CommandSource Source => (CommandSource)_proxy.Command.Action();

    /// <summary>
    /// The confidence of correct voice recognition of the executing command
    /// </summary>
    /// <remarks>Scale of 0-1</remarks>
    public float Confidence => _proxy.Command.Confidence() / 100f;

    /// <summary>
    /// The minimum confidence of correct voice recognition of the executing command
    /// </summary>
    /// <remarks>Scale of 0-1</remarks>
    public float MinConfidence => _proxy.Command.MinConfidence() / 100f;

    /// <summary>
    /// Whether the executing command is called by another command
    /// </summary>
    public bool IsSubCommand => _proxy.Command.IsSubCommand();

    /// <summary>
    /// The full value of the 'When I Say' input box
    /// </summary>
    public string WhenISay => _proxy.Command.WhenISay();

    /// <summary>
    /// The category of the executing command
    /// </summary>
    public string Category => _proxy.Command.Category();

    /// <summary>
    /// Whether the executing command is already executing in another instance
    /// </summary>
    public bool IsDuplicate => _proxy.Command.AlreadyExecuting();
}