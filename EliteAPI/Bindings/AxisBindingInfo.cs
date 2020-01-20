namespace EliteAPI.Bindings
{
    public partial class AxisBindingInfo
    {
        public Binding Binding { get; internal set; }
        public ValueInfo Inverted { get; internal set; }
        public ValueInfo Deadzone { get; internal set; }
    }
}