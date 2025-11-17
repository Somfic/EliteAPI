using EliteVA.Logging;

namespace EliteVA;

public class VoiceAttackPluginWrapper
{
    public static Guid VA_Id() => new("189a4e44-caf1-459b-b62e-fabc60a12986");

    public static string VA_DisplayName() => "EliteAPI";

    public static string VA_DisplayInfo() => "EliteAPI is a VoiceAttack plugin for Elite Dangerous made by Somfic";

    public static void VA_Init1(dynamic vaProxy)
    {
        // Find type that implements VoiceAttackPlugin
        var pluginType = typeof(VoiceAttackPluginWrapper).Assembly
            .GetTypes()
            .FirstOrDefault(t => t.IsSubclassOf(typeof(VoiceAttackPlugin)));
        
        if(pluginType == null)
            throw new InvalidOperationException("No class found that inherits VoiceAttackPlugin.");
        
        VoiceAttackPlugin.Instance = (VoiceAttackPlugin) Activator.CreateInstance(pluginType)!;

        if(VoiceAttackPlugin.Instance == null) 
            throw new InvalidOperationException("No VoiceAttackPlugin instance found.");
        
        VoiceAttackPlugin.Proxy = new VoiceAttackProxy(vaProxy);

        try
        {
            VoiceAttackPlugin.Instance.OnStart(VoiceAttackPlugin.Proxy).GetAwaiter().GetResult();
        }
        catch (Exception e)
        {
            VoiceAttackPlugin.Instance.Log(VoiceAttackColor.Red, "Error during plugin initialisation. See logs for further information");
            var path = Path.Combine(VoiceAttackPlugin.Dir, "Logs", "STARTUP ERROR.log");
            Directory.CreateDirectory(Path.GetDirectoryName(path) ?? VoiceAttackPlugin.Dir);
            File.WriteAllText(path, e.ToString());
        }
    }
    
    public static void VA_Invoke1(dynamic vaProxy)
    {
        if(VoiceAttackPlugin.Instance == null) 
            throw new InvalidOperationException("No VoiceAttackPlugin instance found.");
        
        VoiceAttackPlugin.Proxy = new VoiceAttackProxy(vaProxy);
        var context = VoiceAttackPlugin.Proxy.Context;

        try
        {
            VoiceAttackPlugin.Instance.OnInvoke(VoiceAttackPlugin.Proxy, context).GetAwaiter().GetResult();
        } 
        catch (Exception e)
        {
            VoiceAttackPlugin.Instance.Log(VoiceAttackColor.Red, "Error during plugin invocation", e);
        }
    }

    public static void VA_StopCommand()
    {
        if(VoiceAttackPlugin.Instance == null) 
            throw new InvalidOperationException("No VoiceAttackPlugin instance found.");
        
        if(VoiceAttackPlugin.Proxy == null)
            throw new InvalidOperationException("No VoiceAttackProxy instance found.");
        
        try 
        {
            VoiceAttackPlugin.Instance.OnCommandStopped(VoiceAttackPlugin.Proxy).GetAwaiter().GetResult();
        }
        catch (Exception e)
        {
            VoiceAttackPlugin.Instance.Log(VoiceAttackColor.Red, "Error during command stop", e);
        }
    }
    
    public static void VA_Exit1(dynamic vaProxy)
    {
        if(VoiceAttackPlugin.Instance == null) 
            throw new InvalidOperationException("No VoiceAttackPlugin instance found.");
        
        VoiceAttackPlugin.Proxy = new VoiceAttackProxy(vaProxy);
        
        try
        {
            VoiceAttackPlugin.Instance.OnStop(VoiceAttackPlugin.Proxy).GetAwaiter().GetResult();
        }
        catch (Exception e)
        {
            VoiceAttackPlugin.Instance.Log(VoiceAttackColor.Red, "Error during plugin exit", e);
        }
    }
}