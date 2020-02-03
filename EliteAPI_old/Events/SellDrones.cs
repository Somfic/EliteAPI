using System; 

using System.Collections.Generic;

namespace EliteAPI
{
  public class SellDronesInfo
  {
      public DateTime timestamp { get; set; }
      public string Type { get; set; }
      public int Count { get; set; }
      public int SellPrice { get; set; }
      public int TotalSale { get; set; }
  }
}
