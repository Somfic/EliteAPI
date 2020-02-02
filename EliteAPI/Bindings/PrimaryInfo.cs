using System.Collections.Generic;

namespace EliteAPI.Bindings
{
    public partial class PrimaryInfo
    {
        public string Device { get; internal set; }
        public string Key { get; internal set; }
        public List<Binding> Modifier { get; internal set; }
    }
}