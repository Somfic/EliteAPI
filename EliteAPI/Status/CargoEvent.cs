namespace EliteAPI.Status
{
    public class CargoEvent
    {
        internal CargoEvent(string eventName, object value)
        {
            @Event = eventName;
            Value = value;
        }
        public string @Event { get; internal set; }
        public object Value { get; internal set; }
    }
}