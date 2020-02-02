namespace EliteAPI.Bindings
{
    public partial class PrimaryToggleBindingInfo
    {
        public PrimaryInfo Primary { get; internal set; }
        public Binding Secondary { get; internal set; }
        public ValueInfo ToggleOn { get; internal set; }
    }
}