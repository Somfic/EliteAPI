using System;
using System.Collections.Generic;

namespace EliteAPI
{
  public class ModuleRetrieveInfo
  {
      public DateTime timestamp { get; }
      public int MarketID { get; }
      public string Slot { get; }
      public string RetrievedItem { get; }
      public string RetrievedItem_Localised { get; }
      public string Ship { get; }
      public int ShipID { get; }
      public Boolean Hot { get; }
      public string EngineerModifications { get; }
      public int Level { get; }
      public Double Quality { get; }
  }
}
