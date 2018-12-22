using System;
using System.Collections.Generic;

namespace EliteAPI
{
  public class SellDronesInfo
  {
      public DateTime timestamp { get; }
      public string Type { get; }
      public int Count { get; }
      public int SellPrice { get; }
      public int TotalSale { get; }
  }
}
