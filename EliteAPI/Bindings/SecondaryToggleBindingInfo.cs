namespace EliteAPI.Bindings
{
    public partial class SecondaryToggleBindingInfo
    {
        public Binding Primary { get; internal set; }
        public SecondaryInfo Secondary { get; internal set; }
        public ValueInfo ToggleOn { get; internal set; }
    }
}