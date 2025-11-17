namespace EliteVA.Paths;

public class VoiceAttackPaths
{
    private readonly dynamic _proxy;

    internal VoiceAttackPaths(dynamic proxy)
    {
        _proxy = proxy;
    }

    /// <summary>
    /// The VoiceAttack installation directory
    /// </summary>
    public DirectoryInfo VoiceAttack => new DirectoryInfo(_proxy.InstallDir);

    /// <summary>
    /// The VoiceAttack sounds directory
    /// </summary>
    public DirectoryInfo Sounds => new DirectoryInfo(_proxy.SoundsDir);

    /// <summary>
    /// The VoiceAttack plugins directory
    /// </summary>
    public DirectoryInfo Plugins => new DirectoryInfo(_proxy.AppsDir);

    /// <summary>
    /// The VoiceAttack assemblies directory
    /// </summary>
    public DirectoryInfo Assemblies => new DirectoryInfo(_proxy.AssembliesDir);
}