using System;
using System.Collections.Generic;

namespace EliteAPI
{
  public class HullDamageInfo
  {
      public DateTime timestamp { get; }
      public Double Health { get; }
      public Boolean PlayerPilot { get; }
      public Boolean Fighter { get; }
  }
}
