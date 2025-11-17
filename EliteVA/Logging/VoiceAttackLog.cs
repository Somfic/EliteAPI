namespace EliteVA.Logging;

public class VoiceAttackLog
{
    private readonly dynamic _proxy;

    internal VoiceAttackLog(dynamic proxy)
    {
        _proxy = proxy;
    }

    /// <summary>
    /// Writes to the VoiceAttack log
    /// </summary>
    /// <param name="content">The log message</param>
    /// <param name="color">The log color</param>
    public void Write(string content, VoiceAttackColor color)
    {
        _proxy.WriteToLog(content, color.ToString());
    }

    /// <summary>
    /// Clears the VoiceAttack log
    /// </summary>
    public void Clear()
    {
        _proxy.ClearLog();
    }
}