using System;

namespace EliteAPI.Utils;

public static class SafeInvoke
{
    public static void Invoke(string context, Action action)
    {
        try
        {
            action();
        }
        catch (Exception ex)
        {
            Log.Error($"Error while {context}", ex);
        }
    }

    public static void Invoke<T>(string context, Action<T> action, T arg)
    {
        try
        {
            action(arg);
        }
        catch (Exception ex)
        {
            Log.Error($"Error while {context}", ex);
        }
    }

    public static void Invoke<T1, T2>(string context, Action<T1, T2> action, T1 arg1, T2 arg2)
    {
        try
        {
            action(arg1, arg2);
        }
        catch (Exception ex)
        {
            Log.Error($"Error while {context}", ex);
        }
    }
}
