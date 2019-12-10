using System; 

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteAPI.EDDB
{
    public class EddbStation
    {
        public int? id { get; set; }
        public string name { get; set; }
        public int? system_id { get; set; }
        public int? updated_at { get; set; }
        public string max_landing_pad_size { get; set; }
        public int? distance_to_star { get; set; }
        public int? government_id { get; set; }
        public string government { get; set; }
        public int? allegiance_id { get; set; }
        public string allegiance { get; set; }
        public int? state_id { get; set; }
        public string state { get; set; }
        public int? type_id { get; set; }
        public string type { get; set; }
        public bool? has_blackmarket { get; set; }
        public bool? has_market { get; set; }
        public bool? has_refuel { get; set; }
        public bool? has_repair { get; set; }
        public bool? has_rearm { get; set; }
        public bool? has_outfitting { get; set; }
        public bool? has_shipyard { get; set; }
        public bool? has_docking { get; set; }
        public bool? has_commodities { get; set; }
        public List<string> import_commodities { get; set; }
        public List<string> export_commodities { get; set; }
        public List<string> prohibited_commodities { get; set; }
        public List<string> economies { get; set; }
        public int? shipyard_updated_at { get; set; }
        public int? outfitting_updated_at { get; set; }
        public int? market_updated_at { get; set; }
        public bool? is_planetary { get; set; }
        public List<string> selling_ships { get; set; }
        public List<int?> selling_modules { get; set; }
        public object settlement_size_id { get; set; }
        public object settlement_size { get; set; }
        public object settlement_security_id { get; set; }
        public object settlement_security { get; set; }
        public int? body_id { get; set; }
        public int? controlling_minor_faction_id { get; set; }
    }
}
