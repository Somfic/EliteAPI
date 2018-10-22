using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using ChoETL;

using Newtonsoft.Json;

namespace EliteAPI.EDDB
{
    public enum DataRequests { Systems, Stations, Prices }

    public class EDDBApi
    {
        private WebClient web;

        public EDDBApi()
        {
            Reset();
        }

        /// <summary>
        /// Resets the service.
        /// </summary>
        public void Reset()
        {
            web = new WebClient();
        }

        /// <summary>
        /// Updates the data from the EDDB database.
        /// </summary>
        /// <param name="data">Array of datatypes to be updated.</param>
        public void UpdateData(DataRequests[] data)
        {
            foreach (DataRequests dr in data)
            {
                switch (dr)
                {
                    case DataRequests.Prices:
                        web.DownloadFile("https://eddb.io/archive/v5/listings.csv", "prices.csv");
                        StringBuilder sb = new StringBuilder();
                        var p = ChoCSVReader.LoadLines(File.ReadAllLines("prices.csv")).WithFirstLineHeader();
                        var w = new ChoJSONWriter(sb);
                        w.Write(p);
                        File.WriteAllText("prices.json", sb.ToString());
                        File.Delete("prices.csv");
                        p = null;
                        w = null;
                        sb = null;

                        break;

                    case DataRequests.Stations:
                        web.DownloadFile("https://eddb.io/archive/v5/stations.json", "stations.json");
                        break;

                    case DataRequests.Systems:
                        web.DownloadFile("https://eddb.io/archive/v5/systems_populated.json", "systems.json");
                        break;
                }
            }
        }

        public EddbSystem GetSystemByName(string systemName)
        {
            return JsonConvert.DeserializeObject<List<EddbSystem>>(File.ReadAllText("systems.json")).First(x => x.name == systemName);
        }

        public EddbSystem GetSystemByEdsmID(int edsmID)
        {
            return JsonConvert.DeserializeObject<List<EddbSystem>>(File.ReadAllText("systems.json")).First(x => x.edsm_id == edsmID);
        }

        public EddbSystem GetSystemByID(int ID)
        {
            return JsonConvert.DeserializeObject<List<EddbSystem>>(File.ReadAllText("systems.json")).First(x => x.id == ID);
        }

        public IReadOnlyList<EddbStation> GetStationByName(string stationName)
        {
            return JsonConvert.DeserializeObject<List<EddbStation>>(File.ReadAllText("stations.json")).Where(x => x.name == stationName).ToList();
        }

        public EddbStation GetStationByID(int ID)
        {
            return JsonConvert.DeserializeObject<List<EddbStation>>(File.ReadAllText("stations.json")).First(x => x.id == ID);
        }

        public IReadOnlyList<EddbStation> GetStationsBySystem(EddbSystem system)
        {
            return JsonConvert.DeserializeObject<List<EddbStation>>(File.ReadAllText("stations.json")).Where(x => x.system_id == system.id).ToList();
        }

        /// <summary>
        /// Updates the data from the EDDB database.
        /// </summary>
        /// <param name="data">Datatype to be updated.</param>
        public void UpdateData(DataRequests data)
        {
            UpdateData(new DataRequests[] { data });
        }
    }
}
