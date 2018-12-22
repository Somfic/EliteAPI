using System;
using System.Collections.Generic;

namespace EliteAPI
{
  public class SAAScanCompleteInfo
  {
      public DateTime timestamp { get; }
      public string BodyName { get; }
      public int BodyID { get; }
      public int ProbesUsed { get; }
      public int EfficiencyTarget { get; }
  }
}
