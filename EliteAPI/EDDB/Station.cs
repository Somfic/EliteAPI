using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteAPI.EDDB
{
    public class EddbStation
    {
        public int? id { get; }
        public string name { get; }
        public int? system_id { get; }
        public int? updated_at { get; }
        public string max_landing_pad_size { get; }
        public int? distance_to_star { get; }
        public int? government_id { get; }
        public string government { get; }
        public int? allegiance_id { get; }
        public string allegiance { get; }
        public int? state_id { get; }
        public string state { get; }
        public int? type_id { get; }
        public string type { get; }
        public bool? has_blackmarket { get; }
        public bool? has_market { get; }
        public bool? has_refuel { get; }
        public bool? has_repair { get; }
        public bool? has_rearm { get; }
        public bool? has_outfitting { get; }
        public bool? has_shipyard { get; }
        public bool? has_docking { get; }
        public bool? has_commodities { get; }
        public List<string> import_commodities { get; }
        public List<string> export_commodities { get; }
        public List<string> prohibited_commodities { get; }
        public List<string> economies { get; }
        public int? shipyard_updated_at { get; }
        public int? outfitting_updated_at { get; }
        public int? market_updated_at { get; }
        public bool? is_planetary { get; }
        public List<string> selling_ships { get; }
        public List<int?> selling_modules { get; }
        public object settlement_size_id { get; }
        public object settlement_size { get; }
        public object settlement_security_id { get; }
        public object settlement_security { get; }
        public int? body_id { get; }
        public int? controlling_minor_faction_id { get; }
    }
}
