using System;
using System.Collections.Generic;

namespace EliteAPI
{
    public class MaterialsInfo
    {
        public class RawInfo
        {
            public string Name { get; set; }
            public int Count { get; set; }
        }

        public class ManufacturedInfo
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public int Count { get; set; }
        }

        public class EncodedInfo
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public int Count { get; set; }
        }

        public DateTime timestamp { get; set; }
        public List<RawInfo> Raw { get; set; }
        public List<ManufacturedInfo> Manufactured { get; set; }
        public List<EncodedInfo> Encoded { get; set; }
    }
}
