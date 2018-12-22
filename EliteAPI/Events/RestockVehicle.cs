using System;
using System.Collections.Generic;

namespace EliteAPI
{
  public class RestockVehicleInfo
  {
      public DateTime timestamp { get; }
      public string Type { get; }
      public string Loadout { get; }
      public int Cost { get; }
      public int Count { get; }
  }
}
