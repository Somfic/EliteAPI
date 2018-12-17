using System;
using System.Collections.Generic;

namespace EliteAPI
{
  public class CrimeVictimInfo
  {
      public DateTime timestamp { get; set; }
      public string Offender { get; set; }
      public string CrimeType { get; set; }
      public int Bounty { get; set; }
  }
}
