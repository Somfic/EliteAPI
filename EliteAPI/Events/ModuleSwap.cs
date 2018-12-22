using System;
using System.Collections.Generic;

namespace EliteAPI
{
  public class ModuleSwapInfo
  {
      public DateTime timestamp { get; }
      public int MarketID { get; }
      public string FromSlot { get; }
      public string ToSlot { get; }
      public string FromItem { get; }
      public string FromItem_Localised { get; }
      public string ToItem { get; }
      public string ToItem_Localised { get; }
      public string Ship { get; }
      public int ShipID { get; }
  }
}
