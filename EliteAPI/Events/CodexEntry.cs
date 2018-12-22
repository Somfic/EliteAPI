using System;
using System.Collections.Generic;

namespace EliteAPI
{
  public class CodexEntryInfo
  {
      public DateTime timestamp { get; }
      public int EntryID { get; }
      public string Name { get; }
      public string Name_Localised { get; }
      public string SubCategory { get; }
      public string SubCategory_Localised { get; }
      public string Category { get; }
      public string Category_Localised { get; }
      public string Region { get; }
      public string Region_Localised { get; }
      public string System { get; }
      public int SystemAddress { get; }
      public Boolean IsNewEntry { get; }
  }
}
