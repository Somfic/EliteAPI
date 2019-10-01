using System; 


namespace EliteAPI
{
    public class ReceiveTextInfo
    {
        public DateTime timestamp { get; set; }
        public string From { get; set; }
        public string From_Localised { get; set; }
        public string Message { get; set; }
        public string Message_Localised { get; set; }
        public string Channel { get; set; }
    }
}
