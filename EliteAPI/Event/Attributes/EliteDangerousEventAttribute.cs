using System;

namespace EliteAPI.Event.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class EliteDangerousEventAttribute : Attribute
    {
        public EliteDangerousEventAttribute(bool runOnCatchup = false)
        { 
            RunOnCatchup = runOnCatchup;
        }

        public bool RunOnCatchup { get; }
    }
}