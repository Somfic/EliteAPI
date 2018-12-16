using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace EliteAPI.EDDB
{
    public enum DataRequests { Systems, Stations, Prices, CommoditiesGeneral }

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
                        ParsePrices();
                        break;

                    case DataRequests.Stations:
                        web.DownloadFile("https://eddb.io/archive/v5/stations.json", "stations.json");
                        break;

                    case DataRequests.Systems:
                        web.DownloadFile("https://eddb.io/archive/v5/systems_populated.json", "systems.json");
                        break;

                    case DataRequests.CommoditiesGeneral:
                        web.DownloadFile("https://eddb.io/archive/v5/commodities.json", "commodities.json");
                        break;
                }
            }
        }

        public void ParsePrices()
        {
           List<string> MidArray = new List<string>();

            TextFieldParser parser = new TextFieldParser("prices.csv");
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");

           List<Price> allPrices = new List<Price>();

            parser.ReadFields();

            File.WriteAllText("prices.json", "[" + Environment.NewLine);

            char x = '"';

            while (!parser.EndOfData)
            {
                string[] y = parser.ReadFields();
                MidArray.Add("{" + $"{x}station{x}:{y[1]},{x}type{x}:{y[2]},{x}supply{x}:{y[3]},{x}buy{x}:{y[5]},{x}sell{x}:{y[6]},{x}demand{x}:{y[7]}" + "},");
                if(MidArray.Count > 250000) { File.AppendAllLines("prices.json", MidArray); MidArray = new List<string>(); }
            }

            MidArray[MidArray.Count - 1] = MidArray[MidArray.Count - 1].Substring(0, MidArray[MidArray.Count - 1].Length - 1);
            File.AppendAllLines("prices.json", MidArray);
            File.AppendAllText("prices.json", "]");

            File.Delete("prices.csv");
        }

        /// <summary>
        /// Returns all the price info available for the station.
        /// </summary>
        /// <param name="station">The specific station</param>
        /// <returns></returns>
        public List<Price> GetPriceInfoByStation(EddbStation station)
        {
            return JsonConvert.DeserializeObject<List<Price>>(File.ReadAllText("prices.json")).Where(x => x.station == station.id).ToList();
        }

        /// <summary>
        /// Gets a system by name.
        /// </summary>
        /// <param name="systemName">The system name</param>
        /// <returns></returns>
        public EddbSystem GetSystemByName(string systemName)
        {
            return JsonConvert.DeserializeObject<List<EddbSystem>>(File.ReadAllText("systems.json")).First(x => x.name == systemName);
        }

        /// <summary>
        /// Gets a system by its EDSM ID.
        /// </summary>
        /// <param name="edsmID">The EDSMid</param>
        /// <returns></returns>
        public EddbSystem GetSystemByEdsmID(int edsmID)
        {
            return JsonConvert.DeserializeObject<List<EddbSystem>>(File.ReadAllText("systems.json")).First(x => x.edsm_id == edsmID);
        }

        /// <summary>
        /// Gets a system by its ID.
        /// </summary>
        /// <param name="ID">The systemid</param>
        /// <returns></returns>
        public EddbSystem GetSystemByID(int ID)
        {
            return JsonConvert.DeserializeObject<List<EddbSystem>>(File.ReadAllText("systems.json")).First(x => x.id == ID);
        }

        /// <summary>
        /// Returns true if the station has the commodity in stock, and it's in supply.
        /// </summary>
        /// <param name="station">The station you want to search in</param>
        /// <param name="commodity">The specific commodity</param>
        /// <returns></returns>
        public bool StationHasCommodity(EddbStation station, CommodityType commodity)
        {
            List<Price> StationPrices = GetPriceInfoByStation(station);
            foreach (var item in StationPrices)
            {
                if((CommodityType)item.type.Value == commodity && item.supply > 0) { return true; }
            }
            return false;
        }

        /// <summary>
        /// Gets a station by name, since it could be multiple, returns a list.
        /// </summary>
        /// <param name="stationName">The stationname</param>
        /// <returns></returns>
        public List<EddbStation> GetStationByName(string stationName)
        {
            return JsonConvert.DeserializeObject<List<EddbStation>>(File.ReadAllText("stations.json")).Where(x => x.name == stationName).ToList();
        }

        /// <summary>
        /// Gets a station by its id.
        /// </summary>
        /// <param name="ID">The station id</param>
        /// <returns></returns>
        public EddbStation GetStationByID(int ID)
        {
            return JsonConvert.DeserializeObject<List<EddbStation>>(File.ReadAllText("stations.json")).First(x => x.id == ID);
        }

        /// <summary>
        /// Gets all the stations from a specific system.
        /// </summary>
        /// <param name="system">The specific system</param>
        /// <returns></returns>
        public List<EddbStation> GetStationsBySystem(EddbSystem system)
        {
            return GetStationsBySystem(system.id);
        }

        /// <summary>
        /// Gets all the stations from a specific system.
        /// </summary>
        /// <param name="id">The system's id</param>
        /// <returns></returns>
        public List<EddbStation> GetStationsBySystem(int id)
        {
            return JsonConvert.DeserializeObject<List<EddbStation>>(File.ReadAllText("stations.json")).Where(x => x.system_id == id).ToList();
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
