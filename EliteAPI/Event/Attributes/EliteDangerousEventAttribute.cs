using System;

namespace EliteAPI.Event.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class EliteDangerousEventAttribute : Attribute
    {
    }
}