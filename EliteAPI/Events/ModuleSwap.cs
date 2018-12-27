using System;
using System.Collections.Generic;

namespace EliteAPI
{
  public class ModuleSwapInfo
  {
      public DateTime timestamp { get; set; }
      public int MarketID { get; set; }
      public string FromSlot { get; set; }
      public string ToSlot { get; set; }
      public string FromItem { get; set; }
      public string FromItem_Localised { get; set; }
      public string ToItem { get; set; }
      public string ToItem_Localised { get; set; }
      public string Ship { get; set; }
      public int ShipID { get; set; }
  }
}
