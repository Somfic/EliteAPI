using System; 

using System.Collections.Generic;

namespace EliteAPI
{
  public class CodexEntryInfo
  {
      public DateTime timestamp { get; set; }
      public int EntryID { get; set; }
      public string Name { get; set; }
      public string Name_Localised { get; set; }
      public string SubCategory { get; set; }
      public string SubCategory_Localised { get; set; }
      public string Category { get; set; }
      public string Category_Localised { get; set; }
      public string Region { get; set; }
      public string Region_Localised { get; set; }
      public string System { get; set; }
      public int SystemAddress { get; set; }
      public Boolean IsNewEntry { get; set; }
  }
}
