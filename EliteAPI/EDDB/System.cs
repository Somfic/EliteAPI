using System;
using System.Collections.Generic;

namespace EliteAPI.EDDB
{
    public class EddbMinorFactionPresence
    {
        public int? minor_faction_id { get; internal set; }
        public int? state_id { get; internal set; }
        public double? influence { get; internal set; }
        public string state { get; internal set; }
    }

    public class EddbSystem
    {
        public int id { get; internal set; }
        public int edsm_id { get; internal set; }
        public string name { get; internal set; }
        public double x { get; internal set; }
        public double y { get; internal set; }
        public double z { get; internal set; }
        public ulong population { get; internal set; }
        public bool is_populated { get; internal set; }
        public int? government_id { get; internal set; }
        public string government { get; internal set; }
        public int? allegiance_id { get; internal set; }
        public string allegiance { get; internal set; }
        public int? state_id { get; internal set; }
        public string state { get; internal set; }
        public int? security_id { get; internal set; }
        public string security { get; internal set; }
        public int? primary_economy_id { get; internal set; }
        public string primary_economy { get; internal set; }
        public object power { get; internal set; }
        public object power_state { get; internal set; }
        public object power_state_id { get; internal set; }
        public bool needs_permit { get; internal set; }
        public int? updated_at { get; internal set; }
        public string simbad_ref { get; internal set; }
        public int? controlling_minor_faction_id { get; internal set; }
        public string controlling_minor_faction { get; internal set; }
        public int? reserve_type_id { get; internal set; }
        public string reserve_type { get; internal set; }
        public List<EddbMinorFactionPresence> minor_faction_presences { get; internal set; }
    }
}