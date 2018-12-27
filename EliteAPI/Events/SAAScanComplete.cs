using System;
using System.Collections.Generic;

namespace EliteAPI
{
  public class SAAScanCompleteInfo
  {
      public DateTime timestamp { get; set; }
      public string BodyName { get; set; }
      public int BodyID { get; set; }
      public int ProbesUsed { get; set; }
      public int EfficiencyTarget { get; set; }
  }
}
