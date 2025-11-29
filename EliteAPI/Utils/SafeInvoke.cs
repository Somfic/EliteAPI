using System;

namespace EliteAPI.Utils;

public static class SafeInvoke
{
    public static void Invoke(Action action)
    {
        try
        {
            action();
        }
        catch (Exception ex)
        {
            // TODO: proper logging
            Console.WriteLine($"Error in handler: {ex}");
        }
    }

    public static void Invoke<T>(Action<T> action, T arg)
    {
        try
        {
            action(arg);
        }
        catch (Exception ex)
        {
            // TODO: proper logging
            Console.WriteLine($"Error in handler: {ex}");
        }
    }

    public static void Invoke<T1, T2>(Action<T1, T2> action, T1 arg1, T2 arg2)
    {
        try
        {
            action(arg1, arg2);
        }
        catch (Exception ex)
        {
            // TODO: proper logging
            Console.WriteLine($"Error in handler: {ex}");
        }
    }
}
