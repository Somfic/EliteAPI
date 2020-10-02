using System;

namespace EliteAPI.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class EliteDangerousEventAttribute : Attribute
    {
    }
}