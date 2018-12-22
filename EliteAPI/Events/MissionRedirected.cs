using System;
using System.Collections.Generic;

namespace EliteAPI
{
  public class MissionRedirectedInfo
  {
      public DateTime timestamp { get; }
      public int MissionID { get; }
      public string Name { get; }
      public string NewDestinationStation { get; }
      public string NewDestinationSystem { get; }
      public string OldDestinationStation { get; }
      public string OldDestinationSystem { get; }
  }
}
