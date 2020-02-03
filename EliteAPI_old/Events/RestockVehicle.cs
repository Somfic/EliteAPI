using System; 

using System.Collections.Generic;

namespace EliteAPI
{
  public class RestockVehicleInfo
  {
      public DateTime timestamp { get; set; }
      public string Type { get; set; }
      public string Loadout { get; set; }
      public int Cost { get; set; }
      public int Count { get; set; }
  }
}
