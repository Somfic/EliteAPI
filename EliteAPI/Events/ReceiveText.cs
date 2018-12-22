using System;

namespace EliteAPI
{
    public class ReceiveTextInfo
    {
        public DateTime timestamp { get; }
        public string From { get; }
        public string From_Localised { get; }
        public string Message { get; }
        public string Message_Localised { get; }
        public string Channel { get; }
    }
}
