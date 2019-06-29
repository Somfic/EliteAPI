using System;
using System.Collections.Generic;

namespace EliteAPI
{
  public class HullDamageInfo
  {
      public DateTime timestamp { get; set; }
      public Double Health { get; set; }
      public Boolean PlayerPilot { get; set; }
      public Boolean Fighter { get; set; }
  }
}
