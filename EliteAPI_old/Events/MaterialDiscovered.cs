using System; 

using System.Collections.Generic;

namespace EliteAPI
{
  public class MaterialDiscoveredInfo
  {
      public DateTime timestamp { get; set; }
      public string Category { get; set; }
      public string Name { get; set; }
      public int DiscoveryNumber { get; set; }
  }
}
