using System.Reflection;
using EliteVA.Logging;

namespace EliteVA;

public abstract class VoiceAttackPlugin : VoiceAttackService
{
    public static VoiceAttackPlugin? Instance;
    public static VoiceAttackProxy Proxy;
    
    public static readonly string Dir = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName ?? Directory.GetCurrentDirectory();
    
    protected VoiceAttackPlugin()
    {
        Instance ??= this;
    }
    

    public void Log(VoiceAttackColor color, string message, Exception? exception = null)
    {
        Proxy.Log.Write(message, color);
        
        if (exception != null)
            Proxy.Log.Write(exception.ToString(), color);
    } 
}
