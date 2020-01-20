namespace EliteAPI.Bindings
{
    public partial class ToggleBindingInfo
    {
        public Binding Primary { get; internal set; }
        public Binding Secondary { get; internal set; }
        public ValueInfo ToggleOn { get; internal set; }
    }
}