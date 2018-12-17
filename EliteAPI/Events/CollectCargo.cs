using System;
using System.Collections.Generic;

namespace EliteAPI
{
  public class CollectCargoInfo
  {
      public DateTime timestamp { get; set; }
      public string Type { get; set; }
      public string Type_Localised { get; set; }
      public Boolean Stolen { get; set; }
  }
}
