using System;
using System.Collections.Generic;

namespace EliteAPI
{
  public class PowerplayInfo
  {
      public DateTime timestamp { get; set; }
      public string Power { get; set; }
      public int Rank { get; set; }
      public int Merits { get; set; }
      public int Votes { get; set; }
      public int TimePledged { get; set; }
  }
}
