using System;
using System.Collections.Generic;

namespace EliteAPI
{
  public class MaterialCollectedInfo
  {
      public DateTime timestamp { get; set; }
      public string Category { get; set; }
      public string Name { get; set; }
      public int Count { get; set; }
  }
}
