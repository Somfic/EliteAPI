using System;
using System.Collections.Generic;

namespace EliteAPI
{
    public class MaterialsInfo
    {
        public class RawInfo
        {
            public string Name { get; }
            public int Count { get; }
        }

        public class ManufacturedInfo
        {
            public string Name { get; }
            public string Name_Localised { get; }
            public int Count { get; }
        }

        public class EncodedInfo
        {
            public string Name { get; }
            public string Name_Localised { get; }
            public int Count { get; }
        }

        public DateTime timestamp { get; }
        public List<RawInfo> Raw { get; }
        public List<ManufacturedInfo> Manufactured { get; }
        public List<EncodedInfo> Encoded { get; }
    }
}
