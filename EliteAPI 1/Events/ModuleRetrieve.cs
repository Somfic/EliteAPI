using System; 

using System.Collections.Generic;

namespace EliteAPI
{
  public class ModuleRetrieveInfo
  {
      public DateTime timestamp { get; set; }
      public int MarketID { get; set; }
      public string Slot { get; set; }
      public string RetrievedItem { get; set; }
      public string RetrievedItem_Localised { get; set; }
      public string Ship { get; set; }
      public int ShipID { get; set; }
      public Boolean Hot { get; set; }
      public string EngineerModifications { get; set; }
      public int Level { get; set; }
      public Double Quality { get; set; }
  }
}
