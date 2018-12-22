using System;
using System.Collections.Generic;

namespace EliteAPI
{
  public class CrimeVictimInfo
  {
      public DateTime timestamp { get; }
      public string Offender { get; }
      public string CrimeType { get; }
      public int Bounty { get; }
  }
}
