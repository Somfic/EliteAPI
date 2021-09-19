using Newtonsoft.Json;

namespace EliteAPI.Dashboard.WebSockets.Message
{
    public class WebSocketMessage
    {
        [JsonConstructor]
        public WebSocketMessage(string type, string value)
        {
            Type = type;
            Value = value;
        }

        public WebSocketMessage(string type, object value)
        {
            Type = type;
            Value = JsonConvert.SerializeObject(value);
        }

        public WebSocketMessage(string type)
        {
            Type = type;
        }

        [JsonProperty("type")]
        public string Type { get; }
        
        [JsonProperty("value")]
        public string Value { get; }
    }
}