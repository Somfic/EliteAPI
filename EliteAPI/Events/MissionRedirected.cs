using System;
using System.Collections.Generic;

namespace EliteAPI
{
  public class MissionRedirectedInfo
  {
      public DateTime timestamp { get; set; }
      public int MissionID { get; set; }
      public string Name { get; set; }
      public string NewDestinationStation { get; set; }
      public string NewDestinationSystem { get; set; }
      public string OldDestinationStation { get; set; }
      public string OldDestinationSystem { get; set; }
  }
}
